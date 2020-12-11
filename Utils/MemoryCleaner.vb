Imports System.Threading
Imports System.Runtime
Imports System.Runtime.InteropServices
Public Class MemoryCleaner
    Public Shared isStarted As Boolean = False
    <DllImport("psapi.dll")>
    Private Shared Function EmptyWorkingSet(ByVal hwProc As IntPtr) As Integer
    End Function
    Public Shared Sub StartMemoryCleaner()
        If Not isStarted Then
            Dim threader As Thread = New Thread(AddressOf ClearMemory)
            threader.Start()
        End If
    End Sub
    Public Shared Sub ClearMemory()
        While True
            Thread.Sleep(500)
            EmptyWorkingSet(Process.GetCurrentProcess().Handle)
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce
            GC.Collect(GC.MaxGeneration)
            GC.WaitForPendingFinalizers()
        End While
    End Sub
End Class