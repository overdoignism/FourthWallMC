#
# It's a sample code for FourthWallMC
#
# 2022-07-14
#
# For 4WMC ver 1.20 or newer
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

	param ($server, $port, $password, $message, $execTimes, $err2stop = $true, $showDebug = $false, $useThrow = $true)

	$UseString = $password + ";" + $message
	$explainStr
	$execCount = 0

	while($true)
	{

		$BeTerminate = $false
		$unexpected = $false
		$execCount += 1

		try
		{
			$ReturnResult = ServerSocket -socket_server $server -socket_port $port -socket_message $UseString
			Start-Sleep -Seconds 1
		}
		catch
		{
			$ReturnResult = "FAIL"
			$BeTerminate = $true
		}
		
		switch ($ReturnResult)
		{
			
			'BAD'
			{
				$explainStr = "Bad command format or password."
				$BeTerminate = $true
				$unexpected = $true
			}
			'PASS'
			{
				$UseString = $password + ";sy;A task has been cancelled."
				ServerSocket -socket_server $server -socket_port $port -socket_message $UseString
				
				$explainStr = "This task has been cancelled."
				$BeTerminate = $true
				$unexpected = $true
 			}		

			'FAIL'
			{
				$explainStr = 'Socket error happend during connection.'
				$unexpected = $true
				if ($err2stop) {$BeTerminate = $true}
			}
			
			'NEED-SETUP'
			{
				$explainStr = 'FourthWallMC has some setting incorrect.'
				$unexpected = $true
				if ($err2stop) {$BeTerminate = $true}
			}

	 		'NOT-ON'
			{
				$explainStr = 'This operation is need Minecraft server be on-line.'
				$unexpected = $true
			}

    		'NOT-OFF'
			{
				$explainStr = 'This operation is need Minecraft server be off-line.'
				$unexpected = $true
			}

			'BUSY'
			{
				$explainStr = 'FourthWallMC is busy.'
				$unexpected = $true
			}
			
			'WAIT'
			{
				$explainStr = 'FourthWallMC asked to wait.'
				$unexpected = $true
			}
			
			default #normal return
			{
				$explainStr = 'A normal return. '
				$BeTerminate = $true
			}
		}
		
		if($showDebug -eq $true) 
		{ 
			Write-Host "debug: (Execute times)" $execCount"/"$execTimes
			Write-Host "debug: (Server return) "$ReturnResult 
			Write-Host "debug: (Explain) "$explainStr
		}
	
		if($execTimes -gt 0) 
		{
			if($execCount -ge $execTimes) 
			{
				$BeTerminate = $true
			}
		}

		if($BeTerminate)
		{		
			if ($showDebug -eq $true)  
			{
				if ($unexpected)
				{
					Write-Host "debug: (Unexpected happened)"
				} 
				else 
				{
					Write-Host "debug: (Normal return)"
				}
			}

			if ($useThrow)
			{
				if ($unexpected)
				{
					Throw $ReturnResult + ": " + $explainStr
				}
			}
			
			return $ReturnResult
		}
	}
}

