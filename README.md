![](https://blog.yusri.com.my/wp-content/uploads/2014/05/antibrute-817x320.jpg)
# AntiBruteRDP
AntiBruteRDP is a simple tool to block bruteforce attempts on your Windows Servers running RDP.

Most people will say that, why have it running in the first place? Well, there are times that you will need to have Remote Desktop service available. Tested on Windows Server 2003, Windows Server 2008, and Windows 8, it works flawlessly to block the bruteforce attempts.

Please take note that auditing of failed logons are enabled on windows servers by default. If you are running client version eg. Windows 7 or Windows 8, you need to change the Audit Policy for logon attempts using Group Policy Editor (gpedit.msc). For more information, you can refer to technet here http://technet.microsoft.com/en-us/library/cc787567(v=ws.10).aspx

It works by monitoring failed attempts by remote addresses and block the attempts. You can configure the settings using the AntiBruteRDP Front End, while the backend will run as a service to monitor bad login attempts, and write events to the RDPBruteLog in Windows Event Log.

----
### Screenshots:

![](https://blog.yusri.com.my/wp-content/uploads/2014/05/1-MainSettings.png)

> Settings screen.

![](https://blog.yusri.com.my/wp-content/uploads/2014/05/2-SerciveCOnfig.png)

> Service status

### Installation

```bash
sc create AntiBruteRDP binPath= C:\<install path>\AntiBruteRDP.exe
```

----
AntiBruteRDP is a freeware but you are welcome to donate if you find this tool is useful for you.

It was adapted from ts-block.vbs by Evan Andersen, you can find the original vb script below.

----
## Related

- [ts_block](https://github.com/EvanAnderson/ts_block/) - Blocks brute force Terminal Services login attempts
- [Audit logon events](http://technet.microsoft.com/en-us/library/cc787567(v=ws.10).aspx) - This security setting determines whether to audit each instance of a user logging on to or logging off from a computer.


