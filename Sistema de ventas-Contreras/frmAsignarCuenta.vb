Imports System.Data
Imports System.Data.OleDb
Public Class frmAsignarCuenta
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If txtIdEmpleado.Text = "" Then
            MsgBox("falta el dato Id del empleado")
            txtIdEmpleado.Focus()
            Exit Sub
        End If
        Try
            Dim sentsql As String = "Select * from Empleados Where IdEmpleado= " & txtIdEmpleado.Text
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

                IdBuscado = txtIdEmpleado.Text

                txtnombre.DataBindings.Clear()
                txtPaterno.DataBindings.Clear()
                TextBox3.DataBindings.Clear()

                ComboBox1.DataBindings.Clear()
                dtpFechaNac.DataBindings.Clear()

                txtDireccion.DataBindings.Clear()
                txtTelefono.DataBindings.Clear()
            End If
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If txtUsuario.Text = "" Then
            MsgBox("Falta el dato usuario")
            txtUsuario.Focus()
            Exit Sub
        End If

        If txtContraseña.Text = "" Then
            MsgBox("Falta el dato contraseña")
            txtContraseña.Focus()
            Exit Sub
        End If

        If txtConfirmar.Text = "" Then
            MsgBox("Falta confirmar la contraseña")
            txtConfirmar.Focus()
            Exit Sub
        End If

        If txtContraseña.Text <> txtConfirmar.Text Then
            MsgBox("La contraseña no coincide con la confirmacion. Proporcionelas de nuevo.")
            txtConfirmar.Clear()
            txtContraseña.Clear()
            txtContraseña.Focus()
            Exit Sub
        End If




        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim sentsqlinsert As String = "INSERT INTO USUARIOS(IDEMPLEADO,USUARIO,CONTRASEÑA,TIPO) VALUES (" & txtIdEmpleado.Text & ",'" & txtUsuario.Text & "','" & txtContraseña.Text & "','" & cboTipo.SelectedItem & "')"

            Dim comando As New OleDbCommand(sentsqlinsert, conexion)

            conexion.Open()
            comando.ExecuteNonQuery()

            MessageBox.Show("Los Datos fueron guardados con exito", "Sistema de contro de ventas")

            conexion.Close()

            txtIdEmpleado.Clear()
            txtnombre.Clear()
            txtPaterno.Clear()
            TextBox3.Clear()
            txtDireccion.Clear()
            txtTelefono.Clear()

            txtUsuario.Clear()
            txtContraseña.Clear()
            txtConfirmar.Clear()
            cboTipo.SelectedIndex = -1
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtConfirmar.PasswordChar = ""
            txtContraseña.PasswordChar = ""
        Else
            txtContraseña.PasswordChar = "*"
            txtConfirmar.PasswordChar = "*"
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmAsignarCuenta_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout
        frmMenuvb.Show()
    End Sub
End Class