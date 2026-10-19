Imports System.IO
Imports System.Threading

Partial Public Class Form1
    Private Delegate Sub StatusUpdate(ByVal label1 As Label, ByVal statusText As String)

    Private probeOne As HostProbe
    Private probeTwo As HostProbe
    Private probeThree As HostProbe

    Public Sub ApplyStatus(ByVal label1 As Label, ByVal statusText As String)
        Try
            If statusText = "Online" Then
                label1.ForeColor = Color.DarkGreen
            End If
            If statusText = "Offline" Then
                label1.ForeColor = Color.Red
                Button1.Enabled = True
                Me.Focus()
                Me.BringToFront()
                Me.ShowInTaskbar = False
                Dim alarm As New Thread(AddressOf PlayOfflineAlarm)
                alarm.Start()
            End If
            label1.Text = statusText
        Catch ex As Exception
            System.Console.Write("fff")
        End Try
    End Sub

    Private Sub PlayOfflineAlarm()
        System.Console.Beep(700, 30000)
    End Sub

    Private Sub EnsureProbes()
        If probeOne Is Nothing Then
            probeOne = New HostProbe("www.boards.ie")
            probeTwo = New HostProbe("www.google.com")
            probeThree = New HostProbe("www.yahoo.com")
        End If
    End Sub

    Private Sub StartMonitoring()
        EnsureProbes()
        Button1.Enabled = False
        probeOne.Begin()
        probeTwo.Begin()
        probeThree.Begin()
        Dim check As New Thread(AddressOf WatchStatus)
        check.Start()
    End Sub

    Private Sub WatchStatus()
        Dim keepWatching As Integer = 1
        Dim statusText As String = "Online"
        While keepWatching > 0
            If Not probeOne.Running AndAlso Not probeTwo.Running AndAlso Not probeThree.Running Then
                keepWatching = -1
                statusText = "Offline"
            End If
            Thread.Sleep(1000)
            If Me.Label1.InvokeRequired Then
                Me.Label1.Invoke(New StatusUpdate(AddressOf ApplyStatus), New Object() {Label1, statusText})
            Else
                Me.ApplyStatus(Label1, statusText)
            End If
        End While
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartMonitoring()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        StartMonitoring()
    End Sub
End Class

Friend Class HostProbe
    Public Running As Boolean
    Private ReadOnly host As String

    Public Sub New(ByVal site As String)
        host = site
    End Sub

    Public Sub Begin()
        Running = True
        Dim worker As New Thread(AddressOf Watch)
        worker.Start()
    End Sub

    Public Sub Watch()
        While Running
            Dim output As String = PingHost(host)
            If output.Contains("timed") OrElse output.Contains("again") Then
                Running = False
            End If
        End While
    End Sub

    Private Function PingHost(ByVal site As String) As String
        Dim myProcess As Process = New Process()
        Dim output As String

        myProcess.StartInfo.FileName = "ping.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.Arguments = site
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.StartInfo.RedirectStandardError = True
        myProcess.Start()

        Dim standardInput As StreamWriter = myProcess.StandardInput
        standardInput.AutoFlush = True
        Dim standardOutput As StreamReader = myProcess.StandardOutput
        Dim standardError As StreamReader = myProcess.StandardError
        standardInput.Write("dir c:\windows\system32\*.com" & System.Environment.NewLine)
        standardInput.Write("exit" & System.Environment.NewLine)
        output = standardOutput.ReadToEnd()
        If Not myProcess.HasExited Then
            myProcess.Kill()
        End If
        standardInput.Close()
        standardOutput.Close()
        standardError.Close()
        myProcess.Close()
        Return output
    End Function
End Class
