docker network create demo

docker run --name redis --network demo -d brandonroyal/demo_redis:latest
docker run --name web --network demo -d brandonroyal/demo_web:latest
docker run --name api --network demo --link redis -d brandonroyal/demo_api:latest
docker run --name nginx --network demo --link web --link api -p 80:80 -d brandonroyal/demo_nginx:latest