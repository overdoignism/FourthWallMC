#
# It's a sample code for FourthWallMC
#
# 2021-03-13
#
# Please do not modify this if you are not know what are you doing.
#

function ServerSocket {	
	param ($socket_message, $socket_server, $socket_port)

	Start-Sleep -Milliseconds 50
	$ReturnVaule = "FAIL"

	try {

		$socket = new-object System.Net.Sockets.TcpClient($socket_server, $socket_port)
		$socket.ReceiveTimeout = 10000
		$socketNetworkStream = $Socket.GetStream()

		if ($socket.Connected)
		{

			if ($socketNetworkStream.CanWrite)
			{
				$socketWriteByte = [System.Text.Encoding]::UTF8.GetBytes($socket_message)
				$socketNetworkStream.Write($socketWriteByte, 0, $socketWriteByte.Length)
				$socketNetworkStream.Flush()
			}

	    		$Receivebuffer = New-Object Byte[] $socket.ReceiveBufferSize

			if ($socketNetworkStream.CanRead)
			{
				$ReadLength = $socketNetworkStream.Read($Receivebuffer, 0, $socket.ReceiveBufferSize) 
				$ReturnVaule = [System.Text.Encoding]::UTF8.GetString($Receivebuffer)
				$ReturnVaule = $ReturnVaule.Trim([char]0x0000)
			}
		}
	}
	catch
	{
	}

	return $ReturnVaule
}


function ConnectServer {
	param ($server, $port, $password, $message, $waitsec, $err2stop = $true, $showResult = $false)

	$ReturnResult = 'BUSY'
	$WaitCount = 0
	$UseString = $password + "," + $message

	while($ReturnResult -eq 'BUSY')
	{

		try
		{
			$ReturnResult = ServerSocket -socket_server $server -socket_port $port -socket_message $UseString
			if($showResult -eq $true) { Write-Host "Socket reutrn:"$ReturnResult }
			Start-Sleep -s 1
		}
		catch
		{
			$ReturnResult='FAIL'
		}

		if($waitsec -gt 0) {$WaitCount += 1}

		if ($WaitCount -gt $waitsec)
		{
			Write-Host 'The task has timed out.'
			if ($err2stop) {exit 1}
		}
		else
		{
			
			switch ($ReturnResult)
			{
				'PASS'
				{
					$UseString = $password + ",sy,This task has been cancelled."
					$NoDisplay = ServerSocket -socket_server $server -socket_port $port -socket_message $UseString
					Write-Host "PASS: This task has been cancelled."
                    			exit 2
 				}

	 			'NOT-ON'
   			        {
	        		        Write-Host 'NOT-ON: This operation is need Minecraft server be on-line.'
 					if ($err2stop) {exit 3}
                		}

	    			'NOT-OFF'
				{
					Write-Host 'NOT-OFF: This operation is need Minecraft server be off-line.'
					if ($err2stop) {exit 4}
				}

				'FAIL'
                		{	
					Write-Host 'Error happend during connection.'
					if ($err2stop) {exit 5}
                		}

				default
				{
    				}
			}
		}
	}

	return $ReturnResult

}