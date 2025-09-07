Imports System.Data
Imports System.Data.OleDb
Public Class frmConsultaGeneralPedidos

    Private Sub frmConsultaGeneralPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim SentSQL As String
            SentSQL = "Select * from Pedidos "
            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objadap As New OleDbDataAdapter(SentSQL, conexion)
            Dim Miconsulta As New DataTable()
            Dim objDataset As New DataSet

            conexion.Open()
            objadap.Fill(Miconsulta)
            objadap.Fill(objDataset)


            dgvlista.DataSource = objDataset.Tables(0)
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
End Class