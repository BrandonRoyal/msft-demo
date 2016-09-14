docker run --name redis --restart always -d brandonroyal/demo_redis:latest
docker run --name web --restart always -d brandonroyal/demo_web:latest
docker run --name api --restart always --link redis -d brandonroyal/demo_api:latest
docker run --name nginx --restart always --link web --link api -p 80:80 -d brandonroyal/demo_nginx:latest