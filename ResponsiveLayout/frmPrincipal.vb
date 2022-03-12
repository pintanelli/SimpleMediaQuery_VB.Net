Public Class frmPrincipal

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim mediaQuery As New MediaQuery(Panel5)
        mediaQuery.addChildren(Panel1)
        mediaQuery.addChildren(Panel2)
        mediaQuery.addChildren(Panel3)
        mediaQuery.addChildren(Panel4)
        mediaQuery.setAll(6, 12, 6, 4, 3)
        mediaQuery.redefinirLayout()

    End Sub

    Private Sub frmPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblTamanho.Text = "Tamanho da Tela: " & Me.Size.Width
    End Sub
End Class
