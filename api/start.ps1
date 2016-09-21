Param (
    [Parameter(Mandatory=$TRUE)]
    [string]$RedisIp
)

#ipconfig | Select-String 'Default Gateway' | ForEach-Object { $gateway = $_.Line.Substring(39) }
$Env:REDIS_IP = $RedisIp
Write-Host "Connecting to Default Gateway -> $Env:REDIS_IP"
dotnet run --server.urls http://0.0.0.0:5000