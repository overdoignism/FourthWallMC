package FourthWallMC.Plugin;

import org.bukkit.Bukkit;
import org.bukkit.Chunk;
import org.bukkit.HeightMap;
import org.bukkit.Location;
import org.bukkit.TreeType;
import org.bukkit.World;
import org.bukkit.attribute.Attribute;
import org.bukkit.block.Biome;
import org.bukkit.command.BlockCommandSender;
import org.bukkit.command.Command;
import org.bukkit.command.CommandSender;
import org.bukkit.command.ConsoleCommandSender;
import org.bukkit.command.RemoteConsoleCommandSender;
import org.bukkit.entity.Player;
import org.bukkit.entity.minecart.CommandMinecart;
import org.bukkit.plugin.java.JavaPlugin;

import java.lang.Runtime.Version;
import java.nio.charset.Charset;
import java.util.List;



public class main extends JavaPlugin {
	
	String ver = "1.21"; 

    @Override
    public void onEnable() {
    	 getLogger().info("4WMC init done. [" + ver + "]");
    }
    
    @Override
    public void onDisable() {
    }
    
    @Override
    public boolean onCommand(CommandSender sender,
                             Command command,
                             String label,
                             String[] args) {
    	
    	   	
        String TrueSenderStr = ""; 

        if (sender instanceof BlockCommandSender) {
        	Location Loc;
            final BlockCommandSender bsender = (BlockCommandSender) sender;
            Loc = bsender.getBlock().getLocation();
            TrueSenderStr = "@CommandBlock:" +
            		String.valueOf((int) Math.round(Loc.getX())) + "," +
            		String.valueOf((int) Math.round(Loc.getY())) + "," +
            		String.valueOf((int) Math.round(Loc.getZ()));
            TrueSenderStr += ";" + bsender.getBlock().getWorld().getName();
        }
        else if (sender instanceof ConsoleCommandSender) {
            final ConsoleCommandSender Csender = (ConsoleCommandSender) sender;
            TrueSenderStr = "@" + Csender.getName();
        } 
        else if (sender instanceof RemoteConsoleCommandSender) {
            final ConsoleCommandSender Csender = (ConsoleCommandSender) sender;
            TrueSenderStr = "@" + Csender.getName();
        }    
        else if (sender instanceof CommandMinecart) {
            //final CommandMinecart Csender = (CommandMinecart) sender;
            TrueSenderStr = "@CommandBlock:minecart";
            //TrueSenderStr = "*" + Csender.getName();
        }
        else {
    		org.bukkit.entity.Player Player;
       		Player = Bukkit.getPlayerExact(sender.getName());
        	TrueSenderStr = sender.getName();
        	TrueSenderStr += ";" + Player.getWorld().getName();
        }
    	
        
        if (command.getName().equalsIgnoreCase("fwts")) {

        	if (args.length == 0) { return false; }
        	
            String str = "";
            
            for(int Theidx1 = 0; Theidx1 < args.length; Theidx1++) {
            	
            	if (TestTargetSelect(args[Theidx1])) {
                	try {
                    	List<org.bukkit.entity.Entity> EntList;
                    	EntList = org.bukkit.Bukkit.selectEntities(sender,args[Theidx1]);
                		
                        for(org.bukkit.entity.Entity element : EntList) {
                        	str = str + element.getName() + " ";
                        }
                	}
                	catch(java.lang.IllegalArgumentException e)	{
                		str =  str + args[Theidx1] + " ";
                	}
            	}
            	else {
                	str =  str + args[Theidx1] + " ";
            	}
            }
            if (!str.equals("")) {
            	getLogger().info("<cmd> " + TrueSenderStr + " " + str);
            }
            return true;
        }

        if (command.getName().equalsIgnoreCase("fwra")) {
        	
        	if (args.length == 0) { return false; }
        
            String str = "";
        	for(int Theidx1 = 0; Theidx1 < args.length; Theidx1++) {
            	str =  str + args[Theidx1] + " ";
        	}
            if (!str.equals("")) {
            	getLogger().info("<cmd> " + TrueSenderStr + " " + str);
            }
            return true;
        }
                
        /*if (command.getName().equalsIgnoreCase("ffff")) {
        	Bukkit.getServer().dispatchCommand(Bukkit.getConsoleSender(), "say hi");
        	getLogger().info("ffff");
        	 return true;
        }*/
        
        if (!sender.getName().equals("@") && !sender.getName().equals("CONSOLE")) {return true;}
        //===================================================Console only-----
        
        String Workstr;

        if (command.getName().equalsIgnoreCase("fwsgetinf")) { 
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 1) {
        		
        		String TmpStr = Bukkit.getIp();
        		if (TmpStr.equals("")) {TmpStr = "*";}
        		
            	Workstr = Bukkit.getMotd();
            	Workstr = Workstr + ";" + Bukkit.getVersion();
            	Workstr = Workstr + ";" + Bukkit.getBukkitVersion();
            	Workstr = Workstr + ";" + Boolean.toString(Bukkit.isHardcore());
            	Workstr = Workstr + ";" + TmpStr;
            	Workstr = Workstr + ";" + String.valueOf(Bukkit.getPort());      		
        		Workstr = args[0] + " " + Workstr;
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
    		return true;
        }        
        
        if (command.getName().equalsIgnoreCase("fwlistw")) {

        	if (args.length == 0) { return false; }
        	
        	if (args.length == 1) {
        		Workstr = args[0] + " " + GetWorldList();
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
    		return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwwgetinfs")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 2) {           	
        		Workstr = args[1] + " " + GetWorldInfos(args[0]);
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
    		return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwwgetinfm")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 2) {           	
        		Workstr = args[1] + " " + GetWorldInfom(args[0]);
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
    		return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwwget1h")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if ((args.length == 4) || (args.length == 5)) {           	
        		int TheX;
        		int TheZ;
        		int TheType = 0;
        		int argsUper = args.length - 1;
        		try {
        			TheX = Integer.parseInt(args[1]);
        			TheZ = Integer.parseInt(args[2]);

        			if (args.length == 5) 
        			{
        				TheType = Integer.parseInt(args[3]);
        				
        				if ((TheType >= 5) || (TheType < 0))
        				{
        					Workstr = args[argsUper] + " #Er3";
        		        	getLogger().info("<rtn> " + Workstr);
        		    		return true;
        				}
        			} 
        			
        			Workstr = args[argsUper] + " " + GetHeightestBlock(args[0], TheX, TheZ, TheType);
        		}
        		catch (NumberFormatException ex) {
        			Workstr = args[argsUper] + " #Er3";
        		}
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
    		return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwwgetp")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 5) {           	
        			int TheX;
        			int TheY;
        			int TheZ;
        	        try {
            			TheX = Integer.parseInt(args[1]);
            			TheY = Integer.parseInt(args[2]);
            			TheZ = Integer.parseInt(args[3]);
            			Workstr = args[4] + " " + GetPosInfo(args[0], TheX, TheY, TheZ);
        	        }
        	        catch (NumberFormatException ex) {
            			Workstr = args[4] + " #Er3";
        	        }
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
        	getLogger().info("<rtn> " + Workstr);
        	return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwcexpo")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 8) {           	
        	
                String Worldname = "";
    			double TheX;
    			double TheY;
    			double TheZ;
    			float Pwr;
        		
        		try {
        			Worldname = args[0];
        			TheX = Double.parseDouble(args[1]);
        			TheY = Double.parseDouble(args[2]);
        			TheZ = Double.parseDouble(args[3]);
        			Pwr = Float.parseFloat(args[4]);
        			Workstr = args[7] + " " + CreateExpo(Worldname,TheX,TheY,TheZ,Pwr,
        					(Integer.parseInt(args[5])==1),(Integer.parseInt(args[6])==1));
    	        }
    	        catch (NumberFormatException ex) {
    	        	Workstr = args[7] + " #Er3";
    	        }
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwctree")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 6) {           	
        		Workstr = args[5] + " " + CreateTree(args[0], args[1], args[2], args[3], args[4]);
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwsetbio")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 6) {           	
        	
    			int TheX;
    			int TheY;
    			int TheZ;
       		
        		try {
        			TheX = Integer.parseInt(args[2]);
        			TheY = Integer.parseInt(args[3]);
        			TheZ = Integer.parseInt(args[4]);
        			Workstr = args[5] + " " + SetBio(args[0],args[1],TheX,TheY,TheZ);
    	        }
    	        catch (NumberFormatException ex) {
    	        	Workstr = args[5] + " #Er3";
    	        }
        	}
        	else {
        		Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwpgetpos")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 2) {
        		float TmpFlt;
        		org.bukkit.entity.Player Player;
        		Location loc;
           		Player = Bukkit.getPlayerExact(args[0]);
           		if (Player != null) {
           			Workstr = Player.getWorld().getName();
            		loc = Player.getLocation();
            		Workstr = Workstr + ";" + String.valueOf(loc.getBlockX());
            		Workstr = Workstr + ";" + String.valueOf(loc.getBlockY());
            		Workstr = Workstr + ";" + String.valueOf(loc.getBlockZ());
            		TmpFlt = (float) (Math.round(Player.getLocation().getYaw()*100.0)/100.0);  
            		Workstr = Workstr + ";" + String.valueOf(TmpFlt);
            		TmpFlt = (float) (Math.round(Player.getLocation().getPitch()*100.0)/100.0);  
            		Workstr = Workstr + ";" + String.valueOf(TmpFlt);
            		Workstr = args[1] + " " + Workstr;
           		}
           		else {
           			Workstr = args[1] + " #Er4";
           		}
        	}
        	else {
       				Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;	
        }
        
        if (command.getName().equalsIgnoreCase("fwpgetspa")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 2) {
        		org.bukkit.entity.Player Player;
        		Location loc;
           		Player = Bukkit.getPlayerExact(args[0]);
           		if (Player != null) {
           			Workstr = Player.getWorld().getName();
            		loc = Player.getBedSpawnLocation();
            		
            		if (loc != null){
                		Workstr = args[1] + " " + String.valueOf(loc.getBlockX());
                		Workstr = Workstr + ";" + String.valueOf(loc.getBlockY());
                		Workstr = Workstr + ";" + String.valueOf(loc.getBlockZ());
            		}
            		else {
            			Workstr = args[1] + " " + "null";
            		}
           		}
           		else {
           			Workstr = args[1] + " #Er4";
           		}
        	}
        	else {
       				Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;	
        }
        
        if (command.getName().equalsIgnoreCase("fwpgetval")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 2) {
        		double TmpDbl;
        		org.bukkit.entity.Player Player;
           		Player = Bukkit.getPlayerExact(args[0]);
           		if (Player != null) {
            		TmpDbl = Math.round(Player.getHealth()*100.0)/100.0;       		
            		Workstr = String.valueOf(TmpDbl);
            		Workstr = Workstr + ";" + String.valueOf(Player.getFoodLevel());
            		Workstr = Workstr + ";" + String.valueOf(Player.getLevel());
            		Workstr = args[1] + " " + Workstr;
           		}
           		else {
           			Workstr = args[1] + " #Er4";
           		}
        	}
        	else {
       				Workstr = args[args.length-1] + " #Er3";
        	}
			getLogger().info("<rtn> " + Workstr);
			return true;	
        }
        
        if (command.getName().equalsIgnoreCase("fwpset")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 4) {
        		
        		Workstr = args[3] + " #Er3";
           		org.bukkit.entity.Player Player;       		
           		Player = Bukkit.getPlayerExact(args[0]);
           		
           		if (!(Player != null)) {
                	getLogger().info("<rtn> " + args[1] + " #Er4");
                	return true;
               	}
               		
        		if (args[1].equalsIgnoreCase("sethp")) {
        			
        			try {
        				
        				if (Double.parseDouble(args[2]) > Player.getAttribute(Attribute.GENERIC_MAX_HEALTH).getDefaultValue()) {
        					Workstr = args[3] + " #Er3";
        				}
        				else {
            				Player.setHealth(Double.parseDouble(args[2]));
            				Workstr = args[3] + " #Er0";
        				}
        	        }
        	        catch (NumberFormatException ex) {
        	        }      			       		 
                    getLogger().info("<rtn> " + Workstr);
                    return true;
                }
        		else if (args[1].equalsIgnoreCase("setfood")) {
        			try {
        				Player.setFoodLevel(Integer.parseInt(args[2]));
        				Workstr = args[3] + " #Er0";
        	        }
        	        catch (NumberFormatException ex) {
        	        }             			       		 
                    getLogger().info("<rtn> " + Workstr);
                    return true;
        		}
        		else if (args[1].equalsIgnoreCase("setexplv")) {
        			try {
        				int Val1;
        				Val1 = Integer.parseInt(args[2]);
        				if (Val1 >= 0) {
            				Player.setLevel(Integer.parseInt(args[2]));
            				Workstr = args[3] + " #Er0";	
        				}
        	        }
        	        catch (NumberFormatException ex) {
        	        }             			       		 
                    getLogger().info("<rtn> " + Workstr);
                    return true;
        		}
        		else {
        			getLogger().info("<rtn> " + Workstr);
        			return true;	
        		}
        	}
        	else {
    			getLogger().info("<rtn> " + args[args.length-1] + " #Er3");
    			return true;	
        	}
        }
        
        if (command.getName().equalsIgnoreCase("fwsay")) {
        	
        	if (args.length == 0) {return true;}
        	
        	byte[] decodedBytes = java.util.Base64.getDecoder().decode(args[0].getBytes());
        	String decodedStr = new String(decodedBytes, Charset.forName("UTF-8"));
        	Bukkit.broadcastMessage("[Server] " + decodedStr);
        	return true;
        }
        
        if (command.getName().equalsIgnoreCase("fwwh")) {
        	
        	if (args.length == 0) { return false; }
        	        	
        	if (!(args.length <= 1))
        	{        	        	
        		for (Player player : Bukkit.getOnlinePlayers()) {
        			if (player.getName().equals(args[0]))
        			{
        				byte[] decodedBytes = java.util.Base64.getDecoder().decode(args[1].getBytes());
        				String decodedStr = new String(decodedBytes, Charset.forName("UTF-8"));
        				player.sendMessage("[Server to you] " + decodedStr);
        				return true;	
        			}
           		}
    			getLogger().info("The Player " + args[0] +" is not found.");	
    			return true;
        	}
        }
        
        if (command.getName().equalsIgnoreCase("fwheap")) {
        	
        	if (args.length == 0) { return false; }
        	
        	if (args.length == 1) {
            	long heapSize = Runtime.getRuntime().totalMemory(); 
            	long heapMaxSize = Runtime.getRuntime().maxMemory();
            	long heapFreeSize = Runtime.getRuntime().freeMemory(); 
            	
               	Workstr = args[0] + " " + Long.toString(heapSize)+";"+ Long.toString(heapMaxSize)+";" +Long.toString(heapFreeSize);
        	}
        	else {
   				Workstr = args[args.length-1] + " #Er3";
        	}
        	        	
        	getLogger().info("<rtn> " + Workstr);
        	return true;

        }
        if (command.getName().equalsIgnoreCase("fwgc")) {
        	System.gc();
        	return true;
        }
        
        return false;
    }
    
    //==========================================================================================================================
    
    static boolean TestTargetSelect(String TheStr) {
    	if (TheStr.startsWith("@p"))	{return true;}
    	if (TheStr.startsWith("@r"))	{return true;}
    	if (TheStr.startsWith("@a"))	{return true;}
    	if (TheStr.startsWith("@e"))	{return true;}
    	if (TheStr.startsWith("@s"))	{return true;}
    	return false;
    }
    
	
	public String GetWorldInfos(String Worldname) {
    	String Tmpstr;
    	
    	List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	        	
         if (element.getName().equals(Worldname)) {
        	
          	Tmpstr = String.valueOf(element.getEnvironment().name()) + ";";
        	Tmpstr = Tmpstr + String.valueOf(element.getMaxHeight()) + ";";
        	Tmpstr = Tmpstr + String.valueOf(element.getSeaLevel()) + ";";
        	Location loc = element.getSpawnLocation();
        	Tmpstr = Tmpstr + String.valueOf(loc.getX()) + ";";
        	Tmpstr = Tmpstr + String.valueOf(loc.getY()) + ";";
        	Tmpstr = Tmpstr + String.valueOf(loc.getZ());
	
        	return Tmpstr;
         }
        }
        return "#Er4";    	
    }

	public String GetWorldInfom(String Worldname) {
    	String Tmpstr;
    	
    	List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	        	
         if (element.getName().equals(Worldname)) {
        	if (element.isThundering())     {Tmpstr = "Thundering;";}
        	else if (element.hasStorm())    {Tmpstr = "Storm;";}        	 
        	else 							{Tmpstr = "Clear;";}
        	Tmpstr = Tmpstr + String.valueOf(element.getTime()) + ";";
        	return Tmpstr;
         }
        }
        return "#Er4";    	
    }
	
	public String GetHeightestBlock(String Worldname, int X, int Z, int TheType) {
		
    	int TmpInt;
    	String TmpStr1 = "", TmpStr2 = "", TmpStr3 = "", TmpStr4 = "";
    	
    	List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	        	
        	if (element.getName().equals(Worldname)) {
        		
        		try {
        			        			
        			Chunk theCh;
        			Location loc = new Location(element, Double.valueOf(X), 60, Double.valueOf(Z));         			
        			theCh= element.getChunkAt(loc);
        			
        			if (theCh.isLoaded() != true)
        			{
        				theCh.load();
        			}
       			
        			if ((TheType == 0) || (TheType == 1))
        			{
        				TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.MOTION_BLOCKING);  
        				TmpStr1 = String.valueOf(TmpInt);
        			}
        			if ((TheType == 0) || (TheType == 2))
        			{
                 		TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.MOTION_BLOCKING_NO_LEAVES);  
                 		TmpStr2 = String.valueOf(TmpInt);
        			}
        			if ((TheType == 0) || (TheType == 3))
        			{
                 		TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.OCEAN_FLOOR);  
                 		TmpStr3 =  String.valueOf(TmpInt);
        			}
        			if ((TheType == 0) || (TheType == 4))
        			{
                 		TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.WORLD_SURFACE);  
                 		TmpStr4 =  String.valueOf(TmpInt);
        			}
        			
        			if (TheType == 0)
        			{
        				return TmpStr1 + ";" + TmpStr2 + ";" + TmpStr3 + ";" + TmpStr4;
        			}
        			else
        			{
        				return TmpStr1 + TmpStr2 + TmpStr3 + TmpStr4;
        			}
        			
             		/* TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.OCEAN_FLOOR_WG);  
             		   TmpInt = element.getHighestBlockYAt(X,Z,HeightMap.WORLD_SURFACE_WG); */

        		}
        		catch(java.lang.IllegalArgumentException e) {
        			return "#Er3";
        		}
        	}
        }
        return "#Er4";
    }
	
	public String GetPosInfo(String Worldname, int X, int Y, int Z) {
		
    	double TmpDouble;
    	Biome Thebiome;
    	String TmpStr;
    	
    	List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	        	
        	if (element.getName().equals(Worldname)) {
        		
        		try {
        			
        			Thebiome = element.getBiome(X,Y,Z);
        			TmpStr = Thebiome.name();
          			TmpDouble = element.getTemperature(X,Y,Z);        			
        			TmpDouble = Math.round(TmpDouble*100.0)/100.0;
        			TmpStr = TmpStr + ";" + String.valueOf(TmpDouble);
        			TmpDouble = element.getHumidity(X,Y,Z);        			
        			TmpDouble = Math.round(TmpDouble*100.0)/100.0;
        			TmpStr = TmpStr + ";" + String.valueOf(TmpDouble);
        		}
        		catch(java.lang.IllegalArgumentException e) {
        			return "#Er3";
        		}

        		return TmpStr;
        	}
        }
        return "#Er4";
    }

	public String GetWorldList() {
    	String Tmpstr = "";
    	
    	List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {       	
        	Tmpstr = Tmpstr + element.getName() + ";";
        }
        Tmpstr = Tmpstr + "?";
        Tmpstr = Tmpstr.replace(";?", "");
        
        return Tmpstr;
    }
   
	public String CreateExpo(String Worldname, double x, double y, double z, float power,boolean setFire, boolean breakBlocks) {
		
		List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	if (element.getName().equals(Worldname)) {
        		if (element.createExplosion(x,y,z,power,setFire,breakBlocks)) {
        			return "#Er0";
        		}
        		else {
        			return "#Er5";
        		}
        	}
        }
		return "#Er4";
	}
	
	public String CreateTree(String Worldname,String treetype, String x, String y, String z) {
		
		List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	TreeType tree1;
    	
    	try {
        	tree1 = org.bukkit.TreeType.valueOf(treetype);
    	}
    	catch (IllegalArgumentException e) {
			return "#Er4";
    	}    	
    	
        for(org.bukkit.World element : WorldList) {
        	if (element.getName().equals(Worldname)) {
        		try {
        			Location loc = new Location(element, Double.parseDouble(x), Double.parseDouble(y), Double.parseDouble(z));  
            		if (element.generateTree(loc,tree1)) {
            			return "#Er0";
            		}
            		else {
            			return "#Er5";
            		}
    	        }
    	        catch (NumberFormatException ex) {
    	        	return "#Er3";
    	        }
        	}
        }
		return "#Er4";
	}	
	
	public String SetBio(String Worldname, String Bioname, int x, int y, int z) {
		
		List<org.bukkit.World> WorldList;
    	WorldList = Bukkit.getWorlds();
    	
        for(org.bukkit.World element : WorldList) {
        	
        	if (element.getName().equals(Worldname)) {

        		Biome TheBiome;
        		try {
        			TheBiome = Biome.valueOf(Bioname);
        			element.setBiome(x, y, z, TheBiome);
        			return "#Er0";
        		}
        		catch (IllegalArgumentException e) { 
        			return "#Er4";
        		}
        	}
        }
		return "#Er4";
	}	
	
	
}

