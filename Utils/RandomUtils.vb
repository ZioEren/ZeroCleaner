﻿Public Class RandomUtils
    Public Shared rand As New Random()
    Public Shared UsedStrings As List(Of String) = New List(Of String)
    Public Shared Function RandomChineseString(ByVal length As Integer) As String
        Dim Chr As String = "顾氏家族的成泽是顾商城公司的首席执行官顾太太希望她的生物孙"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To length
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        If UsedStrings.Contains(sb.ToString()) Then
            Do Until Not UsedStrings.Contains(sb.ToString())
                sb.Clear()
                For i As Integer = 1 To length
                    Dim idx As Integer = rand.Next(0, Chr.Length)
                    sb.Append(Chr.Substring(idx, 1))
                Next
            Loop
        End If
        UsedStrings.Add(sb.ToString())
        Return sb.ToString
    End Function
    Public Shared Function RandomNormalString(ByVal length As Integer) As String
        Dim Chr As String = "abcedfghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To length
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        If UsedStrings.Contains(sb.ToString()) Then
            Do Until Not UsedStrings.Contains(sb.ToString())
                sb.Clear()
                For i As Integer = 1 To length
                    Dim idx As Integer = rand.Next(0, Chr.Length)
                    sb.Append(Chr.Substring(idx, 1))
                Next
            Loop
        End If
        UsedStrings.Add(sb.ToString())
        Return sb.ToString
    End Function
    Public Shared Function RandomCapitalString(ByVal Caps As Integer) As String
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To Caps
            Dim idx As Integer = rand.Next(100, 900)
            sb.Append("\u" + idx.ToString())
        Next
        sb.Append("\")
        If UsedStrings.Contains(sb.ToString()) Then
            Do Until Not UsedStrings.Contains(sb.ToString())
                sb.Clear()
                For i As Integer = 1 To Caps
                    Dim idx As Integer = rand.Next(100, 900)
                    sb.Append("\u" + idx.ToString())
                Next
                sb.Append("\")
            Loop
        End If
        UsedStrings.Add(sb.ToString())
        Return sb.ToString()
    End Function
    Public Shared Function GetRandomNumber(ByVal cap As Integer) As Integer
        Return rand.Next(0, cap)
    End Function
    Public Shared Function GetRandomNumber(ByVal min As Integer, ByVal cap As Integer) As Integer
        Return rand.Next(min, cap)
    End Function
End Class