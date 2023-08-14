Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Management
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.Utils
Imports DevExpress.Utils.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls


Imports System.Net.Security

Public Enum PropertyType
    <Description("Single Family Home")> _
    SingleFamilyHome
    <Description("Condo/Townhouse")> _
    Townhome
    <Description("Multi-Family Home")> _
    MultiFamilyHome
End Enum

Public Enum PropertyStatus
    <Description("New Construction")> _
    NewConstruction
    <Description("Foreclosures")> _
    Foreclosures
    <Description("Recently Sold")> _
    RecentlySold
End Enum

Public Class Home
    Private row As DataRow
    Private photo_Renamed, plan_Renamed As Image
    Private photos_Renamed As List(Of Image)
    Private features_Renamed As String
    Public Sub New(ByVal row As DataRow)
        Me.row = row
        features_Renamed = DataHelper.GetFeaturesFormat(String.Format("{0}", row("Features")))
        If Not (TypeOf row("Photo") Is DBNull) Then
            photo_Renamed = ByteImageConverter.FromByteArray(CType(row("Photo"), Byte()))
        End If
    End Sub
    Public ReadOnly Property ID() As Integer
        Get
            Return CInt(Fix(row("ID")))
        End Get
    End Property
    Public ReadOnly Property Address() As String
        Get
            Return String.Format("{0}", row("Address"))
        End Get
    End Property
    Public ReadOnly Property BathsString() As String
        Get
            Return String.Format("{0}", row("Baths"))
        End Get
    End Property
    Public ReadOnly Property BedsString() As String
        Get
            Return String.Format("{0}", row("Beds"))
        End Get
    End Property
    Public ReadOnly Property HouseSizeString() As String
        Get
            Return String.Format("{0:n0} Sq Ft", row("HouseSize"))
        End Get
    End Property
    Public ReadOnly Property Baths() As Short
        Get
            Return CShort(Fix(row("Baths")))
        End Get
    End Property
    Public ReadOnly Property Beds() As Short
        Get
            Return CShort(Fix(row("Beds")))
        End Get
    End Property
    Public ReadOnly Property HouseSize() As Double
        Get
            Return Convert.ToDouble(row("HouseSize"))
        End Get
    End Property
    Public ReadOnly Property LotSize() As String
        Get
            Return String.Format("{0} Acres", row("LotSize"))
        End Get
    End Property
    Public ReadOnly Property Price() As Decimal
        Get
            Return Convert.ToDecimal(row("Price"))
        End Get
    End Property
    Public ReadOnly Property PriceString() As String
        Get
            Return String.Format("{0:c0}", Price)
        End Get
    End Property
    Public ReadOnly Property YearBuilt() As String
        Get
            Return String.Format("{0}", row("YearBuilt"))
        End Get
    End Property
    Public ReadOnly Property Photo() As Image
        Get
            Return photo_Renamed
        End Get
    End Property
    Public ReadOnly Property Plan() As Image
        Get
            If plan_Renamed Is Nothing Then
                plan_Renamed = DataHelper.GetLayoutByID(ID)
            End If
            Return plan_Renamed
        End Get
    End Property
    Public ReadOnly Property Features() As String
        Get
            Return features_Renamed
        End Get
    End Property
    Public ReadOnly Property FeaturesString() As String
        Get
            Return String.Format("{0}", row("Features"))
        End Get
    End Property
    Public ReadOnly Property Type() As String
        Get
            Return DevExpress.Data.Mask.EnumHelper.GetEnumItemDisplayText(CType(row("Type"), PropertyType))
        End Get
    End Property
    Public ReadOnly Property Status() As String
        Get
            Return DevExpress.Data.Mask.EnumHelper.GetEnumItemDisplayText(CType(row("Status"), PropertyStatus))
        End Get
    End Property
    Public ReadOnly Property Photos() As List(Of Image)
        Get
            If photos_Renamed Is Nothing Then
                photos_Renamed = DataHelper.GetPhotos(Me)
            End If
            Return photos_Renamed
        End Get
    End Property
End Class

Public Class Agent
    Private person As DataRow
    Private photo_Renamed As Image
    Public Sub New(ByVal person As DataRow)
        Me.person = person
        If Not (TypeOf person("Photo") Is DBNull) Then
            photo_Renamed = ByteImageConverter.FromByteArray(CType(person("Photo"), Byte()))
        End If
    End Sub
    Public ReadOnly Property FirstName() As String
        Get
            Return String.Format("{0}", person("FirstName"))
        End Get
    End Property
    Public ReadOnly Property LastName() As String
        Get
            Return String.Format("{0}", person("LastName"))
        End Get
    End Property
    Public ReadOnly Property Phone() As String
        Get
            Return String.Format("{0}", person("Phone"))
        End Get
    End Property
    Public ReadOnly Property Photo() As Image
        Get
            Return photo_Renamed
        End Get
    End Property
    Public ReadOnly Property Email() As String
        Get
            Return String.Format("{0}", person("Email"))
        End Get
    End Property
    Public ReadOnly Property ID() As Integer
        Get
            Return CInt(Fix(person("ID")))
        End Get
    End Property
End Class

Public Class MortgageRate
    Private mortgageRate_Renamed As DataRow

    Public ReadOnly Property [Date]() As DateTime
        Get
            Return CDate(mortgageRate_Renamed("Date"))
        End Get
    End Property
    Public ReadOnly Property FRM30() As Double
        Get
            Return CDbl(mortgageRate_Renamed("FRM30"))
        End Get
    End Property
    Public ReadOnly Property FRM15() As Double
        Get
            Return CDbl(mortgageRate_Renamed("FRM15"))
        End Get
    End Property
    Public ReadOnly Property ARM1() As Double
        Get
            Return CDbl(mortgageRate_Renamed("ARM1"))
        End Get
    End Property

    Public Sub New(ByVal mortgageRate As DataRow)
        Me.mortgageRate_Renamed = mortgageRate
    End Sub
End Class

Public Class LoanPayment
    Private monthNumber_Renamed As Integer
    Private balance_Renamed, interest_Renamed, principal_Renamed As Double
    Private month_Renamed As DateTime
    Public Sub New(ByVal balance As Double, ByVal monthlyPayment As Double, ByVal month As Integer, ByVal interestRate As Double, ByVal startMonth As DateTime)
        Me.monthNumber_Renamed = month
        Me.month_Renamed = startMonth.AddMonths(month - 1)
        Me.interest_Renamed = Trunc2(balance * interestRate)
        Me.principal_Renamed = Trunc2(monthlyPayment - Me.interest_Renamed)
        Me.balance_Renamed = Trunc2(balance - Me.principal_Renamed)
    End Sub
    Public Sub UpdateBalance()
        If Me.balance_Renamed < 0 Then
            Me.principal_Renamed += Me.balance_Renamed
        End If
        Me.balance_Renamed = 0
    End Sub

    Public ReadOnly Property Month() As DateTime
        Get
            Return month_Renamed
        End Get
    End Property
    Public ReadOnly Property MonthNumber() As Integer
        Get
            Return monthNumber_Renamed
        End Get
    End Property
    Public ReadOnly Property MonthlyPayment() As Double
        Get
            Return Interest + Principal
        End Get
    End Property
    Public ReadOnly Property Balance() As Double
        Get
            Return balance_Renamed
        End Get
    End Property
    Public ReadOnly Property Interest() As Double
        Get
            Return interest_Renamed
        End Get
    End Property
    Public ReadOnly Property Principal() As Double
        Get
            Return principal_Renamed
        End Get
    End Property
    Public ReadOnly Property MonthString() As String
        Get
            Return String.Format("{0}<size=-2> ({1:MMMM, yyyy})", MonthNumber, Month)
        End Get
    End Property
    Public Shared Function Trunc2(ByVal val As Double) As Double
        Return Convert.ToDouble(Convert.ToInt64(val * 100)) / 100
    End Function
    Public Shared Function Calculate(ByVal loanAmount As Double, ByVal interestRate As Double, ByVal months As Double, ByVal startMonth As DateTime, <System.Runtime.InteropServices.Out()> ByRef payment As Double) As List(Of LoanPayment)
        payment = (loanAmount * interestRate) / (1 - Math.Exp((-months) * Math.Log(1 + interestRate)))
        payment = LoanPayment.Trunc2(payment)
        Dim payments As New List(Of LoanPayment)()
        Dim balance As Double = loanAmount
        For i As Integer = 1 To Convert.ToInt32(months)
            Dim lp As New LoanPayment(balance, payment, i, interestRate, startMonth)
            balance = lp.Balance
            payments.Add(lp)
            If lp.Balance <= 0 Then
                Exit For
            End If
        Next i
        payments(payments.Count - 1).UpdateBalance()
        Return payments
    End Function
    Public Shared Sub InitStartMonth(ByVal edit As ImageComboBoxEdit)
        Dim start As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        For i As Integer = 1 To 6
            edit.Properties.Items.Add(New ImageComboBoxItem(String.Format("{0:MMMM, yyyy}", start.AddMonths(i)), start.AddMonths(i), -1))
        Next i
        edit.SelectedIndex = 0
    End Sub
    Public Shared Sub InitTermOfLoan(ByVal edit As ImageComboBoxEdit)
        Dim terms() As Integer = {1, 5, 10, 15, 20, 25, 30}
        For Each term As Integer In terms
            edit.Properties.Items.Add(New ImageComboBoxItem(String.Format("{0} year{1}", term, If(term = 1, String.Empty, "s")), term, -1))
        Next term
        edit.SelectedIndex = 3
    End Sub
    Public Shared Sub InitInterestRateData(ByVal edit As ImageComboBoxEdit)
        For i As Double = 2.5 To 14 Step 0.125
            edit.Properties.Items.Add(New ImageComboBoxItem(String.Format("{0:n3} %", i), i, -1))
        Next i
        edit.SelectedIndex = 25
    End Sub
    Public Shared Function GetMonthString(ByVal month As Integer, ByVal data As List(Of LoanPayment)) As String
        For Each payment As LoanPayment In data
            If payment.MonthNumber.Equals(month) Then
                Return StringPainter.Default.RemoveFormat(payment.MonthString)
            End If
        Next payment
        Return String.Empty
    End Function
End Class

Public Class PaymentTypeSum
    Private interestSum_Renamed As Double = 0
    Private principalSum_Renamed As Double = 0
    Public Sub New()
        interestSum_Renamed = 0
        principalSum_Renamed = 0
    End Sub
    Public ReadOnly Property InterestSum() As Double
        Get
            Return interestSum_Renamed
        End Get
    End Property
    Public ReadOnly Property PrincipalSum() As Double
        Get
            Return principalSum_Renamed
        End Get
    End Property
    Public Sub AddToSum(ByVal value1 As Double, ByVal value2 As Double)
        interestSum_Renamed += value1
        principalSum_Renamed += value2
    End Sub
End Class

Public Class AppConst
    Public Const TileSize As Integer = 170
    Public Shared ReadOnly Property HtmlInformationColor() As String
        Get
            Dim color As Color = CommonColors.GetInformationColor(DevExpress.LookAndFeel.UserLookAndFeel.Default)
            Return GetRGBColor(color)
        End Get
    End Property
    Public Shared ReadOnly Property HtmlHighlightTextColor() As String
        Get
            Dim color As Color = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("HighlightText")
            Return GetRGBColor(color)
        End Get
    End Property
    Public Shared ReadOnly Property HtmlTextColor() As String
        Get
            Dim color As Color = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("WindowText")
            Return GetRGBColorHighlight(color)
        End Get
    End Property
    Public Shared ReadOnly Property HtmlWindowTextColor() As String
        Get
            Dim color As Color = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors.GetColor("WindowText")
            Return GetRGBColor(color)
        End Get
    End Property
    Private Shared Function GetRGBColor(ByVal color As Color) As String
        Return String.Format("{0},{1},{2}", color.R, color.G, color.B)
    End Function
    Private Shared Function GetRGBColorHighlight(ByVal color As Color) As String
        Return String.Format("{0},{1},{2}", GetHighlight(color.R), GetHighlight(color.G), GetHighlight(color.B))
    End Function

    Private Shared Function GetHighlight(ByVal p As Byte) As Byte
        Dim ret As Integer = p - 50
        If ret < 0 Then
            ret = 0
        End If
        Return CByte(ret)
    End Function
End Class

Public Class DataHelper
    Private Shared worker As New BackgroundWorker()
    Private Shared wmiService_Renamed As WMIService
    Private Shared photos As DataTable
    Private Shared housesSales As DataTable
    Private Shared homes_Renamed As List(Of Home) = Nothing
    Private Shared agents_Renamed As List(Of Agent) = Nothing
    Private Shared mortgageRates_Renamed As List(Of MortgageRate) = Nothing
    Private Shared ReadOnly Property PhotosTable() As DataTable
        Get
            If photos Is Nothing Then
                Dim temp As New DataSet()
                temp.ReadXml(FilesHelper.FindingFileName(Application.StartupPath, "Data\HomePhotos.xml", False))
                photos = temp.Tables(0)
            End If
            Return photos
        End Get
    End Property
    Private Shared Function GetMortgageRatesTable() As DataTable
        Dim temp As New DataSet()
        temp.ReadXml(DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\Mortgage.xml"))
        Return temp.Tables(0)
    End Function
    Public Shared Function GetHousesSalesTable() As DataTable
        If housesSales Is Nothing Then
            Dim temp As New DataSet()
            temp.ReadXml(FilesHelper.FindingFileName(Application.StartupPath, "Data\HousesSales.xml", False))
            housesSales = temp.Tables(0)
        End If
        Return housesSales
    End Function
    Public Shared ReadOnly Property Homes() As List(Of Home)
        Get
            If homes_Renamed Is Nothing Then
                homes_Renamed = GetHomes()
            End If
            Return homes_Renamed
        End Get
    End Property
    Public Shared ReadOnly Property Agents() As List(Of Agent)
        Get
            If agents_Renamed Is Nothing Then
                agents_Renamed = GetAgents()
            End If
            Return agents_Renamed
        End Get
    End Property
    Public Shared ReadOnly Property MortgageRates() As List(Of MortgageRate)
        Get
            If mortgageRates_Renamed Is Nothing Then
                mortgageRates_Renamed = GetMortgageRates()
            End If
            Return mortgageRates_Renamed
        End Get
    End Property
    Friend Shared Function GetPhotos(ByVal home As Home) As List(Of Image)
        Dim ret As New List(Of Image)()
        ret.Add(home.Photo)
        For Each row As DataRow In PhotosTable.Rows
            Dim id As Integer = home.ID Mod 7 + 1
            If id.Equals(row("ParentID")) Then
                ret.Add(ByteImageConverter.FromByteArray(CType(row("Photo"), Byte())))
            End If
        Next row
        Return ret
    End Function
    Public Shared Function GetLayoutByID(ByVal ID As Integer) As Image
        Dim imageName As String = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, String.Format("Data\Images\HomePlan{0}.jpg", ID Mod 5 + 1), False)
        Return If(imageName <> String.Empty, Image.FromFile(imageName), Nothing)
    End Function
    Private Shared Function GetHomes() As List(Of Home)
        Dim ret As New List(Of Home)()
        Dim temp As New DataSet()
        Dim dbName As String = FilesHelper.FindingFileName(Application.StartupPath, "Data\Homes.xml")
        If String.IsNullOrEmpty(dbName) Then
            Return ret
        End If
        temp.ReadXml(dbName)
        For Each row As DataRow In temp.Tables("Homes").Rows
            ret.Add(New Home(row))
        Next row
        Return ret
    End Function
    Private Shared Function GetAgents() As List(Of Agent)
        Dim ret As New List(Of Agent)()
        Dim temp As New DataSet()
        Dim dbName As String = FilesHelper.FindingFileName(Application.StartupPath, "Data\Homes.xml", False)
        If String.IsNullOrEmpty(dbName) Then
            Return ret
        End If
        temp.ReadXml(dbName)
        For Each row As DataRow In temp.Tables("Agents").Rows
            ret.Add(New Agent(row))
        Next row
        Return ret
    End Function
    Private Shared Function GetMortgageRates() As List(Of MortgageRate)
        Dim table As DataTable = GetMortgageRatesTable()
        Dim rates As New List(Of MortgageRate)()
        For Each row As DataRow In table.Rows
            rates.Add(New MortgageRate(row))
        Next row
        Return rates
    End Function
    Public Shared Function GetFeaturesFormat(ByVal text As String) As String
        Dim features() As String = text.Split(","c)
        Dim ret As String = String.Empty
        For Each feature As String In features
            ret &= String.Format("• {0}" & Constants.vbCrLf, feature.Trim())
        Next feature
        Return ret
    End Function
    Public Shared Sub InitListingsTile(ByVal tile As ITileItem)
        Dim animateText As Boolean = True
        For Each home As Home In DataHelper.Homes
            animateText = True
            For Each photo As Image In home.Photos
                Dim info As New TileItemFrame()
                info.AnimateBackgroundImage = True
                info.UseBackgroundImage = True
                info.BackgroundImage = photo
                info.AnimateText = animateText
                info.UseText = True
                info.Text2 = String.Format("<backcolor=108,189,69> {0} Beds   <br> {1} Baths  ", home.BedsString, home.BathsString)
                info.Text3 = String.Format("<backcolor=108,189,69><size=+3> {0} ", home.PriceString)
                info.Tag = home
                animateText = False
                tile.Frames.Add(info)
            Next photo
        Next home
    End Sub
    Public Shared Sub InitAgentsTile(ByVal tile As ITileItem, ByVal size As Integer)
        tile.Properties.FrameAnimationInterval = 5100
        tile.Properties.BackgroundImageAlignment = TileItemContentAlignment.MiddleRight
        tile.Properties.BackgroundImageScaleMode = TileItemImageScaleMode.NoScale

        For Each agent As Agent In DataHelper.Agents
            Dim info As New TileItemFrame()
            info.AnimateBackgroundImage = True
            info.UseBackgroundImage = True
            info.BackgroundImage = GetScaleImage(agent.Photo, 90)

            info.AnimateText = True
            info.UseText = True
            info.Text = String.Format("<size=+4>{0} {1}</size><br>{2}", agent.FirstName, agent.LastName, agent.Phone)
            info.Tag = agent
            tile.Frames.Add(info)
        Next agent
    End Sub
    Public Shared Sub InitDocumentosClienteTile(ByVal tile As ITileItem, ByVal size As Integer)
        tile.Properties.FrameAnimationInterval = 5100
        tile.Properties.BackgroundImageAlignment = TileItemContentAlignment.MiddleRight
        tile.Properties.BackgroundImageScaleMode = TileItemImageScaleMode.NoScale
        tile.Properties.IsLarge = False

        '   For Each agent As Agent In DataHelper.Agents
        Dim info As New TileItemFrame()

        ''CLIENTES
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True
        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.Clientes, 90)
        info.AnimateText = True
        info.UseText = True
        info.Text = String.Format("<size=+4>{0}  ", "Ventas")
        info.Text4 = String.Format("<size=+3>{0} ", "Clientes")
        ' info.Text = String.Format("<size=+4>{0} {1}</size><br>{2}", agent.FirstName, agent.LastName, agent.Phone)
        ' info.Tag = agent
        tile.Frames.Add(info)


        ''ARTICULOS
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True
        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.Articulos, 100)
        info.AnimateText = True
        info.UseText = True
        info.Text = String.Format("<size=+4>{0}  ", "Ventas")
        info.Text4 = String.Format("<size=+3>{0} ", "Artículos")
        tile.Frames.Add(info)



        ' Next agent
    End Sub

    Public Shared Sub InitOpcionesFacturacionTile(ByVal tile As ITileItem, ByVal size As Integer)

        tile.Properties.FrameAnimationInterval = 2100
        tile.Elements(0).TextAlignment = TileItemContentAlignment.MiddleCenter
        tile.Elements(0).ImageAlignment = TileItemContentAlignment.MiddleCenter
        tile.Elements(0).ImageToTextAlignment = TileControlImageToTextAlignment.Top

        '  tile.Properties.BackgroundImageAlignment = TileItemContentAlignment.TopCenter
        'tile.Properties.BackgroundImageScaleMode = TileItemImageScaleMode.NoScale
        'tile.Elements(0).TextAlignment = TileItemContentAlignment.BottomCenter
        'tile.Elements(0).ImageAlignment = TileItemContentAlignment.MiddleCenter

        ' For Each agent As Agent In DataHelper.Agents
        Dim info As New TileItemFrame()

        'FAMILIAS
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True

        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.Familias, 100)

        info.AnimateText = True
        info.UseText = True
        ' info.Text = String.Format("<size=+4>{0} {1}</size><br>{2}", "Tablas Auxiliares", "Familias", Agent.Phone)
        info.Text4 = String.Format("<size=+3>{0}</size> <br>{1}", "Familias", "Tablas Generales")
        ' info.Tag = Agent
        tile.Frames.Add(info)


        'FORMAS DE PAGO
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True
        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.FormasPago, 100)
        info.AnimateText = True
        info.UseText = True
        info.Text4 = String.Format("<size=+3>{0}</size> <br>{1}", "Formas de Pago", "Tablas Generales")
        tile.Frames.Add(info)

        'ALMACENES
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True
        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.Almacenes, 100)
        info.AnimateText = True
        info.UseText = True
        info.Text4 = String.Format("<size=+3>{0}</size> <br>{1}", "Almacenes", "Tablas Generales")
        tile.Frames.Add(info)

        'Marcas
        info = New TileItemFrame()
        info.AnimateBackgroundImage = True
        info.UseBackgroundImage = True
        info.BackgroundImage = GetScaleImage(My.Resources.Marcas, 100)
        info.AnimateText = True
        info.UseText = True
        info.Text4 = String.Format("<size=+3>{0}</size> <br>{1}", "Marcas", "Tablas Generales")
        tile.Frames.Add(info)

        '  Next agent
    End Sub
    Public Shared Function GetScaleImage(ByVal image As Image, ByVal percent As Integer) As Bitmap
        Return New Bitmap(image, image.Width * percent \ 100, image.Height * percent \ 100)
    End Function
    Public Shared Sub InitZillowTile(ByVal tile As ITileItem)
        Dim info As New TileItemFrame()
        info.AnimateImage = True
        info.AnimateText = True
        info.UseImage = True
        info.UseText = True
        info.Image = My.Resources.Albaranes
        info.Text = String.Empty
        tile.Frames.Add(info)
        info = New TileItemFrame()
        info.AnimateText = True
        info.AnimateImage = True
        info.Image = Nothing
        info.Text = "<size=+2>Your <b>Edge</b> in <b>Real Estate</b>"
        info.UseImage = True
        info.UseText = True
        tile.Frames.Add(info)
    End Sub
    Public Shared Function GetHomesByAgent(ByVal agent As Agent) As List(Of Home)
        Dim ret As New List(Of Home)()
        For Each home As Home In Homes
            If (home.ID Mod Agents.Count + 1) = agent.ID Then
                ret.Add(home)
            End If
        Next home
        Return ret
    End Function
    Public Shared Function GetAgentByHome(ByVal home As Home) As Agent
        For Each agent As Agent In Agents
            If (home.ID Mod Agents.Count + 1) = agent.ID Then
                Return agent
            End If
        Next agent
        Return Nothing
    End Function
    Public Shared ReadOnly Property WmiService() As WMIService
        Get
            CreateWmiService()
            Return wmiService_Renamed
        End Get
    End Property
    Friend Shared Sub CreateWmiService()
        If wmiService_Renamed Is Nothing Then
            AddHandler worker.DoWork, AddressOf worker_DoWork
            worker.RunWorkerAsync()
        End If
    End Sub

    Private Shared Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        wmiService_Renamed = WmiService.GetInstance(Nothing)
    End Sub
    Public Shared Sub SetTileSelectedItem(ByVal current As Object, ByVal control As TileControl)
        For Each item As TileItem In control.Groups(0).Items
            If current.Equals(item.Tag) Then
                control.SelectedItem = item
                Exit For
            End If
        Next item
    End Sub
End Class
Public NotInheritable Class WMIService
    Implements IDisposable
    Public Shared Function GetInstance(ByVal path As String) As WMIService
        Return New WMIService(If(String.IsNullOrEmpty(path), "//./root/cimv2", path))
    End Function

    Private connectedCore As Boolean = False
    Private scopeCore As ManagementScope
    Private queryCacheCore As Dictionary(Of String, ManagementObjectCollection)

    Private ReadOnly Property QueryCache() As Dictionary(Of String, ManagementObjectCollection)
        Get
            Return queryCacheCore
        End Get
    End Property
    Public ReadOnly Property Connected() As Boolean
        Get
            Return connectedCore
        End Get
    End Property
    Public ReadOnly Property Scope() As ManagementScope
        Get
            Return scopeCore
        End Get
    End Property

    Private Sub New(ByVal path As String)
        queryCacheCore = New Dictionary(Of String, ManagementObjectCollection)()
        Dim options As New ConnectionOptions()
        options.Impersonation = ImpersonationLevel.Impersonate
        options.Authentication = System.Management.AuthenticationLevel.Packet
        Me.scopeCore = New ManagementScope(path, options)
        Try
            Scope.Connect()
            connectedCore = Scope.IsConnected
        Catch
            connectedCore = False
        End Try
    End Sub
    Private Function GetManagementObjectCollection(ByVal queryString As String) As ManagementObjectCollection
        Dim result As ManagementObjectCollection = Nothing
        Dim query As New ObjectQuery(queryString)
        Using searcher As New ManagementObjectSearcher(Scope, query)
            result = searcher.Get()
        End Using
        Return result
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        connectedCore = False
        If queryCacheCore IsNot Nothing Then
            For Each pair As KeyValuePair(Of String, ManagementObjectCollection) In queryCacheCore
                If pair.Value IsNot Nothing Then
                    pair.Value.Dispose()
                End If
            Next pair
            queryCacheCore.Clear()
            queryCacheCore = Nothing
        End If
        scopeCore = Nothing
    End Sub
    Public Function GetObjectCollection(ByVal queryString As String, ByVal allowQueryCaching As Boolean) As ManagementObjectCollection
        Dim result As ManagementObjectCollection = Nothing
        If allowQueryCaching Then
            QueryCache.TryGetValue(queryString, result)
        End If
        If result Is Nothing Then
            result = GetManagementObjectCollection(queryString)
            If allowQueryCaching Then
                If QueryCache.ContainsKey(queryString) Then
                    QueryCache(queryString) = result
                Else
                    QueryCache.Add(queryString, result)
                End If
            End If
        End If
        Return result
    End Function
    Public Function GetObjects(ByVal queryString As String, ByVal allowQueryCaching As Boolean) As ManagementObject()
        Dim result(-1) As ManagementObject
        Dim collection As ManagementObjectCollection = GetObjectCollection(queryString, allowQueryCaching)
        If collection IsNot Nothing AndAlso collection.Count > 0 Then
            result = New ManagementObject(collection.Count - 1) {}
            collection.CopyTo(result, 0)
        End If
        Return result
    End Function
End Class

