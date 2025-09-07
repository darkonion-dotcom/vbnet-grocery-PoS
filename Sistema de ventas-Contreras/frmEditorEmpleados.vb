Imports System.Data
Imports System.Data.OleDb
Public Class frmEditorEmpleados

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmEditorEmpleados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtDireccion.Text = "" Then
            MsgBox("Falta el dato dirección")
            txtDireccion.Focus()
            Exit Sub
        End If
        If txtIdEmpleado.Text = "" Then
            MsgBox("Falta el Id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        If txtMaterno.Text = "" Then
            MsgBox("Falta el apellido Materno")
            txtMaterno.Focus()
            Exit Sub
        End If
        If txtNombre.Text = "" Then
            MsgBox("Falta el nombre del empleado")
            txtNombre.Focus()
            Exit Sub
        End If
        If txtTel.Text = "" Then
            MsgBox("Falta el telefono del cliente")
            txtTel.Focus()
            Exit Sub
        End If
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Falta el dato Sexo")
            ComboBox1.Focus()
            Exit Sub
        End If

        Try

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim SentSQlUpdate As String
            SentSQlUpdate = "Update Empleados SET Nombre='" & txtNombre.Text & "', ApellidoP ='" & txtPaterno.Text & "', ApellidoM ='" & txtMaterno.Text & "', Sexo ='" & ComboBox1.SelectedItem & "', Fecha_Nac ='" & dtpFechaNac.Value.ToString & "', Direccion  ='" & txtDireccion.Text & "', Telefono ='" & txtTel.Text & "' Where IdEmpleado =" & IdBuscado
            ' Dim SentSqlUpdate2 As String

           
            Dim comando As New OleDbCommand(SentSQlUpdate, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()

            MessageBox.Show("Los datos fueron actualizados con exito", "Editar datos...")
            conexion.Close()

            txtDireccion.Clear()
            txtIdEmpleado.Clear()
            txtMaterno.Clear()
            txtNombre.Clear()
            txtPaterno.Clear()
            txtTel.Clear()
            ComboBox1.SelectedItem = -1

            txtNombre.Enabled = False
            txtDireccion.Enabled = False
            txtTel.Enabled = False

            btnAceptar.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
    Private Sub BtnBuscar_Click_1(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("Falta el id de empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Try
            Dim sentSQL As String
            sentSQL = "Select * from Empleados where IdEmpleado= " & txtIdEmpleado.Text

            Dim conexion As New OleDbConnection()
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
End Class