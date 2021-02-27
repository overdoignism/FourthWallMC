<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Help_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.Iagree_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Ok_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Help_RichTextBox
        '
        Me.Help_RichTextBox.BackColor = System.Drawing.Color.White
        Me.Help_RichTextBox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Help_RichTextBox.Location = New System.Drawing.Point(12, 12)
        Me.Help_RichTextBox.Name = "Help_RichTextBox"
        Me.Help_RichTextBox.ReadOnly = True
        Me.Help_RichTextBox.Size = New System.Drawing.Size(776, 416)
        Me.Help_RichTextBox.TabIndex = 0
        Me.Help_RichTextBox.Text = ""
        '
        'Iagree_CheckBox
        '
        Me.Iagree_CheckBox.AutoSize = True
        Me.Iagree_CheckBox.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Iagree_CheckBox.Location = New System.Drawing.Point(368, 453)
        Me.Iagree_CheckBox.Name = "Iagree_CheckBox"
        Me.Iagree_CheckBox.Size = New System.Drawing.Size(70, 20)
        Me.Iagree_CheckBox.TabIndex = 23
        Me.Iagree_CheckBox.Text = "I agree."
        Me.Iagree_CheckBox.UseVisualStyleBackColor = True
        '
        'Ok_Button
        '
        Me.Ok_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ok_Button.Location = New System.Drawing.Point(346, 493)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Size = New System.Drawing.Size(108, 36)
        Me.Ok_Button.TabIndex = 24
        Me.Ok_Button.Text = "OK"
        Me.Ok_Button.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 557)
        Me.Controls.Add(Me.Ok_Button)
        Me.Controls.Add(Me.Iagree_CheckBox)
        Me.Controls.Add(Me.Help_RichTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3"
        Me.Text = "Help & About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Help_RichTextBox As RichTextBox
    Friend WithEvents Iagree_CheckBox As CheckBox
    Friend WithEvents Ok_Button As Button
End Class
