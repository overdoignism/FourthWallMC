@ECHO off
Echo ************************************************************
Echo  It's a simple tool to change PowerShell Execution Policy.
Echo ************************************************************
Echo.
Echo.
Powershell -Command Set-ExecutionPolicy RemoteSigned CurrentUser
Powershell -Command Get-ExecutionPolicy -list
Echo.
Echo.
Echo If you see "CurrentUser RemoteSigned", It's work successfuly.
Echo.
Pause