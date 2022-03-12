Public Class MediaQuery

    'Breakpoints (Pixels)
    Private sm As Integer
    Private md As Integer
    Private lg As Integer
    Private xl As Integer
    Private xxl As Integer
    Private containerFluid As Boolean

    'Configurações definidas pelo usuário
    Private userSM As Integer
    Private userMD As Integer
    Private userLG As Integer
    Private userXL As Integer
    Private userXXL As Integer

    'Elemento Pai
    Private objPai As Windows.Forms.Control

    'Elementos Filhos
    Private objsFilhos As New List(Of Windows.Forms.Control)

    'Método Construtor
    Sub New(ByVal obj As Windows.Forms.Control, Optional ByVal fluid As Boolean = False)

        objPai = obj
        containerFluid = fluid

        sm = 576
        md = 768
        lg = 992
        xl = 1200
        xxl = 1400

        userSM = 12
        userMD = 12
        userLG = 12
        userXL = 12
        userXXL = 12

        AddHandler obj.Resize, AddressOf redefinirLayout

    End Sub

    'Métodos Sets
    Public Sub setSM(ByVal userSM As Integer)
        Me.userSM = userSM
    End Sub

    Public Sub setMD(ByVal userMD As Integer)
        Me.userMD = userMD
    End Sub

    Public Sub setLG(ByVal userLG As Integer)
        Me.userLG = userLG
    End Sub

    Public Sub setXL(ByVal userXL As Integer)
        Me.userXL = userXL
    End Sub

    Public Sub setXXL(ByVal userXXL As Integer)
        Me.userXXL = userXXL
    End Sub

    Public Sub setAll(ByVal userSM As Integer, ByVal userMD As Integer, ByVal userLG As Integer, ByVal userXL As Integer, ByVal userXXL As Integer)
        Me.userSM = userSM
        Me.userMD = userMD
        Me.userLG = userLG
        Me.userXL = userXL
        Me.userXXL = userXXL
    End Sub

    Public Sub addChildren(ByVal children As Object)
        objsFilhos.Add(children)
    End Sub

    'Métodos Personalizados
    Public Sub redefinirLayout()

        Dim tamanhoBase As Integer
        Dim tamanhoTotal As Integer = objPai.Size.Width

        If containerFluid Then
            tamanhoBase = tamanhoTotal
        Else
            tamanhoBase = breakPoint()
        End If

        Dim configAtual As Integer = returnConfig()
        Dim tamanhoElemento As Integer = (tamanhoBase \ 12) * configAtual
        Dim qtdElementosPorLinha As Integer = 12 \ configAtual
        Dim tamanhoRestante As Integer = tamanhoTotal - (tamanhoElemento * qtdElementosPorLinha)
        Dim auxX As Integer
        Dim auxY As Integer = 0
        Dim auxQtdElementos As Integer = 0

        For Each i As Windows.Forms.Control In objsFilhos

            If (auxQtdElementos = 0) Then
                auxX = tamanhoRestante / 2
            Else
                auxX += tamanhoElemento
            End If

            i.Size = New Size(tamanhoElemento, i.Size.Height)
            i.Location = New Point(auxX, auxY)

            If auxQtdElementos = (qtdElementosPorLinha - 1) Then
                auxQtdElementos = 0
                auxY = auxY + i.Size.Height
            Else
                auxQtdElementos += 1
            End If
        Next

    End Sub

    Private Function breakPoint() As Integer

        Dim tamanho As Integer = objPai.Size.Width

        If tamanho < sm Then
            Return tamanho
        ElseIf tamanho < md Then
            Return sm
        ElseIf tamanho < lg Then
            Return md
        ElseIf tamanho < xl Then
            Return lg
        ElseIf tamanho < xxl Then
            Return xl
        Else
            Return xxl
        End If

    End Function

    Private Function returnConfig() As Integer

        Dim tamanho As Integer = objPai.Size.Width

        If tamanho < sm Then
            Return 12
        ElseIf tamanho < md Then
            Return userSM
        ElseIf tamanho < lg Then
            Return userMD
        ElseIf tamanho < xl Then
            Return userLG
        ElseIf tamanho < xxl Then
            Return userXL
        Else
            Return userXXL
        End If

    End Function

End Class
