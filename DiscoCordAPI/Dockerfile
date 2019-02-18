FROM microsoft/dotnet
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
