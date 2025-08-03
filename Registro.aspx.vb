Imports System.Data.SqlClient

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub Limpiar()
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtEmail.Text = ""
        txtPass.Text = ""
        ddlRol.SelectedIndex = 0
    End Sub
    Protected Function Registro(Usuario As Usuarios) As Boolean
        Try
            Dim Ayuda As New DatabaseHelper()
            Dim query As String = "INSERT INTO USUARIOS (NOMBRE, APELLIDOS, EMAIL, CONTRASEÑA, ROL_ID) 
                                   VALUES (@Nombre, @Apellido, @Email, @Contrasena, @Rol_ID)"
            Dim Datos As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Usuario.Nombre),
                New SqlParameter("@Apellido", Usuario.Apellido),
                New SqlParameter("@Email", Usuario.Email),
                New SqlParameter("@Contrasena", Usuario.Contrasena),
                New SqlParameter("@Rol_ID", Usuario.Rol_ID)
            }

            Dim Result As Boolean = Ayuda.ExecuteNonQuery(query, Datos)
            Return Result
        Catch ex As Exception
            ' Manejo de errores
            Return False
        End Try
    End Function
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtPass.Text) OrElse
           ddlRol.SelectedIndex = 0 Then
            Limpiar()
            lblError.Text = "Por favor, complete todos los campos."
            Return
        End If
        Dim roll As Integer = Convert.ToInt32(ddlRol.SelectedValue)
        Dim usuario As New Usuarios With {
            .Nombre = txtNombre.Text,
            .Apellido = txtApellido.Text,
            .Email = txtEmail.Text,
            .Contrasena = txtPass.Text,
                .Rol_ID = roll
            }
        If Registro(usuario) Then
            Limpiar()
            ScriptManager.RegisterStartupScript(
                     Me, Me.GetType(),
                     "RegistrarUsuarioOk",
                     "Swal.fire('Usuario Registrado').then((result) => {
                            if (result.isConfirmed) {
                                 window.location.href = 'Login.aspx';
                            }
                     });",
                     True)
        Else
            Limpiar()
            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(),
                "RegistrarUsuarioError",
                "Swal.fire('Error al registrar el usuario. Inténtalo de nuevo.');",
                True)
        End If
    End Sub
End Class