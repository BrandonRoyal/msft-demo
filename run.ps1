Write-Host "running demo_redis"
docker run --name redis --network default -d brandonroyal/demo_redis:latest
$redis_ip = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" redis
Write-Host "redis_ip: $redis_ip"
Write-Host "------"

Write-Host "running demo_web"
docker run --name web --network default -p 5000:80 -d brandonroyal/demo_web:latest
$web_ip = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" web
Write-Host "web_ip: $web_ip"
Write-Host "------"

Write-Host "running demo_api"
docker run --name api --network default -d brandonroyal/demo_api:latest powershell ./start.ps1 $redis_ip
$api_ip = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" web
Write-Host "api_ip: $api_ip"
Write-Host "------"

Write-Host "skipping demo_nginx"
docker run --name nginx --network default -p 80:80 -d brandonroyal/demo_nginx:latest powershell ./start.ps1 $web_ip $api_ip
Write-Host "------"