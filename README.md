# HTTPS MITM silent proxy
Source code of HTTPS proxy. Performs silent root certificate installation (without Windows message box popup).

![Preview](https://raw.githubusercontent.com/ardabada/CertTest/master/preview.png)

Uses [Titanium Web Proxy](https://github.com/justcoding121/Titanium-Web-Proxy) as core proxy and [Microsoft Detours](https://github.com/microsoft/Detours) to prevent warning message box popup before certificate installation.

Flow:
1. Injects detour in GUI process to hook [MessageBox](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messagebox) function
2. Generates and installs root certificate
3. Starts proxy
4. Listening to HTTP and HTTPS traffic until close
5. Stops proxy
6. Removes generated root certificate
