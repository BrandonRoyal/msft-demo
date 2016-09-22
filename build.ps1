docker build -t brandonroyal/redis:latest -t brandonroyal/redis:win-2.8.2400 ./redis
docker build -t brandonroyal/demo_web:latest ./web
docker build -t brandonroyal/demo_api:latest ./api
docker build -t brandonroyal/nginx:latest -t brandonroyal/nginx:win-1.9.13 ./nginx

docker push brandonroyal/redis:latest
docker push brandonroyal/demo_web:latest
docker push brandonroyal/demo_api:latest
docker push brandonroyal/nginx:latest

docker push brandonroyal/redis:win-2.8.2400
docker push brandonroyal/nginx:win-1.9.13
