Imports System.IO
Imports System.Data.OleDb


Public Class ClusterApp

    Public Const TABLENAME As String = "TableName"
    Public Const OUTPUTFILEBASE As String = "output"
    Public Const OUTPUTFILESUFFIX As String = "csv"
    Public Const CLUSTERFILEBASE As String = "clusters"
    Public Const CLUSTERFILESUFFIX As String = "csv"

    Private myCC As ClusterConfig
    Private myDT As DataTable
    Private myFileName As String


    Public Property DT() As DataTable
        Get
            Return myDT
        End Get
        Set(ByVal value As DataTable)
            myDT = value
        End Set
    End Property



    Public Sub New()


        ' This call is required by the Windows Form Designer.

        myCC = New ClusterConfig()
        InitializeComponent()




        UpdateFields(myCC)


    End Sub







    Private Function ConnectCSV(ByVal CSVFile As String, ByVal sqlString As String) As DataTable


        Dim CSVFolderPath As String = Path.GetDirectoryName(CSVFile)
        Dim CSVFileName As String = Path.GetFileName(CSVFile)

        Dim dt = New DataTable
        Try

            Dim strConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
       "Data Source=" & CSVFolderPath & ";" & _
       "Extended Properties=""text;HDR=Yes;FMT=Delimited"""

            
            Dim cn As New OleDbConnection(strConnString)

            Dim sqlSelect As String
            sqlSelect = sqlString.Replace(TABLENAME, CSVFileName)

            cn.Open()
            
            'Fetch records from CSV

            Dim objCmdSelect As New OleDbCommand(sqlSelect, cn)
            Dim da As New OleDbDataAdapter()
            da.SelectCommand = objCmdSelect

            da.Fill(dt)

            cn.Close()

        Catch e As Exception
            Throw e
        End Try

        Return dt


    End Function





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If myCC.Names Is Nothing Then
            MsgBox("No columns selected. Please select then re-run")
            Return
        End If

        Me.RunClusteringProcess()



    End Sub



    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        Dim filename As String = ""

        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Try

                myCC = ClusterConfig.deserialise(openFileDialog1.FileName)
                myCC.FileChanged = False
                Me.UpdateFields(myCC)

                myFileName = openFileDialog1.FileName

            Catch ex As Exception
                MsgBox("There was a problem opening the Config File:" & ex.ToString)
            End Try

        End If



    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        If myFileName Is Nothing Then

            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "*.xml|*.xml"
            saveFileDialog1.Title = "Save current Cluster Configuration"
            saveFileDialog1.ShowDialog()

            ' If the file name is not an empty string open it for saving.
            If saveFileDialog1.FileName <> "" Then

                ClusterConfig.serialise(myCC, saveFileDialog1.FileName)
                myCC.FileChanged = False
            End If

        Else

            ClusterConfig.serialise(myCC, myFileName)
            myCC.FileChanged = False


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim filename As String = ""

        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Try

                myCC.SourceFile = openFileDialog1.FileName
                Me.UpdateFields(myCC)

            Catch ex As Exception
                MsgBox("There was a problem opening the source data file:" & ex.ToString)
            End Try

        End If


    End Sub


    Private Sub RunClusteringProcess()

        out.AppendText("Gathering data..." & vbCrLf)

        Dim successful As Boolean = True
        Try
            DT = Me.ConnectCSV(myCC.SourceFile, myCC.SQLString)


        Catch e As Exception
            successful = False
        End Try

        Try
            Dim dir As New System.IO.DirectoryInfo(myCC.OutputPath)

        Catch e As Exception
            successful = False
        End Try

        If successful Then

            out.AppendText("Preparing data for clustering..." & vbCrLf)

            Dim data(DT.Rows.Count - 1, myCC.Names.Count - 1) As Single

            Dim rw(DT.Rows.Count - 1) As Single

            Try
                Dim count As Integer = 0
                For Each row As DataRow In DT.Rows


                    If count Mod 10 = 0 Then
                        out.AppendText("Data load..." & count & vbCrLf)

                    End If

                    For j As Integer = 0 To myCC.Names.Count - 1




                        Dim val As Object

                        Try
                            val = row.Item(myCC.Names(j))

                        Catch icex As InvalidCastException
                            val = ""
                        End Try

                        Dim tempRW As Object
                        Try
                            tempRW = row.Item(myCC.WeightsCol)

                        Catch ex As Exception
                            tempRW = ""
                        End Try


                        Dim item As String = val.ToString()

                        If (item.Equals("") Or item.Equals("NULL")) Then
                            data(count, j) = Single.NaN
                        Else
                            data(count, j) = System.Convert.ToSingle(item)
                        End If

                        item = tempRW.ToString()

                        If (item.Equals("") Or item.Equals("NULL")) Then
                            rw(count) = 1
                        Else
                            rw(count) = System.Convert.ToSingle(item)
                        End If


                    Next

                    count += 1
                Next

            Catch f As FormatException

                out.AppendText("Problem reading data - not all columns can be converted to numbers.")
                Return

            End Try


            Dim run As KohonenCluster = New KohonenCluster(myCC, data, rw)


            out.AppendText("Running..." & vbCrLf)

            run.Initialise()

            Dim dEta As Single = myCC.Eta
            Dim dSigma As Single = myCC.Sigma
            Dim tor As Single = myCC.Iterations


            For i As Integer = 0 To myCC.Iterations - 1

                run.Update(dEta, dSigma, myCC.Normalise)

                'dEta = (myCC.Eta / (1 + i / tor))
                'dSigma = (myCC.Sigma / (1 + i / tor))

                dEta = (myCC.Eta / (1 + i / myCC.TOREta))
                dSigma = (myCC.Sigma / (1 + i / myCC.TORSigma))


                'dEta -= (myCC.Eta - myCC.EtaEnd) / myCC.Iterations
                'dSigma -= (myCC.Sigma - myCC.SigmaEnd) / myCC.Iterations


                If i Mod 10 = 0 Then
                    out.AppendText("Iteration..." & i & vbCrLf)

                End If

            Next

            out.AppendText("Clustering Complete." & vbCrLf)
            out.AppendText("Writing output data..." & vbCrLf)


            Dim clusterFile As String = CLUSTERFILEBASE


            Dim dir As New System.IO.DirectoryInfo(myCC.OutputPath)

            Dim maxa As Integer = 0
            For Each f As System.IO.FileInfo In dir.GetFiles(CLUSTERFILEBASE & "*." & CLUSTERFILESUFFIX)

                Try
                    Dim num As Integer = Integer.Parse(f.Name.Substring(CLUSTERFILEBASE.Length, (f.Name.Length - CLUSTERFILEBASE.Length - CLUSTERFILESUFFIX.Length - 1)))
                    If num > maxa Then
                        maxa = num
                    End If
                Catch ex As Exception

                End Try

            Next

            maxa = maxa + 1

            dir = New System.IO.DirectoryInfo(myCC.OutputPath)

            Dim maxb As Integer = 0
            For Each f As System.IO.FileInfo In dir.GetFiles(OUTPUTFILEBASE & "*." & OUTPUTFILESUFFIX)

                Try
                    Dim num As Integer = Integer.Parse(f.Name.Substring(OUTPUTFILEBASE.Length, (f.Name.Length - OUTPUTFILEBASE.Length - OUTPUTFILESUFFIX.Length - 1)))
                    If num > maxb Then
                        maxb = num
                    End If
                Catch ex As Exception

                End Try

            Next

            maxb = maxb + 1


            Dim max As Integer = 0
            If maxa > maxb Then
                max = maxa
            Else
                max = maxb
            End If

            clusterFile = System.IO.Path.Combine(myCC.OutputPath, clusterFile & max & "." & CLUSTERFILESUFFIX)


            Dim sb2 As New System.Text.StringBuilder()

            Try

                Dim osr As New StreamWriter(clusterFile)

                Dim sb As New System.Text.StringBuilder()

                Dim clusters(,) As Single = run.DenormalisedClusters()
                Dim sds() As Single = run.StandardDevs
                Dim avgs() As Single = run.Averages
                Dim sizes() As Integer = run.Sizes(myCC.Normalise)
                Dim weightedSizes() As Single = run.WeightedSizes(myCC.Normalise)

                sb.Append("Cluster_ID").Append(",")

                For i As Integer = 0 To myCC.Names.Count - 1
                    sb.Append(myCC.Names(i)).Append(",")
                Next


                For i As Integer = 0 To myCC.Names.Count - 1
                    sb.Append(myCC.Names(i)).Append("_sd").Append(",")
                Next

                sb.Append("Size").Append(",")
                sb.Append("Weighted Size")

                osr.WriteLine(sb.ToString)


                For j As Integer = 0 To clusters.GetLength(0) - 1
                    sb = New System.Text.StringBuilder("" & j & ",")
                    For i As Integer = 0 To myCC.Names.Count - 1

                        sb.Append(clusters(j, i)).Append(",")

                    Next

                    For i As Integer = 0 To myCC.Names.Count - 1
                        sb.Append(sds(i)).Append(",")
                    Next
                    sb.Append(sizes(j)).Append(",")
                    sb.Append(weightedSizes(j))
                    osr.WriteLine(sb.ToString)
                Next

                For j As Integer = 0 To clusters.GetLength(0) - 1
                    sb2.Append(sizes(j)).Append(",")
                Next

                sb2.Append(vbCrLf).Append(vbCrLf)

                For j As Integer = 0 To clusters.GetLength(0) - 1
                    sb2.Append(weightedSizes(j)).Append(",")
                Next

                osr.Close()
            Catch ex As Exception
                out.AppendText("Problem outputting data.")

            End Try



            out.AppendText(sb2.ToString & vbCrLf)




            Dim cm() As Integer = run.GetNNArray(myCC.Normalise)

            Dim outputFile As String = OUTPUTFILEBASE




            outputFile = System.IO.Path.Combine(myCC.OutputPath, outputFile & max & "." & OUTPUTFILESUFFIX)

            Try
                Dim osr As New StreamWriter(outputFile)


                Dim sb As New System.Text.StringBuilder()

                For Each column As DataColumn In DT.Columns

                    sb.Append(column.ToString()).Append(",")

                Next
                sb.Append("Cluster_ID")

                osr.WriteLine(sb.ToString)


                Dim count As Integer = 0
                For Each row As DataRow In DT.Rows
                    sb = New System.Text.StringBuilder()

                    For Each column As DataColumn In DT.Columns

                        Dim item As String

                        Dim obj As Object = row.Item(column)

                        If obj Is Nothing Then

                        Else
                            If TypeOf (obj) Is System.DBNull Then
                                item = ""
                            Else
                                item = row.Item(column)
                            End If
                        End If

                        sb.Append(item).Append(",")
                    Next
                    sb.Append(cm(count))

                    count += 1

                    osr.WriteLine(sb.ToString)
                Next

                osr.Close()

                

            Catch ex As Exception
                out.AppendText("Problem outputting data.")

            End Try



            out.AppendText("Output data written." & vbCrLf)

        Else
            out.AppendText("Problem reading input data or finding output directory." & vbCrLf)
        End If


    End Sub

    Private Sub UpdateFields(ByVal cc As ClusterConfig)

        TextBox1.Text = myCC.SourceFile

        Dim fn As String = Path.GetFileName(myCC.SourceFile)
        Dim ss As String = myCC.SQLString.Replace(TABLENAME, fn)

        SQLTextBox.Text = ss

        TextBox2.Text = myCC.OutputPath

        nudIterations.Value = myCC.Iterations
        nudWidth.Value = myCC.Width
        nudeta.Value = myCC.Eta
        nudSigma.Value = myCC.Sigma
        nudEtaEnd.Value = myCC.EtaEnd
        nudSigmaEnd.Value = myCC.SigmaEnd
        cbNorm.Checked = myCC.Normalise
        cbRandom.Checked = myCC.Randomise
        If myCC.Neighbourhood = NeighbourhoodFunction.Bubble Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        DT = Me.ConnectCSV(myCC.SourceFile, myCC.SQLString)



        Dim cit As New ChooseInputColumns(DT.Columns, myCC.Names, myCC.WeightsCol)

        If (cit.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            myCC.Names = cit.CheckedItems
            myCC.WeightsCol = cit.Weights
        End If




    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudIterations.ValueChanged
        myCC.Iterations = nudIterations.Value

    End Sub

    Private Sub nudWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudWidth.ValueChanged
        myCC.Width = nudWidth.Value
    End Sub

    Private Sub nudeta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudeta.ValueChanged
        myCC.Eta = nudeta.Value
    End Sub

    Private Sub SQLTextBox_Left(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SQLTextBox.Leave
        If Not SQLTextBox.Text Is Nothing Then

            Dim ss As String = SQLTextBox.Text

            If Not myCC.SourceFile Is Nothing Then

                If ss.Contains(Path.GetFileName(myCC.SourceFile)) Then
                    ss = ss.Replace(Path.GetFileName(myCC.SourceFile), TABLENAME)
                Else
                    out.AppendText("Warning - SQL no longer includes correct tablename.")
                End If
                myCC.SQLString = ss

            End If
        End If
    End Sub


    Private Sub nudSigma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSigma.ValueChanged
        myCC.Sigma = nudSigma.Value

    End Sub

    Private Sub cbNorm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNorm.CheckedChanged
        myCC.Normalise = cbNorm.Checked
    End Sub

    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudEtaEnd.ValueChanged
        myCC.EtaEnd = nudEtaEnd.Value
    End Sub

    Private Sub nudSigmaEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSigmaEnd.ValueChanged
        myCC.SigmaEnd = nudSigmaEnd.Value
    End Sub

    Private Sub cbRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRandom.CheckedChanged
        myCC.Randomise = cbRandom.Checked
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim filename As String = ""

        Dim folderBrowserDialog1 As New FolderBrowserDialog()

        If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Try

                myCC.OutputPath = folderBrowserDialog1.SelectedPath
                Me.UpdateFields(myCC)

            Catch ex As Exception
                MsgBox("There was a problem selecting the output folder:" & ex.ToString)
            End Try

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        myCC.Neighbourhood = NeighbourhoodFunction.Bubble
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        myCC.Neighbourhood = NeighbourhoodFunction.Gaussian
    End Sub




    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*.xml|*.xml"
        saveFileDialog1.Title = "Save current Cluster Configuration"
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then

            ClusterConfig.serialise(myCC, saveFileDialog1.FileName)
            myCC.FileChanged = False
        End If


    End Sub
End Class

