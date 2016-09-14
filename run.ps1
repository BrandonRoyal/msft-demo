docker run --name demo_redis --restart always -d brandonroyal/demo_redis:latest
docker run --name demo_web --restart always -d brandonroyal/demo_web:latest
docker run --name demo_api --restart always --link demo_redis:redis -d brandonroyal/demo_api:latest
docker run --name demo_proxy --restart always --link demo_web:web --link demo_api:api -p 80:80 -d brandonroyal/demo_nginx:latest