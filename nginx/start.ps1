[CmdletBinding()]
Param (
    [Parameter(Mandatory=$TRUE)]
    [string]$WebIp,

    [Parameter(Mandatory=$TRUE)]
    [string]$ApiIp
)

Add-HostEntry web $WebIp
Add-HostEntry api $ApiIp
ping -n 1 web
ping -n 1 api
./nginx.exe