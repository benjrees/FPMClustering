Public Class KohonenCluster
    Inherits ClusterAlgorithm

    Private sigma As Single


    Public Sub New(ByVal cc As ClusterConfig, ByVal data As Single(,), ByVal rowWeights As Single())

        iterations = cc.Iterations
        w = cc.Width
        K = w ^ 2                   ' # of clusters
        N = data.GetLength(0)       ' # of rows
        V = cc.Names.Count          ' # of parameters
        eta = cc.Eta
        x = data                    ' # of rows, # of parameters
        normalise = cc.Normalise
        randomise = cc.Randomise
        neighbourhood = cc.Neighbourhood
        rws = rowWeights

        ReDim wt(K - 1, V - 1)      ' # of clusters, # of parameters
        ReDim sds(V - 1)
        ReDim avgs(V - 1)

    End Sub

    Public Sub Initialise()



        Dim num(N - 1) As Single
        For i As Integer = 0 To V - 1
            For j As Integer = 0 To N - 1

                num(j) = x(j, i)
            Next
            sds(i) = stdDev(num)
            avgs(i) = average(num)
        Next


        If normalise Then
            NormaliseInputs()
        End If


        Dim count As Integer = 0
        Do While count < K

            Dim r As Integer = System.Convert.ToInt32(Rnd() * (N - 1))

            Dim allPresent As Boolean = True
            For i As Integer = 0 To V - 1
                If Single.IsNaN(x(r, i)) Then
                    allPresent = False
                End If
            Next

            If allPresent Then

                For i As Integer = 0 To V - 1
                    wt(count, i) = x(r, i)
                Next
                count += 1
            End If

        Loop



    End Sub


    Public Sub Update(ByVal dEta As Single, ByVal dSigma As Single, ByVal iNorm As Boolean)

        eta = dEta
        sigma = dSigma



        Dim delWt(V - 1) As Single
        Dim nn As Integer = 0

        Dim rn(N - 1) As Single

        If randomise Then
            For i As Integer = 0 To N - 1
                rn(i) = Rnd()
            Next
        End If

        For i As Integer = 0 To N - 1

            Dim item As Integer

            If randomise Then

                Dim big As Single = Single.MaxValue

                For t As Integer = 0 To N - 1
                    If rn(t) < big Then
                        big = rn(t)
                        item = t
                    End If
                Next
                rn(item) = Single.MaxValue

            Else
                item = i
            End If

            nn = FindNearest(item, iNorm)

            For l As Integer = 0 To K - 1
                Dim d As Single = 0

                Dim xCoord, yCoord As Integer

                If XC(nn) > XC(l) Then
                    Dim leftDist As Integer = XC(nn) - XC(l)
                    Dim rightDist As Integer = XC(l) + w - XC(nn)
                    If rightDist < leftDist Then
                        xCoord = XC(l) + w
                    Else
                        xCoord = XC(l)
                    End If
                Else
                    Dim leftDist As Integer = XC(nn) - XC(l) + w
                    Dim rightDist As Integer = XC(l) - XC(nn)
                    If rightDist < leftDist Then
                        xCoord = XC(l)
                    Else
                        xCoord = XC(l) - w
                    End If
                End If

                If YC(nn) > YC(l) Then
                    Dim leftDist As Integer = YC(nn) - YC(l)
                    Dim rightDist As Integer = YC(l) + w - YC(nn)
                    If rightDist < leftDist Then
                        yCoord = YC(l) + w
                    Else
                        yCoord = YC(l)
                    End If
                Else
                    Dim leftDist As Integer = YC(nn) - YC(l) + w
                    Dim rightDist As Integer = YC(l) - YC(nn)
                    If rightDist < leftDist Then
                        yCoord = YC(l)
                    Else
                        yCoord = YC(l) - w
                    End If
                End If

                'd += Math.Pow(XC(nn) - XC(l), 2) + Math.Pow(YC(nn) - YC(l), 2)
                d += Math.Pow(XC(nn) - xCoord, 2) + Math.Pow(YC(nn) - yCoord, 2)

                d = Math.Sqrt(d)

                Dim lambda As Single
                Select Case neighbourhood
                    Case NeighbourhoodFunction.Gaussian
                        lambda = Math.Exp(-Math.Pow(d, 2) / (2 * Math.Pow(sigma, 2)))
                    Case NeighbourhoodFunction.Bubble
                        If d < sigma Then
                            lambda = 1
                        Else
                            lambda = 0
                        End If
                End Select



                For j As Integer = 0 To V - 1
                    If (Not Single.IsNaN(x(item, j))) Then

                        ' account for input weights on rows. Update eta as though item is presented 'weights' times
                        Dim wEta = 1 - Math.Pow(1 - eta, rws(item))

                        delWt(j) = wEta * lambda * (x(item, j) - wt(l, j))
                        wt(l, j) += delWt(j)
                    End If


                Next


            Next
        Next




    End Sub



    Private Function XC(ByVal clusterNum As Integer) As Integer
        Return clusterNum Mod w
    End Function

    Private Function YC(ByVal clusterNum As Integer) As Integer
        Return clusterNum \ w
    End Function

    Public Function DenormalisedClusters() As Single(,)

        Dim ret(,) As Single = wt.Clone

        If normalise Then

            For j As Integer = 0 To K - 1
                For i As Integer = 0 To V - 1
                    If Not Single.IsNaN(ret(j, i)) Then
                        ret(j, i) = sds(i) * ret(j, i) + avgs(i)
                    End If
                Next
            Next
        End If

        Return ret

    End Function


    Public Function outputSDs() As Single()

        Dim ret(V - 1) As Single
        Dim xx(V - 1) As Single
        Dim x2(V - 1) As Single

        For i As Integer = 0 To V - 1
            ret(i) = 0
            xx(i) = 0
            x2(i) = 0
        Next

        Dim count As Integer = 0

        For i As Integer = 0 To V - 1
            For j As Integer = 0 To N - 1
                If Not Single.IsNaN(x(j, i)) Then
                    xx(i) += x(j, i)
                    x2(i) += x(j, i) ^ 2
                    count += 1
                End If
            Next
        Next

        For i As Integer = 0 To V - 1
            ret(i) = System.Convert.ToSingle((1 / count) * Math.Sqrt(N * x2(i) - Math.Pow(xx(i), 2)))
        Next

        Return ret

    End Function


End Class
