Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()
    Public Shared submissions As New List(Of Submission)()

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
        UpdateStopwatchDisplay()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission As New Submission With {
            .Name = TextBox1.Text,
            .Email = TextBox2.Text,
            .Phone = TextBox3.Text,
            .GitHubLink = TextBox4.Text,
            .StopwatchTime = lblStopwatchTime.Text
        }
        ' Add the submission to the list
        submissions.Add(submission)
        ' Optionally, save to a file or database here
        ' Close the form after submission
        Me.Close()
    End Sub

    Private Sub UpdateStopwatchDisplay()
        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.T) Then
            btnToggleStopwatch.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
