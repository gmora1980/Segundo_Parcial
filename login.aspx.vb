Imports System.Data.SqlClient

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Function Verificacion(users As Usuarios) As Usuarios
        Try
            Dim Ayuda As New DatabaseHelper()
            Dim Datos As New List(Of SqlParameter) From {
                New SqlParameter("@Email", users.Email),
                New SqlParameter("@Contrasena", users.Contrasena)
            }
            Dim query As String = "SELECT * FROM USUARIOS WHERE EMAIL = @Email AND CONTRASEÑA = @Contrasena"
            Dim dt As DataTable = Ayuda.ExecuteQuery(query, Datos)
            If dt.Rows.Count > 0 Then
                Dim userC As Usuarios = users.dtToUsuarios(dt)
                Session("UsuarioId") = userC.Id.ToString()
                Session("UsuarioNombre") = userC.Nombre.ToString()
                Session("UsuarioApellido") = userC.Apellido.ToString()
                Session("UsuarioEmail") = userC.Email.ToString()
                Session("UsuarioRol") = userC.Rol_ID.ToString()
                Return userC
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim usuario As New Usuarios With {
            .Email = txtEmail.Text.Trim(),
            .Contrasena = txtPass.Text.Trim()
        }
        Dim userC As Usuarios = Verificacion(usuario)
        If userC IsNot Nothing Then
            Select Case userC.Rol_ID
                Case 1 ' Administrador
                    Response.Redirect("Administrador.aspx")
                Case 2 ' Usuario normal
                    Response.Redirect("Standar.aspx")
                Case Else
                    lblError.Text = "Rol de usuario no reconocido."
            End Select
        Else
            ' Mostrar mensaje de error
            lblError.Text = "Credenciales incorrectas. Por favor, inténtelo de nuevo."
        End If
    End Sub
End Class