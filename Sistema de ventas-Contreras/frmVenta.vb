Imports System.Data
Imports System.Data.OleDb
Public Class frmVenta
    Public existe As Boolean
    Public Sub sumar()
        Dim S As Double = 0
        For i = 0 To dgvLista.Rows.Count - 2
            S += dgvLista.Rows(i).Cells(4).Value
        Next
        txtTotal.Text = S.ToString("0.00")
    End Sub
    Private Sub btnNuevaVenta_Click(sender As Object, e As EventArgs)
        dgvLista.Rows.Clear()
        txtCodigo.Clear()
        txtPrecio.Clear()
        txtTotal.Clear()
        nmuCantidad.Value = 1
        txtNumVenta.Clear()

        Try
            Dim sentSQL As String
            sentSQL = "slect max(NumVenta) as maximo from ventas"
            'sentSQL= "slect max(NumVenta) as maximo from ventas where txtNumVenta > " & Format(Now, "ddMMyyy") & "000"

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'No hay registros coincidentes.
                txtNumVenta.Text = "1"
                ' txtNumVenta = Format(Now, "ddMMyyy") & "000"
            Else
                txtNumVenta.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub
    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Obtener el nombre del usuario activo
            Dim sentSQL As String
            sentSQL = "SELECT * from empleados where idempleado =" & idEmpActivo

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

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

            'generar el numero de venta automaticamente
            sentSQL = "Select max(NumVenta) as maximo from ventas"
            'sentSQL= "Select max(NumVenta) as maximo from ventas where NumVenta > " & Format(Now, "ddMMyyy") & "000"
            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'No hay registros coincidentes.
                txtNumVenta.Text = "1"
                ' txtNumVenta = Format(Now, "ddMMyyy") & "000"
            Else
                txtNumVenta.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
        dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLista.MultiSelect = False
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AgregarFunc()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If IsAut = False Then
            frmIniciosesion.ShowDialog()
            IsAut = True
            quitarFunc()
        Else
            IsAut = True
            quitarFunc()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'GUARDAR DATOS
        Try
            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
            conexion.Open()

            '***guardar datos en la tabla ventas
            Dim SentSQLInsert As String

            SentSQLInsert = "Insert Into Ventas (NumVenta, Fecha, Hora, Quien, Total) VALUES (" & _txtNumVenta.Text & ", #" & Format(Now, "yyyy-MM-dd") & "#, #" & Format(Now, "HH:mm") & "#, '" & _txtEmpleado.Text & "', " & txtTotal.Text & ")"



            Dim comando As New OleDbCommand(SentSQLInsert, conexion)
            comando.ExecuteNonQuery()
            comando.Dispose()

            '*** guardar datos en la tabla detalle de ventas
            Dim SentSQLInsert2 As String
            Dim i As Integer
            For i = 0 To dgvLista.Rows.Count - 2

                SentSQLInsert2 = "INSERT INTO [Detalle_Ventas] (NumVenta, Codigo, Producto, Cantidad, Precio, Importe) VALUES (" & txtNumVenta.Text & ", '" & dgvLista.Rows(i).Cells(1).Value & "', '" & dgvLista.Rows(i).Cells(2).Value & "', " & dgvLista.Rows(i).Cells(0).Value & ", " & dgvLista.Rows(i).Cells(3).Value & ", " & dgvLista.Rows(i).Cells(4).Value & ")"

                Dim comando2 As New OleDbCommand(SentSQLInsert2, conexion)
                comando2.ExecuteNonQuery()
                comando2.Dispose()

            Next

            '*** descargar productos del inventario
            Dim SentSQLUpdate As String
            Dim j As Integer
            For j = 0 To dgvLista.Rows.Count - 2

                SentSQLUpdate = "Update Productos Set Existencia = existencia - " & dgvLista.Rows(j).Cells(0).Value & " Where Codigo=" & dgvLista.Rows(j).Cells(1).Value

                Dim comando3 As New OleDbCommand(SentSQLUpdate, conexion)
                comando3.ExecuteNonQuery()
                comando3.Dispose()
            Next
            MessageBox.Show("Los datos fueron guardados con exito", "Datos Guardados. . .")

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
        'GENERAR NUEVA LISTA
        dgvLista.Rows.Clear()
        txtCodigo.Clear()
        txtPrecio.Clear()
        txtTotal.Clear()
        nmuCantidad.Value = 1
        txtNumVenta.Clear()

        Try
            Dim sentSQL As String
            sentSQL = "slect max(NumVenta) as maximo from ventas"
            'sentSQL= "slect max(NumVenta) as maximo from ventas where txtNumVenta > " & Format(Now, "ddMMyyy") & "000"

            Dim conexion As New OleDbConnection()
            conexion.ConnectionString = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

            Dim MiComando As New OleDbCommand(sentSQL, conexion)

            conexion.Open()

            If IsDBNull(MiComando.ExecuteScalar()) = True Then
                'No hay registros coincidentes.
                txtNumVenta.Text = "1"
                ' txtNumVenta = Format(Now, "ddMMyyy") & "000"
            Else
                txtNumVenta.Text = (MiComando.ExecuteScalar() + 1).ToString
            End If

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hr As String

        hr = Format(Now, "HH")

        If Val(hr) < 12 Then
            LBLsaludo.Text = "Buenos dias le atiende"
        Else
            If Val(hr) > 18 Then
                LBLsaludo.Text = "Buenas noches le atiende"
            Else
                LBLsaludo.Text = "Buenas tarde le atiende"
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub

    Public Sub AgregarFunc()
        'buscar
        If txtCodigo.Text = "" Then
            MsgBox("falta Codigo")
            txtCodigo.Focus()
            Exit Sub
        End If
        Try
            Dim sentSQL As String
            sentSQL = "Select * from productos where codigo=" & txtCodigo.Text

            Dim conexion As New OleDbConnection
            conexion.ConnectionString = ("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta)

            Dim objDataSet As New DataSet()
            Dim objAdap As New OleDbDataAdapter(sentSQL, conexion)
            Dim MiConsulta As New DataTable

            txtProducto.Visible = True
            txtPrecio.Visible = True
            nmuCantidad.Visible = True

            'Consulta
            conexion.Open()
            objAdap.Fill(MiConsulta)
            If (MiConsulta.Rows.Count) = 0 Then
                'No hay registros
                MessageBox.Show("Articulo inexistente")
                existe = False
                txtProducto.Clear()
                txtPrecio.Clear()
                txtCodigo.Clear()
            Else
                'Enlazamos los controles TextBox con el objeto DataTable devuelto
                txtProducto.DataBindings.Add("text", MiConsulta, "Nombre")
                txtPrecio.DataBindings.Add("text", MiConsulta, "Precio")

                'Desenlazamos los controles TextBox
                txtProducto.DataBindings.Clear()
                txtPrecio.DataBindings.Clear()

                btnAgregar.Enabled = True

            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
        'termina de buscar

        If txtCodigo.Text = "" Then
            MsgBox("falta Codigo")
            txtCodigo.Focus()
            Exit Sub
        End If
        If txtProducto.Text = "" Then
            MsgBox("falta Producto")
            txtProducto.Focus()
            Exit Sub
        End If
        If txtPrecio.Text = "" Then
            MsgBox("falta Precio")
            txtPrecio.Focus()
            Exit Sub
        End If
        Dim importe As Integer
        'contar todas las filas

        Dim existedg As Boolean = False
        Dim S As Double
        S = 0
        For i = 0 To dgvLista.Rows.Count - 2
            S = S = +dgvLista.Rows(i).Cells(4).Value

            'verificar si esta en dl dg
            If dgvLista.Rows(i).Cells(1).Value.ToString = txtCodigo.Text.ToString Then
                existedg = True
            End If
            If existedg Then
                'sumar 1 al campo cantidad
                Dim cantidadactual As Integer = dgvLista.Rows(i).Cells(0).Value.ToString
                Dim sum As Integer = 1 + cantidadactual
                dgvLista.Rows(i).Cells(0).Value = sum.ToString

                'actualizar el campo importe
                Dim newval As Decimal = sum * Val(txtPrecio.Text.ToString)
                dgvLista.Rows(i).Cells(4).Value = newval.ToString()
                'actualizar el campo total YA FUNCIONA
                sumar()

                'Desactivar los textboxs y activar los botones como abajo 
                txtProducto.Visible = False
                txtPrecio.Visible = False
                nmuCantidad.Visible = False
                btnQuitar.Enabled = True
                btnGuardar.Enabled = True
                Exit Sub
            End If
        Next
        importe = Val(nmuCantidad.Value) * Val(txtPrecio.Text)

        dgvLista.Rows.Add(nmuCantidad.Value.ToString, txtCodigo.Text, txtProducto.Text, txtPrecio.Text, importe.ToString)

        sumar()
        'Desactivar los textboxs y activar los botones como arriba 
        btnQuitar.Enabled = True
        btnGuardar.Enabled = True

        txtProducto.Visible = False
        txtPrecio.Visible = False
        nmuCantidad.Visible = False
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Q Then
            If IsAut = False Then
                frmIniciosesion.ShowDialog()
                IsAut = True
                quitarFunc()
            Else
                IsAut = True
                quitarFunc()
            End If
        End If
        Return True
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub quitarFunc()
        If Not dgvLista.CurrentRow.IsNewRow Then
            dgvLista.Rows.Remove(dgvLista.CurrentRow)
            sumar()
            If dgvLista.Rows.Count = 1 Then
                btnQuitar.Enabled = False
                btnGuardar.Enabled = False
            End If
        End If
    End Sub
End Class