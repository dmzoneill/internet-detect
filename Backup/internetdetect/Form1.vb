
Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading


Public Class Form1
    Dim t1 As Boolean
    Dim t2 As Boolean
    Dim t3 As Boolean
    Delegate Sub changeText1ControlDelegate(ByVal label1 As Label, ByVal ret As String)

    Public Sub setdisplaytext1(ByVal label1 As Label, ByVal ret As String)
        Dim playFile As String = "error.wav"
        Try
            If ret = "Online" Then
                label1.ForeColor = Color.DarkGreen
            End If
            If ret = "Offline" Then
                label1.ForeColor = Color.Red
                Button1.Enabled = True
                Me.Focus()
                Me.BringToFront()
                Me.ShowInTaskbar = False

            End If
            label1.Text = ret

            If ret = "Offline" Then
                Dim ggg As New Threading.Thread(AddressOf fuck)
                ggg.Start()
            End If

        Catch ffff As Exception
            System.Console.Write("fff")
        End Try

    End Sub

    Private Sub fuck()
        System.Console.Beep(700, 30000)
    End Sub
    Private Sub firstsite()
        Dim site As String = "www.boards.ie"


        While t1 = True


            Dim myProcess As Process = New Process()
            Dim s As String

            myProcess.StartInfo.FileName = "ping.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.StartInfo.Arguments = site
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True
            myProcess.Start()
            Dim sIn As StreamWriter = myProcess.StandardInput
            sIn.AutoFlush = True

            Dim sOut As StreamReader = myProcess.StandardOutput
            Dim sErr As StreamReader = myProcess.StandardError
            sIn.Write("dir c:\windows\system32\*.com" & _
               System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()
            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If

            If s.Contains("timed") Then
                t1 = False
            End If
            If s.Contains("again") Then
                t1 = False
            End If

            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()
        End While

    End Sub

    Private Sub secondsite()
        Dim site As String = "www.google.com"


        While t2 = True


            Dim myProcess As Process = New Process()
            Dim s As String

            myProcess.StartInfo.FileName = "ping.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.StartInfo.Arguments = site
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True
            myProcess.Start()
            Dim sIn As StreamWriter = myProcess.StandardInput
            sIn.AutoFlush = True

            Dim sOut As StreamReader = myProcess.StandardOutput
            Dim sErr As StreamReader = myProcess.StandardError
            sIn.Write("dir c:\windows\system32\*.com" & _
               System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()
            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If

            If s.Contains("timed") Then
                t2 = False
            End If
            If s.Contains("again") Then
                t2 = False
            End If

            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()
        End While

    End Sub

    Private Sub thirdsite()
        Dim site As String = "www.yahoo.com"


        While t3 = True


            Dim myProcess As Process = New Process()
            Dim s As String

            myProcess.StartInfo.FileName = "ping.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.StartInfo.Arguments = site
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True
            myProcess.Start()
            Dim sIn As StreamWriter = myProcess.StandardInput
            sIn.AutoFlush = True

            Dim sOut As StreamReader = myProcess.StandardOutput
            Dim sErr As StreamReader = myProcess.StandardError
            sIn.Write("dir c:\windows\system32\*.com" & _
               System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()
            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If

            If s.Contains("timed") Then
                t3 = False
            End If
            If s.Contains("again") Then
                t3 = False
            End If
            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()
        End While


    End Sub

    Private Sub monitor()
        Dim x As Integer = 1
        Dim ret As String
        ret = "Online"
        While x > 0

            If t1 = False Then
                If t2 = False Then
                    If t3 = False Then
                        x = -1
                        ret = "Offline"
                    End If
                End If
            End If
            System.Threading.Thread.Sleep(1000)

            If Me.Label1.InvokeRequired Then
                Me.Label1.Invoke(New changeText1ControlDelegate(AddressOf setdisplaytext1), New Object() {Label1, ret})

            Else
                Me.setdisplaytext1(Label1, ret)
            End If

        End While

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        t1 = True
        t2 = True
        t3 = True
        Button1.Enabled = False

        Dim one As New Threading.Thread(AddressOf firstsite)
        one.Start()
        Dim two As New Threading.Thread(AddressOf secondsite)
        two.Start()
        Dim three As New Threading.Thread(AddressOf thirdsite)
        three.Start()
        Dim check As New Threading.Thread(AddressOf monitor)
        check.Start()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        t1 = True
        t2 = True
        t3 = True
        Button1.Enabled = False

        Dim one As New Threading.Thread(AddressOf firstsite)
        one.Start()
        Dim two As New Threading.Thread(AddressOf secondsite)
        two.Start()
        Dim three As New Threading.Thread(AddressOf thirdsite)
        three.Start()
        Dim check As New Threading.Thread(AddressOf monitor)
        check.Start()
    End Sub

End Class
