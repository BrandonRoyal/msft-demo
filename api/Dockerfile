FROM microsoft/dotnet:1.0.0-preview2-windowsservercore-sdk

COPY ./project.json /app/project.json

WORKDIR /app

RUN powershell -Command \
    Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force ; \
    Install-Module PsHosts -Force

RUN ["dotnet", "restore"]

COPY . /app

RUN ["dotnet", "build"]

EXPOSE 5000/tcp