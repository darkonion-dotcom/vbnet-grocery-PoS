Imports System.Data
Imports System.Data.OleDb
Public Class frmRegistrarEmpleados

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
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

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim SentSQlInsert As String

            SentSQlInsert = "INSERT Into Empleados(IdEmpleado, Nombre, ApellidoP, ApellidoM, Sexo, Fecha_Nac, Direccion, Telefono) VALUES (" & txtIdEmpleado.Text & ",'" & txtNombre.Text & "','" & txtPaterno.Text & "','" & txtMaterno.Text & "','" & ComboBox1.SelectedItem.ToString & "','" & dtpFechaNac.Value & "','" & txtDireccion.Text & "','" & txtTel.Text & "')"
            Dim comadno As New OleDbCommand(SentSQlInsert, conexion)

            conexion.Open()
            comadno.ExecuteNonQuery()
            MessageBox.Show("Los datos fueron guardados con exito", "Sistema de centro de ventas")
            conexion.Close()

            txtDireccion.Clear()
            txtIdEmpleado.Clear()
            txtMaterno.Clear()
            txtNombre.Clear()
            txtPaterno.Clear()
            txtTel.Clear()
            ComboBox1.SelectedItem = -1

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub

    Private Sub frmRegistrarEmpleados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub

    Private Sub frmRegistrarEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim SentSQL As String
            SentSQL = "Select max (IdEmpleado) as maximo from Empleados Where IdEmpleado > " & Format(Now, "yyyy179") & "0000"

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim MiComando As New OleDbCommand(SentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                txtIdEmpleado.Text = Format(Now, "yyyy179") & "0001"
            Else
                txtIdEmpleado.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
End Class