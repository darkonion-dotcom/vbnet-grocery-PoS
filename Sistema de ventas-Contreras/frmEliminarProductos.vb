Imports System.Data
Imports System.Data.OleDb

Public Class frmEliminarProductos

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCodigo.Text = "" Then
            MsgBox("Falta codigo")
            txtCodigo.Focus()
            Exit Sub
        End If

        Dim r As Integer
        r = MsgBox("El articulo con los datos" & Chr(13) & "Codigo: " & txtCodigo.Text & Chr(13) & " Sera eliminado de forma permanente. Estas Seguro? ", vbYesNo)
        Try
            Dim conexion As New OleDbConnection
            Dim SentSQLDelete As String

            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            SentSQLDelete = "Delete * from Productos Where Codigo = " & CodigoBuscado

            Dim comando As New OleDbCommand(SentSQLDelete, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()

            MessageBox.Show("Los datos fueron borrados con Exito", "Eliminar datos")
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim SentSQL As String

            SentSQL = "SELECT * From productos where Codigo=" & txtCodigo.Text

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim objAdap As New OleDbDataAdapter(SentSQL, conexion)
            Dim MiConsulta As New DataTable()
            conexion.Open()
            objAdap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                ' No hay registros coincidentes.
                MessageBox.Show("El con codigo" & txtCodigo.Text & "no existe. Verifique")

                txtNombre.Clear()
                txtPrecio.Clear()
                txtExistencia.Clear()
                txtReorden.Clear()

                txtNombre.Clear()

            Else
                'Enlazamos de nuevo los controles Textbox con el
                'Objeto DataTable devuelto.
                txtNombre.Enabled = True
                txtPrecio.Enabled = True
                txtExistencia.Enabled = True
                txtReorden.Enabled = True
                btnAceptar.Enabled = True

                txtNombre.DataBindings.Add("text", MiConsulta, "Nombre")
                txtPrecio.DataBindings.Add("text", MiConsulta, "Precio")
                txtExistencia.DataBindings.Add("text", MiConsulta, "Existencia")
                txtReorden.DataBindings.Add("text", MiConsulta, "Reorden")

                CodigoBuscado = txtCodigo.Text

                txtNombre.DataBindings.Clear()
                txtPrecio.DataBindings.Clear()
                txtExistencia.DataBindings.Clear()
                txtReorden.DataBindings.Clear()
            End If

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub frmEliminarProductosvb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub
End Class