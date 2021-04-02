# TryMiniToTray

为Unity的Windows包实现最小化到托盘功能

平台：Windows 10
 
Unity版本：2020.2.2

思路：

1. 用 NotifyIcon 实现托盘Icon

https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon?view=netframework-4.7.2

2. 用 SetWindowLongW () 控制窗口的任务栏按钮显示/隐藏

https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongw

