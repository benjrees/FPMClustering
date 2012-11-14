Public Class KMeansCluster
    Inherits ClusterAlgorithm



    Public Sub New(ByVal cc As ClusterConfig, ByVal data As Single(,))

        iterations = cc.Iterations
        K = cc.Width * cc.Width
        N = data.GetLength(0)
        V = cc.Names.Count
        eta = cc.Eta
        x = data

        ReDim wt(K - 1, V - 1)
        ReDim sds(V - 1)
        ReDim avgs(V - 1)

    End Sub

    Public Sub Initialise()

        Dim taken(N - 1) As Boolean

        Dim count As Integer = 0

        Do While count < K

            Dim r As Integer = System.Convert.ToInt32(Rnd() * N)
            If taken(r) = False Then
                taken(r) = True

                For i As Integer = 0 To V - 1
                    wt(count, i) = x(r, i)
                Next
                count += 1
            End If
        Loop


        Dim num(N - 1) As Single
        For i As Integer = 0 To V - 1
            For j As Integer = 0 To N - 1

                num(j) = x(j, i)
            Next
            sds(i) = stdDev(num)
            avgs(i) = average(num)
        Next




    End Sub


    Public Sub Update(ByVal dEta As Single, ByVal iNorm As Boolean)

        eta = dEta

        Dim delMu(V - 1) As Single
        Dim nn As Integer = 0

        For i As Integer = 0 To N - 1

            nn = FindNearest(i, iNorm)

            For j As Integer = 0 To V - 1
                delMu(j) = eta * (x(i, j) - wt(nn, j))

                wt(nn, j) += delMu(j)

            Next

        Next




    End Sub


   




End Class
