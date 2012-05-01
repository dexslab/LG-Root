Imports RegawMOD.Android
Public Class Form1
    Dim android As AndroidController
    Dim device As Device
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        android = AndroidController.Instance
    End Sub
End Class
