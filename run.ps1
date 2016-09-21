Write-Host "running demo_redis"
docker run --name redis --network default -d brandonroyal/demo_redis:latest
$redis_ip = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" redis
Write-Host "redis_ip: $redis_ip"
Write-Host "------"

Write-Host "running demo_web"
docker run --name web --network default -d brandonroyal/demo_web:latest
Write-Host "------"

Write-Host "running demo_api"
docker run --name api --network default -d brandonroyal/demo_api:latest powershell ./start.ps1 $redis_ip
Write-Host "------"

Write-Host "skipping demo_nginx"
#docker run --name nginx --network default -d brandonroyal/demo_nginx:latest
Write-Host "------"