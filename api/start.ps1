Param (
    [Parameter(Mandatory=$TRUE)]
    [string]$RedisIp
)

$Env:REDIS_IP = $RedisIp
Add-HostEntry redis $RedisIp
Write-Host "Redis IP: $Env:REDIS_IP"
dotnet run --server.urls http://0.0.0.0:5000