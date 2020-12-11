Imports System.Runtime.InteropServices
Public Class WindowsUtils
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Public Const SWP_HIDEWINDOW = &H80
    Public Const SWP_SHOWWINDOW = &H40
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetWindow(ByVal hWnd As IntPtr, ByVal uCmd As UInteger) As IntPtr
    End Function
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Integer, ByVal hWnd2 As Integer, ByVal lpsz1 As String, ByVal lpsz2 As String) As Integer
    Private Enum GetWindowCmd As UInteger
        GW_HWNDFIRST = 0
        GW_HWNDLAST = 1
        GW_HWNDNEXT = 2
        GW_HWNDPREV = 3
        GW_OWNER = 4
        GW_CHILD = 5
        GW_ENABLEDPOPUP = 6
    End Enum
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
    End Function
    Private Enum SW As Int32
        Hide = 0
        Normal = 1
        ShowMinimized = 2
        ShowMaximized = 3
        ShowNoActivate = 4
        Show = 5
        Minimize = 6
        ShowMinNoActive = 7
        ShowNA = 8
        Restore = 9
        ShowDefault = 10
        ForceMinimize = 11
        Max = 11
    End Enum
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function IsWindowVisible(ByVal hwnd As IntPtr) As Boolean
    End Function
    Public Shared Sub HideTaskBar(ByVal Toggle As Boolean)
        If Toggle Then
            Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
            SetWindowPos(intReturn, 0, 0, 0, 0, 0, SWP_HIDEWINDOW)
        Else
            Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
            SetWindowPos(intReturn, 0, 0, 0, 0, 0, SWP_SHOWWINDOW)
        End If
    End Sub
    Public Shared Sub HideDesktopIcons(ByVal Toggle As Boolean)
        Dim hWnd As IntPtr = FindWindow("ProgMan", Nothing)
        hWnd = GetWindow(hWnd, GetWindowCmd.GW_CHILD)
        If Toggle Then
            If IsWindowVisible(hWnd) Then
                ShowWindow(hWnd, SW.Hide)
            End If
        Else
            If Not IsWindowVisible(hWnd) Then
                ShowWindow(hWnd, SW.ShowNoActivate)
            End If
        End If
    End Sub
End Class