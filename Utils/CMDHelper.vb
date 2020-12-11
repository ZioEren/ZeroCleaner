Public Class CMDHelper
    Public Shared Sub RunCommand(ByVal command As String)
        Using process = New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.UseShellExecute = False
            process.StartInfo.Verb = "runas"
            process.StartInfo.RedirectStandardInput = True
            process.StartInfo.RedirectStandardOutput = True
            Try
                process.Start()
                process.StandardInput.WriteLine(command)
                process.StandardInput.Close()
                process.WaitForExit()
            Catch __unusedException1__ As Exception
            End Try
        End Using
    End Sub
    Public Shared Sub RunCommand(ByVal command As String, ByVal arguments As String)
        Using process = New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.UseShellExecute = False
            process.StartInfo.Arguments = arguments
            process.StartInfo.Verb = "runas"
            process.StartInfo.RedirectStandardInput = True
            process.StartInfo.RedirectStandardOutput = True
            Try
                process.Start()
                process.StandardInput.WriteLine(command)
                process.StandardInput.Close()
                process.WaitForExit()
            Catch __unusedException1__ As Exception
            End Try
        End Using
    End Sub
    Public Shared Function RunCommandReturn(ByVal command As String) As String
        Using process = New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardInput = True
            process.StartInfo.RedirectStandardOutput = True
            Try
                process.Start()
                process.StandardInput.WriteLine(command)
                process.StandardInput.Close()
                process.WaitForExit()
                Return process.StandardOutput.ReadToEnd()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        Return Nothing
    End Function
End Class