[CmdletBinding()]
Param (
    [Parameter(Mandatory=$TRUE)]
    [string]$WebIp,

    [Parameter(Mandatory=$TRUE)]
    [string]$ApiIp
)

#ipconfig | Select-String 'Default Gateway' | ForEach-Object { $gateway = $_.Line.Substring(39) }
Add-HostEntry web $WebIp
Add-HostEntry api $ApiIp
ping web
ping api
./nginx.exe