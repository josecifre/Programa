Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace DevExpress.CrmDemo.Win.Helpers

	Public Structure IconInfo
		Public fIcon As Boolean
		Public xHotspot As Integer
		Public yHotspot As Integer
		Public hbmMask As IntPtr
		Public hbmColor As IntPtr
	End Structure

	''' <summary>
	''' Wraps a custom cursor created from a bitmap.  Disposable to clean up unmanaged resource.
	''' </summary>
	Public Class CustomCursorWrapper
		Implements IDisposable

		#Region "Private constructor"
		Private Sub New(ByVal cursorPointer As IntPtr)
			Me.CursorPointer = cursorPointer
			Me.Cursor = New Cursor(cursorPointer)
		End Sub
		#End Region

		#Region "Public members"
		Private privateCursor As Cursor
		Public Property Cursor() As Cursor
			Get
				Return privateCursor
			End Get
			Private Set(ByVal value As Cursor)
				privateCursor = value
			End Set
		End Property

		Public Shared Function CreateFromBitmap(ByVal bitmap As Bitmap, ByVal point As Point) As CustomCursorWrapper
			If bitmap IsNot Nothing Then
				Dim canvas As Graphics = Graphics.FromImage(bitmap)
				canvas.Save()

				Dim iconInfo As New IconInfo()
				Dim pointer As IntPtr = bitmap.GetHicon()
				GetIconInfo(pointer, iconInfo)
				Dim cursorPointer_Renamed = CreateIconIndirect(iconInfo)

				' Clean up intermediary unmanaged resources
				'
				If iconInfo.hbmColor <> IntPtr.Zero Then
					DeleteObject(iconInfo.hbmColor)
				End If
				If iconInfo.hbmMask <> IntPtr.Zero Then
					DeleteObject(iconInfo.hbmMask)
				End If
				Return New CustomCursorWrapper(cursorPointer_Renamed)
			End If
			Return Nothing
		End Function

		Private Shared ReadOnly Property ArrowCursorImage() As Bitmap
			Get
				If _arrowCursorImage Is Nothing Then
					Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
					Using stream As Stream = myAssembly.GetManifestResourceStream(GetType(CustomCursorWrapper).Namespace & ".base_cursor.png")
						_arrowCursorImage = New Bitmap(stream)
					End Using
				End If
				Return _arrowCursorImage
			End Get
		End Property
		Private Shared _arrowCursorImage As Bitmap = Nothing
		#End Region

		#Region "PInvoke methods"
		<DllImport("user32.dll")> _
		Public Shared Function CreateIconIndirect(ByRef icon As IconInfo) As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function GetIconInfo(ByVal hIcon As IntPtr, ByRef pIconInfo As IconInfo) As <MarshalAs(UnmanagedType.Bool)> Boolean
		End Function

		<DllImport("gdi32.dll")> _
		Public Shared Function DeleteObject(ByVal handle As IntPtr) As Boolean
		End Function

		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Public Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
		End Function

		Private privateCursorPointer As IntPtr
		Private Property CursorPointer() As IntPtr
			Get
				Return privateCursorPointer
			End Get
			Set(ByVal value As IntPtr)
				privateCursorPointer = value
			End Set
		End Property
		#End Region

		#Region "IDisposable implementation"
		Private disposed As Boolean = False

		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
		End Sub

		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			' Check to see if Dispose has already been called.
			If Not Me.disposed Then
				If CursorPointer <> IntPtr.Zero Then
					DestroyIcon(CursorPointer)
					CursorPointer = IntPtr.Zero
					Me.Cursor = Nothing
				End If
				disposed = True
			End If
		End Sub

		Protected Overrides Sub Finalize()
			Dispose(False)
		End Sub
		#End Region
	End Class
End Namespace
