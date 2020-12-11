'ACleaner - Temp file scanning and cleaning software
'Copyright (C) 2011  Ernest Jr
'
'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'any later version.
'
'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
'You should have received a copy of the GNU General Public License
'along with this program.  If not, see <http://www.gnu.org/licenses/>

Imports System.IO

Module Paths

    Sub New()

    End Sub

#Region " Base Path Methods "
    ''' <summary>
    ''' This method is only declared to make, making changes to all variables that require
    ''' the AppData Roaming path, easier.
    ''' </summary>
    ''' <returns>Returns the user profile AppData Roaming path</returns>
    ''' <remarks>ie: C:\Users\%USERPROFILE%\AppData\Roaming</remarks>
    Private Function profileAppDataRoaming() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    End Function

    ''' <summary>
    ''' User profile application data local path.
    ''' </summary>
    ''' <returns>AppData Local</returns>
    ''' <remarks>N/A</remarks>
    Private Function profileAppDataLocal() As String

        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    End Function

    ''' <summary>
    ''' User profile application data local low path.
    ''' </summary>
    ''' <returns>Returns the user profile LocalLow AppData path</returns>
    ''' <remarks>N/A</remarks>
    Private Function profileAppDataLocalLow() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "Low"
    End Function

    ''' <summary>
    ''' System32
    ''' </summary>
    ''' <returns>Returns System32 path</returns>
    ''' <remarks>N/A</remarks>
    Private Function system32Path() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.System)
    End Function

    ''' <summary>
    ''' OS drive program data
    ''' </summary>
    ''' <returns>Returns the program data path</returns>
    ''' <remarks>N/A</remarks>
    Private Function programData() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    End Function

    ''' <summary>
    ''' OS drive path
    ''' </summary>
    ''' <returns>%OSDRIVE%\Windows</returns>
    ''' <remarks>ie. C:\Windows</remarks>
    Private Function osDriveWindows() As String

        Return Environment.GetEnvironmentVariable("WINDIR", EnvironmentVariableTarget.Machine)
    End Function

    ''' <summary>
    ''' OS drive
    ''' </summary>
    ''' <returns>Drive letter OS is installed on</returns>
    ''' <remarks>Typically is C:\</remarks>
    Private Function osDrive() As String

        Return system32Path.Substring(0, 3)

    End Function

    ''' <summary>
    ''' This method is used to identify the FF paths via the unique profile name
    ''' </summary>
    ''' <param name="pathType">Path type of path, ie: cookies, downloads, formhistory, cache</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function mozillaFireFoxPaths(ByVal pathType As String) As String
        Dim rootPath = profileAppDataRoaming() & "\Mozilla\Firefox\Profiles"
        Dim rootPath2 = profileAppDataLocal() & "\Mozilla\Firefox\Profiles"

        If Directory.Exists(rootPath) Then
            Dim defaultProfilePaths = Directory.GetDirectories(rootPath, "*.default")

            For Each subfolderPath In defaultProfilePaths
                Select Case pathType
                    Case "cookies"
                        Return subfolderPath & "\cookies.sqlite"
                    Case "webappsstore"
                        Return subfolderPath & "\webappsstore.sqlite"
                    Case "downloads"
                        Return subfolderPath & "\downloads.sqlite"
                    Case "formhistory"
                        Return subfolderPath & "\formhistory.sqlite"
                    Case "cache"
                        Dim defaultProfilePaths2 = Directory.GetDirectories(rootPath2, "*.default")

                        For Each subfolderPath2 In defaultProfilePaths2
                            Return subfolderPath2 & "\cache"
                        Next
                    Case "sessionstore.js"
                        Return subfolderPath & "\sessionstore.js"
                    Case "sessionstore.bak"
                        Return subfolderPath & "\sessionstore.bak"
                    Case Else
                        Throw New ArgumentException("Exception Occured. Invalid argument for mozillaFireFoxPaths method.")
                End Select
            Next
        End If
    End Function
#End Region

#Region " Internet Explorer "
    ''' <summary>
    ''' Path to Internet Explorer's cookies
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public InternetExplorerCookies As String = profileAppDataRoaming() & "\Microsoft\Windows\Cookies"
    ''' <summary>
    ''' Path to IE's cookies via DOM Store
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public InternetExplorerCookiesDomStore As String = profileAppDataLocalLow() & "\Microsoft\Internet Explorer\DOMStore"
    ''' <summary>
    ''' Path to Internet Explorer's temp files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public InternetExplorerTemps As String = profileAppDataLocal() & "\Microsoft\Windows\Temporary Internet Files"
    ''' <summary>
    ''' Path to Internet Explorer's history
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public InternetExplorerHistory As String = profileAppDataLocal() & "\Microsoft\Windows\History"
    ''' <summary>
    ''' Path to Internet Explorer's recently typed URLs. See remarks.
    ''' </summary>
    ''' <remarks>IE's recently typed URLs are stored in the regstry, under HKCU.</remarks>
    Public InternetExplorerRecentlyTypedUrls As String = "SOFTWARE\Microsoft\Internet Explorer\TypedURLs"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_1 As String = profileAppDataRoaming() & "\Microsoft\Windows\PrivacIE\index.dat"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_2 As String = profileAppDataRoaming() & "\Microsoft\Windows\PrivacIE\Low\index.dat"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_3 As String = profileAppDataRoaming() & "\Microsoft\Windows\IECompactCache\index.dat"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_4 As String = profileAppDataRoaming() & "\Microsoft\Windows\IECompactCache\Low\index.dat"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_5 As String = profileAppDataRoaming() & "\Microsoft\Windows\IETldCache\index.dat"
    ''' <summary>
    ''' Path to one of Internet Explorer's index.dat files
    ''' </summary>
    ''' <remarks>File, not directory. Index.dat files are usually locked. So you'll need to unlock it before deleting.</remarks>
    Public InternetExplorerIndexDat_6 As String = profileAppDataRoaming() & "\Microsoft\Windows\IETldCache\Low\index.dat"
#End Region

#Region " Google Chrome "
    ''' <summary>
    ''' Path to Google Chrome's cookies. See Remarks.
    ''' </summary>
    ''' <remarks>This is NOT a directory and is instead a file with no extension. I think it's a SQLITE database.
    ''' Either way, Chrome must be closed in order to delete this file and clear the cookies.</remarks>
    Public GoogleChromeCookies As String = profileAppDataLocal() & "\Google\Chrome\User Data\Default\Cookies"
    ''' <summary>
    ''' Path to Google Chrome's database cookies.
    ''' </summary>
    ''' <remarks>Search recursively - directory</remarks>
    Public GoogleChromeCookiesDBs As String = profileAppDataLocal() & "\Google\Chrome\User Data\Default\databases"
    ''' <summary>
    ''' Path to Google Chrome's local storage cookies.
    ''' </summary>
    ''' <remarks> Search non-recursively - directory</remarks>
    Public GoogleChromeCookiesLocalStorage As String = profileAppDataLocal() & "\Google\Chrome\User Data\Default\Local Storage"
    ''' <summary>
    ''' Path to Google Chrome's cache.
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public GoogleChromeCache As String = profileAppDataLocal() & "\Google\Chrome\User Data\Default\Cache"
    ''' <summary>
    ''' Path to Google Chrome's history directory. See Remarks.
    ''' </summary>
    ''' <remarks>The history is contained in four different files that all contain the word "History" and must be deleted
    ''' in order to clear all of chrome's history. They look something like "History Index 2011-00-journal", "History Index 2011-00", 
    ''' "History", "History-journal". It's best to loop through each file in the directory, non-recursively, and filter for "History".</remarks>
    Public GoogleChromeInternetHistory As String = profileAppDataLocal() & "\Google\Chrome\User Data\Default"
#End Region

#Region " Mozilla FireFox "
    ''' <summary>
    ''' Mozilla Firefox cookies path
    ''' </summary>
    ''' <remarks>Path is file not directory</remarks>
    Public MozillaFireFoxCookies As String = mozillaFireFoxPaths("cookies")
    ''' <summary>
    ''' Mozilla Firefox
    ''' </summary>
    ''' <remarks>Path is file, not directory</remarks>
    Public MozillaFireFoxCookiesWebAppsStore As String = mozillaFireFoxPaths("webappsstore")
    ''' <summary>
    ''' Mozilla Firefox Download history path
    ''' </summary>
    ''' <remarks>Path is file not directory</remarks>
    Public MozillaFireFoxDownloads As String = mozillaFireFoxPaths("downloads")
    ''' <summary>
    ''' Mozilla Firefox form history path
    ''' </summary>
    ''' <remarks>Path is file not directory</remarks>
    Public MozillaFireFoxFormHistory As String = mozillaFireFoxPaths("formhistory")
    ''' <summary>
    ''' Mozilla Firefox cache path
    ''' </summary>
    ''' <remarks>Path is directory, not path</remarks>
    Public MozillaFireFoxCache As String = mozillaFireFoxPaths("cache")
    ''' <summary>
    ''' Mozilla Firefox session store path
    ''' </summary>
    ''' <remarks>Path is a file, not a directory</remarks>
    Public MozillaFirefoxSessionStore As String = mozillaFireFoxPaths("sessionstore.js")
    ''' <summary>
    ''' Mozilla Firefox session store backup path
    ''' </summary>
    ''' <remarks>Path is a file, not a directory</remarks>
    Public MozillaFirefoxSessionStoreBackup As String = mozillaFireFoxPaths("sessionstore.bak")
#End Region

#Region " Safari "
    ''' <summary>
    ''' Safari cache path
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public SafariCache As String = profileAppDataRoaming() & "\Apple Computer\Safari\Cache.db"
    ''' <summary>
    ''' Safari History list
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public SafariHistoryPlist As String = profileAppDataRoaming() & "\Apple Computer\Safari\History.plist"
    ''' <summary>
    ''' Safari last session path
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public SafariHistoryLastSessionPlist As String = profileAppDataRoaming() & "\Apple Computer\Safari\LastSession.plist"
    ''' <summary>
    ''' Safari History downloads list
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public SafariHistoryDownloadsPlist As String = profileAppDataRoaming() & "\Apple Computer\Safari\Downloads.plist"
    ''' <summary>
    ''' Safari  History path
    ''' </summary>
    ''' <remarks>Directory</remarks>
    Public SafariHistory As String = profileAppDataLocal() & "\Apple Computer\Safari\History"
    ''' <summary>
    ''' Safari Webpage Previews
    ''' </summary>
    ''' <remarks>Directory</remarks>
    Public SafariWebpagePreviews As String = profileAppDataLocal() & "\Apple Computer\Safari\Webpage Previews"
#End Region

#Region " Opera "
    ''' <summary>
    ''' Opera Cache
    ''' </summary>
    ''' <remarks>Search recursively</remarks>
    Public OperaCache As String = profileAppDataLocal() & "\Opera\Opera\cache"
    ''' <summary>
    ''' Opera OP Cache
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public OperaOPCache As String = profileAppDataLocal() & "\Opera\Opera\opcache"
    ''' <summary>
    ''' Opera Icon Cache
    ''' </summary>
    ''' <remarks>Search recursively</remarks>
    Public OperaIconCache As String = profileAppDataLocal() & "\Opera\Opera\icons\cache"
    ''' <summary>
    ''' Opera Internet History
    ''' </summary>
    ''' <remarks>Search recursively</remarks>
    Public OperaInternetHistory_1 As String = profileAppDataLocal() & "\Opera\Opera\vps"
    ''' <summary>
    ''' Opera Internet History - DAT Files
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaInternetHistory_2 As String = profileAppDataRoaming() & "\Opera\Opera\global_history.dat"
    ''' <summary>
    ''' Opera Internet History
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaInternetHistory_3 As String = profileAppDataRoaming() & "\Opera\Opera\download.dat"
    ''' <summary>
    ''' Opera Internet History
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaInternetHistory_4 As String = profileAppDataRoaming() & "\Opera\Opera\vlink4.dat"
    ''' <summary>
    ''' Opera Internet History
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaInternetHistory_5 As String = profileAppDataRoaming() & "\Opera\Opera\typed_history.xml"
    ''' <summary>
    ''' Opera Internet History
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaInternetHistory_6 As String = profileAppDataRoaming() & "\Opera\Opera\sessions\autosave.win"
    ''' <summary>
    ''' Opera Cookies
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public OperaCookies As String = profileAppDataRoaming() & "\Opera\Opera\cookies4.dat"
    ''' <summary>
    ''' Opera Website Icons
    ''' </summary>
    ''' <remarks>Do not recurse</remarks>
    Public OperaWebsiteIcon As String = profileAppDataLocal() & "\icons"
    ''' <summary>
    ''' Opera Temporary Downloads - Download History
    ''' </summary>
    ''' <remarks></remarks>
    Public OperaCacheTempDownloads As String = profileAppDataLocal() & "\Opera\Opera\temporary_downloads"
#End Region

#Region " Internet - uTorrent, Java "
    ''' <summary>
    ''' Main uTorrent temp files. Typically "resume.dat.old" and "settings.dat.old"
    ''' </summary>
    ''' <remarks>Filter with *.old</remarks>
    Public uTorrentTempFiles As String = profileAppDataRoaming() & "\uTorrent"
    ''' <summary>
    ''' uTorrent DLL Image Cache
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public uTorrentDllImageCache As String = profileAppDataRoaming() & "\uTorrent\dllimagecache"
    ''' <summary>
    ''' Sun Java Cache
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public SunJavaCache As String = profileAppDataLocalLow() & "\Sun\Java\Deployment\cache\6.0"
    ''' <summary>
    ''' Sun Java System Cache
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public SunJavaSystemCache As String = profileAppDataLocalLow() & "\Sun\Java\Deployment\SystemCache\6.0"
    ''' <summary>
    ''' FileZilla Recent Server List
    ''' </summary>
    ''' <remarks>File, not directory</remarks>
    Public FileZillaRecentServers As String = profileAppDataRoaming() & "\FileZila\recentservers.xml"
#End Region

#Region " Antivirus "
    ''' <summary>
    ''' AVG Antivirus 10 log files.
    ''' </summary>
    ''' <remarks>Filter for .log and .xml files</remarks>
    Public AvgAntivirus10Log As String = programData() & "\avg10\Log"
    ''' <summary>
    ''' AVG Antivirus 10 backup files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public AvgAntivirus10Backup As String = programData() & "\avg10\update\backup"
    ''' <summary>
    ''' AVG Antivirus 10 misc files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public AvgAntivirus10Misc As String = programData() & "\avg10\IDS\profile"
    ''' <summary>
    ''' AVG Antivirus 10 temp files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public AvgAntivirus10Temps As String = programData() & "\avg10\Temp"

    ''' <summary>
    ''' MalwareBytes log files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public MalwareBytesLogs As String = profileAppDataRoaming() & "\Malwarebytes\Malwarebytes' Anti-Malware\Logs"
    ''' <summary>
    ''' MalwareBytes backup files
    ''' </summary>
    ''' <remarks>Filter for "BACKUP" and "QUAR" files</remarks>
    Public MalwareBytesQuarantineBackup As String = profileAppDataRoaming() & "\Malwarebytes\Malwarebytes' Anti-Malware\Quarantine"

    ''' <summary>
    ''' Windows Defender quick history
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsDefenderHistoryQuick As String = programData() & "\Microsoft\Windows Defender\Scans\History\Results\Quick"
    ''' <summary>
    ''' Windows Defender resource history
    ''' </summary>
    ''' <remarks></remarks>
    Public WindowsDefenderHistoryResource As String = programData() & "\Microsoft\Windows Defender\Scans\History\Results\Resource"

    ''' <summary>
    ''' Spybot SD log files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public SpybotSdLogs As String = programData() & "\Spybot - Search & Destroy\Logs"
    ''' <summary>
    ''' Spybot SD statistics ini file
    ''' </summary>
    ''' <remarks>This is a file, not a directory</remarks>
    Public SpybotSdIni As String = programData() & "\Spybot - Search & Destroy\Statistics.ini"
    ''' <summary>
    ''' Spybot SD Backup files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public SpybotSdBackups As String = programData() & "\Spybot - Search & Destroy\Backups"
#End Region

#Region " Windows Explorer "
    ''' <summary>
    ''' Windows Explorer recent files list
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsExplorerRecent As String = profileAppDataRoaming() & "\Microsoft\Windows\Recent"
    ''' <summary>
    ''' Windows Explorer thumbnail cache
    ''' </summary>
    ''' <remarks></remarks>
    Public WindowsExplorerThumbnailCache As String = profileAppDataLocal() & "\MICROSOFT\Windows\Explorer"
#End Region

#Region " System "
    ''' <summary>
    ''' Windows system temp
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsTempFiles As String = osDriveWindows() & "\Temp"
    ''' <summary>
    ''' User temp files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public UserTemps As String = profileAppDataLocal() & "\Temp"
    ''' <summary>
    ''' ChkDsk file fragments
    ''' </summary>
    ''' <remarks>Filter with *.chk</remarks>
    Public ChkDskFileFragments As String = osDrive.Substring(0, 1)

    ''' <summary>
    ''' Windows log files
    ''' </summary>
    ''' <remarks>Filter with *.log</remarks>
    Public WindowsLogFiles As String = osDrive.Substring(0, 1)
    ''' <summary>
    ''' Windows error reporting files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsErrorReporting_1 As String = profileAppDataLocal() & "\Microsoft\Windows\WER\ReportArchive"
    ''' <summary>
    ''' Windows error reporting files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsErrorReporting_2 As String = profileAppDataLocal() & "\Microsoft\Windows\WER\ReportQueue"
    ''' <summary>
    ''' Windows error reporting files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsErrorReporting_3 As String = programData() & "\Windows\WER\ReportArchive"
    ''' <summary>
    ''' Windows error reporting files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsErrorReporting_4 As String = programData() & "\Microsoft\Windows\WER\ReportQueue"
#End Region

#Region " Advanced "
    ''' <summary>
    ''' Windows prefetch data
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public PrefetchData As String = "C:\Windows\Prefetch"

#End Region

#Region " Media "
    ''' <summary>
    ''' Windows Media Player temp files
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public WindowsMediaPlayer As String = profileAppDataLocal() & "\Microsoft\Media Player"
    ''' <summary>
    ''' Quick Time player cache
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public QuickTimePlayerCache As String = profileAppDataLocalLow() & "\Apple Computer\QuickTime\downloads"
    ''' <summary>
    ''' QT session data
    ''' </summary>
    ''' <remarks>Handle as file, not directory</remarks>
    Public QuickTimerPlayer As String = profileAppDataLocalLow() & "\Apple Computer\QuickTime\QTPlayerSession.xml"
    ''' <summary>
    ''' Adobe Flash Player
    ''' </summary>
    ''' <remarks>N/A</remarks>
    Public AdobeFlashPlayer As String = profileAppDataRoaming() & "\Macromedia"
#End Region

#Region " Misc Applications "
    ''' <summary>
    ''' Paint.Net temp files
    ''' </summary>
    ''' <remarks>Recurse through each folder in this directory.</remarks>
    Public PaintNet As String = profileAppDataLocal() & "\Paint.NET"
#End Region

#Region " Visual Studio "
    ''' <summary>
    ''' VS 2010 File MRU List
    ''' </summary>
    ''' <remarks>HKCU</remarks>
    Public VisualStudio2010FileMRUList As String = "SOFTWARE\Microsoft\VisualStudio\10.0\FileMRUList"
    ''' <summary>
    ''' VS 2010 Project MRU List
    ''' </summary>
    ''' <remarks>HKCU</remarks>
    Public VisualStudio2010ProjectMRUList As String = "SOFTWARE\Microsoft\VisualStudio\10.0\ProjectMRUList"
    ''' <summary>
    ''' VS 2008 File MRU List
    ''' </summary>
    ''' <remarks></remarks>
    Public VisualStudio2008FileMRUList As String = "SOFTWARE\Microsoft\VisualStudio\9.0\FileMRUList"
    ''' <summary>
    ''' VS 2008 Project MRU List
    ''' </summary>
    ''' <remarks>HKCU</remarks>
    Public VisualStudio2008ProjectMRUList As String = "SOFTWARE\Microsoft\VisualStudio\9.0\ProjectMRUList"
    ''' <summary>
    ''' VS 2005 File MRU List
    ''' </summary>
    ''' <remarks></remarks>
    Public VisualStudio2005FileMRUList As String = "SOFTWARE\Microsoft\VisualStudio\8.0\FileMRUList"
    ''' <summary>
    ''' VS 2005 Project MRU List
    ''' </summary>
    ''' <remarks>HKCU</remarks>
    Public VisualStudio2005ProjectMRUList As String = "SOFTWARE\Microsoft\VisualStudio\8.0\ProjectMRUList"
#End Region

End Module