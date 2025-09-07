Imports System.Data
Imports System.Data.OleDb
Public Class frmEliminarCuenta
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("falta el dato Id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Try
            'sentsql = "Select * from Empleados Where IdEmpleado= " & txtIdEmpleado.Text
            Dim sentsql As String = "SELECT EMPLEADOS.*, USUARIOS.* FROM EMPLEADOS, USUARIOS WHERE EMPLEADOS.IDEMPLEADO=USUARIOS.IDEMPLEADO AND EMPLEADOS.IDEMPLEADO =" & txtIdEmpleado.Text
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim objadap As New OleDbDataAdapter(sentsql, conexion)
            Dim MiConsulta As New DataTable

            conexion.Open()
            objadap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                txtnombre.Clear()
                txtPaterno.Clear()
                ComboBox1.SelectedIndex = -1
                dtpFechaNac.Value = Now
                txtDireccion.Clear()
                txtTelefono.Clear()

                MessageBox.Show("El empleado con id " & txtIdEmpleado.Text & "No existe. Verifique")

            Else
                'Enlazamos de nuevo los controles  Textbox con el 
                'Objeto DataTable devuelto.

                BtnAceptar.Enabled = True

                txtnombre.DataBindings.Add("text", MiConsulta, "Nombre")
                txtPaterno.DataBindings.Add("text", MiConsulta, "ApellidoP")
                TextBox3.DataBindings.Add("text", MiConsulta, "ApellidoM")

                ComboBox1.DataBindings.Add("Text", MiConsulta, "Sexo")
                dtpFechaNac.DataBindings.Add("Text", MiConsulta, "Fecha_Nac")

                txtDireccion.DataBindings.Add("Text", MiConsulta, "Direccion")
                txtTelefono.DataBindings.Add("Text", MiConsulta, "Telefono")

                txtUsuario.DataBindings.Add("text", MiConsulta, "Usuario")
                txtContraseña.DataBindings.Add("text", MiConsulta, "Contraseña")
                cboTipo.DataBindings.Add("text", MiConsulta, "Tipo")

                IdEmpBuscado = txtIdEmpleado.Text

                txtnombre.DataBindings.Clear()
                txtPaterno.DataBindings.Clear()
                TextBox3.DataBindings.Clear()

                ComboBox1.DataBindings.Clear()
                dtpFechaNac.DataBindings.Clear()

                txtDireccion.DataBindings.Clear()
                txtTelefono.DataBindings.Clear()

                txtUsuario.DataBindings.Clear()
                txtContraseña.DataBindings.Clear()
                cboTipo.DataBindings.Clear()

            End If
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("falta el dato Id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If

        Dim r As Integer = MsgBox("El empleado con los datos" & Chr(13) & "Id Empleado: " & txtIdEmpleado.Text & Chr(13) & "Nombre: " & txtnombre.Text & Chr(13) & " Sera eliminado de forma permanente. Estas Seguro? ", vbYesNo)

        If r = vbYes Then
            Try
                Dim conexion As New OleDbConnection()
                conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
                Dim sentsqldelete As String = "DELETE FROM usuarios WHERE IdEmpleado = " & IdEmpBuscado & " AND usuario = '" & txtUsuario.Text & "'"
                Dim comando As New OleDbCommand(sentsqldelete, conexion)
              

                conexion.Open()
                comando.ExecuteNonQuery()

                MessageBox.Show("Los datos fueron borrados con exito", "Eliminar datos")
                conexion.Close()
                conexion.Close()

                txtIdEmpleado.Clear()
                txtnombre.Clear()
                txtPaterno.Clear()
                TextBox3.Clear()
                txtDireccion.Clear()
                txtTelefono.Clear()

                txtUsuario.Clear()
                txtContraseña.Clear()
                cboTipo.SelectedIndex = -1
                ComboBox1.SelectedIndex = -1
            Catch ex As Exception
                MsgBox(ex.Message.ToString())
            End Try
        End If

    End Sub

    Private Sub frmEliminarCuenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtContraseña.PasswordChar = ""
        Else
            txtContraseña.PasswordChar = "*"
        End If
    End Sub
End Class