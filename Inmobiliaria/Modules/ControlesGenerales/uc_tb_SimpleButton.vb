Public Class uc_tb_SimpleButton
    Inherits DevExpress.XtraEditors.SimpleButton


    Sub New()


        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Appearance.BackColor = Color.White
        Me.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.Appearance.BorderColor = System.Drawing.Color.SteelBlue
    End Sub


End Class
