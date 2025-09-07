Imports System.Data
Imports System.Data.OleDb
Public Class frmConsultaEmpleados

    Private Sub frmConsultaEmpleados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub
    Private Sub frmConsultaEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim SentSQL As String
            SentSQL = "Select idEmpleado, Nombre, ApellidoP as [Apellido Paterno], ApellidoM as [Apellido Materno], Sexo, Fecha_Nac as [Fecha de nacimiento], Direccion, Telefono from Empleados"

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objadap As New OleDbDataAdapter(sentSQL, conexion)
            Dim Miconsulta As New DataTable()
            Dim objDataset As New DataSet

            conexion.Open()
            objadap.Fill(objDataset)
            dgvLista.DataSource = objDataset.Tables(0)


        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
End Class