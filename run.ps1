docker run --name redis --network default -d brandonroyal/demo_redis:latest
$redis_ip = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" test

docker run --name web --network default -e "REDIS_IP=$redis_ip" -d brandonroyal/demo_web:latest
docker run --name api --network default --link redis -d brandonroyal/demo_api:latest
docker run --name nginx --network default --link web --link api -d brandonroyal/demo_nginx:latest