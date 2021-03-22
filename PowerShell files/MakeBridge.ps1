#
# It's a sample code for FourthWallMC, It's can make a bridge in game.
#
# Because the Burst Mode, you won't see message on console window. If you want observe, please remark it.
#
# 2021/03/22
#
# Example:
#
# /w playerID #PowerShell -file MakeBridge.ps1 -x -16 -y 73 -z -199 -toward E -length 100 -MakeTunnel YES
# 
#

	param ([long]$x, [long]$y, [long]$z, $toward, [int]$length, [string]$MakeTunnel='NO')


	$toward = $toward.ToUpper()
	$MakeTunnel = $MakeTunnel.ToUpper()

	[long]$Xmov=0
	[long]$XmovTmp=0
	[long]$Xwidth=0
	[long]$Zmov=0
	[long]$ZmovTmp=0
	[long]$Zwidth=0
	[string]$StartBrick=""
	[string]$EndBrick=""

	switch ($toward)
	{
		'N'
		{
			$StartBrick='north'
			$EndBrick='south'
			$Xmov=0
			$Zmov=-1
			$Xwidth=2
			$Zwidth=0
		}
		'S'
		{
			$StartBrick='south'
			$EndBrick='north'
			$Xmov=0
			$Zmov=1
			$Xwidth=2
			$Zwidth=0
		}
		'W'
		{
			$StartBrick='west'
			$EndBrick='east'
			$Xmov=-1
			$Zmov=0
			$Xwidth=0
			$Zwidth=2
		}
		'E'
		{
			$StartBrick='east'
			$EndBrick='west'
			$Xmov=1
			$Zmov=0
			$Xwidth=0
			$Zwidth=2
		}
	}


	# Into Burst Mode
	Write-Host "~*;;1"

	# Turn off sendCommandFeedback
	Write-Host "~gamerule sendCommandFeedback false"

	$XmovTmp=$XmovTmp+$Xmov
	$ZmovTmp=$ZmovTmp+$Zmov

	Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y)($z+$ZmovTmp+$Zwidth)"polished_andesite_stairs[facing=$StartBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp-($Xwidth/2))($y)($z+$ZmovTmp+($Zwidth/2))"polished_andesite_stairs[facing=$StartBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp)($y)($z+$ZmovTmp)"polished_andesite_stairs[facing=$StartBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp+($Xwidth/2))($y)($z+$ZmovTmp-($Zwidth/2))"polished_andesite_stairs[facing=$StartBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y)($z+$ZmovTmp-$Zwidth)"polished_andesite_stairs[facing=$StartBrick] replace"

	for ($i=1; $i -le $length-2; $i++) {

		$XmovTmp=$XmovTmp+$Xmov
		$ZmovTmp=$ZmovTmp+$Zmov

		Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y)($z+$ZmovTmp+$Zwidth)"polished_andesite_slab[type=top] replace"
		Write-Host "~setblock"($x+$XmovTmp-($Xwidth/2))($y)($z+$ZmovTmp+($Zwidth/2))"polished_andesite_slab[type=top] replace"
		Write-Host "~setblock"($x+$XmovTmp)($y)($z+$ZmovTmp)"polished_andesite_slab[type=top] replace"
		Write-Host "~setblock"($x+$XmovTmp+($Xwidth/2))($y)($z+$ZmovTmp-($Zwidth/2))"polished_andesite_slab[type=top] replace"
		Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y)($z+$ZmovTmp-$Zwidth)"polished_andesite_slab[type=top] replace"

		if ($MakeTunnel -eq 'YES') {
			for ($j=1; $j -le 4; $j++) {
				Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y+$j)($z+$ZmovTmp+$Zwidth)"air replace"
				Write-Host "~setblock"($x+$XmovTmp-($Xwidth/2))($y+$j)($z+$ZmovTmp+($Zwidth/2))"air replace"
				Write-Host "~setblock"($x+$XmovTmp)($y+$j)($z+$ZmovTmp)"air replace"
				Write-Host "~setblock"($x+$XmovTmp+($Xwidth/2))($y+$j)($z+$ZmovTmp-($Zwidth/2))"air replace"
				Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y+$j)($z+$ZmovTmp-$Zwidth)"air replace"
			}
		}

		Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y+1)($z+$ZmovTmp+$Zwidth)"birch_fence replace"
		Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y+1)($z+$ZmovTmp-$Zwidth)"birch_fence replace"

		if ($i % 6 -eq 0){Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y+2)($z+$ZmovTmp-$Zwidth)"lantern replace"}
		if ($i % 6 -eq 3){Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y+2)($z+$ZmovTmp+$Zwidth)"lantern replace"}			

	}
	
	$XmovTmp=$XmovTmp+$Xmov
	$ZmovTmp=$ZmovTmp+$Zmov

	Write-Host "~setblock"($x+$XmovTmp-$Xwidth)($y)($z+$ZmovTmp+$Zwidth)"polished_andesite_stairs[facing=$EndBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp-($Xwidth/2))($y)($z+$ZmovTmp+($Zwidth/2))"polished_andesite_stairs[facing=$EndBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp)($y)($z+$ZmovTmp)"polished_andesite_stairs[facing=$EndBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp+($Xwidth/2))($y)($z+$ZmovTmp-($Zwidth/2))"polished_andesite_stairs[facing=$EndBrick] replace"
	Write-Host "~setblock"($x+$XmovTmp+$Xwidth)($y)($z+$ZmovTmp-$Zwidth)"polished_andesite_stairs[facing=$EndBrick] replace"

	# Quit Burst Mode
	Write-Host "~*;;0"

	# Turn on sendCommandFeedback
	Write-Host "~gamerule sendCommandFeedback true"