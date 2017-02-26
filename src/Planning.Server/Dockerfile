#FROM microsoft/dotnet:latest
FROM microsoft/dotnet

#FROM microsoft/dotnet:1.0-sdk-projectjson
#FROM microsoft/dotnet:1.0-runtime

#FROM microsoft/aspnetcore:1.0

COPY . /app
WORKDIR /app
 
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
 
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
 
ENTRYPOINT ["dotnet", "run"]
