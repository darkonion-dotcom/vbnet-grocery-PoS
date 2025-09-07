Imports System.Data
Imports System.Data.OleDb
Public Class frmConsultaPedidosEstatus

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            If cboEstatus.SelectedItem = "0" Then
                MsgBox("Por favor sleccione un proveedor")
                Exit Sub
            End If

            ' Modifica esta línea
            Dim sentsql As String = "Select * from Pedidos where Estatus= '" & cboEstatus.SelectedItem.ToString & "'"

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objDataSet As New DataSet()
            Dim objAdap As New OleDbDataAdapter(sentsql, conexion)
            Dim MiConsulta As New DataTable()


            objAdap.Fill(objDataSet)
            dgvlista.DataSource = objDataSet.Tables(0)

            conexion.Open()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub
End Class