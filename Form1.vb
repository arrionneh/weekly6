Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblHeading.Click

    End Sub

    Private Sub btnSpeed_Click(sender As Object, e As EventArgs) Handles btnSpeed.Click
        Dim strSpeed As String
        Dim decSpeed As Decimal
        Dim decSumofSpeeds As Decimal
        Dim decAverage As Decimal = 0D

        Dim strIBoxMsg As String = "Enter the # of Mbps of your home Internet speed user #"
        Dim strIBoxTitle As String = "Internet Speed"
        Dim strIBoxNumericErr As String = "Error - Enter the speed of your home Internet speed user #"
        Dim strErrMsg As String = "Error - Enter valid speed"

        Dim intMaxEntries As Integer = 10
        Dim intEntries As Integer = 1

        strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)

        Do Until intEntries > intMaxEntries Or strSpeed = ""
            If IsNumeric(strSpeed) Then
                decSpeed = Convert.ToDecimal(strSpeed)
                If decSpeed > 0 Then
                    lstSpeed.Items.Add(decSpeed)
                    decSumofSpeeds += decSpeed
                    intEntries += 1
                    strIBoxMsg = strIBoxMsg
                Else
                    strIBoxMsg = strErrMsg
                End If
            Else
                strIBoxMsg = strIBoxNumericErr
            End If
            If intEntries <= intMaxEntries Then
                strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)
            End If
        Loop

        lblAvg.Visible = True
        If intEntries > 1 Then
            decAverage = decSumofSpeeds / (intEntries - 1)
            lblAvg.Text = "Average Internet Speed: " & decAverage.ToString("F2") & " Mbps "
        Else
            lblAvg.Text = "No Speed Values Entered"
        End If

        btnSpeed.Enabled = False

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstSpeed.Items.Clear()
        lblAvg.Text = " "
        btnSpeed.Enabled = True
    End Sub
End Class
