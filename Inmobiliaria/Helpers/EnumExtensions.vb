Namespace DevExpress.CrmDemo.Win.Helpers
	Public Module EnumExtensions
		<System.Runtime.CompilerServices.Extension> _
		Public Function ToEnum(Of TEnum As Structure)(ByVal text As String, ByVal defaultValue As TEnum) As TEnum
			For Each name As String In System.Enum.GetNames(GetType(TEnum))
				If text = name Then
					Return CType(System.Enum.Parse(GetType(TEnum), text), TEnum)
				End If
			Next name
			Return defaultValue
		End Function
	End Module
End Namespace
