#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy-amd64

RUN apt update
RUN apt install -y unzip xvfb libxi6 libgconf-2-4 gnupg
RUN curl -sS -o - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add
RUN wget http://dl.google.com/linux/chrome/deb/pool/main/g/google-chrome-stable/google-chrome-stable_120.0.6099.129-1_amd64.deb
RUN apt -y install ./google-chrome-stable_120.0.6099.129-1_amd64.deb

RUN wget https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/linux64/chromedriver-linux64.zip
RUN unzip chromedriver-linux64.zip

WORKDIR /src
COPY [".", "."]
RUN dotnet restore "./system_test.csproj"

ENV CONTAINER_MODE=true

ENTRYPOINT ["dotnet", "test"]