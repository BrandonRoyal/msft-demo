docker stop redis
docker stop web
docker stop api
docker stop nginx

docker rm -f redis
docker rm -f web
docker rm -f api
docker rm -f nginx