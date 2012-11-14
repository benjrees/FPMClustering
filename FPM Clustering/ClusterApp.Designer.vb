<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClusterApp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.SQLTextBox = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.out = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudIterations = New System.Windows.Forms.NumericUpDown
        Me.nudWidth = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudeta = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudSigma = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbNorm = New System.Windows.Forms.CheckBox
        Me.nudEtaEnd = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.nudSigmaEnd = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbRandom = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        CType(Me.nudIterations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSigma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEtaEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSigmaEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button1.Location = New System.Drawing.Point(370, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Run"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(498, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OpenToolStripMenuItem.Text = "Open.."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SaveToolStripMenuItem.Text = "Save.."
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 38)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(188, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(209, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SQLTextBox
        '
        Me.SQLTextBox.Location = New System.Drawing.Point(12, 75)
        Me.SQLTextBox.Multiline = True
        Me.SQLTextBox.Name = "SQLTextBox"
        Me.SQLTextBox.Size = New System.Drawing.Size(224, 89)
        Me.SQLTextBox.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 180)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(127, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Choose Input Columns"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'out
        '
        Me.out.Location = New System.Drawing.Point(12, 314)
        Me.out.Multiline = True
        Me.out.Name = "out"
        Me.out.ReadOnly = True
        Me.out.Size = New System.Drawing.Size(473, 158)
        Me.out.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Iterations"
        '
        'nudIterations
        '
        Me.nudIterations.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudIterations.Location = New System.Drawing.Point(367, 38)
        Me.nudIterations.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudIterations.Name = "nudIterations"
        Me.nudIterations.Size = New System.Drawing.Size(120, 20)
        Me.nudIterations.TabIndex = 8
        '
        'nudWidth
        '
        Me.nudWidth.Location = New System.Drawing.Point(367, 68)
        Me.nudWidth.Name = "nudWidth"
        Me.nudWidth.Size = New System.Drawing.Size(120, 20)
        Me.nudWidth.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(262, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Width"
        '
        'nudeta
        '
        Me.nudeta.DecimalPlaces = 2
        Me.nudeta.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudeta.Location = New System.Drawing.Point(306, 100)
        Me.nudeta.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudeta.Name = "nudeta"
        Me.nudeta.Size = New System.Drawing.Size(60, 20)
        Me.nudeta.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "η Start"
        '
        'nudSigma
        '
        Me.nudSigma.DecimalPlaces = 2
        Me.nudSigma.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSigma.Location = New System.Drawing.Point(307, 136)
        Me.nudSigma.Name = "nudSigma"
        Me.nudSigma.Size = New System.Drawing.Size(59, 20)
        Me.nudSigma.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(262, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "σ Start"
        '
        'cbNorm
        '
        Me.cbNorm.AutoSize = True
        Me.cbNorm.Location = New System.Drawing.Point(12, 219)
        Me.cbNorm.Name = "cbNorm"
        Me.cbNorm.Size = New System.Drawing.Size(96, 17)
        Me.cbNorm.TabIndex = 15
        Me.cbNorm.Text = "Normalise data"
        Me.cbNorm.UseVisualStyleBackColor = True
        '
        'nudEtaEnd
        '
        Me.nudEtaEnd.DecimalPlaces = 2
        Me.nudEtaEnd.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudEtaEnd.Location = New System.Drawing.Point(425, 100)
        Me.nudEtaEnd.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudEtaEnd.Name = "nudEtaEnd"
        Me.nudEtaEnd.Size = New System.Drawing.Size(60, 20)
        Me.nudEtaEnd.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(384, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "η End"
        '
        'nudSigmaEnd
        '
        Me.nudSigmaEnd.DecimalPlaces = 2
        Me.nudSigmaEnd.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSigmaEnd.Location = New System.Drawing.Point(425, 136)
        Me.nudSigmaEnd.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudSigmaEnd.Name = "nudSigmaEnd"
        Me.nudSigmaEnd.Size = New System.Drawing.Size(60, 20)
        Me.nudSigmaEnd.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(384, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "σ End"
        '
        'cbRandom
        '
        Me.cbRandom.AutoSize = True
        Me.cbRandom.Location = New System.Drawing.Point(12, 242)
        Me.cbRandom.Name = "cbRandom"
        Me.cbRandom.Size = New System.Drawing.Size(103, 17)
        Me.cbRandom.TabIndex = 20
        Me.cbRandom.Text = "Randomise data"
        Me.cbRandom.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(292, 275)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 20)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(98, 275)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(188, 20)
        Me.TextBox2.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 278)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Output Folder"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(265, 180)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(134, 17)
        Me.RadioButton1.TabIndex = 24
        Me.RadioButton1.Text = "Bubble Neighbourhood"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(265, 204)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(145, 17)
        Me.RadioButton2.TabIndex = 25
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Gaussian Neighbourhood"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'ClusterApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 484)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.cbRandom)
        Me.Controls.Add(Me.nudSigmaEnd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudEtaEnd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNorm)
        Me.Controls.Add(Me.nudSigma)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudeta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudWidth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudIterations)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.out)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.SQLTextBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ClusterApp"
        Me.Text = "FPM Cluster Application"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.nudIterations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSigma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEtaEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSigmaEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SQLTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents out As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudIterations As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudeta As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudSigma As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbNorm As System.Windows.Forms.CheckBox
    Friend WithEvents nudEtaEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudSigmaEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbRandom As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
