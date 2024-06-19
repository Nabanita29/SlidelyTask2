Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer

    Public Sub New(submissions As List(Of Submission))
        InitializeComponent()
        Me.submissions = submissions
        currentIndex = 0
        DisplaySubmission()
    End Sub

    Private Sub DisplaySubmission()
        If submissions.Count = 0 Then Return
        Dim submission = submissions(currentIndex)
        TextBox1.Text = submission.Name
        TextBox2.Text = submission.Email
        TextBox3.Text = submission.Phone
        TextBox4.Text = submission.GitHubLink
        TextBox5.Text = submission.StopwatchTime
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
