FROM microsoft/dotnet:latest

COPY ./project.json /app/project.json

WORKDIR /app

RUN ["dotnet", "restore"]

COPY . /app

RUN ["dotnet", "build"]

EXPOSE 5000/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000"]