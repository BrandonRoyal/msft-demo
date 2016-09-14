docker run --name demo_redis --restart always -d microsoft/sample-redis:windowsservercore-10.0.14300.1030
docker run --name demo_web --restart always -d brandonroyal/demo_web:latest
docker run --name demo_api --restart always -d brandonroyal/demo_api:latest
docker run --name demo_proxy --restart always -d microsoft/sample-nginx:windowsservercore-10.0.14300.1030