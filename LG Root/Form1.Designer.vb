<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.rootButton = New System.Windows.Forms.Button()
        Me.rootCWMButton = New System.Windows.Forms.Button()
        Me.cwmButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.unroot = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Crimson
        Me.TextBox1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.TextBox1.Location = New System.Drawing.Point(277, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(248, 375)
        Me.TextBox1.TabIndex = 0
        '
        'rootButton
        '
        Me.rootButton.Location = New System.Drawing.Point(12, 12)
        Me.rootButton.Name = "rootButton"
        Me.rootButton.Size = New System.Drawing.Size(115, 23)
        Me.rootButton.TabIndex = 1
        Me.rootButton.Text = "Root"
        Me.rootButton.UseVisualStyleBackColor = True
        '
        'rootCWMButton
        '
        Me.rootCWMButton.Location = New System.Drawing.Point(12, 41)
        Me.rootCWMButton.Name = "rootCWMButton"
        Me.rootCWMButton.Size = New System.Drawing.Size(115, 23)
        Me.rootCWMButton.TabIndex = 2
        Me.rootCWMButton.Text = "Root and CWM"
        Me.rootCWMButton.UseVisualStyleBackColor = True
        '
        'cwmButton
        '
        Me.cwmButton.Location = New System.Drawing.Point(133, 12)
        Me.cwmButton.Name = "cwmButton"
        Me.cwmButton.Size = New System.Drawing.Size(115, 23)
        Me.cwmButton.TabIndex = 3
        Me.cwmButton.Text = "Install CWM"
        Me.cwmButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 133)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(259, 245)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'unroot
        '
        Me.unroot.Location = New System.Drawing.Point(133, 41)
        Me.unroot.Name = "unroot"
        Me.unroot.Size = New System.Drawing.Size(115, 23)
        Me.unroot.TabIndex = 7
        Me.unroot.Text = "Unroot Stock Reovery"
        Me.unroot.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 390)
        Me.Controls.Add(Me.unroot)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cwmButton)
        Me.Controls.Add(Me.rootCWMButton)
        Me.Controls.Add(Me.rootButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "LG Root"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents rootButton As System.Windows.Forms.Button
    Friend WithEvents rootCWMButton As System.Windows.Forms.Button
    Friend WithEvents cwmButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents unroot As System.Windows.Forms.Button

End Class
