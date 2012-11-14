Public Class ClusterAlgorithm

    Protected iterations As Integer
    Protected w As Integer
    Protected K As Integer
    Protected N As Integer
    Protected x(,) As Single
    Protected wt(,) As Single
    Protected eta As Single
    Protected V As Integer
    Protected sds() As Single
    Protected avgs() As Single
    Protected normalise As Boolean
    Protected randomise As Boolean
    Protected neighbourhood As NeighbourhoodFunction
    Protected rws() As Single

    Public ReadOnly Property StandardDevs() As Single()
        Get
            Return sds
        End Get
    End Property

    Public ReadOnly Property Averages() As Single()
        Get
            Return avgs
        End Get
    End Property


    Public ReadOnly Property Clusters() As Single(,)
        Get
            Return wt
        End Get

    End Property




    Protected Function stdDev(ByVal vals() As Single) As Single

        Dim x2 As Single = 0
        Dim x As Single = 0
        Dim no As Integer = vals.Length

        For i As Integer = 0 To vals.Length - 1
            If Single.IsNaN(vals(i)) Then
                no = no - 1
            Else
                x2 += vals(i) * vals(i)
                x += vals(i)
            End If
        Next

        Return Math.Sqrt((x2 - (x * x) / no) / no)

    End Function



    Protected Function average(ByVal vals() As Single) As Single

        Dim x As Single = 0
        Dim no As Integer = vals.Length

        For i As Integer = 0 To vals.Length - 1
            If Single.IsNaN(vals(i)) Then
                no = no - 1
            Else
                x += vals(i)
            End If
        Next

        Return x / no

    End Function

    Public Function GetNNArray(ByVal iNorm As Boolean) As Integer()

        Dim nns(N - 1) As Integer
        For i As Integer = 0 To N - 1
            nns(i) = FindNearest(i, iNorm)
        Next

        Return nns

    End Function

    Public Function FindNearest(ByVal point As Integer, ByVal iNorm As Boolean) As Integer

        Dim nearest As Integer = 0
        Dim min As Single = Single.MaxValue
        Dim d As Single = 0

        For i As Integer = 0 To K - 1

            d = 0
            For j As Integer = 0 To V - 1
                If (Not Single.IsNaN(x(point, j))) Then
                    'If iNorm Then
                    d += Math.Pow((x(point, j) - wt(i, j)), 2)
                    'Else
                    '    If sds(j) <> 0 Then
                    '        d += Math.Pow((x(point, j) - wt(i, j)) / sds(j), 2)
                    '    End If
                    'End If
                End If

            Next

            If d < min Then
                nearest = i
                min = d
            End If

        Next

        Return nearest

    End Function


    Public Function Sizes(ByVal iNorm As Boolean) As Integer()

        Dim sz(K - 1) As Integer

        For i As Integer = 0 To N - 1

            sz(FindNearest(i, iNorm)) += 1

        Next

        Return sz

    End Function



    Public Function WeightedSizes(ByVal iNorm As Boolean) As Single()

        Dim wsz(K - 1) As Single

        For i As Integer = 0 To N - 1

            wsz(FindNearest(i, iNorm)) += rws(i)

        Next

        Return wsz

    End Function


    Protected Sub NormaliseInputs()

        For i As Integer = 0 To N - 1
            For j As Integer = 0 To V - 1
                If (Not Single.IsNaN(x(i, j))) Then
                    If sds(j) = 0 Then
                        x(i, j) = 0
                    Else
                        x(i, j) = (x(i, j) - avgs(j)) / sds(j)
                    End If
                    
                End If

            Next
        Next


    End Sub

End Class
