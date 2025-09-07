<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibirProducto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvlista = New System.Windows.Forms.DataGridView()
        Me.btnRecibir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtNoPedido = New System.Windows.Forms.TextBox()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.txtProvedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNosurtir = New System.Windows.Forms.Button()
        CType(Me.dgvlista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvlista
        '
        Me.dgvlista.BackgroundColor = System.Drawing.Color.Olive
        Me.dgvlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlista.Location = New System.Drawing.Point(13, 132)
        Me.dgvlista.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvlista.Name = "dgvlista"
        Me.dgvlista.RowTemplate.Height = 24
        Me.dgvlista.Size = New System.Drawing.Size(800, 466)
        Me.dgvlista.TabIndex = 0
        '
        'btnRecibir
        '
        Me.btnRecibir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnRecibir.Location = New System.Drawing.Point(819, 293)
        Me.btnRecibir.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRecibir.Name = "btnRecibir"
        Me.btnRecibir.Size = New System.Drawing.Size(93, 46)
        Me.btnRecibir.TabIndex = 1
        Me.btnRecibir.Text = "Recibir"
        Me.btnRecibir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnGuardar.Location = New System.Drawing.Point(819, 409)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(93, 35)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtnBuscar.Location = New System.Drawing.Point(209, 3)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(76, 28)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtNoPedido
        '
        Me.TxtNoPedido.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoPedido.Location = New System.Drawing.Point(85, 3)
        Me.TxtNoPedido.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtNoPedido.Name = "TxtNoPedido"
        Me.TxtNoPedido.Size = New System.Drawing.Size(116, 26)
        Me.TxtNoPedido.TabIndex = 4
        '
        'txtResponsable
        '
        Me.txtResponsable.Enabled = False
        Me.txtResponsable.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsable.Location = New System.Drawing.Point(484, 5)
        Me.txtResponsable.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(116, 26)
        Me.txtResponsable.TabIndex = 5
        '
        'txtProvedor
        '
        Me.txtProvedor.Enabled = False
        Me.txtProvedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvedor.Location = New System.Drawing.Point(484, 42)
        Me.txtProvedor.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtProvedor.Name = "txtProvedor"
        Me.txtProvedor.Size = New System.Drawing.Size(116, 26)
        Me.txtProvedor.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "No. Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(396, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Responsable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(420, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Provedor"
        '
        'btnNosurtir
        '
        Me.btnNosurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnNosurtir.Location = New System.Drawing.Point(819, 345)
        Me.btnNosurtir.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnNosurtir.Name = "btnNosurtir"
        Me.btnNosurtir.Size = New System.Drawing.Size(93, 57)
        Me.btnNosurtir.TabIndex = 10
        Me.btnNosurtir.Text = "No surtido"
        Me.btnNosurtir.UseVisualStyleBackColor = True
        '
        'frmRecibirProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(920, 636)
        Me.Controls.Add(Me.btnNosurtir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProvedor)
        Me.Controls.Add(Me.txtResponsable)
        Me.Controls.Add(Me.TxtNoPedido)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnRecibir)
        Me.Controls.Add(Me.dgvlista)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ForeColor = System.Drawing.Color.OliveDrab
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmRecibirProducto"
        Me.Text = "Recibir Productos"
        CType(Me.dgvlista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvlista As System.Windows.Forms.DataGridView
    Friend WithEvents btnRecibir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtNoPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents txtProvedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNosurtir As System.Windows.Forms.Button
End Class
