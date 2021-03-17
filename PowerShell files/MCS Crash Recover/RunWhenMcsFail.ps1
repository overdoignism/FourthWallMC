#
# 2021-03-17
#
# 這是一個範例程式，用於 FourthWallMC，用於麥塊當掉時的處置。
# It's a sample code for FourthWallMC, use for Minecraft server was crash. 
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
# 程式開始，參數一用於時間，參數二用於次數。
# Program begin. $args[0] = date & time, $args[1] = times.
#

$timestamp=$args[0]
$failtimes=$args[1]
Write-Host "The MineCraft server failed recovery task is started. "

#
# 測試 Minecraft server 是否為啟動。
# Test for if Minecraft server is on.
#


$result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,info1' -waitsec 20 -err2stop $true -showResult $true

if ($result -eq "ON") 
{
	#
	# 此程式只有伺服器異常關閉時才應該被執行。
	# Only when the Minecraft server is stopped by an abnormality. 
	#

	Write-Host "Only when the Minecraft server is stopped by an abnormality."
	Start-Sleep -second 5

}
elseif ($result -eq "OFF")
{

	#
	# 紀錄至記錄檔 fail.log 
	# Record to fail.log
	#

	Write-Host "Record to fail.log.."
	$OutputStr = "Date and time: $timestamp   Times(last 4WMC start): $failtimes"
	$OutputStr | Out-File ".\fail.log" -Append

	#
	# 進行備份
	# Backup Minecraft.
	#

	Write-Host "Start Backup.."
	$result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,backup' -waitsec 120 -err2stop $true -showResult $true

	#
	# 檢查 Minecraft server 失敗次數。大於三次將不會進行重啟，改為email通知。
	# Check the Minecraft server fail times. If >3, it will not restart, and send an email to admin.
	#
	if ($failtimes -gt 3){

		Write-Host "Error happend > 3 times, Send an alert e-mail. Server will not restart."

		#
		# 這裡使用Gmail為例。如果使用別的郵件服務，請自行查閱相關指令。
		# 使用Gmail收發必須在<帳戶><安全性>啟用<低安全性應用程式存取權>。
		#
		# It's an example for gmail. If you are using another one, please google how to use (with powershell).
		# Use gmail need Enable the <account><security><Allow Less Secure Apps to Access>
		#
		# $EmailFrom, $EmailTo, $SMTPClient.Credentials need be modify.
		#

		$EmailFrom = "yourname@gmail.com"
		$EmailTo = "yourname@gmail.com"
		$Subject = "Minecraft Server Crashed > 3 times"
		$Body = $OutputStr
		$SMTPServer = "smtp.gmail.com"
		$SMTPClient = New-Object Net.Mail.SmtpClient($SmtpServer, 587)
		$SMTPClient.EnableSsl = $true
		$SMTPClient.Credentials = New-Object System.Net.NetworkCredential("yourname@gmail.com", "yourpassword");
		$SMTPClient.Send($EmailFrom, $EmailTo, $Subject, $Body)

	}
	else{
		#
		# 重啟 Minecraft 伺服器
		# Re-Start Minecraft server
		#

		Write-Host "Restart Minecraft Server....."
    		$result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,start' -waitsec 120 -err2stop $true -showResult $true
	}

	write-host "All done."
	Start-Sleep -second 5

}
else
{

	#
	# 如果一開始時發生錯誤，停止工作。
	# If error happend in start, stop the work.
	#

	write-host 'FourthWallMC may not working, or setting/password incorrect!'
	Start-Sleep -second 5
}



