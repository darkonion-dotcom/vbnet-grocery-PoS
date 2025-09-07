Imports System.Data
Imports System.Data.OleDb
Public Class frmPedidos
    Public existe As Boolean
    Public Sub sumar()
        Dim S As Double = 0
        For i = 0 To dgvLista.Rows.Count - 2
            S += dgvLista.Rows(i).Cells(4).Value
        Next
    End Sub
    Private Sub frmPedidos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenuvb.Show()
    End Sub


    Private Sub frmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim SentSQL As String
            SentSQL = "Select Codigo, Nombre, Existencia, Reorden, 0 AS Cantidad From Productos where Existencia <= Reorden"

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objadap As New OleDbDataAdapter(SentSQL, conexion)
            Dim Miconsulta As New DataTable()
            Dim objDataset As New DataSet

            conexion.Open()
            objadap.Fill(objDataset)
            dgvLista.DataSource = objDataset.Tables(0)




            'generar el numero de venta automaticamente

            Dim SentSQL2 As String = "Select max(NumPedido) as maximo from Pedidos where NumPedido > " & Format(Now, "yyyyMM") & "00"

            Dim MiComando2 As New OleDbCommand(SentSQL2, conexion)


            If IsDBNull(MiComando2.ExecuteScalar()) = True Then
                txtNumPedido.Text = Format(Now, "yyyyMM") & "01"
            Else
                txtNumPedido.Text = (MiComando2.ExecuteScalar() + 1).ToString
            End If


            conexion.Close()



        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try


        dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLista.MultiSelect = False

        Try

            '***Calcula catidad de acuerdo al redorden
            For i = 0 To dgvLista.Rows.Count - 1
                Dim cant As Integer = dgvLista.Rows(i).Cells(3).Value.ToString() / 0.15
                dgvLista.Rows(i).Cells(4).Value = cant.ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If Not dgvLista.CurrentRow.IsNewRow Then
            dgvLista.Rows.Remove(dgvLista.CurrentRow)
            If dgvLista.Rows.Count = 1 Then

            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            ' Obtenga referencia al DataTable
            Dim dt As DataTable = DirectCast(dgvLista.DataSource, DataTable)

            ' Cree una nueva fila
            Dim newRow As DataRow = dt.NewRow()

            ' Asigne valores a la fila (ajuste los nombres de columna según su DataTable)
            newRow("Cantidad") = 0
            newRow("Codigo") = TxtCodigo.Text
            newRow("Nombre") = TxtNombre.Text
            newRow("Existencia") = 0
            newRow("Reorden") = 0

            ' Agregue la fila al DataTable
            dt.Rows.Add(newRow)
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'GUARDAR DATOS
        If cboProveedor.SelectedItem = "0" Then
            MsgBox("Por favor sleccione un proveedor")
            Exit Sub
        End If
        Try
            Dim sentSQL As String
            sentSQL = "SELECT * from empleados where idempleado =" & idEmpActivo

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
            conexion.Open()


            Dim Miconsulta As New DataTable()
            Dim objadap As New OleDbDataAdapter(sentSQL, conexion)

            objadap.Fill(Miconsulta)

            If (Miconsulta.Rows.Count) = 0 Then
                ' NO hay registros coincidentes
                MessageBox.Show("El empleado con id " & idEmpActivo & " no existe. Verifique")
            Else
                NomEmpActivo = ""

                txtEmpleado.DataBindings.Add("text", Miconsulta, "Nombre")
                NomEmpActivo = txtEmpleado.Text
                txtEmpleado.DataBindings.Clear()

                txtEmpleado.DataBindings.Add("text", Miconsulta, "ApellidoP")
                NomEmpActivo = NomEmpActivo & " " & txtEmpleado.Text
                txtEmpleado.DataBindings.Clear()

                txtEmpleado.DataBindings.Add("text", Miconsulta, "ApellidoM")
                NomEmpActivo = NomEmpActivo & " " & txtEmpleado.Text
                txtEmpleado.DataBindings.Clear()

                txtEmpleado.Text = NomEmpActivo
            End If

            Dim SentSQLInsert As String

            SentSQLInsert = "Insert Into Pedidos (NumPedido, Fecha, Hora, Responsable, Proveedor, Estatus) VALUES (" & txtNumPedido.Text & ", #" & Format(Now, "yyyy-MM-dd") & "#, #" & Format(Now, "HH:mm") & "#, '" & NomEmpActivo.ToString & "', '" & cboProveedor.SelectedItem.ToString & "', 'Pendiente')"

            Dim comando As New OleDbCommand(SentSQLInsert, conexion)
            comando.ExecuteNonQuery()
            comando.Dispose()

            'Actualizar el campo existencia conforme a la operación que se hace en el load, esto aun no se hace, se hace en el formulario de recibir

            'Dim SentSQLUpdate As String
            'Dim j As Integer
            ' For j = 0 To dgvLista.Rows.Count - 2

            ''SentSQLUpdate = "Update Productos Set Existencia = " & dgvLista.Rows(j).Cells(0).Value & " Where Codigo=" & dgvLista.Rows(j).Cells(1).Value

            'Dim comando3 As New OleDbCommand(SentSQLUpdate, conexion)
            'comando3.ExecuteNonQuery()
            'comando3.Dispose()
            ' Next
            '*** guardar datos en la tabla detalle de pedidos
            Dim SentSQLInsert2 As String
            Dim i As Integer
            For i = 0 To dgvLista.Rows.Count - 2

                SentSQLInsert2 = "INSERT INTO [Detalle_Pedidos] (Codigo, Nombre, Cantidad, NumPedido) VALUES ('" & dgvLista.Rows(i).Cells(0).Value & "', '" & dgvLista.Rows(i).Cells(1).Value & "', " & dgvLista.Rows(i).Cells(4).Value & ", " & txtNumPedido.Text & ")"

                Dim comando2 As New OleDbCommand(SentSQLInsert2, conexion)
                comando2.ExecuteNonQuery()
                comando2.Dispose()
            Next


            MessageBox.Show("Los datos fueron guardados con exito", "Datos Guardados. . .")

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigo.TextChanged
        BtnAgregar.Enabled = True
        If TxtCodigo.Text = "" Then
            BtnAgregar.Enabled = False
        End If
    End Sub
End Class