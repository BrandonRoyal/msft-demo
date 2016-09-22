FROM microsoft/windowsservercore

LABEL Description="Nginx" Vendor=Nginx" Version="1.0.13"

RUN powershell -Command \
    $ErrorActionPreference = 'Stop'; \
    Invoke-WebRequest -Method Get -Uri http://nginx.org/download/nginx-1.9.13.zip -OutFile c:\nginx-1.9.13.zip ; \
    Expand-Archive -Path c:\nginx-1.9.13.zip -DestinationPath c:\ ; \
    Remove-Item c:\nginx-1.9.13.zip -Force

RUN powershell -Command \
    Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force ; \
    Install-Module PsHosts -Force

COPY ./nginx.conf /nginx-1.9.13/conf/nginx.conf
COPY ./start.ps1 /nginx-1.9.13/start.ps1

# RUN copy c:\tmp\nginx.conf c:\nginx-1.9.13\conf\ /Y

WORKDIR /nginx-1.9.13