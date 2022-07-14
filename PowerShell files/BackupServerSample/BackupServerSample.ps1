#
# 2022-07-14
#
# For 4WMC ver 1.20 or newer
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
# 語法:   ConnectServer -port (port) 
#
#         -server (IP或域名)
#
#         -password(密碼)
#
#         -message (見指令文件，在專案wiki)
#
#         -execTimes (如果不成功，最大總執行次數。1=1次，0=永遠重試)(每秒重試一次)
#
#		  -err2stop ($true = 如果發生 'FAIL' 或 'NEED-SETUP' 錯誤就立即停止。)
#
#		  -showDebug ($true = 顯示除錯用訊息)
#
#         -useThrow ($true = 意外狀況使用錯誤擲回(否則用return擲回))
#
# Syntax: ConnectServer -port (port) 
#
#        -server (IP or Domainname)
#
#        -password(Password)
#
#        -message (See command document in project wiki)
#
#        -execTimes (Max execute times if unsuccessful. 1=once, 0=unlimited.)(Retry in every second.)
#
#        -err2stop ($true = stop immediately if 'FAIL' or 'NEED-SETUP' happend.)
#
#        -showDebug ($true = Show the debug message)
#
#        -useThrow ($true = Use error throw when unexpected (Else use value return))
#
#
# 程式開始
# Program begin.
#

Write-Host "Backup task started."


try {
    
    #
    # 測試 Minecraft server 是否為啟動。
    # Test for if Minecraft server is on.
    #

    $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm;info1' -execTimes 20 -err2stop $true -showDebug $true

    if ($result -eq "ON") 
    {
        #
        # 在 Minecraft 伺服器內用 say 指令進行數次廣播
        # Broadcast servial times in Minecraft server with say command
        #

        Write-Host "Countdown 10 secs."
        $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in;say We will shutdown server in 10 secs.' -execTimes 1 -err2stop $true -showDebug $true
        Start-Sleep -second 5

        Write-Host "Countdown 5 secs."
        $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in;say We will shutdown server in 5 secs.' -execTimes 1 -err2stop $true -showDebug $true
        Start-Sleep -second 5

        Write-Host "Countdown end, we are shutting down."
        $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in;say We are shutting down the server.' -execTimes 1 -err2stop $true -showDebug $true

        #
        # 在Minecraft伺服器內用 stop 指令進行關機
        # Shutdown Minecraft server with stop command
        #

        Write-Host "Minecraft server is shutdown now."
        $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in;stop' -execTimes 0 -err2stop $true -showDebug $true

        #
        # 等待完成關機，讓 FourthWallMC 進行備份動作
        # Waiting for Shutdown, and let's FourthWallMC Backup Minecraft
        #

        Write-Host "Waiting for Shutdown, then Start Backup.."
        $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm;backup' -execTimes 120 -err2stop $true -showDebug $true

        #
        # 等待完成備份，重啟 Minecraft 伺服器
        # Waiting for Shutdown, and Re-Start Minecraft server
        #

        Write-Host "Waiting backup finish, then Restart Minecraft Server....."
        $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm;start' -execTimes 120 -err2stop $true -showDebug $true

    }
    elseif ($result -eq "OFF")
    {

        #
        # 如果 Minecraft 未啟動，就僅進行備份
        # If Minecraft server is not on, Just backup Minecraft only.
        #

        Write-Host "Start Backup.."
        $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm;backup' -execTimes 120 -err2stop $true -showDebug $true

    }

}
catch
{

    #
    # 如果一開始時發生錯誤，停止工作。
    # If error happend in start, stop the work.
    #

    write-host 'Error happened, please check the message.'
    Write-Host 'Error throw: '$_
}