Imports Microsoft.Win32
Imports System.IO
Imports System.Net
Public Class MainForm
    Dim thread1 As System.Threading.Thread
    Dim thread2 As System.Threading.Thread
    Dim thread3 As System.Threading.Thread
    Dim thread4 As System.Threading.Thread
    Dim thread6 As System.Threading.Thread
    Dim thread7 As System.Threading.Thread
    Dim thread8 As System.Threading.Thread
    Dim thread9 As System.Threading.Thread
    Dim thread10 As System.Threading.Thread
    Dim thread11 As System.Threading.Thread
    Dim thread12 As System.Threading.Thread
    Dim prefetchFiles As List(Of String) = New List(Of String)
    Dim archiveTempFiles As List(Of String) = New List(Of String)
    Dim tempFiles As List(Of String) = New List(Of String)
    Dim installCacheFiles As List(Of String) = New List(Of String)
    Dim windowsLogsFiles As List(Of String) = New List(Of String)
    Dim steamLogsFiles As List(Of String) = New List(Of String)
    Dim minecraftLogsFiles As List(Of String) = New List(Of String)
    Dim fontCacheFiles As List(Of String) = New List(Of String)
    Dim localLowFiles As List(Of String) = New List(Of String)
    Dim browserCacheFiles As List(Of String) = New List(Of String)
    Dim internetCacheFiles As List(Of String) = New List(Of String)
    Dim softwareDistributionFiles As List(Of String) = New List(Of String)
    Dim clrFiles As List(Of String) = New List(Of String)
    Dim crashDumpsFiles As List(Of String) = New List(Of String)
    Dim reportArchiveFiles As List(Of String) = New List(Of String)
    Dim kernelReportsFiles As List(Of String) = New List(Of String)
    Dim thumbnailCacheFiles As List(Of String) = New List(Of String)
    Dim downloadFolderFiles As List(Of String) = New List(Of String)
    Dim IISLogsFiles As List(Of String) = New List(Of String)
    Dim desktopShortcutsFiles As List(Of String) = New List(Of String)
    Dim memoryDumpsFiles As List(Of String) = New List(Of String)
    Dim chkDskFileFragments As List(Of String) = New List(Of String)
    Dim applicationsTempFiles As List(Of String) = New List(Of String)
    Private Declare Function SHEmptyRecycleBin Lib "shell32.dll" Alias "SHEmptyRecycleBinA" (ByVal hWnd As Int32, ByVal pszRootPath As String, ByVal dwFlags As Int32) As Int32
    Private Declare Function SHUpdateRecycleBinIcon Lib "shell32.dll" () As Int32
    Private Const SHERB_NOCONFIRMATION = &H1
    Private Const SHERB_NOSOUND = &H4
    Dim actualSize As Long = 0
    Private amd64 As Boolean = Environment.Is64BitOperatingSystem
    Dim PcList As New List(Of PerformanceCounter)
    Dim HddList As New List(Of PerformanceCounter)
    Dim cpuPerformanceCounter As PerformanceCounter
    Dim processorName As String
    Dim antiAdwareHosts As String
    Dim foundMalwares As List(Of String) = New List(Of String)
    Dim cleanedMalwares As Long = 0
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H80
            Return cp
        End Get
    End Property
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime
        Me.CheckForIllegalCrossThreadCalls = False
        AdaptSize.Start()
        MetroTabControl1.SelectedIndex = 0
        If Not System.IO.Directory.Exists("C:\ZeroCleaner") Then
            System.IO.Directory.CreateDirectory("C:\ZeroCleaner")
        End If
        If Not System.IO.File.Exists("C:\ZeroCleaner\restore_point.txt") Then
            System.IO.File.WriteAllText("C:\ZeroCleaner\restore_point.txt", 0)
        End If
        RefreshDrives()
        If System.IO.File.Exists("C:\ZeroCleaner\process_names.txt") Then
            Dim processNames As String = System.IO.File.ReadAllText("C:\ZeroCleaner\process_names.txt")
            If Not processNames.Replace(Environment.NewLine, "").Replace(" ", "") = "" Then
                If Not processNames.Contains(Environment.NewLine) Then
                    ListBox1.Items.Add(processNames)
                Else
                    Dim splitter() As String = Split(processNames, Environment.NewLine)
                    For i = 0 To splitter.Count - 1
                        ListBox1.Items.Add(splitter(i))
                    Next
                End If
            End If
        End If
        If System.IO.File.Exists("C:\ZeroCleaner\process_windows.txt") Then
            Dim processWindows As String = System.IO.File.ReadAllText("C:\ZeroCleaner\process_windows.txt")
            If Not processWindows.Replace(Environment.NewLine, "").Replace(" ", "") = "" Then
                If Not processWindows.Contains(Environment.NewLine) Then
                    ListBox2.Items.Add(processWindows)
                Else
                    Dim splitter() As String = Split(processWindows, Environment.NewLine)
                    For i = 0 To splitter.Count - 1
                        ListBox2.Items.Add(splitter(i))
                    Next
                End If
            End If
        End If
        Dim webClient As New WebClient
        antiAdwareHosts = webClient.DownloadString("https://www.someonewhocares.org/hosts/hosts")
    End Sub
    Private Sub MetroButton1_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton1.MouseLeave
        GroupBox1.Select()
    End Sub
    Private Sub MetroButton2_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton2.MouseLeave
        GroupBox2.Select()
    End Sub
    Private Sub MetroCheckBox1_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox1.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox2_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox2.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox3_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox3.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox4_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox4.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox5_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox5.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox6_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox6.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox7_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox7.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox8_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox8.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox9_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox9.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox10_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox10.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox11_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox11.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox12_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox12.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox13_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox13.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox14_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox14.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox15_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox15.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox16_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox16.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox17_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox17.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox18_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox18.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox19_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox19.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox20_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox20.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox21_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox21.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox22_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox22.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox23_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox23.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox24_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox24.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox25_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox25.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox26_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox26.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox27_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox27.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox28_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox28.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox29_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox29.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox30_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox30.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox31_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox31.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox32_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox32.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox33_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox33.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox34_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox34.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox35_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox35.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox36_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox36.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox37_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox37.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox38_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox38.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox39_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox39.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox40_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox40.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox41_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox41.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox42_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox42.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox43_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox43.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox44_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox44.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox45_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox45.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox46_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox46.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox47_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox47.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox48_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox48.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox49_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox49.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox50_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox50.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox51_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox51.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox52_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox52.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox53_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox53.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox54_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox54.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox55_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox55.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox56_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox56.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox57_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox57.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox58_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox58.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox59_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox59.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox60_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox60.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox61_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox61.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox62_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox62.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox63_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox63.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox64_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox64.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox65_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox65.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox66_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox66.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox67_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox67.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox68_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox68.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox69_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox69.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox70_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox70.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox71_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox71.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox72_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox72.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox73_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox73.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox74_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox74.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox75_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox75.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox76_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox76.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox77_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox77.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox78_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox78.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox79_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox79.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox80_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox80.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox81_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox81.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox82_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox82.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox83_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox83.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox84_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox84.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox85_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox85.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox86_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox86.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox87_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox87.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox88_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox88.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox89_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox89.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox90_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox90.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox91_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox91.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox92_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox92.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox93_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox93.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox94_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox94.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox95_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox95.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox96_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox96.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox97_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox97.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox98_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox98.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox99_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox99.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox100_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox100.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox101_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox101.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox102_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox102.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox103_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox103.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox104_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox104.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroCheckBox105_MouseClick(sender As Object, e As EventArgs) Handles MetroCheckBox105.MouseClick
        My.Computer.Audio.Play(My.Resources.checkbox, AudioPlayMode.Background)
    End Sub
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton1.Text = "Stop finding" Then
            Try
                thread1.Abort()
            Catch ex As Exception
            End Try
            MetroButton1.Text = "Find for files"
            MetroButton2.Enabled = True
            My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Dim total As Long = ((((actualSize) / 1024) / 1024))
            Dim lol As Integer = Int32.Parse(total)
            MetroLabel127.Text = "Found " + lol.ToString() + "MBs of files to clean."
        Else
            actualSize = 0
            prefetchFiles.Clear()
            archiveTempFiles.Clear()
            tempFiles.Clear()
            installCacheFiles.Clear()
            windowsLogsFiles.Clear()
            steamLogsFiles.Clear()
            minecraftLogsFiles.Clear()
            fontCacheFiles.Clear()
            localLowFiles.Clear()
            browserCacheFiles.Clear()
            internetCacheFiles.Clear()
            softwareDistributionFiles.Clear()
            clrFiles.Clear()
            crashDumpsFiles.Clear()
            reportArchiveFiles.Clear()
            kernelReportsFiles.Clear()
            thumbnailCacheFiles.Clear()
            IISLogsFiles.Clear()
            desktopShortcutsFiles.Clear()
            memoryDumpsFiles.Clear()
            chkDskFileFragments.Clear()
            applicationsTempFiles.Clear()
            MetroLabel6.Text = "0"
            MetroLabel8.Text = "0"
            MetroLabel11.Text = "0"
            MetroLabel14.Text = "0"
            MetroLabel17.Text = "0"
            MetroLabel5.Text = "0"
            MetroLabel9.Text = "0"
            MetroLabel12.Text = "0"
            MetroLabel15.Text = "0"
            MetroLabel18.Text = "0"
            MetroLabel21.Text = "0"
            MetroLabel20.Text = "0"
            MetroLabel24.Text = "0"
            MetroLabel23.Text = "0"
            MetroLabel27.Text = "0"
            MetroLabel26.Text = "0"
            MetroLabel30.Text = "0"
            MetroLabel29.Text = "0"
            MetroLabel32.Text = "0"
            MetroLabel33.Text = "0"
            MetroLabel36.Text = "0"
            MetroLabel35.Text = "0"
            MetroLabel38.Text = "0"
            MetroLabel39.Text = "0"
            MetroLabel42.Text = "0"
            MetroLabel41.Text = "0"
            MetroLabel45.Text = "0"
            MetroLabel44.Text = "0"
            MetroLabel48.Text = "0"
            MetroLabel47.Text = "0"
            MetroLabel54.Text = "0"
            MetroLabel55.Text = "0"
            MetroLabel64.Text = "0"
            MetroLabel63.Text = "0"
            MetroLabel130.Text = "0"
            MetroLabel129.Text = "0"
            MetroLabel135.Text = "0"
            MetroLabel134.Text = "0"
            MetroLabel138.Text = "0"
            MetroLabel137.Text = "0"
            MetroLabel196.Text = "0"
            MetroLabel195.Text = "0"
            MetroLabel199.Text = "0"
            MetroLabel198.Text = "0"
            MetroLabel202.Text = "0"
            MetroLabel201.Text = "0"
            MetroLabel127.Text = "Scanning files..."
            MetroButton1.Text = "Stop finding"
            MetroButton2.Enabled = False
            thread1 = New System.Threading.Thread(AddressOf FindAll)
            thread1.Start()
        End If
    End Sub
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton2.Text = "Stop cleaning" Then
            Try
                thread2.Abort()
            Catch ex As Exception
            End Try
            MetroButton2.Text = "Clean found files"
            MetroButton1.Enabled = True
            My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Dim totalK As Long = ((((actualSize) / 1024) / 1024))
            Dim lol As Integer = Int32.Parse(totalK)
            MetroLabel127.Text = "Succesfully cleaned " + lol.ToString() + "MBs of files."
        Else
            CreateRestorePoint()
            actualSize = 0
            MetroLabel127.Text = "Cleaning files..."
            MetroButton2.Text = "Stop cleaning"
            MetroButton1.Enabled = False
            thread2 = New System.Threading.Thread(AddressOf CleanAll)
            thread2.Start()
            If MetroCheckBox19.Checked Then
                SHEmptyRecycleBin(Me.Handle.ToInt32, "", SHERB_NOCONFIRMATION + SHERB_NOSOUND)
                SHUpdateRecycleBinIcon()
            End If
        End If
    End Sub
    Public Sub CreateRestorePoint()
        If MetroCheckBox68.Checked Then
            MetroLabel127.Text = "Creating a Windows Restore Point..."
            Dim loadedRestorePoint As Integer = 1
            If System.IO.File.Exists("C:\ZeroCleaner\restore_point.txt") Then
                Try
                    loadedRestorePoint = Int32.Parse(System.IO.File.ReadAllText("C:\ZeroCleaner\restore_point.txt"))
                Catch ex As Exception
                    System.IO.File.WriteAllText("C:\ZeroCleaner\restore_point.txt", 1)
                End Try
            Else
                If Not System.IO.Directory.Exists("C:\ZeroCleaner") Then
                    System.IO.Directory.CreateDirectory("C:\ZeroCleaner")
                End If
                System.IO.File.WriteAllText("C:\ZeroCleaner\restore_point.txt", 1)
            End If
            If loadedRestorePoint < 1 Then
                loadedRestorePoint = 1
            End If
            Dim restPoint = GetObject("winmgmts:\\.\root\default:Systemrestore")
            If restPoint IsNot Nothing Then
                Try
                    restPoint.CreateRestorePoint("ZeroCleaner Restore Point #" + loadedRestorePoint.ToString(), 0, 100)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub MetroTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroTabControl1.SelectedIndexChanged
        My.Computer.Audio.Play(My.Resources.tabbing, AudioPlayMode.Background)
        If MetroTabControl1.SelectedIndex = 5 Then
            RefreshDrives()
        End If
    End Sub
    Public Sub RefreshDrives()
        ComboBox1.Items.Clear()
        Dim drives As String() = System.IO.Directory.GetLogicalDrives()
        For Each drive As String In drives
            ComboBox1.Items.Add(drive)
        Next
        Try
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Public Function DirLen(RootFolder As String) As Long
        Dim TotalSize As Long = 0
        Dim FolderInfo = New IO.DirectoryInfo(RootFolder)
        Try
            Try
                For Each File In FolderInfo.GetFiles : TotalSize += File.Length
                Next
            Catch ex As Exception
            End Try
            Try
                For Each SubFolderInfo In FolderInfo.GetDirectories : DirLen(SubFolderInfo.FullName)
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Return TotalSize
    End Function
    Public Function FilesInDir(RootFolder As String) As Long
        Dim TotalSize As Long = 0
        Dim FolderInfo = New IO.DirectoryInfo(RootFolder)
        Try
            Try
                For Each File In FolderInfo.GetFiles : TotalSize += 1
                Next
            Catch ex As Exception
            End Try
            Try
                For Each SubFolderInfo In FolderInfo.GetDirectories : FilesInDir(SubFolderInfo.FullName)
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Return TotalSize
    End Function
    Public Sub FindAll()
        If MetroCheckBox1.Checked Then
            If System.IO.Directory.Exists("C:\Windows\Prefetch") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\Prefetch")
                    actualSize += FileLen(file)
                    prefetchFiles.Add(file)
                    MetroLabel5.Text = prefetchFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\Prefetch")
                    actualSize += DirLen(dir)
                    prefetchFiles.Add(dir)
                    MetroLabel5.Text = prefetchFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox2.Checked Then
            If System.IO.Directory.Exists(System.IO.Path.GetTempPath()) Then
                For Each file As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath())
                    actualSize += FileLen(file)
                    archiveTempFiles.Add(file)
                    MetroLabel9.Text = archiveTempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories(System.IO.Path.GetTempPath())
                    actualSize += DirLen(dir)
                    archiveTempFiles.Add(dir)
                    MetroLabel9.Text = archiveTempFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox3.Checked Then
            If System.IO.Directory.Exists("C:\Windows\Temp") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\Temp")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\Temp")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\ProgramData\Package Cache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\ProgramData\Package Cache")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\ProgramData\Package Cache")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\ProgramData\USOShared\Logs") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\ProgramData\USOShared\Logs")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\ProgramData\USOShared\Logs")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Windows\ServiceProfiles\LocalService\AppData\Local") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\ServiceProfiles\LocalService\AppData\Local")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\ServiceProfiles\LocalService\AppData\Local")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\ServiceProfiles\LocalService\AppData\LocalLow")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Temp") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\Temp")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Temp")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\WebCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\WebCache")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\WebCache")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\utente\AppData\Local\Microsoft\Windows") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\utente\AppData\Local\Microsoft\Windows")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CDBurning)) Then
                For Each file As String In System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CDBurning))
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.CDBurning))
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Program Files\Common Files\Microsoft Shared\ClickToRun\") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Program Files\Common Files\Microsoft Shared\ClickToRun\")
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Program Files\Common Files\Microsoft Shared\ClickToRun\")
                    actualSize += DirLen(dir)
                    tempFiles.Add(dir)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                Next
            End If
            For Each file As String In System.IO.Directory.GetFiles("C:\")
                If Not System.IO.Path.GetExtension(file).ToLower() = ".chk" And Not System.IO.Path.GetFileNameWithoutExtension(file).ToLower() = "pagefile" And Not System.IO.Path.GetFileNameWithoutExtension(file).ToLower() = "swapfile" Then
                    actualSize += FileLen(file)
                    tempFiles.Add(file)
                    MetroLabel12.Text = tempFiles.Count.ToString()
                End If
            Next
        End If
        If MetroCheckBox4.Checked Then
            If System.IO.Directory.Exists("C:\Windows\Installer") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\Installer")
                    actualSize += FileLen(file)
                    installCacheFiles.Add(file)
                    MetroLabel15.Text = installCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\Installer")
                    actualSize += DirLen(dir)
                    installCacheFiles.Add(dir)
                    MetroLabel15.Text = installCacheFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox5.Checked Then
            If System.IO.Directory.Exists("C:\Windows\Logs") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\Logs")
                    actualSize += FileLen(file)
                    windowsLogsFiles.Add(file)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\Logs")
                    actualSize += DirLen(dir)
                    windowsLogsFiles.Add(dir)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                Next
            End If
            For Each file As String In System.IO.Directory.GetFiles("C:\Windows")
                If System.IO.Path.GetExtension(file).ToLower() = ".log" Then
                    actualSize += FileLen(file)
                    windowsLogsFiles.Add(file)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                End If
            Next
            If System.IO.Directory.Exists("C:\Windows\Debug") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\Debug")
                    actualSize += FileLen(file)
                    windowsLogsFiles.Add(file)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\Debug")
                    actualSize += DirLen(dir)
                    windowsLogsFiles.Add(dir)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Windows\system32\LogFiles\WMI") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\system32\LogFiles\WMI")
                    actualSize += FileLen(file)
                    windowsLogsFiles.Add(file)
                    MetroLabel18.Text = windowsLogsFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox6.Checked Then
            If System.IO.Directory.Exists("C:\Program Files (x86)\Steam\Logs") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Program Files (x86)\Steam\Logs")
                    actualSize += FileLen(file)
                    steamLogsFiles.Add(file)
                    MetroLabel21.Text = steamLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Program Files (x86)\Steam\Logs")
                    actualSize += DirLen(dir)
                    steamLogsFiles.Add(dir)
                    MetroLabel21.Text = steamLogsFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Program Files (x86)\Steam\Dumps") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Program Files (x86)\Steam\Dumps")
                    actualSize += FileLen(file)
                    steamLogsFiles.Add(file)
                    MetroLabel21.Text = steamLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Program Files (x86)\Steam\Dumps")
                    actualSize += DirLen(dir)
                    steamLogsFiles.Add(dir)
                    MetroLabel21.Text = steamLogsFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Program Files (x86)\Steam") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Program Files (x86)\Steam")
                    If System.IO.Path.GetExtension(file).ToLower() = ".log" Then
                        actualSize += FileLen(file)
                        steamLogsFiles.Add(file)
                        MetroLabel21.Text = steamLogsFiles.Count.ToString()
                    End If
                Next
            End If
        End If
        If MetroCheckBox7.Checked Then
            If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\logs") Then
                For Each file As String In System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\logs")
                    actualSize += FileLen(file)
                    minecraftLogsFiles.Add(file)
                    MetroLabel24.Text = minecraftLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\logs")
                    actualSize += DirLen(dir)
                    minecraftLogsFiles.Add(dir)
                    MetroLabel24.Text = minecraftLogsFiles.Count.ToString()
                Next
                If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\launcher_log.txt") Then
                    actualSize += FileLen(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\launcher_log.txt")
                    minecraftLogsFiles.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\launcher_log.txt")
                    MetroLabel24.Text = minecraftLogsFiles.Count.ToString()
                End If
            End If
        End If
        If MetroCheckBox8.Checked Then
            If System.IO.Directory.Exists("C:\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache")
                    actualSize += FileLen(file)
                    fontCacheFiles.Add(file)
                    MetroLabel27.Text = fontCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache")
                    actualSize += DirLen(dir)
                    fontCacheFiles.Add(dir)
                    MetroLabel27.Text = fontCacheFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox9.Checked Then
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\LocalLow") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\LocalLow")
                    actualSize += FileLen(file)
                    localLowFiles.Add(file)
                    MetroLabel30.Text = localLowFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\LocalLow")
                    actualSize += DirLen(dir)
                    localLowFiles.Add(dir)
                    MetroLabel30.Text = localLowFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox10.Checked Then
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Opera Software") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\Opera Software")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Opera Software")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla\Firefox\Profiles") Then
                For Each directory As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla\Firefox\Profiles")
                    If System.IO.Directory.Exists(directory + "\cache2") Then
                        For Each file As String In System.IO.Directory.GetFiles(directory + "\cache2")
                            actualSize += FileLen(file)
                            browserCacheFiles.Add(file)
                            MetroLabel33.Text = browserCacheFiles.Count.ToString()
                        Next
                        For Each dir As String In System.IO.Directory.GetDirectories(directory + "\cache2")
                            actualSize += DirLen(dir)
                            browserCacheFiles.Add(dir)
                            MetroLabel33.Text = browserCacheFiles.Count.ToString()
                        Next
                    End If
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Local\Opera Software\Opera Stable\Cache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Local\Opera Software\Opera Stable\Cache")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Local\Opera Software\Opera Stable\Cache")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\GPUCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\GPUCache")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\GPUCache")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\ShaderCache\GPUCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\ShaderCache\GPUCache")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\ShaderCache\GPUCache")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\File System") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\File System")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\File System")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\CacheStorage") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\CacheStorage")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\CacheStorage")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\Database") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\Database")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\Database")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\ScriptCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\ScriptCache")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\ScriptCache")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\databases") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\databases")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\databases")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List Icons") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List Icons")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List Icons")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List IconsOld") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List IconsOld")
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List IconsOld")
                    actualSize += DirLen(dir)
                    browserCacheFiles.Add(dir)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                Next
            End If
            Dim fireFoxFiles() As String = {Paths.MozillaFireFoxCache, Paths.MozillaFireFoxCookies, Paths.MozillaFireFoxCookiesWebAppsStore, Paths.MozillaFireFoxDownloads, Paths.MozillaFireFoxFormHistory, Paths.MozillaFirefoxSessionStore, Paths.MozillaFirefoxSessionStoreBackup}
            For Each file As String In fireFoxFiles
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                End If
            Next
            Dim googleChromeFiles() As String = {Paths.GoogleChromeCache, Paths.GoogleChromeCookies, Paths.GoogleChromeCookiesDBs, Paths.GoogleChromeCookiesLocalStorage, Paths.GoogleChromeInternetHistory}
            For Each file As String In googleChromeFiles
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                End If
            Next
            Dim safariFiles() As String = {Paths.SafariCache, Paths.SafariHistory, Paths.SafariHistoryDownloadsPlist, Paths.SafariHistoryLastSessionPlist, Paths.SafariHistoryPlist, Paths.SafariWebpagePreviews}
            For Each file As String In safariFiles
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                End If
            Next
            Dim operaFiles() As String = {Paths.OperaCache, Paths.OperaCacheTempDownloads, Paths.OperaCookies, Paths.OperaIconCache, Paths.OperaInternetHistory_1, Paths.OperaInternetHistory_2, Paths.OperaInternetHistory_3, Paths.OperaInternetHistory_4, Paths.OperaInternetHistory_5, Paths.OperaInternetHistory_6, Paths.OperaOPCache, Paths.OperaWebsiteIcon}
            For Each file As String In operaFiles
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    browserCacheFiles.Add(file)
                    MetroLabel33.Text = browserCacheFiles.Count.ToString()
                End If
            Next
        End If
        If MetroCheckBox11.Checked Then
            If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)) Then
                For Each file As String In System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
                    actualSize += FileLen(file)
                    internetCacheFiles.Add(file)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
                    actualSize += DirLen(dir)
                    internetCacheFiles.Add(dir)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                Next
            End If
            If System.IO.Directory.Exists("C:\Users\utente\AppData\Local\Packages\windows_ie_ac_001\AC\INetCache") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\utente\AppData\Local\Packages\windows_ie_ac_001\AC\INetCache")
                    actualSize += FileLen(file)
                    internetCacheFiles.Add(file)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\utente\AppData\Local\Packages\windows_ie_ac_001\AC\INetCache")
                    actualSize += DirLen(dir)
                    internetCacheFiles.Add(dir)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                Next
            End If
            Dim internetExplorerFiles() As String = {Paths.InternetExplorerCookies, Paths.InternetExplorerCookiesDomStore, Paths.InternetExplorerHistory, Paths.InternetExplorerIndexDat_1, Paths.InternetExplorerIndexDat_2,
            Paths.InternetExplorerIndexDat_3, Paths.InternetExplorerIndexDat_4, Paths.InternetExplorerIndexDat_5, Paths.InternetExplorerIndexDat_6, Paths.InternetExplorerRecentlyTypedUrls,
            Paths.InternetExplorerTemps}
            For Each file As String In internetExplorerFiles
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    internetCacheFiles.Add(file)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    internetCacheFiles.Add(file)
                    MetroLabel36.Text = internetCacheFiles.Count.ToString()
                End If
            Next
        End If
        If MetroCheckBox13.Checked Then
            If System.IO.Directory.Exists("C:\Windows\SoftwareDistribution") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\SoftwareDistribution")
                    actualSize += FileLen(file)
                    softwareDistributionFiles.Add(file)
                    MetroLabel39.Text = softwareDistributionFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\SoftwareDistribution")
                    actualSize += DirLen(dir)
                    softwareDistributionFiles.Add(dir)
                    MetroLabel39.Text = softwareDistributionFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox14.Checked Then
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft") Then
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft")
                    If dir.Contains("\CLR") Then
                        actualSize += DirLen(dir)
                        clrFiles.Add(dir)
                        MetroLabel42.Text = clrFiles.Count.ToString()
                    End If
                Next
            End If
            If System.IO.Directory.Exists("C:\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs")
                    actualSize += FileLen(file)
                    clrFiles.Add(file)
                    MetroLabel42.Text = clrFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\SysWOW64\config\systemprofile\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs")
                    actualSize += DirLen(dir)
                    clrFiles.Add(dir)
                    MetroLabel42.Text = clrFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox15.Checked Then
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\CrashDumps") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\CrashDumps")
                    actualSize += FileLen(file)
                    crashDumpsFiles.Add(file)
                    MetroLabel45.Text = crashDumpsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\CrashDumps")
                    actualSize += DirLen(dir)
                    crashDumpsFiles.Add(dir)
                    MetroLabel45.Text = crashDumpsFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox16.Checked Then
            If System.IO.Directory.Exists("C:\ProgramData\Microsoft\Windows\WER") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\ProgramData\Microsoft\Windows\WER")
                    actualSize += FileLen(file)
                    reportArchiveFiles.Add(file)
                    MetroLabel48.Text = reportArchiveFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\ProgramData\Microsoft\Windows\WER")
                    actualSize += DirLen(dir)
                    reportArchiveFiles.Add(dir)
                    MetroLabel48.Text = reportArchiveFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox20.Checked Then
            If System.IO.Directory.Exists("C:\Windows\LiveKernelReports") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\LiveKernelReports")
                    actualSize += FileLen(file)
                    kernelReportsFiles.Add(file)
                    MetroLabel55.Text = kernelReportsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\LiveKernelReports")
                    actualSize += DirLen(dir)
                    kernelReportsFiles.Add(dir)
                    MetroLabel55.Text = kernelReportsFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox25.Checked Then
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\Explorer") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\Explorer")
                    actualSize += FileLen(file)
                    thumbnailCacheFiles.Add(file)
                    MetroLabel64.Text = thumbnailCacheFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\Explorer")
                    actualSize += DirLen(dir)
                    thumbnailCacheFiles.Add(dir)
                    MetroLabel64.Text = thumbnailCacheFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox57.Checked Then
            Dim path2Downloads As String = String.Empty
            Dim files As String() = {""}
            Dim directories As String() = {""}
            path2Downloads = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads")
            If System.IO.Directory.Exists(path2Downloads) Then
                files = System.IO.Directory.GetFiles(path2Downloads)
                directories = System.IO.Directory.GetDirectories(path2Downloads)
            End If
            For Each file As String In files
                actualSize += FileLen(file)
                downloadFolderFiles.Add(file)
                MetroLabel130.Text = downloadFolderFiles.Count.ToString()
            Next
        End If
        If MetroCheckBox59.Checked Then
            If System.IO.Directory.Exists("C:\inetpub\logs") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\inetpub\logs")
                    actualSize += FileLen(file)
                    IISLogsFiles.Add(file)
                    MetroLabel135.Text = IISLogsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\inetpub\logs")
                    actualSize += DirLen(dir)
                    IISLogsFiles.Add(dir)
                    MetroLabel135.Text = IISLogsFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox61.Checked Then
            For Each file As String In System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                If System.IO.Path.GetExtension(file).ToLower() = ".lnk" Then
                    actualSize += FileLen(file)
                    desktopShortcutsFiles.Add(file)
                    MetroLabel138.Text = desktopShortcutsFiles.Count.ToString()
                End If
            Next
        End If
        If MetroCheckBox101.Checked Then
            If System.IO.Directory.Exists("C:\Windows") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows")
                    If System.IO.Path.GetExtension(file).ToLower() = ".dmp" Then
                        actualSize += FileLen(file)
                        memoryDumpsFiles.Add(file)
                        MetroLabel196.Text = memoryDumpsFiles.Count.ToString()
                    End If
                Next
            End If
            If System.IO.Directory.Exists("C:\Windows\MiniDump") Then
                For Each file As String In System.IO.Directory.GetFiles("C:\Windows\MiniDump")
                    actualSize += FileLen(file)
                    memoryDumpsFiles.Add(file)
                    MetroLabel196.Text = memoryDumpsFiles.Count.ToString()
                Next
                For Each dir As String In System.IO.Directory.GetDirectories("C:\Windows\MiniDump")
                    actualSize += DirLen(dir)
                    memoryDumpsFiles.Add(dir)
                    MetroLabel196.Text = memoryDumpsFiles.Count.ToString()
                Next
            End If
        End If
        If MetroCheckBox104.Checked Then
            For Each file As String In System.IO.Directory.GetFiles("C:\")
                If System.IO.Path.GetExtension(file).ToLower() = ".chk" Then
                    actualSize += FileLen(file)
                    chkDskFileFragments.Add(file)
                    MetroLabel199.Text = chkDskFileFragments.Count.ToString()
                End If
            Next
            For Each file As String In System.IO.Directory.GetFiles("C:\Users\" + Environment.UserName)
                If System.IO.Path.GetExtension(file).ToLower() = ".chk" Then
                    actualSize += FileLen(file)
                    chkDskFileFragments.Add(file)
                    MetroLabel199.Text = chkDskFileFragments.Count.ToString()
                End If
            Next
        End If
        If MetroCheckBox105.Checked Then
            Dim files() As String = {Paths.AdobeFlashPlayer, Paths.AvgAntivirus10Backup, Paths.AvgAntivirus10Log, Paths.AvgAntivirus10Misc, Paths.AvgAntivirus10Temps, Paths.FileZillaRecentServers, Paths.MalwareBytesLogs, Paths.MalwareBytesQuarantineBackup, Paths.PaintNet, Paths.QuickTimePlayerCache, Paths.QuickTimerPlayer, Paths.SpybotSdBackups, Paths.SpybotSdIni, Paths.SpybotSdLogs, Paths.SunJavaCache, Paths.SunJavaSystemCache, Paths.uTorrentDllImageCache, Paths.uTorrentTempFiles, Paths.VisualStudio2005FileMRUList, Paths.VisualStudio2005ProjectMRUList, Paths.VisualStudio2008FileMRUList, Paths.VisualStudio2008ProjectMRUList, Paths.VisualStudio2010FileMRUList, Paths.VisualStudio2010ProjectMRUList, Paths.WindowsDefenderHistoryQuick, Paths.WindowsDefenderHistoryResource, Paths.WindowsErrorReporting_1, Paths.WindowsErrorReporting_2, Paths.WindowsErrorReporting_3, Paths.WindowsErrorReporting_4, Paths.PaintNet, Paths.WindowsExplorerRecent, Paths.WindowsExplorerThumbnailCache, Paths.WindowsLogFiles, Paths.WindowsMediaPlayer, Paths.WindowsTempFiles, Paths.UserTemps,
                "C:\Users\" + Environment.UserName + "\AppData\Roaming\notepad++\session.xml", "C:\Users\" + Environment.UserName + "\AppData\Roaming\IDM\foldresHistory.txt"}
            For Each file As String In files
                If System.IO.File.Exists(file) Then
                    actualSize += FileLen(file)
                    applicationsTempFiles.Add(file)
                    MetroLabel202.Text = applicationsTempFiles.Count.ToString()
                ElseIf System.IO.Directory.Exists(file) Then
                    actualSize += DirLen(file)
                    applicationsTempFiles.Add(file)
                    MetroLabel202.Text = applicationsTempFiles.Count.ToString()
                End If
            Next
        End If
        MetroButton1.Text = "Find for files"
        MetroButton2.Enabled = True
        My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
        Dim total As Long = ((((actualSize) / 1024) / 1024))
        Dim lol As Integer = Int32.Parse(total)
        MetroLabel127.Text = "Found " + lol.ToString() + "MBs of files to clean."
    End Sub
    Public Sub CleanAll()
        If MetroCheckBox1.Checked Then
            MetroLabel127.Text = "Cleaning Prefetch..."
            If System.IO.Directory.Exists("C:\Windows\Prefetch") Then
                Dim total As Integer = prefetchFiles.Count + 1
                For Each thing As String In prefetchFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel6.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel6.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox2.Checked Then
            MetroLabel127.Text = "Cleaning Archive Temp..."
            If System.IO.Directory.Exists(System.IO.Path.GetTempPath()) Then
                Dim total As Integer = archiveTempFiles.Count + 1
                For Each thing As String In archiveTempFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel8.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel8.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox3.Checked Then
            MetroLabel127.Text = "Cleaning Temp Files..."
            If System.IO.Directory.Exists("C:\Windows\Temp") Then
                Dim total As Integer = tempFiles.Count + 1
                For Each thing As String In tempFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel11.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel11.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox4.Checked Then
            MetroLabel127.Text = "Cleaning Install Cache..."
            If System.IO.Directory.Exists("C:\Windows\Installer") Then
                Dim total As Integer = installCacheFiles.Count + 1
                For Each thing As String In installCacheFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel14.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel14.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox5.Checked Then
            MetroLabel127.Text = "Cleaning Windows Logs..."
            If System.IO.Directory.Exists("C:\Windows\Logs") Then
                Dim total As Integer = windowsLogsFiles.Count + 1
                For Each thing As String In windowsLogsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel17.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel17.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox6.Checked Then
            MetroLabel127.Text = "Cleaning Steam Logs..."
            If System.IO.Directory.Exists("C:\Program Files (x86)\Steam\logs") Then
                Dim total As Integer = steamLogsFiles.Count + 1
                For Each thing As String In steamLogsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel20.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel20.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox7.Checked Then
            MetroLabel127.Text = "Cleaning Minecraft Logs..."
            If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\logs") Then
                Dim total As Integer = minecraftLogsFiles.Count + 1
                For Each thing As String In minecraftLogsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel20.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel20.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox8.Checked Then
            MetroLabel127.Text = "Cleaning Font Cache..."
            If System.IO.Directory.Exists("C:\Windows\ServiceProfiles\LocalService\AppData\Local\FontCache") Then
                Dim total As Integer = fontCacheFiles.Count + 1
                For Each thing As String In fontCacheFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel26.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel26.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox9.Checked Then
            MetroLabel127.Text = "Cleaning LocalLow Files..."
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\LocalLow") Then
                Dim total As Integer = localLowFiles.Count + 1
                For Each thing As String In localLowFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel29.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel29.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox10.Checked Then
            MetroLabel127.Text = "Cleaning Browser Cache..."
            Dim total As Integer = browserCacheFiles.Count + 1
            For Each thing As String In browserCacheFiles
                Try
                    If System.IO.File.Exists(thing) Then
                        actualSize += FileLen(thing)
                        DestroyFile(thing)
                        total -= 1
                        MetroLabel32.Text = total.ToString()
                    Else
                        If System.IO.Directory.Exists(thing) Then
                            actualSize += DirLen(thing)
                            DestroyDirectory(thing, True)
                            total -= 1
                            MetroLabel32.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If MetroCheckBox11.Checked Then
            MetroLabel127.Text = "Cleaning Internet Cache..."
            If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)) Then
                Dim total As Integer = internetCacheFiles.Count + 1
                For Each thing As String In internetCacheFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel35.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel35.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox12.Checked Then
            MetroLabel127.Text = "Cleaning Explorer Cache..."
            Try
                CMDHelper.RunCommand("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox13.Checked Then
            MetroLabel127.Text = "Cleaning Software Distribution..."
            If System.IO.Directory.Exists("C:\Windows\SoftwareDistribution") Then
                Dim total As Integer = softwareDistributionFiles.Count + 1
                For Each thing As String In softwareDistributionFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel38.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel38.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox14.Checked Then
            MetroLabel127.Text = "Cleaning CLR..."
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft") Then
                Dim total As Integer = clrFiles.Count + 1
                For Each thing As String In clrFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel41.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel41.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox15.Checked Then
            MetroLabel127.Text = "Cleaning Crash Dumps..."
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\CrashDumps") Then
                Dim total As Integer = crashDumpsFiles.Count + 1
                For Each thing As String In crashDumpsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel44.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel44.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox16.Checked Then
            MetroLabel127.Text = "Cleaning Report Archive..."
            If System.IO.Directory.Exists("C:\ProgramData\Microsoft\Windows\WER") Then
                Dim total As Integer = reportArchiveFiles.Count + 1
                For Each thing As String In reportArchiveFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel47.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel47.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox17.Checked Then
            MetroLabel127.Text = "Cleaning DNS Cache..."
            CMDHelper.RunCommand("ipconfig /release")
            CMDHelper.RunCommand("ipconfig /renew")
            CMDHelper.RunCommand("ipconfig /flushdns")
        End If
        If MetroCheckBox20.Checked Then
            MetroLabel127.Text = "Cleaning Kernel Reports..."
            If System.IO.Directory.Exists("C:\Windows\LiveKernelReports") Then
                Dim total As Integer = kernelReportsFiles.Count + 1
                For Each thing As String In kernelReportsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel54.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel54.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox24.Checked Then
            MetroLabel127.Text = "Cleaning Icon Cache..."
            If System.IO.File.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\IconCache.db") Then
                Try
                    actualSize += FileLen("C:\Users\" + Environment.UserName + "\AppData\Local\IconCache.db")
                    DestroyFile("C:\Users\" + Environment.UserName + "\AppData\Local\IconCache.db")
                Catch ex As Exception
                End Try
            End If
        End If
        If MetroCheckBox25.Checked Then
            MetroLabel127.Text = "Cleaning Thumbnail Cache..."
            If System.IO.Directory.Exists("C:\Users\" + Environment.UserName + "\AppData\Local\Microsoft\Windows\Explorer") Then
                Dim total As Integer = thumbnailCacheFiles.Count + 1
                For Each thing As String In thumbnailCacheFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel63.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel63.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox57.Checked Then
            MetroLabel127.Text = "Cleaning Download Folder..."
            Dim total As Integer = downloadFolderFiles.Count + 1
            For Each thing As String In downloadFolderFiles
                Try
                    If System.IO.File.Exists(thing) Then
                        actualSize += FileLen(thing)
                        DestroyFile(thing)
                        total -= 1
                        MetroLabel63.Text = total.ToString()
                    Else
                        If System.IO.Directory.Exists(thing) Then
                            actualSize += DirLen(thing)
                            DestroyDirectory(thing, True)
                            total -= 1
                            MetroLabel63.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If MetroCheckBox59.Checked Then
            MetroLabel127.Text = "Cleaning IIS Logs..."
            If System.IO.Directory.Exists("C:\inetpub\logs") Then
                Dim total As Integer = IISLogsFiles.Count + 1
                For Each thing As String In IISLogsFiles
                    Try
                        If System.IO.File.Exists(thing) Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel134.Text = total.ToString()
                        Else
                            If System.IO.Directory.Exists(thing) Then
                                actualSize += DirLen(thing)
                                DestroyDirectory(thing, True)
                                total -= 1
                                MetroLabel134.Text = total.ToString()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
        If MetroCheckBox60.Checked Then
            MetroLabel127.Text = "Cleaning Windows Event Logs..."
            Dim process As New Process()
            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
            processStartInfo.CreateNoWindow = True
            processStartInfo.Arguments = "wevtutil el | Foreach-Object {wevtutil cl “"$_"”}"
            processStartInfo.Verb = "runas"
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            processStartInfo.FileName = "powershell"
            process.StartInfo = processStartInfo
            process.Start()
            process.WaitForExit()
        End If
        If MetroCheckBox61.Checked Then
            MetroLabel127.Text = "Cleaning Desktop Shortcuts..."
            Dim total As Integer = desktopShortcutsFiles.Count + 1
            For Each thing As String In desktopShortcutsFiles
                Try
                    If System.IO.File.Exists(thing) Then
                        If System.IO.Path.GetExtension(thing).ToLower() = ".lnk" Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel137.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If MetroCheckBox62.Checked Then
            MetroLabel127.Text = "Cleaning Start Menu Shortcuts..."
            Dim process As New Process()
            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
            processStartInfo.CreateNoWindow = True
            processStartInfo.Arguments = "Get-ChildItem ""$env:PROGRAMDATA\ Microsoft \ Windows \ Start Menu\Programs\*.lnk"" -recurse|ForEach-Object { Remove-Item $_ }"
            processStartInfo.Verb = "runas"
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            processStartInfo.FileName = "powershell"
            process.StartInfo = processStartInfo
            process.Start()
            process.WaitForExit()
        End If
        If MetroCheckBox63.Checked Then
            MetroLabel127.Text = "Cleaning User Assist History..."
            Dim process As New Process()
            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
            processStartInfo.CreateNoWindow = True
            processStartInfo.Arguments = "Delete-History -Windows"
            processStartInfo.Verb = "runas"
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
            processStartInfo.FileName = "powershell"
            process.StartInfo = processStartInfo
            process.Start()
            process.WaitForExit()
        End If
        If MetroCheckBox95.Checked Then
            MetroLabel127.Text = "Resetting WinSock..."
            Try
                CMDHelper.RunCommand("netsh winsock reset")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox96.Checked Then
            MetroLabel127.Text = "Resetting TCP/IP..."
            Try
                CMDHelper.RunCommand("netsh int ip reset")
                CMDHelper.RunCommand("netsh int ipv6 reset")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox97.Checked Then
            MetroLabel127.Text = "Resetting BITS..."
            Try
                CMDHelper.RunCommand("bitsadmin /reset")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox98.Checked Then
            MetroLabel127.Text = "Resetting Firewall..."
            Try
                CMDHelper.RunCommand("netsh advfirewall reset")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox99.Checked Then
            MetroLabel127.Text = "Resetting Hosts..."
            Try
                System.IO.File.WriteAllText("C:\Windows\System32\drivers\etc\hosts", "127.0.0.1 localhost")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox100.Checked Then
            MetroLabel127.Text = "Resetting Printer Queue..."
            Try
                CMDHelper.RunCommand("net stop spooler")
                CMDHelper.RunCommand("del %systemroot%\System32\spool\printers\* /Q ")
                CMDHelper.RunCommand("net start spooler")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox101.Checked Then
            MetroLabel127.Text = "Cleaning Memory Dumps..."
            Dim total As Integer = memoryDumpsFiles.Count + 1
            For Each thing As String In memoryDumpsFiles
                Try
                    If System.IO.File.Exists(thing) Then
                        actualSize += FileLen(thing)
                        DestroyFile(thing)
                        total -= 1
                        MetroLabel195.Text = total.ToString()
                    Else
                        If System.IO.Directory.Exists(thing) Then
                            actualSize += DirLen(thing)
                            DestroyDirectory(thing, True)
                            total -= 1
                            MetroLabel195.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If MetroCheckBox102.Checked Then
            MetroLabel127.Text = "Repairing Windows corrupted files..."
            Try
                CMDHelper.RunCommand("sfc /scannow")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox103.Checked Then
            MetroLabel127.Text = "Repairing Windows Image..."
            Try
                CMDHelper.RunCommand("DISM.exe /Online /Cleanup-image /Restorehealth")
            Catch ex As Exception
            End Try
        End If
        If MetroCheckBox104.Checked Then
            MetroLabel127.Text = "Cleaning Chkdsk File Fragments..."
            Dim total As Integer = chkDskFileFragments.Count + 1
            For Each thing As String In chkDskFileFragments
                Try
                    If System.IO.File.Exists(thing) Then
                        If System.IO.Path.GetExtension(thing).ToLower() = ".chk" Then
                            actualSize += FileLen(thing)
                            DestroyFile(thing)
                            total -= 1
                            MetroLabel198.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If MetroCheckBox105.Checked Then
            MetroLabel127.Text = "Cleaning Applications Temp Files.."
            Dim total As Integer = applicationsTempFiles.Count + 1
            For Each thing As String In applicationsTempFiles
                Try
                    If System.IO.File.Exists(thing) Then
                        actualSize += FileLen(thing)
                        DestroyFile(thing)
                        total -= 1
                        MetroLabel201.Text = total.ToString()
                    Else
                        If System.IO.Directory.Exists(thing) Then
                            actualSize += DirLen(thing)
                            DestroyDirectory(thing, True)
                            total -= 1
                            MetroLabel201.Text = total.ToString()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        MetroButton2.Text = "Clean found files"
        MetroButton1.Enabled = True
        My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
        Dim totalK As Long = ((((actualSize) / 1024) / 1024))
        Dim lol As Integer = Int32.Parse(totalK)
        MetroLabel127.Text = "Succesfully cleaned " + lol.ToString() + "MBs of files."
    End Sub
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton3.Text = "Stop optimizing your device" Then
            Try
                thread3.Abort()
            Catch ex As Exception
            End Try
            MetroButton3.Text = "Apply all optimizations to your device"
            My.Computer.Audio.Play(My.Resources.notice, AudioPlayMode.Background)
            MessageBox.Show("You succesfully optimized your computer. Please, restart.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            CreateRestorePoint()
            MetroButton3.Text = "Stop optimizing your device"
            MetroLabel51.Text = "Ready"
            MetroLabel57.Text = "Ready"
            MetroLabel59.Text = "Ready"
            MetroLabel61.Text = "Ready"
            MetroLabel66.Text = "Ready"
            MetroLabel68.Text = "Ready"
            MetroLabel70.Text = "Ready"
            MetroLabel72.Text = "Ready"
            MetroLabel74.Text = "Ready"
            MetroLabel76.Text = "Ready"
            MetroLabel78.Text = "Ready"
            MetroLabel80.Text = "Ready"
            MetroLabel82.Text = "Ready"
            MetroLabel84.Text = "Ready"
            MetroLabel106.Text = "Ready"
            MetroLabel107.Text = "Ready"
            MetroLabel108.Text = "Ready"
            MetroLabel109.Text = "Ready"
            MetroLabel110.Text = "Ready"
            MetroLabel111.Text = "Ready"
            MetroLabel112.Text = "Ready"
            MetroLabel113.Text = "Ready"
            MetroLabel114.Text = "Ready"
            MetroLabel115.Text = "Ready"
            MetroLabel116.Text = "Ready"
            MetroLabel117.Text = "Ready"
            MetroLabel118.Text = "Ready"
            MetroLabel119.Text = "Ready"
            MetroLabel120.Text = "Ready"
            MetroLabel121.Text = "Ready"
            MetroLabel122.Text = "Ready"
            MetroLabel123.Text = "Ready"
            MetroLabel124.Text = "Ready"
            MetroLabel125.Text = "Ready"
            MetroLabel126.Text = "Ready"
            MetroLabel131.Text = "Ready"
            MetroLabel140.Text = "Ready"
            MetroLabel142.Text = "Ready"
            MetroLabel146.Text = "Ready"
            MetroLabel148.Text = "Ready"
            MetroLabel150.Text = "Ready"
            MetroLabel152.Text = "Ready"
            MetroLabel154.Text = "Ready"
            MetroLabel156.Text = "Ready"
            MetroLabel159.Text = "Ready"
            MetroLabel160.Text = "Ready"
            MetroLabel162.Text = "Ready"
            MetroLabel164.Text = "Ready"
            MetroLabel166.Text = "Ready"
            MetroLabel172.Text = "Ready"
            MetroLabel174.Text = "Ready"
            MetroLabel176.Text = "Ready"
            MetroLabel178.Text = "Ready"
            MetroLabel180.Text = "Ready"
            MetroLabel182.Text = "Ready"
            MetroLabel184.Text = "Ready"
            MetroLabel186.Text = "Ready"
            thread3 = New System.Threading.Thread(AddressOf OptimizeAll)
            thread3.Start()
        End If
    End Sub
    Public Sub OptimizeAll()
        If MetroCheckBox18.Checked Then
            MetroLabel51.Text = "Working"
            Try
                Shell("powercfg.exe /hibernate off")
                MetroLabel51.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel51.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox21.Checked Then
            MetroLabel57.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", "TCPNoDelay", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", "IPAutoconfigurationEnabled", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", "TCPDelAckTicks", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", "TcpAckFrequency", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "TCPNoDelay", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "IPAutoconfigurationEnabled", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "TCPDelAckTicks", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "TcpAckFrequency", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\ServiceProvider", "Class", 8)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\ServiceProvider", "DnsPriority", 96)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\ServiceProvider", "HostsPriority", 95)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\ServiceProvider", "NetbtPriority", 97)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\ServiceProvider", "LocalPriority", 94)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows", "NonBestEffortLimit", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", &HFFFFFFFF)
                Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoInstrumentation", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoInstrumentation", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\SQMClient\Windows", "CEIPEnable", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports", "PreventHandwritingErrorReports", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection", "AllowTelemetry", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\AppCompat", "AITEnable", 0)
                Registry.SetValue("HKEY_CURRENT_USER\Network", "Network_Bandwidth", 512)
                If System.IO.Directory.Exists("C:\Program Files\rempl") Then
                    For Each file As String In System.IO.Directory.GetFiles("C:\Program Files\rempl")
                        Try
                            DestroyFile(file)
                        Catch ex As Exception
                        End Try
                    Next
                    For Each dir As String In System.IO.Directory.GetDirectories("C:\Program Files\rempl")
                        Try
                            DestroyFile(dir)
                        Catch ex As Exception
                        End Try
                    Next
                End If
                If System.IO.Directory.Exists("C:\Program Files\rempl") Then
                    Try
                        DestroyDirectory("C:\Program Files\rempl", True)
                    Catch ex As Exception
                    End Try
                End If
                MetroLabel57.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel57.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox22.Checked Then
            MetroLabel59.Text = "Working"
            Try
                If System.IO.File.Exists("C:\pagefile.sys") Then
                    DestroyFile("C:\pagefile.sys")
                    MetroLabel59.Text = "Success"
                    My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
                End If
            Catch ex As Exception
                MetroLabel59.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox23.Checked Then
            MetroLabel61.Text = "Working"
            Try
                If System.IO.File.Exists("C:\swapfile.sys") Then
                    DestroyFile("C:\swapfile.sys")
                    MetroLabel61.Text = "Success"
                    My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
                End If
            Catch ex As Exception
                MetroLabel61.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox26.Checked Then
            MetroLabel66.Text = "Working"
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Mouse", "MouseHoverTime", 8)
                Registry.SetValue("HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseSpeed", 0)
                Registry.SetValue("HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseThreshold1", 0)
                Registry.SetValue("HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseThreshold2", 0)
                Registry.SetValue("HKEY_USERS\.DEFAULT\Control Panel\Mouse", "MouseSensitivy", 10)
                MetroLabel66.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel66.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox27.Checked Then
            MetroLabel68.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend", "Start", 4)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService", "Start", 4)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "ProductStatus", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "ManagedDefenderProductType", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "DisableAntiVirus", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "DisableAntiSpyware", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "DisableRoutinelyTakingAction", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender", "OneTimeSqmDataSent", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Real-Time Protection", "DisableAntiSpywareRealtimeProtection", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Real-Time Protection", "DisableRealtimeMonitoring", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Real-Time Protection", "DpaDisabled", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Scan", "AutomaticallyCleanAfterScan", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Scan", "ScheduleDay", 8)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\UX Scan", "AllowNonAdminFunctionality", 8)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\MRT", "DontReportInfectionInformation", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiVirus", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet", "SpyNetReporting", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Spynet", "SubmitSamplesConsent", 2)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "SmartScreenEnabled", "Off")
                Dim baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                Try
                    Using key = baseReg.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                        key.DeleteValue("WindowsDefender", False)
                        key.DeleteValue("SecurityHealth", False)
                    End Using
                    Dim defenderPath As String
                    If amd64 Then
                        defenderPath = Environment.ExpandEnvironmentVariables("%ProgramW6432%")
                    Else
                        defenderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                    End If
                    defenderPath += "\Windows Defender\shellext.dll"
                    If File.Exists(defenderPath) Then
                        CMDHelper.RunCommand("regsvr32 /u /s """ & defenderPath & """")
                    Else
                    End If
                Catch ex As Exception
                End Try
                MetroLabel68.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel68.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox28.Checked Then
            MetroLabel70.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TimeBrokerSvc", "Start", 4)
                MetroLabel70.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel70.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox29.Checked Then
            MetroLabel72.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "EnableSuperfetch", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "EnablePrefetcher", 3)
                MetroLabel72.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel72.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox30.Checked Then
            MetroLabel74.Text = "Working"
            Try
                Try
                    Shell("powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61")
                Catch ex As Exception
                End Try
                Try
                    Shell("powercfg -setactive cc3c8616-2d03-4e4d-8f03-d1553e3d66c5")
                Catch ex As Exception
                End Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "AlwaysUnloadDll", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem", "AlwaysUnloadDll", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", 8)
                Registry.SetValue("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\PriorityControl", "IRQ8Priority", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\FileSystem", "NtfsMftZoneReservation", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Class\{4D36E96A-E325-11CE-BFC1-08002BE10318}\0000\", "EnableUDMA66", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Dfrg", "BootOptimizeFunction", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\CiSvc", "Start", 4)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TokenBroker", "Start", 4)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ClickToRunSvc", "Start", 4)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "LargeSystemCache", 0)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "AutoEndTasks", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "HungAppTimeout", 1000)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", 8)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "WaitToKillAppTimeout", 2000)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "LowLevelHooksTimeout", 1000)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "Win8DpiScaling", 0)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "DpiScalingVer", 256)
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "LogPixels", 150)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoLowDiskSpaceChecks", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "LinkResolveIgnoreLinkInfo", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoResolveSearch", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoResolveTrack", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoInternetOpenWith", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control", "WaitToKillServiceTimeout", 2000)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LastActiveClick", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem", "NtfsDisableLastAccessUpdate", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Serialize", "StartupDelayInMSec", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling", "PowerThrottlingOff", 1)
                Registry.SetValue("HKEY_CURRENT_CONFIG", "Mystring", &H95242242)
                Registry.SetValue("HKEY_CURRENT_CONFIG", "MaxLOMChannels", &H14500000)
                Registry.SetValue("HKEY_CURRENT_CONFIG", "Freemem", 20)
                MetroLabel74.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel74.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox31.Checked Then
            MetroLabel76.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl", "Win32PrioritySeparation", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\PriorityControl", "Win32PrioritySeparation", 22)
                MetroLabel76.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel76.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox32.Checked Then
            MetroLabel78.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "Priority", 6)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "GPU Priority", 8)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "Scheduling Category", "High")
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "SFIO Priority", "High")
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "Affinity", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "Background Only", "False")
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", "Clock Rate", 10000)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\javaw.exe\PerfOptions", "CpuPriorityClass", 3)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\FortniteClient-Win64-Shipping.exe\PerfOptions", "CpuPriorityClass", 3)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\GTA5.exe\PerfOptions", "CpuPriorityClass", 3)
                MetroLabel78.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel78.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox33.Checked Then
            MetroLabel80.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WSearch", "Start", 4)
                MetroLabel80.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel80.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox34.Checked Then
            MetroLabel82.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowscalculator* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel82.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel82.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox35.Checked Then
            MetroLabel84.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *3dbuilder* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel84.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel84.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox36.Checked Then
            MetroLabel106.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowsalarms* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel106.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel106.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox37.Checked Then
            MetroLabel107.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel107.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel107.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox38.Checked Then
            MetroLabel108.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowscamera* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel108.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel108.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox39.Checked Then
            MetroLabel109.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *officehub* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel109.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel109.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox40.Checked Then
            MetroLabel110.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *skypeapp* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel110.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel110.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox41.Checked Then
            MetroLabel111.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *getstarted* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel111.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel111.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox42.Checked Then
            MetroLabel112.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *zunemusic* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel112.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel112.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox43.Checked Then
            MetroLabel113.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowsmaps* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel113.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel113.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox44.Checked Then
            MetroLabel114.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *solitairecollection* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel114.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel114.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox45.Checked Then
            MetroLabel115.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *bingfinance* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel115.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel115.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox46.Checked Then
            MetroLabel116.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *zunevideo* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel116.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel116.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox47.Checked Then
            MetroLabel117.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *bingnews* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel117.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel117.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox48.Checked Then
            MetroLabel118.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *onenote* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel118.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel118.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox49.Checked Then
            MetroLabel119.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *people* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel119.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel119.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox50.Checked Then
            MetroLabel120.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowsphone* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel120.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel120.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox51.Checked Then
            MetroLabel121.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *photos* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel121.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel121.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox52.Checked Then
            MetroLabel122.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *windowsstore* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel122.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel122.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox53.Checked Then
            MetroLabel123.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *bingsports* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel123.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel123.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox54.Checked Then
            MetroLabel124.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *soundrecorder* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel124.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel124.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox55.Checked Then
            MetroLabel125.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *bingweather* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel125.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel125.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox56.Checked Then
            MetroLabel126.Text = "Working"
            Try
                Dim process As New Process()
                Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                processStartInfo.CreateNoWindow = True
                processStartInfo.Arguments = "Get-AppxPackage *xboxapp* | Remove-AppxPackage"
                processStartInfo.Verb = "runas"
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
                processStartInfo.FileName = "powershell"
                process.StartInfo = processStartInfo
                process.Start()
                process.WaitForExit()
                MetroLabel126.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel126.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox58.Checked Then
            MetroLabel131.Text = "Working"
            Try
                Dim processName As String = "OneDrive"
                Dim byteArray As Integer = BitConverter.ToInt32(BitConverter.GetBytes(&HB090010D), 0)
                Dim onePath As String
                Try
                    Process.GetProcessesByName(processName)(0).Kill()
                Catch __unusedException1__ As Exception
                End Try
                If amd64 Then
                    onePath = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) & "\OneDriveSetup.exe"
                Else
                    onePath = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\OneDriveSetup.exe"
                End If
                Try
                    Process.Start(onePath, "/uninstall")
                Catch ex As Exception
                End Try
                Dim onePaths As String() = {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\OneDrive", Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) & "OneDriveTemp", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\OneDrive", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft OneDrive"}
                For Each dir As String In onePaths
                    If Directory.Exists(dir) Then
                        Try
                            Directory.Delete(dir, True)
                        Catch __unusedException1__ As Exception
                        End Try
                    End If
                Next
                Dim oneKey As String = "CLSID\{018D5C66-4533-4307-9B53-224DE2ED1FE6}"
                Registry.ClassesRoot.CreateSubKey(oneKey)
                Dim baseReg = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64)
                Try
                    Using key = Registry.ClassesRoot.OpenSubKey(oneKey, True)
                        key.SetValue("System.IsPinnedToNameSpaceTree", 0, RegistryValueKind.DWord)
                    End Using
                    If amd64 Then
                        Using key = baseReg.OpenSubKey(oneKey, True)
                            If key IsNot Nothing Then
                                key.SetValue("System.IsPinnedToNameSpaceTree", 0, RegistryValueKind.DWord)
                            End If
                        End Using
                    End If
                    Using key = Registry.ClassesRoot.OpenSubKey(oneKey & "\ShellFolder", True)
                        If key IsNot Nothing Then
                            key.SetValue("Attributes", byteArray, RegistryValueKind.DWord)
                        End If
                    End Using
                    If amd64 Then
                        Using key = baseReg.OpenSubKey(oneKey & "\ShellFolder", True)
                            If key IsNot Nothing Then
                                key.SetValue("Attributes", byteArray, RegistryValueKind.DWord)
                            End If
                        End Using
                    End If
                    baseReg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                    Using key = baseReg.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                        key.DeleteValue("OneDriveSetup", False)
                    End Using
                Catch ex As Exception
                End Try
                baseReg.Dispose()
                CMDHelper.RunCommand("SCHTASKS /Delete /TN ""OneDrive Standalone Update Task"" /F")
                CMDHelper.RunCommand("SCHTASKS /Delete /TN ""OneDrive Standalone Update Task v2"" /F")
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\OneDrive", "DisableFileSyncNGSC", 1)
                CMDHelper.RunCommand("/c taskkill /f /im OneDrive.exe > NUL 2>&1")
                CMDHelper.RunCommand("/c ping 127.0.0.1 -n 5 > NUL 2>&1")
                CMDHelper.RunCommand("/c ping 127.0.0.1 -n 5 > NUL 2>&1")
                CMDHelper.RunCommand("/c rd \""%USERPROFILE%\\OneDrive\"" /Q /S > NUL 2>&1")
                CMDHelper.RunCommand("/c rd \""C:\\OneDriveTemp\"" /Q /S > NUL 2>&1")
                CMDHelper.RunCommand("/c rd \""%LOCALAPPDATA%\\Microsoft\\OneDrive\"" /Q /S > NUL 2>&1")
                CMDHelper.RunCommand("/c rd \""%PROGRAMDATA%\\Microsoft OneDrive\"" /Q /S > NUL 2>&1")
                CMDHelper.RunCommand("/c REG DELETE \""HKEY_CLASSES_ROOT\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}\"" /f > NUL 2>&1")
                CMDHelper.RunCommand("/c REG DELETE \""HKEY_CLASSES_ROOT\\Wow6432Node\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}\"" /f > NUL 2>&1")
                MetroLabel131.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel131.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox64.Checked Then
            MetroLabel140.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WSearch", "Start", 0)
                MetroLabel140.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel140.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox65.Checked Then
            MetroLabel142.Text = "Working"
            Try
                If System.IO.File.Exists("C:\Windows\System32\drivers\etc\hosts") Then
                    Try
                        Dim readFile As String = System.IO.File.ReadAllText("C:\Windows\System32\drivers\etc\hosts")
                        Dim hosts() As String = {"iplogger.org", "grabify.link", "api.grabify.link", "blasze.com", "fortnite-stats.site", "minecraft-skins.xyz", "booter.icu", "discordcrypt.xyz", "iplogger.ru", "gyazo.nl", "webresolver.nl"}
                        For Each host As String In hosts
                            readFile += Environment.NewLine + "127.0.0.1 " + host
                        Next
                        System.IO.File.WriteAllText("C:\Windows\System32\drivers\etc\hosts", readFile)
                    Catch ex As Exception
                    End Try
                End If
                MetroLabel142.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel142.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox66.Checked Then
            MetroLabel144.Text = "Working"
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "ClearPageFileAtShutdown", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "DisablePagingExecutive", 1)
                MetroLabel144.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel144.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox67.Checked Then
            MetroLabel146.Text = "Working"
            Try
                Dim cacheSize As UInt32 = 0
                Using Mo As New System.Management.ManagementObject("Win32_Processor.DeviceID='CPU0'")
                    cacheSize = UInt32.Parse((Mo("L2CacheSize")))
                End Using
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "SecondLevelDataCache", 0)
                MetroLabel146.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel146.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox69.Checked Then
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR", "value", 0)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehavior", 2)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", 2)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 1)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowCompatible", 1)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 1)
                Registry.SetValue("HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_EFSEFeatureFlags", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GameDVR", "AllowGameDVR", 0)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 0)
                MetroLabel148.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel148.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox70.Checked Then
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerSettings\54533251-82be-4824-96c1-47b60b740d00\943c8cb6-6f93-4227-ad87-e9a3feec08d1", "Attributes", 2)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerSettings\54533251-82be-4824-96c1-47b60b740d00\0cc5b647-c1df-4637-891a-dec35c318583", "ValueMax", 100)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerSettings\54533251-82be-4824-96c1-47b60b740d00\0cc5b647-c1df-4637-891a-dec35c318583", "ValueMin", 100)
                MetroLabel150.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel150.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox71.Checked Then
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\svsvc", "Start", 4)
                MetroLabel152.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel152.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox72.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "ColorPrevalence", 0)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "EnableTrasparency", 1)
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 0)
                MetroLabel154.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel154.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox73.Checked Then
            Try
                Dim libKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\"
                Dim guidArray As String() = {"{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", "{7d83ee9b-2244-4e70-b1f5-5393042af1e4}", "{f42ee2d3-909f-4907-8871-4c22fc0bf756}", "{0ddd015d-b06c-45d5-8c4c-f59713854639}", "{a0c69a99-21c8-4671-8703-7934162fcf1d}", "{35286a68-3c57-41a1-bbb1-0eae73d76c95}", "{31C0DD25-9439-4F12-BF41-7FF4EDA38722}"}
                Dim finalKey As String
                Dim baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                For Each guid In guidArray
                    Try
                        finalKey = libKey & guid & "\PropertyBag"
                        Using key = baseReg.CreateSubKey(finalKey, True)
                            key.SetValue("ThisPCPolicy", "Hide")
                        End Using
                        If amd64 Then
                            Using key = Registry.LocalMachine.CreateSubKey(finalKey)
                                key.SetValue("ThisPCPolicy", "Hide")
                            End Using
                        End If
                    Catch ex As Exception
                    End Try
                Next
                baseReg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                Try
                    Dim pinLib As String = "Software\Classes\CLSID\{031E4825-7B94-4dc3-B131-E946B44C8DD5}"
                    baseReg.CreateSubKey(pinLib)
                    Using key = baseReg.OpenSubKey(pinLib, True)
                        key.SetValue("System.IsPinnedToNameSpaceTree", 1, RegistryValueKind.DWord)
                    End Using
                    Using key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer", True)
                        key.SetValue("ShowFrequent", 0, RegistryValueKind.DWord)
                        key.SetValue("ShowRecent", 0, RegistryValueKind.DWord)
                    End Using
                    Using key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", True)
                        key.SetValue("LaunchTo", 1, RegistryValueKind.DWord)
                    End Using
                    Using key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", True)
                        key.SetValue("ShowSyncProviderNotifications", 0, RegistryValueKind.DWord)
                    End Using
                    pinLib = "Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People"
                    Registry.CurrentUser.CreateSubKey(pinLib)
                    Using key = Registry.CurrentUser.OpenSubKey(pinLib, True)
                        key.SetValue("PeopleBand", 0, RegistryValueKind.DWord)
                    End Using
                Catch ex As Exception
                End Try
                MetroLabel156.Text = "Success"
                My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel156.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox74.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableNotificationCenter", 1)
                MetroLabel159.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel159.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox75.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer", "EnableLegacyBalloonNotifications", 1)
                MetroLabel159.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel159.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox76.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer", "NoWindowMinimizingShortcuts", 1)
                MetroLabel162.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel162.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox77.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "WindowArrangementActive", 0)
                MetroLabel164.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel164.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox78.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisablePreviewDesktop", 1)
                MetroLabel166.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel166.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox79.Checked Then
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "CortanaEnabled", 0)
                MetroLabel172.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel172.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox80.Checked Then
            Try
                CMDHelper.RunCommand("/c net stop DiagTrack ")
                CMDHelper.RunCommand("/c net stop diagnosticshub.standardcollector.service ")
                CMDHelper.RunCommand("/c net stop dmwappushservice ")
                CMDHelper.RunCommand("/c net stop WMPNetworkSvc ")
                CMDHelper.RunCommand("/c sc config DiagTrack start=disabled ")
                CMDHelper.RunCommand("/c sc config diagnosticshub.standardcollector.service start=disabled ")
                CMDHelper.RunCommand("/c sc config dmwappushservice start=disabled ")
                CMDHelper.RunCommand("/c sc config WMPNetworkSvc start=disabled ")
                CMDHelper.RunCommand("/c REG ADD HKLM\\SYSTEM\\ControlSet001\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener /v Start /t REG_DWORD /d 0 /f")
                CMDHelper.RunCommand("/c sc delete dmwappushsvc")
                CMDHelper.RunCommand("/c sc delete \""Diagnostics Tracking Service\""")
                CMDHelper.RunCommand("/c sc delete diagtrack")
                CMDHelper.RunCommand("/c reg add \""HKLM\\SYSTEM\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\FirewallRules\""  /v \""{60E6D465-398E-4850-BE86-7EF7620A2377}\"" /t REG_SZ /d  \""v2.24|Action=Block|Active=TRUE|Dir=Out|App=C:  \\windows\\system32\\svchost.exe|Svc=DiagTrack|Name=Windows  Telemetry|\"" /f")
                CMDHelper.RunCommand("/c reg add \""HKLM\\SYSTEM\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\FirewallRules\""  /v \""{2765E0F4-2918-4A46-B9C9-43CDD8FCBA2B}\"" /t REG_SZ /d  \""v2.24|Action=Block|Active=TRUE|Dir=Out|App=C:     \\windows\\systemapps\\microsoft.windows.cortana_cw5n1h2txyewy\\searchui.exe|Name=Search  And Cortana  application|AppPkgId=S-1-15-2-1861897761-1695161497-2927542615-642690995-327840285-2659745135-2630312742|\""  /f")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata\"" / v \ ""PreventDeviceMetadataFromNetwork\"" / t REG_DWORD /d 1 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\"" /v \""AllowTelemetry\"" /t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\MRT\"" / v \ ""DontOfferThroughWUAU\"" / t REG_DWORD /d 1 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows\"" /v \""CEIPEnable\"" /t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat\"" / v \ ""AITEnable\"" / t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat\"" /v \""DisableUAR\"" /t REG_DWORD /d 1 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\"" / v \ ""AllowTelemetry\"" / t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener\"" /v \""Start\"" /t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\SQMLogger\"" /v \""Start\"" /t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg add \""HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Siuf\\Rules\"" /v \""NumberOfSIUFInPeriod\"" /t REG_DWORD /d 0 /f ")
                CMDHelper.RunCommand("/c reg delete \""HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Siuf\\Rules\"" /v \""PeriodInNanoSeconds\"" /f ")
                Dim disabletaskslist As String() = {"Microsoft\Office\Office 15 Subscription Heartbeat", "Microsoft\Office\Office ClickToRun Service Monitor", "Microsoft\Office\OfficeTelemetry\AgentFallBack2016", "Microsoft\Office\OfficeTelemetry\OfficeTelemetryAgentLogOn2016", "Microsoft\Office\OfficeTelemetryAgentFallBack", "Microsoft\Office\OfficeTelemetryAgentFallBack2016", "Microsoft\Office\OfficeTelemetryAgentLogOn", "Microsoft\Office\OfficeTelemetryAgentLogOn2016", "Microsoft\Windows\AppID\SmartScreenSpecific", "Microsoft\Windows\Application Experience\AitAgent", "Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser", "Microsoft\Windows\Application Experience\ProgramDataUpdater", "Microsoft\Windows\Application Experience\StartupAppTask", "Microsoft\Windows\Autochk\Proxy", "Microsoft\Windows\CloudExperienceHost\CreateObjectTask", "Microsoft\Windows\Customer Experience Improvement Program\BthSQM", "Microsoft\Windows\Customer Experience Improvement Program\Consolidator", "Microsoft\Windows\Customer Experience Improvement Program\KernelCeipTask", "Microsoft\Windows\Customer Experience Improvement Program\Uploader", "Microsoft\Windows\Customer Experience Improvement Program\UsbCeip", "Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector", "Microsoft\Windows\DiskFootprint\Diagnostics", "Microsoft\Windows\FileHistory\File History (maintenance mode)", "Microsoft\Windows\Maintenance\WinSAT", "Microsoft\Windows\Media Center\ActivateWindowsSearch", "Microsoft\Windows\Media Center\ConfigureInternetTimeService", "Microsoft\Windows\Media Center\DispatchRecoveryTasks", "Microsoft\Windows\Media Center\ehDRMInit", "Microsoft\Windows\Media Center\InstallPlayReady", "Microsoft\Windows\Media Center\mcupdate", "Microsoft\Windows\Media Center\MediaCenterRecoveryTask", "Microsoft\Windows\Media Center\ObjectStoreRecoveryTask", "Microsoft\Windows\Media Center\OCURActivate", "Microsoft\Windows\Media Center\OCURDiscovery", "Microsoft\Windows\Media Center\PBDADiscovery", "Microsoft\Windows\Media Center\PBDADiscoveryW1", "Microsoft\Windows\Media Center\PBDADiscoveryW2", "Microsoft\Windows\Media Center\PvrRecoveryTask", "Microsoft\Windows\Media Center\PvrScheduleTask", "Microsoft\Windows\Media Center\RegisterSearch", "Microsoft\Windows\Media Center\ReindexSearchRoot", "Microsoft\Windows\Media Center\SqlLiteRecoveryTask", "Microsoft\Windows\Media Center\UpdateRecordPath", "Microsoft\Windows\PI\Sqm-Tasks", "Microsoft\Windows\Power Efficiency Diagnostics\AnalyzeSystem", "Microsoft\Windows\Shell\FamilySafetyMonitor", "Microsoft\Windows\Shell\FamilySafetyRefresh", "Microsoft\Windows\Shell\FamilySafetyUpload", "Microsoft\Windows\Windows Error Reporting\QueueReporting"}
                For Each currentTask In disabletaskslist
                    CMDHelper.RunCommand("SCHTASKS", $"/Change /TN \""{currentTask}\"" /disable")
                Next
                Try
                    Dim hostsdomains As String() = {"a.ads1.msn.com", "a.ads2.msads.net", "a.ads2.msn.com", "a.rad.msn.com", "a-0001.a-msedge.net", "a-0002.a-msedge.net", "a-0003.a-msedge.net", "a-0004.a-msedge.net", "a-0005.a-msedge.net", "a-0006.a-msedge.net", "a-0007.a-msedge.net", "a-0008.a-msedge.net", "a-0009.a-msedge.net", "ac3.msn.com", "ad.doubleclick.net", "adnexus.net", "adnxs.com", "ads.msn.com", "ads1.msads.net", "ads1.msn.com", "aidps.atdmt.com", "aka-cdn-ns.adtech.de", "a-msedge.net", "apps.skype.com", "az361816.vo.msecnd.net", "az512334.vo.msecnd.net", "b.ads1.msn.com", "b.ads2.msads.net", "b.rad.msn.com", "bs.serving-sys.com", "c.atdmt.com", "c.msn.com", "ca.telemetry.microsoft.com", "cache.datamart.windows.com", "cdn.atdmt.com", "cds26.ams9.msecn.net", "choice.microsoft.com", "choice.microsoft.com.nsatc.net", "compatexchange.cloudapp.net", "corp.sts.microsoft.com", "corpext.msitadfs.glbdns2.microsoft.com", "cs1.wpc.v0cdn.net", "db3aqu.atdmt.com", "db3wns2011111.wns.windows.com", "df.telemetry.microsoft.com", "diagnostics.support.microsoft.com", "ec.atdmt.com", "fe2.update.microsoft.com.akadns.net", "fe3.delivery.dsp.mp.microsoft.com.nsatc.net", "feedback.microsoft-hohm.com", "feedback.search.microsoft.com", "feedback.windows.com", "flex.msn.com", "g.msn.com", "h1.msn.com", "i1.services.social.microsoft.com", "i1.services.social.microsoft.com.nsatc.net", "lb1.www.ms.akadns.net", "live.rads.msn.com", "m.adnxs.com", "m.hotmail.com", "msedge.net", "msftncsi.com", "msnbot-207-46-194-33.search.msn.com", "msnbot-65-55-108-23.search.msn.com", "msntest.serving-sys.com", "oca.telemetry.microsoft.com", "oca.telemetry.microsoft.com.nsatc.net", "pre.footprintpredict.com", "preview.msn.com", "pricelist.skype.com", "rad.live.com", "rad.msn.com", "redir.metaservices.microsoft.com", "reports.wes.df.telemetry.microsoft.com", "s.gateway.messenger.live.com", "s0.2mdn.net", "schemas.microsoft.akadns.net ", "secure.adnxs.com", "secure.flashtalking.com", "services.wes.df.telemetry.microsoft.com", "settings.data.microsoft.com", "settings-sandbox.data.microsoft.com", "settings-win.data.microsoft.com", "sls.update.microsoft.com.akadns.net", "sO.2mdn.net", "spynet2.microsoft.com", "spynetalt.microsoft.com", "sqm.df.telemetry.microsoft.com", "sqm.telemetry.microsoft.com", "sqm.telemetry.microsoft.com.nsatc.net", "ssw.live.com", "static.2mdn.net", "statsfe1.ws.microsoft.com", "statsfe2.update.microsoft.com.akadns.net", "statsfe2.ws.microsoft.com", "survey.watson.microsoft.com", "telecommand.telemetry.microsoft.com", "telecommand.telemetry.microsoft.com.nsatc.net", "telecommand.telemetry.microsoft.com.nsat­c.net", "telemetry.appex.bing.net", "telemetry.appex.bing.net:443", "telemetry.microsoft.com", "telemetry.urs.microsoft.com", "ui.skype.com", "v10.vortex-win.data.microsoft.com", "view.atdmt.com", "vortex.data.microsoft.com", "vortex-bn2.metron.live.com.nsatc.net", "vortex-cy2.metron.live.com.nsatc.net", "vortex-sandbox.data.microsoft.com", "vortex-win.data.microsoft.com", "watson.live.com", "watson.microsoft.com", "watson.ppe.telemetry.microsoft.com", "watson.telemetry.microsoft.com", "watson.telemetry.microsoft.com.nsatc.net", "wes.df.telemetry.microsoft.com", "win10.ipv6.microsoft.com", "www.msftncsi.com"}
                    Dim hostslocation = "C:\Windows\System32\drivers\etc\hosts"
                    Dim hosts As String = Nothing
                    If File.Exists(hostslocation) Then
                        hosts = File.ReadAllText(hostslocation)
                        File.SetAttributes(hostslocation, FileAttributes.Normal)
                        DestroyFile(hostslocation)
                    End If
                    File.Create(hostslocation).Close()
                    File.WriteAllText(hostslocation, hosts & Environment.NewLine)
                    For Each currentHostsDomain As String In hostsdomains
                        If hosts.IndexOf(currentHostsDomain, StringComparison.Ordinal) = -1 Then
                            CMDHelper.RunCommand($"/c echo 0.0.0.0 {currentHostsDomain} >> \""{hostslocation}\""")
                        End If
                    Next
                Catch ex As Exception
                End Try
                CMDHelper.RunCommand("/c ipconfig /flushdns")
                Dim ipAddr As String() = {"104.96.147.3", "111.221.29.177", "111.221.29.253", "111.221.64.0-111.221.127.255", "131.253.40.37", "134.170.115.60", "134.170.165.248", "134.170.165.253", "134.170.185.70", "134.170.30.202", "137.116.81.24", "137.117.235.16", "157.55.129.21", "157.55.130.0-157.55.130.255", "157.55.133.204", "157.55.235.0-157.55.235.255", "157.55.236.0-157.55.236.255", "157.55.240.220", "157.55.52.0-157.55.52.255", "157.55.56.0-157.55.56.255", "157.56.106.189", "157.56.121.89", "157.56.124.87", "157.56.91.77", "157.56.96.54", "168.63.108.233", "191.232.139.2", "191.232.139.254", "191.232.80.58", "191.232.80.62", "191.237.208.126", "195.138.255.0-195.138.255.255", "2.22.61.43", "2.22.61.66", "204.79.197.200", "207.46.101.29", "207.46.114.58", "207.46.223.94", "207.68.166.254", "212.30.134.204", "212.30.134.205", "213.199.179.0-213.199.179.255", "23.102.21.4", "23.218.212.69", "23.223.20.82", "23.57.101.163", "23.57.107.163", "23.57.107.27", "23.99.10.11", "64.4.23.0-64.4.23.255", "64.4.54.22", "64.4.54.32", "64.4.6.100", "65.39.117.230", "65.39.117.230", "65.52.100.11", "65.52.100.7", "65.52.100.9", "65.52.100.91", "65.52.100.92", "65.52.100.93", "65.52.100.94", "65.52.108.29", "65.52.108.33", "65.55.108.23", "65.55.138.114", "65.55.138.126", "65.55.138.186", "65.55.223.0-65.55.223.255", "65.55.252.63", "65.55.252.71", "65.55.252.92", "65.55.252.93", "65.55.29.238", "65.55.39.10", "77.67.29.176"}
                For Each currentIpAddr In ipAddr
                    CMDHelper.RunCommand($"/c route -p ADD {currentIpAddr} MASK 255.255.255.255 0.0.0.0")
                    CMDHelper.RunCommand($"/c route -p change {currentIpAddr} MASK 255.255.255.255 0.0.0.0 if 1")
                    CMDHelper.RunCommand($"/c netsh advfirewall firewall delete rule name=\""{currentIpAddr}_Block\""")
                    CMDHelper.RunCommand(String.Format("/c netsh advfirewall firewall add rule name=""{0}_Block"" dir=out interface=any action=block remoteip={0}", currentIpAddr))
                Next
                CMDHelper.RunCommand("/c netsh advfirewall firewall delete rule name=""Explorer.EXE_BLOCK""")
                CMDHelper.RunCommand($"/c netsh advfirewall firewall add rule name=\""Explorer.EXE_BLOCK\"" dir=out interface=any action=block program=\""{Path.GetPathRoot(Environment.SystemDirectory)}Windows\\explorer.exe\""")
                CMDHelper.RunCommand("/c netsh advfirewall firewall delete rule name=""WSearch_Block""")
                CMDHelper.RunCommand("/c netsh advfirewall firewall add rule name=""WSearch_Block"" dir=out interface=any action=block service=WSearch")
                Dim hostsFile As String = System.IO.File.ReadAllText("C:\Windows\System32\drivers\etc\hosts")
                hostsFile += Environment.NewLine + antiAdwareHosts
                System.IO.File.WriteAllText("C:\Windows\System32\drivers\etc\hosts", hostsFile)
                MetroLabel174.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel174.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox81.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{2297E4E2-5DBE-466D-A12B-0F8286F0D9CA}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{2EEF81BE-33FA-4800-9670-1CD474972C3F}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{52079E78-A92B-413F-B213-E8FE35712E72}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{7D7E8402-7C54-4821-A34E-AEEFD62DED93}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{8BC668CF-7728-45BD-93F8-CF2B3B41D7AB}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{9231CB4C-BF57-4AF3-8C55-FDA7BFCC04C5}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{992AFA70-6F47-4148-B3E9-3003349C1548}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{D89823BA-7180-4B81-B50C-7E471E6121A3}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{E390DF20-07DF-446D-B962-F5C953062741}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{E5323777-F976-4f5b-9B55-B94699C46E44}", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\LooselyCoupled", "Value", "Deny")
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\InputPersonalization", "RestrictImplicitInkCollection", 1)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Siuf\Rules", "NumberOfSIUFInPeriod", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Siuf\Rules", "PeriodInNanoSeconds", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\TabletPC", "PreventHandwritingDataSharing", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports", "PreventHandwritingErrorReports", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\AppCompat", "DisableInventory", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization", "NoLockScreenCamera", 1)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Input\TIPC", "Enabled", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Biometrics", "Enabled", 0)
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\CredU", "DisablePasswordReveal", 1)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync", "SyncPolicy", 5)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Personalization", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\BrowserSettings", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Credentials", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Language", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Accessibility", "Enabled", 0)
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Windows", "Enabled", 0)
                MetroLabel176.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel176.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox82.Checked Then
            Try
                CMDHelper.RunCommand("/c net stop wuauserv")
                CMDHelper.RunCommand("powershell", "-command \""Set-Service -Name wuauserv -StartupType Disabled\""")
                CMDHelper.RunCommand("/c netsh advfirewall firewall delete rule name=\""WindowsUpdateBlock\""")
                CMDHelper.RunCommand("/c netsh advfirewall firewall add rule name=\""WindowsUpdateBlock\"" dir=out interface=any action=block service=wuauserv")
                MetroLabel178.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel178.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox83.Checked Then
            Try
                Dim windowsIdentityUser = System.Security.Principal.WindowsIdentity.GetCurrent()
                Dim gwxDir = Environment.SystemDirectory & "\GWX"
                If windowsIdentityUser IsNot Nothing Then
                    Dim userName = windowsIdentityUser.Name.Split("\"c)(1)
                    If Directory.Exists(gwxDir) Then
                        CMDHelper.RunCommand("/c TASKKILL /F /IM gwx.exe")
                        CMDHelper.RunCommand($"/c takeown /f \""{gwxDir}\"" /d y")
                        CMDHelper.RunCommand($"/c icacls \""{gwxDir}\"" /grant {userName}:F /q")
                        CMDHelper.RunCommand($"/c rmdir /s /q {gwxDir}")
                    End If
                End If
                MetroLabel180.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel180.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox84.Checked Then
            Try
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.ico", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.tiff", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.bmp", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.png", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.gif", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.jpeg", Nothing, "PhotoViewer.FileAssoc.Tiff")
                Registry.SetValue("HKEY_CURRENT_USER\Software\Classes\.jpg", Nothing, "PhotoViewer.FileAssoc.Tiff")
                MetroLabel182.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel182.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox85.Checked Then
            Try
                Registry.SetValue("HKEY_CLASSES_ROOT\AllFilesystemObjects\shellex\ContextMenuHandlers\Copy To", Nothing, "{C2FBB630-2971-11D1-A18C-00C04FD75D13}")
                MetroLabel184.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel184.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        If MetroCheckBox86.Checked Then
            Try
                Registry.SetValue("HKEY_CLASSES_ROOT\AllFilesystemObjects\shellex\ContextMenuHandlers\Move To", Nothing, "{C2FBB630-2971-11D1-A18C-00C04FD75D13}")
                MetroLabel186.Text = "Success"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            Catch ex As Exception
                MetroLabel186.Text = "Failed"
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
            End Try
        End If
        MetroButton3.Text = "Apply all optimizations to your device"
        My.Computer.Audio.Play(My.Resources.notice, AudioPlayMode.Background)
        MessageBox.Show("You succesfully optimized your computer. Please, restart.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Private Sub MetroButton3_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton3.MouseLeave
        GroupBox4.Select()
    End Sub
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MessageBox.Show("Are you sure you wanna exit from the application?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        Else
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
            Try
                thread1.Abort()
            Catch ex As Exception
            End Try
            Try
                thread2.Abort()
            Catch ex As Exception
            End Try
            Try
                thread3.Abort()
            Catch ex As Exception
            End Try
            Try
                thread4.Abort()
            Catch ex As Exception
            End Try
            Try
                thread6.Abort()
            Catch ex As Exception
            End Try
            Try
                thread7.Abort()
            Catch ex As Exception
            End Try
            Try
                thread8.Abort()
            Catch ex As Exception
            End Try
            Try
                thread9.Abort()
            Catch ex As Exception
            End Try
            Try
                thread10.Abort()
            Catch ex As Exception
            End Try
            Dim ourKey As RegistryKey = Registry.LocalMachine
            ourKey = ourKey.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)
            ourKey.SetValue("AutoRestartShell", 1)
            WindowsUtils.HideDesktopIcons(False)
            WindowsUtils.HideTaskBar(False)
            Dim explorer As Boolean
            For Each proc As Process In Process.GetProcesses()
                If proc.ProcessName.ToLower().Equals("explorer") Then
                    explorer = True
                    Exit For
                End If
            Next
            If Not explorer Then
                Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"))
            End If
            If Not System.IO.Directory.Exists("C:\ZeroCleaner") Then
                System.IO.Directory.CreateDirectory("C:\ZeroCleaner")
            End If
            Dim processNames As String = ""
            Dim processWindows As String = ""
            For i = 0 To ListBox1.Items.Count - 1
                Dim item As String = ListBox1.Items(i).ToString()
                If processNames = "" Then
                    processNames = item
                Else
                    processNames += Environment.NewLine + item
                End If
            Next
            For i = 0 To ListBox2.Items.Count - 1
                Dim item As String = ListBox2.Items(i).ToString()
                If processWindows = "" Then
                    processWindows = item
                Else
                    processWindows += Environment.NewLine + item
                End If
            Next
            System.IO.File.WriteAllText("C:\ZeroCleaner\process_names.txt", processNames)
            System.IO.File.WriteAllText("C:\ZeroCleaner\process_windows.txt", processWindows)
            GC.Collect()
        End If
    End Sub
    Private Sub AdaptSize_Tick(sender As Object, e As EventArgs) Handles AdaptSize.Tick
        Me.Size = New Size(824, 631)
        MetroLabel193.Text = foundMalwares.Count.ToString()
        MetroLabel194.Text = cleanedMalwares.ToString()
    End Sub
    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        If MetroButton4.Text = "Stop checking" Then
            Try
                thread4.Abort()
            Catch ex As Exception
            End Try
            MetroButton4.Text = "Check for a running miner in your computer"
        Else
            MetroLabel167.Text = "PID"
            MetroLabel187.Text = "PATH"
            MetroLabel188.Text = "RISK"
            MetroButton4.Text = "Stop checking"
            Panel6.Height = 426
            Panel7.Height = 426
            thread4 = New System.Threading.Thread(AddressOf CheckForMiner)
            thread4.Start()
        End If
    End Sub
    Private Sub MetroButton4_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton4.MouseLeave
        Panel5.Select()
    End Sub
    Public Sub CheckForMiner()
        For Each process As Process In Process.GetProcesses()
            Try
                If Not process.Id = Process.GetCurrentProcess().Id Then
                    If Not process.MainModule.FileName = "" Then
                        Dim perfCounter As PerformanceCounter = New PerformanceCounter("Process", "% Processor Time", process.ProcessName)
                        perfCounter.NextValue()
                        System.Threading.Thread.Sleep(5000)
                        Dim per As Double = perfCounter.NextValue() / Environment.ProcessorCount
                        If MetroLabel167.Text = "PID" Then
                            MetroLabel167.Text += Environment.NewLine + Environment.NewLine + process.Id.ToString()
                        Else
                            MetroLabel167.Text += Environment.NewLine + process.Id.ToString()
                        End If
                        Dim newName As String = ""
                        If process.MainModule.FileName.Length > 90 Then
                            For i = 0 To 87
                                newName += process.MainModule.FileName(i).ToString()
                            Next
                            newName += "..."
                        Else
                            newName = process.MainModule.FileName
                        End If
                        If MetroLabel187.Text = "PATH" Then
                            MetroLabel187.Text += Environment.NewLine + Environment.NewLine + newName
                        Else
                            MetroLabel187.Text += Environment.NewLine + newName
                        End If
                        If per > 63.5 Then
                            If MetroLabel188.Text = "RISK" Then
                                MetroLabel188.Text += Environment.NewLine + Environment.NewLine + "HIGH"
                            Else
                                MetroLabel188.Text += Environment.NewLine + "HIGH"
                            End If
                        ElseIf per > 45.0 Then
                            If MetroLabel188.Text = "RISK" Then
                                MetroLabel188.Text += Environment.NewLine + Environment.NewLine + "LOW"
                            Else
                                MetroLabel188.Text += Environment.NewLine + "LOW"
                            End If
                        Else
                            If MetroLabel188.Text = "RISK" Then
                                MetroLabel188.Text += Environment.NewLine + Environment.NewLine + "NO"
                            Else
                                MetroLabel188.Text += Environment.NewLine + "NO"
                            End If
                        End If
                        Panel6.Height += 4
                        Panel7.Height += 4
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        MetroButton4.Text = "Check for a running miner in your computer"
    End Sub
    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Try
            Dim textboxona As New TextBox With {.Text = MetroLabel167.Text}
            Dim risks As New TextBox With {.Text = MetroLabel188.Text}
            Dim completeText As String = "REPORT OF ZEROCLEANER ANTI MINER:" + Environment.NewLine
            For i = 2 To textboxona.Lines.Count - 1
                completeText += Environment.NewLine + Environment.NewLine + "PID: " + textboxona.Lines(i).ToString() + " - PATH: " + Process.GetProcessById(Integer.Parse(textboxona.Lines(i).ToString())).MainModule.FileName + " - RISK: " + risks.Lines(i).ToString()
            Next
            System.IO.File.WriteAllText(Application.StartupPath + "\report.txt", completeText)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MetroButton5_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton5.MouseLeave
        Panel5.Select()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If MessageBox.Show("When you use the optimizer, your Windows 10 Search Bar would not work anymore because you are going to disable some Windows functions that make it working. You can install the Windows 7 Classic Bar from Internet that is 100% faster more than the Windows 10 Bar Search, so it can result as an advantage. Link: http://www.classicshell.net | Do you wanna open it now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Process.Start("https://www.classicshell.net")
        End If
    End Sub
    Public Sub PersonalCheck()
        If Not Me.Text = "ZeroCleaner" Or Not Me.MaximizeBox = False Or Not Me.MinimizeBox = True Or Not Me.ControlBox = True Then
            End
        End If
    End Sub
    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton7.Text = "Stop Boosting" Then
            If MetroCheckBox87.Checked Then
                Dim ourKey As RegistryKey = Registry.LocalMachine
                ourKey = ourKey.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)
                ourKey.SetValue("AutoRestartShell", 1)
                Try
                    Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"))
                Catch ex As Exception
                End Try
            End If
            If MetroCheckBox92.Checked Then
                WindowsUtils.HideDesktopIcons(False)
            End If
            If MetroCheckBox93.Checked Then
                WindowsUtils.HideTaskBar(False)
            End If
            If MetroCheckBox94.Checked Then
                Me.TopMost = False
            End If
            MetroButton7.Text = "Start Boosting"
            My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
        Else
            If System.IO.File.Exists(MetroTextBox1.Text) Then
                Try
                    If MetroCheckBox87.Checked Then
                        Dim ourKey As RegistryKey = Registry.LocalMachine
                        ourKey = ourKey.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)
                        ourKey.SetValue("AutoRestartShell", 0)
                    End If
                    Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo()
                    processStartInfo.Verb = "runas"
                    processStartInfo.FileName = MetroTextBox1.Text
                    processStartInfo.Arguments = ""
                    If MetroCheckBox90.Checked Then
                        processStartInfo.Arguments = "-w"
                    End If
                    If MetroCheckBox91.Checked Then
                        If processStartInfo.Arguments = "" Then
                            processStartInfo.Arguments = "-USEALLAVAILABLECORES -sm4"
                        Else
                            processStartInfo.Arguments += " -USEALLAVAILABLECORES -sm4"
                        End If
                    End If
                    If MetroCheckBox92.Checked Then
                        WindowsUtils.HideDesktopIcons(True)
                    End If
                    If MetroCheckBox93.Checked Then
                        WindowsUtils.HideTaskBar(True)
                    End If
                    If MetroCheckBox94.Checked Then
                        Me.TopMost = True
                    End If
                    For Each process As Process In Process.GetProcesses()
                        Dim processName As String = process.ProcessName.ToLower()
                        Dim windowTitle As String = process.MainWindowTitle.ToLower()
                        If process.ProcessName.ToLower.Contains("boot") Or process.ProcessName.ToLower.Contains("system") Then
                            Continue For
                        End If
                        If processName.ToLower() = "explorer" Then
                            If MetroCheckBox87.Checked Then
                                Try
                                    Shell("taskkill /F /IM explorer.exe")
                                Catch ex As Exception
                                End Try
                            End If
                            Continue For
                        End If
                        If MetroCheckBox89.Checked Then
                            Dim can As Boolean = True
                            For i = 0 To ListBox1.Items.Count - 1
                                If processName = ListBox1.Items(i).ToString().ToLower() Then
                                    can = False
                                End If
                            Next
                            If can Then
                                Try
                                    process.Kill()
                                Catch ex As Exception
                                End Try
                                Continue For
                            End If
                        End If
                        If MetroCheckBox88.Checked Then
                            Dim can As Boolean = True
                            For i = 0 To ListBox2.Items.Count - 1
                                If windowTitle = ListBox2.Items(i).ToString().ToLower() Then
                                    can = False
                                End If
                            Next
                            If can Then
                                Try
                                    process.Kill()
                                Catch ex As Exception
                                End Try
                                Continue For
                            End If
                        End If
                    Next
                    My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
                    Process.Start(processStartInfo)
                    MetroButton7.Text = "Stop Boosting"
                    If MetroCheckBox92.Checked Then
                        WindowsUtils.HideDesktopIcons(True)
                    End If
                    If MetroCheckBox93.Checked Then
                        WindowsUtils.HideTaskBar(True)
                    End If
                Catch ex As Exception
                    My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
                    MessageBox.Show("Failed to start the game!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.Background)
                MessageBox.Show("This file does not exist!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
            MetroTextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If Not ListBox1.Items.Contains(MetroTextBox2.Text) And Not MetroTextBox2.Text.Replace(" ", "") = "" Then
            ListBox1.Items.Add(MetroTextBox2.Text)
        End If
        MetroTextBox2.Text = ""
    End Sub
    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If Not ListBox1.SelectedItem = "" And Not ListBox1.SelectedItem = Nothing Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If
    End Sub
    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles MetroButton10.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        ListBox1.Items.Clear()
    End Sub
    Private Sub MetroButton13_Click(sender As Object, e As EventArgs) Handles MetroButton13.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If Not ListBox2.Items.Contains(MetroTextBox3.Text) And Not MetroTextBox3.Text.Replace(" ", "") = "" Then
            ListBox2.Items.Add(MetroTextBox3.Text)
        End If
        MetroTextBox3.Text = ""
    End Sub
    Private Sub MetroButton12_Click(sender As Object, e As EventArgs) Handles MetroButton12.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If Not ListBox2.SelectedItem = "" And Not ListBox2.SelectedItem = Nothing Then
            ListBox2.Items.Remove(ListBox2.SelectedItem)
        End If
    End Sub
    Private Sub MetroButton11_Click(sender As Object, e As EventArgs) Handles MetroButton11.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        ListBox2.Items.Clear()
    End Sub
    Private Sub MetroTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox2.KeyDown
        If e.KeyValue = Keys.Enter Then
            MetroButton8.PerformClick()
        End If
    End Sub
    Private Sub MetroTextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox3.KeyDown
        If e.KeyValue = Keys.Enter Then
            MetroButton13.PerformClick()
        End If
    End Sub
    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.Delete Then
            MetroButton9.PerformClick()
        End If
    End Sub
    Private Sub ListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox2.KeyDown
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.Delete Then
            MetroButton13.PerformClick()
        End If
    End Sub
    Private Sub MetroButton6_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton6.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton7_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton7.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton8_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton8.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton9_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton9.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton10_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton10.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton11_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton11.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton12_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton12.MouseLeave
        GroupBox5.Select()
    End Sub
    Private Sub MetroButton13_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton13.MouseLeave
        GroupBox5.Select()
    End Sub
    Public Sub DestroyFile(ByVal File As String)
        If Not System.IO.File.Exists(File) Then
            Exit Sub
        End If
        Try
            System.IO.File.SetAttributes(File, FileAttributes.Normal)
        Catch ex As Exception
        End Try
        Try
            SetAttr(File, vbNormal)
        Catch ex As Exception
        End Try
        Try
            System.IO.File.Delete(File)
        Catch ex As Exception
        End Try
        Try
            If System.IO.File.Exists(File) Then
                My.Computer.FileSystem.DeleteFile(File)
            End If
        Catch ex As Exception
        End Try
        Try
            If System.IO.File.Exists(File) Then
                FileSystem.Kill(File)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub DestroyDirectory(ByVal Directory As String, ByVal qualcosa As Boolean)
        If Not System.IO.Directory.Exists(Directory) Then
            Exit Sub
        End If
        Try
            Dim FolderInfo = New IO.DirectoryInfo(Directory)
            Try
                Try
                    For Each File In FolderInfo.GetFiles
                        Try
                            DestroyFile(File.FullName)
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
                Try
                    For Each SubFolderInfo In FolderInfo.GetDirectories
                        Try
                            DestroyDirectory(SubFolderInfo.FullName, True)
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Try
            If System.IO.Directory.Exists(Directory) Then
                System.IO.Directory.Delete(Directory, True)
            End If
        Catch ex As Exception
        End Try
        Try
            If System.IO.Directory.Exists(Directory) Then
                System.IO.Directory.Delete(Directory)
            End If
        Catch ex As Exception
        End Try
        Try
            If System.IO.Directory.Exists(Directory) Then
                FileSystem.RmDir(Directory)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function ListDirectory(ByVal Directory As String) As List(Of String)
        If Not System.IO.Directory.Exists(Directory) Then
            Return Nothing
        End If
        Dim allFiles As List(Of String) = New List(Of String)
        Try
            Dim FolderInfo = New IO.DirectoryInfo(Directory)
            Try
                Try
                    For Each File In FolderInfo.GetFiles
                        Try
                            allFiles.Add(File.FullName)
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
                Try
                    For Each SubFolderInfo In FolderInfo.GetDirectories
                        Try
                            For Each fileListed As String In ListDirectory(SubFolderInfo.FullName)
                                allFiles.Add(fileListed)
                            Next
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Return allFiles
    End Function
    Private Sub MetroButton14_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton14.MouseLeave
        MetroTabPage3.Select()
    End Sub
    Private Sub MetroButton15_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton15.MouseLeave
        MetroTabPage3.Select()
    End Sub
    Private Sub MetroButton14_Click(sender As Object, e As EventArgs) Handles MetroButton14.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton14.Text = "Stop scanning for malwares" Then
            MetroButton14.Text = "Scan your computer for malwares"
        Else
            foundMalwares.Clear()
            MetroButton14.Text = "Stop scanning for malwares"
            thread9 = New System.Threading.Thread(AddressOf ScanMalwares)
            thread9.Start()
        End If
    End Sub
    Private Sub MetroButton15_Click(sender As Object, e As EventArgs) Handles MetroButton15.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton15.Text = "Stop killing malwares" Then
            MetroButton15.Text = "Kill all found malwares"
        Else
            cleanedMalwares = 0
            MetroButton15.Text = "Stop killing malwares"
            thread10 = New System.Threading.Thread(AddressOf KillMalwares)
            thread10.Start()
        End If
    End Sub
    Public Sub ScanMalwares()
        Dim webClient As New System.Net.WebClient
        Dim directories() As String = {"C:\Users\" + Environment.UserName + "\AppData\Roaming\UctTimer", "C:\ProgramData\IOBit\Advanced SystemCare",
            "C:\Users\" + Environment.UserName + "\AppData\Roaming\IOBit\Advanced SystemCare",
            "C:\Users\" + Environment.UserName + "\AppData\Roaming\Opera Software\Opera Stable\databases",
            "C:\Users\" + Environment.UserName + "\AppData\Roaming\Opera Software\Opera Stable\IndexedDB", "C:\ProgramData\UAB",
            "C:\Users\" + Environment.UserName + "\AppData\Local\Opera Software", "C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla",
            "C:\Users\" + Environment.UserName + "\AppData\Local\Mozilla\Firefox\Profiles", "C:\Users\" + Environment.UserName + "\appdata\Local\Opera Software\Opera Stable\Cache",
            "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\GPUCache", "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\ShaderCache\GPUCache",
            "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\File System", "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\CacheStorage",
            "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\Database", "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Service Worker\ScriptCache",
            "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List Icons", "C:\Users\" + Environment.UserName + "\appdata\Roaming\Opera Software\Opera Stable\Jump List IconsOld",
            ""}
        Dim files() As String = {""}
        Dim generals() As String = {Paths.GoogleChromeCache, Paths.GoogleChromeCookies, Paths.GoogleChromeCookiesDBs, Paths.GoogleChromeCookiesLocalStorage, Paths.GoogleChromeInternetHistory,
            Paths.MozillaFireFoxCache, Paths.MozillaFireFoxCookies, Paths.MozillaFireFoxCookiesWebAppsStore, Paths.MozillaFireFoxDownloads, Paths.MozillaFireFoxFormHistory, Paths.MozillaFirefoxSessionStore,
            Paths.MozillaFirefoxSessionStoreBackup, Paths.SafariCache, Paths.SafariHistory, Paths.SafariHistoryDownloadsPlist, Paths.SafariHistoryLastSessionPlist, Paths.SafariHistoryPlist, Paths.SafariWebpagePreviews,
            Paths.InternetExplorerCookies, Paths.InternetExplorerCookiesDomStore, Paths.InternetExplorerHistory, Paths.InternetExplorerIndexDat_1, Paths.InternetExplorerIndexDat_2,
            Paths.InternetExplorerIndexDat_3, Paths.InternetExplorerIndexDat_4, Paths.InternetExplorerIndexDat_5, Paths.InternetExplorerIndexDat_6, Paths.InternetExplorerRecentlyTypedUrls,
            Paths.InternetExplorerTemps}
        For Each dir As String In directories
            If System.IO.Directory.Exists(dir) Then
                For Each fileListed As String In ListDirectory(dir)
                    foundMalwares.Add(fileListed)
                Next
                foundMalwares.Add(dir)
            End If
        Next
        For Each file As String In files
            If System.IO.File.Exists(file) Then
                foundMalwares.Add(file)
            End If
        Next
        For Each general As String In generals
            If System.IO.Directory.Exists(general) Then
                For Each fileListed As String In ListDirectory(general)
                    foundMalwares.Add(fileListed)
                Next
                foundMalwares.Add(general)
            ElseIf System.IO.File.Exists(general) Then
                foundMalwares.Add(general)
            End If
        Next
        If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DC3_FEXEC") IsNot Nothing Then
            foundMalwares.Add("a")
        End If
        If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\APN PIP") IsNot Nothing Then
            foundMalwares.Add("a")
        End If
        MetroButton14.Text = "Scan your computer for malwares"
        My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
    End Sub
    Public Sub KillMalwares()
        For Each fileFound As String In foundMalwares
            Try
                If System.IO.File.Exists(fileFound) Then
                    DestroyFile(fileFound)
                    cleanedMalwares += 1
                End If
            Catch ex As Exception
            End Try
            Try
                If System.IO.Directory.Exists(fileFound) Then
                    DestroyDirectory(fileFound, True)
                    cleanedMalwares += 1
                End If
            Catch ex As Exception
            End Try
        Next
        If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DC3_FEXEC") IsNot Nothing Then
            Try
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\DC3_FEXEC")
                cleanedMalwares += 1
            Catch ex As Exception
            End Try
        End If
        If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\APN PIP") IsNot Nothing Then
            Try
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\APN PIP")
                cleanedMalwares += 1
            Catch ex As Exception
            End Try
        End If
        MetroButton15.Text = "Kill all found malwares"
        My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
    End Sub
    Private Sub MetroButton16_Click(sender As Object, e As EventArgs) Handles MetroButton16.Click
        My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        If MetroButton16.Text = "Stop wiping free space" Then
            MetroButton1.Text = "Wipe free space now"
            Try
                thread11.Abort()
            Catch ex As Exception
            End Try
            thread12 = New System.Threading.Thread(AddressOf StopWipeFreeSpace)
            thread12.Start()
        Else
            MetroButton16.Text = "Stop wiping free space"
            Try
                thread11.Abort()
            Catch ex As Exception
            End Try
            Try
                thread12.Abort()
            Catch ex As Exception
            End Try
            thread11 = New System.Threading.Thread(AddressOf StartWipeFreeSpace)
            thread11.Start()
        End If
    End Sub
    Public Sub StartWipeFreeSpace()
        ComboBox1.Invoke(Sub() ComboBox1.Enabled = False)
        MetroButton16.Text = "Stop wiping free space"
        Dim theDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim freeSpace As Long = 0
        For Each d As DriveInfo In theDrives
            If d.IsReady Then
                If d.Name = ComboBox1.SelectedItem.ToString() Then
                    freeSpace = d.TotalFreeSpace
                    Exit For
                End If
            End If
        Next
        If System.IO.Directory.Exists(ComboBox1.SelectedItem.ToString() + "Wipe free space") Then
            DestroyDirectory(ComboBox1.SelectedItem.ToString() + "Wipe free space", True)
        End If
        System.IO.Directory.CreateDirectory(ComboBox1.SelectedItem.ToString() + "Wipe free space")
        For i = 0 To freeSpace - 1
            Try
                System.IO.File.WriteAllText(ComboBox1.SelectedItem.ToString() + "Wipe free space\" + RandomUtils.RandomNormalString(64), "A")
            Catch ex As Exception
                Exit For
            End Try
        Next
        StopWipeFreeSpace()
    End Sub
    Public Sub StopWipeFreeSpace()
        If System.IO.Directory.Exists(ComboBox1.SelectedItem.ToString() + "Wipe free space") Then
            DestroyDirectory(ComboBox1.SelectedItem.ToString() + "Wipe free space", True)
        End If
        MetroButton16.Text = "Wipe free space now"
        My.Computer.Audio.Play(My.Resources.success, AudioPlayMode.Background)
        ComboBox1.Invoke(Sub() ComboBox1.Enabled = True)
    End Sub
    Private Sub MetroButton16_MouseLeave(sender As Object, e As EventArgs) Handles MetroButton16.MouseLeave
        MetroTabPage7.Select()
    End Sub
End Class