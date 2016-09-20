docker run --name redis --network default -d brandonroyal/demo_redis:latest
docker run --name web --network default -d brandonroyal/demo_web:latest
docker run --name api --network default --link redis -d brandonroyal/demo_api:latest
docker run --name nginx --network default --link web --link api -d brandonroyal/demo_nginx:latest