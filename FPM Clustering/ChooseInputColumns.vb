Imports System.Windows.Forms
Imports System.Data

Public Class ChooseInputColumns

    Private Const MAXHEIGHT = 600
    Private Const MAXWIDTH = 1000
    Private Const EACHHEIGHT = 20
    Private Const EACHWIDTH = 140
    Private Const HEIGHTBORDER = 100
    Private Const WIDTHBORDER = 40
    Private Const COMBOHEIGHT = 50

    Private mNumCols As Integer
    Private cb() As CCCheckBox
    Private ws As ComboBox
    Public CheckedItems As System.Collections.Specialized.StringCollection
    Public Weights As String


    Public Property NumCols() As Integer
        Get
            Return mNumCols
        End Get
        Set(ByVal value As Integer)
            mNumCols = value
        End Set
    End Property


    Public Sub New(ByVal cols As DataColumnCollection, ByVal names As System.Collections.Specialized.StringCollection, ByVal weightCol As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.

        Me.Initialise(cols, names, weightCol)

    End Sub


    Private Sub Initialise(ByVal cols As DataColumnCollection, ByVal names As System.Collections.Specialized.StringCollection, ByVal weightCol As String)

        NumCols = cols.Count

        If NumCols * EACHHEIGHT > MAXHEIGHT Then
            Me.Height = MAXHEIGHT
            Me.Width = (System.Convert.ToInt32(NumCols \ (MAXHEIGHT / EACHHEIGHT)) + 1) * EACHWIDTH
        Else
            Me.Height = NumCols * EACHHEIGHT
            Me.Width = EACHWIDTH
        End If

        Height += HEIGHTBORDER
        Width += WIDTHBORDER

        Height += COMBOHEIGHT

        ReDim cb(NumCols - 1)

        Me.SuspendLayout()

        ws = New ComboBox

        Dim count As Integer = 0
        For Each dc As DataColumn In cols
            cb(count) = New CCCheckBox()
            cb(count).Text = dc.ColumnName

            If names.Contains(dc.ColumnName) Then
                cb(count).Checked = True
            End If


            Dim x As Integer = 0
            Dim y As Integer = 0

            x = System.Convert.ToInt32(count \ (MAXHEIGHT / EACHHEIGHT)) * EACHWIDTH
            y = System.Convert.ToInt32(count Mod (MAXHEIGHT / EACHHEIGHT)) * EACHHEIGHT

            cb(count).Location = New System.Drawing.Point(x, y)

            ws.Items.Add(dc.ColumnName)

            count += 1
        Next

        ws.Location = New System.Drawing.Point(10, Height - COMBOHEIGHT * 2)
        ws.SelectedItem = weightCol

        Me.Controls.AddRange(cb)
        Me.Controls.Add(ws)
        Me.ResumeLayout()






    End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        CheckedItems = New System.Collections.Specialized.StringCollection


        For i As Integer = 0 To NumCols - 1

            If cb(i).Checked = True Then
                CheckedItems.Add(cb(i).Text)
            End If

        Next

        Weights = ws.SelectedItem

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
