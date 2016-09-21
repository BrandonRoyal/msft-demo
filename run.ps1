Write-Host "running demo_redis"
docker run --name redis --network default -p 6379:6379 -d brandonroyal/demo_redis:latest

Write-Host "running demo_web"
docker run --name web --network default -d -p 5000:5000 brandonroyal/demo_web:latest

Write-Host "running demo_api"
docker run --name api --network default -p 5001:5000 -d brandonroyal/demo_api:latest

Write-Host "running demo_nginx"
docker run --name nginx --network default --link web --link api -d brandonroyal/demo_nginx:latest