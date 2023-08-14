Namespace DevExpress.CrmDemo.Win.Helpers
	Public Module DateTimeExtensions
		<System.Runtime.CompilerServices.Extension> _
		Public Function GetRelativeTimeString(ByVal ts As TimeSpan) As String
			Dim delta As Double = Math.Abs(ts.TotalSeconds)

            Const SECOND As Integer = 1
            Const MINUTE As Integer = 60 * SECOND
            Const HOUR As Integer = 60 * MINUTE
            Const DAY As Integer = 24 * HOUR
            Const MONTH As Integer = 30 * DAY

            If delta < 0 Then
                Return "not yet"
            End If
            If delta < 1 * MINUTE Then
                Return If(ts.Seconds = 1, "one second ago", ts.Seconds & " seconds ago")
            End If
            If delta < 2 * MINUTE Then
                Return "a minute ago"
            End If
            If delta < 45 * MINUTE Then
                Return ts.Minutes & " minutes ago"
            End If
            If delta < 90 * MINUTE Then
                Return "an hour ago"
            End If
            If delta < 24 * HOUR Then
                Return ts.Hours & " hours ago"
            End If
            If delta < 48 * HOUR Then
                Return "yesterday"
            End If
            If delta < 30 * DAY Then
                Return ts.Days & " days ago"
            End If
            If delta < 12 * MONTH Then
                Dim months As Integer = Convert.ToInt32(Math.Floor(CDbl(ts.Days) / 30))
                Return If(months <= 1, "one month ago", months & " months ago")
            Else
                Dim years As Integer = Convert.ToInt32(Math.Floor(CDbl(ts.Days) / 365))
                Return If(years <= 1, "one year ago", years & " years ago")
            End If
		End Function

		<System.Runtime.CompilerServices.Extension> _
		Public Function ToFiscalYear(ByVal [date] As Date) As Integer
			Dim fyStart As New Date([date].Year, 10, 1)

			Return If([date] >= fyStart, [date].Year + 1, [date].Year)
		End Function

		<System.Runtime.CompilerServices.Extension> _
		Public Function GetDateRangeString(ByVal date1 As Date, ByVal date2 As Date) As String
			Dim startDate As Date
			Dim endDate As Date

			date1 = date1.Date
			date2 = date2.Date

			Dim switchOrder As Boolean = date2 < date1

			startDate = If(switchOrder, date2, date1)
			endDate = If(switchOrder, date1, date2)

			' years are different
			If startDate.Year <> endDate.Year Then
				Return startDate.ToString("MMMM yyyy") & " - " & endDate.ToString("MMMM yyyy")
			End If

			' same year but different months
			If startDate.Month <> endDate.Month Then
				Return startDate.ToString("MMMM") & " - " & endDate.ToString("MMMM yyyy")
			End If

			' same year and month, but different days
			If startDate.Day <> endDate.Day Then
				Return startDate.ToString("MMMM d - ") + endDate.ToString("d, yyyy")
			End If

			' same year, month, day
			Return startDate.ToString("MMMM d, yyyy")
		End Function
	End Module
End Namespace
