docker run --name redis  -d brandonroyal/demo_redis:latest
docker run --name web  -d brandonroyal/demo_web:latest
docker run --name api  --link redis -d brandonroyal/demo_api:latest
docker run --name nginx  --link web --link api -p 80:80 -d brandonroyal/demo_nginx:latest