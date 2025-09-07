Imports System.Data
Imports System.Data.OleDb
Public Class frmEliminarEmpleados
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmEliminarEmpleados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("Falta el id de empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Try
            Dim sentSQL As String
            sentSQL = "Select * from Empleados where IdEmpleado= " & txtIdEmpleado.Text

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objadap As New OleDbDataAdapter(sentSQL, conexion)
            Dim Miconsulta As New DataTable()

            conexion.Open()
            objadap.Fill(Miconsulta)

            If (Miconsulta.Rows.Count) = 0 Then
                'No hay registros coincidentes
                txtDireccion.Clear()
                txtIdEmpleado.Clear()
                txtMaterno.Clear()
                txtNombre.Clear()
                txtPaterno.Clear()
                txtTel.Clear()
                ComboBox1.SelectedItem = -1
                dtpFechaNac.Value = Now

                MessageBox.Show("El empleado con id " & txtIdEmpleado.Text & " No existe. Verifique")

            Else
                'Enlazamos de nuevo los controles textbox con el
                'Objeto DataTable Devuelto.

                btnAceptar.Enabled = True
                IdBuscado = txtIdEmpleado.Text

                txtNombre.DataBindings.Add("text", Miconsulta, "Nombre")
                txtPaterno.DataBindings.Add("text", Miconsulta, "ApellidoP")
                txtMaterno.DataBindings.Add("text", Miconsulta, "ApellidoM")

                ComboBox1.DataBindings.Add("text", Miconsulta, "Sexo")
                dtpFechaNac.DataBindings.Add("text", Miconsulta, "Fecha_Nac")

                txtDireccion.DataBindings.Add("text", Miconsulta, "Direccion")
                txtTel.DataBindings.Add("text", Miconsulta, "Telefono")

                txtNombre.DataBindings.Clear()
                txtPaterno.DataBindings.Clear()
                txtMaterno.DataBindings.Clear()
                ComboBox1.DataBindings.Clear()
                txtDireccion.DataBindings.Clear()
                txtTel.DataBindings.Clear()
                dtpFechaNac.DataBindings.Clear()
            End If
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("Falta el id de empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Dim r As Integer
        r = MsgBox("El empleado con los datos" & Chr(13) & "Id Empleado: " & txtIdEmpleado.Text & Chr(13) & "Nombre: " & txtNombre.Text & Chr(13) & " Sera eliminado de forma permamente. Estas Seguro? ", vbYesNo)
        If r = vbYes Then
            Try
                Dim conexion As New OleDbConnection
                Dim SentSQLDelete As String
                Dim SentSQLDelete2 As String
                conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

                SentSQLDelete = "Delete * from Empleados where IdEmpleado= " & IdBuscado
                SentSQLDelete2 = "Delete * from Usuarios where IdEmpleado= " & IdBuscado

                Dim comando As New OleDbCommand(SentSQLDelete, conexion)
                Dim comando2 As New OleDbCommand(SentSQLDelete2, conexion)

                conexion.Open()
                comando.ExecuteNonQuery()
                comando2.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message.ToString())
            End Try

        End If
    End Sub
End Class