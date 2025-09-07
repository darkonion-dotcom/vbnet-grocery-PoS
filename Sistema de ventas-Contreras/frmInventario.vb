Imports System.Data
Imports System.Data.OleDb
Public Class frmInventario
    Private Sub frmReportesVentas_Load(sender As Object, e As EventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub
    Private Sub frmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sentSQL As String
            sentSQL = "Select codigo, Nombre, Precio, Existencia, Existencia *  Precio As [Monto Existencia] from Productos Where Existencia > 0"

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objDataSet As New DataSet()
            Dim objAdap As New OleDbDataAdapter(sentSQL, conexion)
            Dim MiConsulta As New DataTable()

            conexion.Open()
            objAdap.Fill(objDataSet)
            dgvLista.DataSource = objDataSet.Tables(0)

            conexion.Close()

            Dim s As Double
            s = 0

            For i = 0 To dgvLista.Rows.Count - 2
                s = s + dgvLista.Rows(i).Cells(4).Value
            Next
            txtTotal.Text = s.ToString

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
End Class