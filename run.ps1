docker run --name redis --network nat -p 6379:6379 -d brandonroyal/demo_redis:latest
docker run --name web --network nat -p 5000:5001 -d brandonroyal/demo_web:latest
docker run --name api --network nat --link redis -p 5000:5000 -d brandonroyal/demo_api:latest
docker run --name nginx --network nat --link web --link api -p 80:80 -d brandonroyal/demo_nginx:latest