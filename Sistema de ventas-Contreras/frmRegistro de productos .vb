Imports System.Data
Imports System.Data.OleDb
Public Class frmRegistrarProductos
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCodigo.Text = "" Then
            MsgBox("falta Codigo")
            txtCodigo.Focus()
            Exit Sub
        End If
        If txtNombre.Text = "" Then
            MsgBox("falta Nombre")
            txtNombre.Focus()
            Exit Sub
        End If
        If txtPrecio.Text = "" Then
            MsgBox("falta Precio")
            txtPrecio.Focus()
            Exit Sub
        End If
        If txtExistencia.Text = "" Then
            MsgBox("falta Existencia")
            txtExistencia.Focus()
            Exit Sub
        End If
        txtReorden.Text = (txtExistencia.Text * 15) / 100
        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
            Dim SentSQLinsert As String
            SentSQLinsert = "INSERT INTO Productos(Codigo,Nombre,Precio,Existencia,Reorden) VALUES(" & txtCodigo.Text & ",'" & txtNombre.Text & "'," & txtPrecio.Text & "," & txtExistencia.Text & "," & txtReorden.Text & ")"

            Dim comando As New OleDbCommand(SentSQLinsert, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()

            MessageBox.Show("Los Datos fueron guardados con exito", "Datos guardados...")

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmRegistroProductos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub
    Private Sub txtExistencia_TextChanged(sender As Object, e As EventArgs) Handles txtExistencia.TextChanged
        txtReorden.Text = (Val(txtExistencia.Text) * (15 / 100)).ToString
    End Sub

    Private Sub frmRegistrarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class