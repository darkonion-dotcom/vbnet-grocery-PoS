Imports System.Data
Imports System.Data.OleDb
Public Class frmReportesVentas

    Private Sub frmReportesVentas_Load(sender As Object, e As EventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub


    Private Sub frmReportesVentas_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMes.Items.Add("Enero")
        cboMes.Items.Add("Febrero")
        cboMes.Items.Add("Marzo")
        cboMes.Items.Add("Abril")
        cboMes.Items.Add("Mayo")
        cboMes.Items.Add("Junio")
        cboMes.Items.Add("Julio")
        cboMes.Items.Add("Agosto")
        cboMes.Items.Add("Septiembre")
        cboMes.Items.Add("Octubre")
        cboMes.Items.Add("Noviembre")
        cboMes.Items.Add("Diciembre")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cboMes.SelectedIndex = -1 Then
            MsgBox("Selecciona un mes")
            cboMes.Focus()
            Exit Sub
        End If
        If cboAño.SelectedIndex = -1 Then
            MsgBox("Selecciona un año")
            cboAño.Focus()
            Exit Sub
        End If

        Try
            ' Consulta 1
            Dim sentSQL As String

            sentSQL = "Select * from Ventas where Month(fecha)=" & (cboMes.SelectedIndex + 1).ToString & " and year(fecha)=" & (cboAño.SelectedItem).ToString

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objDataSet As New DataSet()
            Dim objAdap As New OleDbDataAdapter(sentSQL, conexion)
            Dim MiConsulta As New DataTable()


            objAdap.Fill(objDataSet)
            dgvLista.DataSource = objDataSet.Tables(0)

            conexion.Open()
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub
    Private Sub dgvLista_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim venta As Integer = (dgvLista.Rows(e.RowIndex).Cells(0).Value)
            Dim sentSQL As String = "SELECT * FROM Detalle_Ventas WHERE NumVenta=" & venta
            Try
                Dim conexion As New OleDbConnection
                conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

                Dim objDataSet As New DataSet()
                Dim objAdap As New OleDbDataAdapter(sentSQL, conexion)
                Dim MiConsulta As New DataTable()

                objAdap.Fill(objDataSet)
                dgvDetalles.DataSource = objDataSet.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message.ToString())
            End Try
        End If
    End Sub
End Class