Imports System.Data
Imports System.Data.OleDb
Public Class frmCancelarPedido

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvlista.Rows.Count >= 1 And dgvlista.SelectedRows.Count = 1 Then
            Const cancel As String = "Cancelado"
            dgvlista.SelectedRows(0).Cells(5).Value = cancel.ToString
        Else
            MsgBox("Favor de hacer una consulta valida o selecciona una fila")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
            conexion.Open()


            Dim j As Integer
            For j = 0 To dgvlista.Rows.Count - 1

                Dim estatus As String = dgvlista.Rows(j).Cells(5).Value.ToString()
                Dim codigo As String = dgvlista.Rows(j).Cells(0).Value.ToString()

                Dim UpdtSQL As String = "Update Pedidos Set Estatus = '" & estatus & "'  Where NumPedido=" & codigo


                Dim comando1 As New OleDbCommand(UpdtSQL, conexion)
                comando1.ExecuteNonQuery()
                comando1.Dispose()
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If TxtNoPedido.Text = "" Then
            MsgBox("Favor de introducir un pedido")
            TxtNoPedido.Focus()
            Exit Sub
        End If
        Try
            Dim SentSQL As String
            SentSQL = "Select * from Pedidos where NumPedido =" & TxtNoPedido.Text

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objadap As New OleDbDataAdapter(SentSQL, conexion)
            Dim Miconsulta As New DataTable()
            Dim objDataset As New DataSet

            conexion.Open()
            objadap.Fill(Miconsulta)
            objadap.Fill(objDataset)

            If (Miconsulta.Rows.Count) = 0 Then
                MessageBox.Show("Pedido inexistente")
                txtProvedor.Clear()
                txtResponsable.Clear()
                Exit Sub
            Else
                txtProvedor.DataBindings.Add("text", Miconsulta, "Proveedor")
                txtResponsable.DataBindings.Add("text", Miconsulta, "Responsable")

                txtProvedor.DataBindings.Clear()
                txtResponsable.DataBindings.Clear()
            End If

            dgvlista.DataSource = objDataset.Tables(0)
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub frmCancelarPedido_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
        Me.Close()
    End Sub
End Class