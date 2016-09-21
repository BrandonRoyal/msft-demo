[CmdletBinding()]
Param (
    [Parameter(Mandatory=$TRUE)]
    [string]$WebIp,

    [Parameter(Mandatory=$TRUE)]
    [string]$ApiIp
)

#ipconfig | Select-String 'Default Gateway' | ForEach-Object { $gateway = $_.Line.Substring(39) }
$Env:WEB_URI = "http://$WebIp:5000"
$Env:API_URI = "http://$ApiIp:5000"
Write-Host "Web URI: $Env:WEB_URI"
Write-Host "Api URI: $Env:API_URI"
./nginx.exe