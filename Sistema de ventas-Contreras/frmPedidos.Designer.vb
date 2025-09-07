<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Producto = New System.Windows.Forms.TextBox()
        Me.TxtExistencia = New System.Windows.Forms.TextBox()
        Me.txtReorden = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtNumPedido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnQuitar.Location = New System.Drawing.Point(667, 31)
        Me.btnQuitar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(88, 29)
        Me.btnQuitar.TabIndex = 2
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Enabled = False
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtnAgregar.Location = New System.Drawing.Point(464, 31)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(88, 31)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(341, 29)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(116, 26)
        Me.TxtCodigo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(337, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Insertar codigo "
        '
        'Producto
        '
        Me.Producto.Location = New System.Drawing.Point(246, 762)
        Me.Producto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Producto.Name = "Producto"
        Me.Producto.Size = New System.Drawing.Size(88, 21)
        Me.Producto.TabIndex = 6
        '
        'TxtExistencia
        '
        Me.TxtExistencia.Location = New System.Drawing.Point(338, 762)
        Me.TxtExistencia.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(88, 21)
        Me.TxtExistencia.TabIndex = 8
        '
        'txtReorden
        '
        Me.txtReorden.Location = New System.Drawing.Point(432, 762)
        Me.txtReorden.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtReorden.Name = "txtReorden"
        Me.txtReorden.Size = New System.Drawing.Size(88, 21)
        Me.txtReorden.TabIndex = 9
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtnGuardar.Location = New System.Drawing.Point(558, 31)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(104, 29)
        Me.BtnGuardar.TabIndex = 10
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'dgvLista
        '
        Me.dgvLista.BackgroundColor = System.Drawing.Color.Olive
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista.Location = New System.Drawing.Point(1, 65)
        Me.dgvLista.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.RowTemplate.Height = 24
        Me.dgvLista.Size = New System.Drawing.Size(992, 534)
        Me.dgvLista.TabIndex = 11
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(538, 762)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(12, 21)
        Me.txtCantidad.TabIndex = 12
        '
        'txtNumPedido
        '
        Me.txtNumPedido.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPedido.Location = New System.Drawing.Point(173, 29)
        Me.txtNumPedido.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNumPedido.Name = "txtNumPedido"
        Me.txtNumPedido.Size = New System.Drawing.Size(153, 26)
        Me.txtNumPedido.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(169, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Numero de pedido"
        '
        'TxtNombre
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(16, 30)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(114, 26)
        Me.TxtNombre.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(13, 5)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Insertar Nombre"
        '
        'cboProveedor
        '
        Me.cboProveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Items.AddRange(New Object() {"Sigma", "Capcom", "Profeco", "Int. Hall way"})
        Me.cboProveedor.Location = New System.Drawing.Point(774, 30)
        Me.cboProveedor.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(177, 26)
        Me.cboProveedor.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(770, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Proveedor"
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Location = New System.Drawing.Point(103, 808)
        Me.txtEmpleado.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(88, 21)
        Me.txtEmpleado.TabIndex = 19
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(1003, 609)
        Me.Controls.Add(Me.txtEmpleado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumPedido)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.dgvLista)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.txtReorden)
        Me.Controls.Add(Me.TxtExistencia)
        Me.Controls.Add(Me.Producto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ForeColor = System.Drawing.Color.OliveDrab
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmPedidos"
        Me.Text = "frmPedidos"
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Producto As System.Windows.Forms.TextBox
    Friend WithEvents TxtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents txtReorden As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtNumPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
End Class
