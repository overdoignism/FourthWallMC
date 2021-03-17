#
# 2021-03-11
#
# 這是一個範例程式，用於 FourthWallMC，可以廣播、停止、備份、重啟伺服器。
# It's a sample code for FourthWallMC, use to Broadcast, then stop server, backup server, and restart server. 
#

#
# 請將連線端口（Port）改成你實際使用的值。25566為預設值。
# Please change the port to your real FourthWallMC management port. Default is 25566.
#

$GCMC_Port = 25566

#
# 請將 IP 改為 FourthWallMC 的實際使用 IP。（如果是與現在同一台機器，保持 127.0.0.1 即可）
# Please change the IP to your FourthWallMC server IP. (If in same machine, just keep 127.0.0.1)
#

$GCMC_IP = '127.0.0.1'

#
# 請將密碼改為你的實際密碼。（password 是 預設值）
# Please change the password in to your real password. (Default is 'password')
#

$GCMC_PWD = 'password'

#
# 導入連線命令函數
# Import Connect command.
#
. .\ConnectServer.ps1


#
# 語法:   ConnectServer -port (port) -server (IP或域名) -password(密碼) -message (見說明)
#
#         -waitsec (等待Busy的時間，0=永遠等待) -err2stop (如果發生錯誤就停下) -showResult (顯示伺服器回傳的實際值)
#
#
# Syntax: ConnectServer -port (port) -server (IP or Domainname) -password(Password) -message (See command document) 
#
#        -waitsec (Wait seconds for Busy, 0=forever) -err2stop (If error happend stop) -showResult (Show the return form server)
#

#
# 程式開始
# Program begin.
#

Write-Host "Backup task started."

#
# 測試 Minecraft server 是否為啟動。
# Test for if Minecraft server is on.
#

$result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,info1' -waitsec 20 -err2stop $true -showResult $true

if ($result -eq "ON") 
{
    #
    # 在 Minecraft 伺服器內用 say 指令進行數次廣播
    # Broadcast servial times in Minecraft server with say command
    #

    Write-Host "Countdown 5 min."
    $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 5 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 120

    Write-Host "Countdown 3 min."
    $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 3 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 120

    Write-Host "Countdown 1 min."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 1 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 60

    Write-Host "Countdown end, we are shutting down."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We are shutting down the server.' -waitsec 0 -err2stop $true -showResult $true

    #
    # 在Minecraft伺服器內用 stop 指令進行關機
    # Shutdown Minecraft server with stop command
    #

    Write-Host "Minecraft is Shutdown now."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,stop' -waitsec 0 -err2stop $true -showResult $true

    #
    # 讓 FourthWallMC 進行備份動作
    # Let's FourthWallMC Backup Minecraft
    #

    Write-Host "Start Backup.."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,backup' -waitsec 120 -err2stop $true -showResult $true

    #
    # 重啟 Minecraft 伺服器
    # Re-Start Minecraft server
    #

    Write-Host "Restart Minecraft Server....."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,start' -waitsec 120 -err2stop $true -showResult $true

}
elseif ($result -eq "OFF")
{

    #
    # 如果 Minecraft 未啟動，就僅進行備份
    # If Minecraft server is not on, Just backup Minecraft only.
    #

    Write-Host "Start Backup.."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,backup' -waitsec 120 -err2stop $true -showResult $true
}
else
{

    #
    # 如果一開始時發生錯誤，停止工作。
    # If error happend in start, stop the work.
    #

    write-host 'FourthWallMC may not working, or setting/password incorrect!'
}