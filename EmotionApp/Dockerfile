# 1. Use the official Linux .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. Copy the project file directly from the current folder
COPY ["EmotionApp.csproj", "./"]
RUN dotnet restore "EmotionApp.csproj"

# 3. Copy everything else in the current folder and build
COPY . .
RUN dotnet build "EmotionApp.csproj" -c Release -o /app/build

# 4. Publish the application
FROM build AS publish
RUN dotnet publish "EmotionApp.csproj" -c Release -o /app/publish

# 5. Use the lightweight Linux Runtime to run the background tasks
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# 6. Run the app
ENTRYPOINT ["dotnet", "EmotionApp.dll"]