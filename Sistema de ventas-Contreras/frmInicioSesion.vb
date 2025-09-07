Imports System.Data
Imports System.Data.OleDb

Public Class frmIniciosesion
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If txtusuario.Text = "" Then
            MsgBox("Falta el dato usuario")
            txtusuario.Focus()
            Exit Sub
            If txtcontraseña.Text = "" Then MsgBox("Falta la contraseña")
            txtcontraseña.Focus()
            Exit Sub
        End If
        Try
            Dim sentsql As String
            sentsql = "Select * from Usuarios where Usuario='" & Trim(txtusuario.Text) & "' and contraseña ='" & Trim(txtcontraseña.Text) & "'"
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim objadap As New OleDbDataAdapter(sentsql, conexion)
            Dim miConsulta As New DataTable() 'consulta

            conexion.Open()
            objadap.Fill(miConsulta)

            If (miConsulta.Rows.Count) = 0 Then
                ' no hay registros coincidentes.
                MessageBox.Show("El nombre del usuario o la contraseña es incorrecta. Intente de nuevo")
            Else
                txtTemp.Visible = True

                txtTemp.DataBindings.Add("text", miConsulta, "IdEmpleado")
                idEmpActivo = txtTemp.Text
                txtTemp.DataBindings.Clear()
                '****
                txtTemp.DataBindings.Add("text", miConsulta, "Tipo")
                TipoUsuario = txtTemp.Text
                txtTemp.DataBindings.Clear()
                '****

                txtTemp.Visible = False

                Select Case (TipoUsuario)
                    Case "ADMINISTRADOR"
                        frmMenuvb.Show()
                        IsAut = True
                    Case "CAJERO"
                        frmVenta.Show()
                    Case Else
                        MsgBox("Verifica la base de datos")
                End Select

                Me.Close()
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        End
    End Sub

    Private Sub frmIniciosesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
