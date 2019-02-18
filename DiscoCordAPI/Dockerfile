FROM microsoft/dotnet
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./DiscoCordAPI.Web.Api/entrypoint.sh
CMD /bin/bash ./DiscoCordAPI.Web.Api/entrypoint.sh
