Imports System.Data
Imports System.Data.OleDb
Public Class frmCambiarContraseña
    Public passactual As String
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("falta el dato Id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim sentsql As String = "SELECT EMPLEADOS.*, USUARIOS.* FROM EMPLEADOS, USUARIOS WHERE EMPLEADOS.IDEMPLEADO=USUARIOS.IDEMPLEADO AND EMPLEADOS.IDEMPLEADO =" & txtIdEmpleado.Text

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
                passactual = txtContraseña.Text
                cboTipo.DataBindings.Add("text", MiConsulta, "Tipo")

                IdBuscado = txtIdEmpleado.Text

                txtnombre.DataBindings.Clear()
                txtPaterno.DataBindings.Clear()
                TextBox3.DataBindings.Clear()

                ComboBox1.DataBindings.Clear()
                dtpFechaNac.DataBindings.Clear()

                txtDireccion.DataBindings.Clear()
                txtTelefono.DataBindings.Clear()

                txtUsuario.DataBindings.Clear()
                txtContraseña.DataBindings.Clear()
                txtContraseña.Clear()

                cboTipo.DataBindings.Clear()


            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("Falta el id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If

        If (txtContraseña.Text <> passactual) Then
            MessageBox.Show("La contraseña actual que capturaste no es correcta. Verifique")
        End If

        If (txtnewpassword.Text <> txtConfirmar.Text) Then
            MessageBox.Show("La contraseña nueva y su confirmacion no coinciden. Verifique")
        Else
            Try
                Dim conexion As New OleDbConnection
                conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

                Dim sentsqlupdate = "UPDATE USUARIOS SET CONTRASEÑA='" & txtnewpassword.Text & "' WHERE IDEMPLEADO=" & IdBuscado

                Dim comando As New OleDbCommand(sentsqlupdate, conexion)

                conexion.Open()
                comando.ExecuteNonQuery()

                MessageBox.Show("Los datos fueron actualizados con exito")
                conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message.ToString())
            End Try
        End If


    End Sub

    Private Sub frmCambiarContraseña_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtConfirmar.PasswordChar = ""
            txtContraseña.PasswordChar = ""
            txtnewpassword.PasswordChar = ""
        Else
            txtContraseña.PasswordChar = "*"
            txtConfirmar.PasswordChar = "*"
            txtnewpassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtConfirmar_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmar.TextChanged

    End Sub

    Private Sub txtnewpassword_TextChanged(sender As Object, e As EventArgs) Handles txtnewpassword.TextChanged

    End Sub

    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña.TextChanged

    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged

    End Sub
End Class