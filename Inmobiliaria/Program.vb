Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.Skins.Info
Imports DevExpress.UserSkins
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors

Friend NotInheritable Class Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Private Sub New()
    End Sub
    <STAThread()> _
    Shared Sub Main()
        SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()


        '  AppearanceObject.DefaultFont = New Font("Segoe UI", 8.25F)

        AppearanceObject.DefaultFont = New Font("Tahoma", 9, FontStyle.Bold)
        '   AppearanceObject.ControlAppearance.Font = New Font("Tahoma", 9, FontStyle.Bold)
        '     AppearanceDefault.Control.Font = New Font("Tahoma", 9, FontStyle.Bold)


      
        '    LabelControlAppearanceObject.DefaultFont = New Font("Tahoma", 7, FontStyle.Bold)

        'LabelControlAppearanceObject.ControlAppearance.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'Dim a As New LabelControlAppearanceObject
        'a.Font = New Font("Tahoma", 7, FontStyle.Bold)
        'a.DefaultFont = New Font("Tahoma", 7, FontStyle.Bold)

        ''AppearanceObjectEx.DefaultFont = New Font("Tahoma", 10, FontStyle.Bold)
        'AppearanceObjectEx.ControlAppearance.Font = New Font("Tahoma", 10, FontStyle.Bold)


        'LabelControl.Appearance.TextOptions.VAlignment()

        'Dim skinCreator As New SkinBlobXmlCreator("MetroBlack", "MetroBlackXAF.Win.", GetType(Program).Assembly, Nothing)
        'SkinManager.Default.RegisterSkin(skinCreator)
        'DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("MetroBlack")




        'Dim skinCreator As New SkinBlobXmlCreator("MetroBlack", "kuvik.SkinData.", GetType(Program).Assembly, Nothing)
        '    SkinManager.Default.RegisterSkin(skinCreator)
        ''  AsyncAdornerBootStrapper.RegisterLookAndFeel("MetroBlack", "SkinData.", GetType(Program).Assembly)
        'DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis")
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis")
        Dim demoCI As CultureInfo = CType(Application.CurrentCulture.Clone(), CultureInfo)
        demoCI.NumberFormat.CurrencySymbol = "€"
        '  SplashScreenManager.RegisterUserSkin(skinCreator)
        Application.CurrentCulture = demoCI
        Application.EnableVisualStyles()
        AddHandler Microsoft.Win32.SystemEvents.UserPreferenceChanged, AddressOf pp
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
         
        Application.SetCompatibleTextRenderingDefault(False)
        DataHelper.CreateWmiService()
        Application.Run(frmPrincipal)


    End Sub

    Shared Sub pp(sender As Object, e As Microsoft.Win32.UserPreferenceChangedEventArgs)

    End Sub
End Class

Friend Interface IMainForm
    Sub ShowHome(ByVal home As Home)
    Sub ShowAgent(ByVal agent As Agent)
End Interface

