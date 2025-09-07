Public Class frmMenuvb
    Private Sub RegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroToolStripMenuItem.Click
        frmRegistrarProductos.Show()
        Me.Close()
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        frmEditarProductosvb.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        frmEliminarProductos.Show()
        Me.Close()
    End Sub

    Private Sub ReporteDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasToolStripMenuItem.Click
        frmReportesVentas.Show()
        Me.Close()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.Click
        frmInventario.Show()
        Me.Close()
    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click
        frmRegistrarEmpleados.Show()
        Me.Close()
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click
        frmConsultaEmpleados.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        frmEliminarEmpleados.Show()
        Me.Close()
    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem1.Click
        frmEditorEmpleados.Show()
        Me.Close()
    End Sub

    Private Sub AsignarCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarCuentaToolStripMenuItem.Click
        frmAsignarCuenta.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem2.Click
        frmEliminarCuenta.Show()
        Me.Close()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        frmCambiarContraseña.Show()
        Me.Close()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmPedidos.Show()
        Me.Close()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        frmPedidos.Show()
        Me.Close()
    End Sub

    Private Sub RecibirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibirToolStripMenuItem.Click
        frmRecibirProducto.Show()
        Me.Close()
    End Sub
    Private Sub CancelarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem.Click
        frmCancelarPedido.Show()
        Me.Close()
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem.Click
        frmConsultaGeneralPedidos.Show()
        Me.Close()
    End Sub

    Private Sub PorMesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorMesToolStripMenuItem.Click
        frmConsultaPedidosMensual.Show()
        Me.Close()
    End Sub

    Private Sub PorEstatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorEstatusToolStripMenuItem.Click
        frmConsultaPedidosEstatus.Show()
        Me.Close()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class