Public Class Usuarios
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Email As String
    Public Property Contrasena As String
    Public Property Rol_ID As Integer
    Public Sub New()
    End Sub
    Public Function dtToUsuarios(dt As DataTable) As Usuarios
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim row As DataRow = dt.Rows(0)
        Dim user As New Usuarios With {
            .Id = Convert.ToInt32(row("ID")),
            .Nombre = Convert.ToString(row("NOMBRE")),
            .Apellido = Convert.ToString(row("APELLIDOS")),
            .Email = Convert.ToString(row("EMAIL")),
            .Contrasena = Convert.ToString(row("CONTRASEÑA")),
            .Rol_ID = Convert.ToInt32(row("ROL_ID"))
            }
        Return user
    End Function

End Class
