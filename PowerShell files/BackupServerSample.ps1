#
# It's a sample code for FourthWallMC, use to Broadcast, then stop server, backup server, and restart server. 
#
# 2021-02-27
#
# Please change the port to your real FourthWallMC management port.
#

$GCMC_Port = 25566

#
# Please change the IP to your real server IP. (If in same machine, just keep 127.0.0.1)
#

$GCMC_IP = '127.0.0.1'

#
# Please change the password in to your real password.
#

$GCMC_PWD = 'password'

# Import Connect command.
. .\ConnectServer.ps1


#
#Syntax: ConnectServer -port (port) -server (IP or Domainname) -password(Password) -message (See command document) 
#
#        -waitsec (Wait seconds for Busy) -err2stop (If error happend stop) -showResult (Show the return form server)
#

#Program begin.
Write-Host "Backup task started."

# Test for if Minecraft server is on.
$result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,info1' -waitsec 20 -err2stop $true -showResult $true

if ($result -eq "ON") 
{

    #Broadcast
    Write-Host "Countdown 5 min."
    $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 5 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 120

    #Broadcast
    Write-Host "Countdown 3 min."
    $result = ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 3 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 120

    #Broadcast
    Write-Host "Countdown 1 min."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We will shutdown server in 1 min.' -waitsec 0 -err2stop $true -showResult $true
    Start-Sleep -second 60

    #Broadcast
    Write-Host "Countdown end, we are shutting down."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,say We are shutting down the server.' -waitsec 0 -err2stop $true -showResult $true
    
    #Shutdown Minecraft
    Write-Host "Minecraft is Shutdown now."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'in,stop' -waitsec 0 -err2stop $true -showResult $true

    #Backup Minecraft
    Write-Host "Start Backup.."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,backup' -waitsec 120 -err2stop $true -showResult $true

    #Start Minecraft
    Write-Host "Restart Minecraft Server....."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,start' -waitsec 120 -err2stop $true -showResult $true

}
elseif ($result -eq "OFF")
{
    #Backup Minecraft
    Write-Host "Start Backup.."
    $result =  ConnectServer -port $GCMC_Port -server $GCMC_IP -password $GCMC_PWD -message 'cm,backup' -waitsec 120 -err2stop $true -showResult $true
}
else
{
    write-host 'FourthWallMC may not working, or setting/password incorrect!'
}