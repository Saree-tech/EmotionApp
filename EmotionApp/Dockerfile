# 1. Use the official Microsoft .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR /src

# 2. Copy the project file directly from the current folder
COPY ["EmotionApp.csproj", "./"]
RUN dotnet restore "EmotionApp.csproj"

# 3. Copy everything else in the current folder and build
COPY . .
RUN dotnet publish "EmotionApp.csproj" -c Release -o /app/publish

# 4. Use the Windows Runtime to run the app
FROM mcr.microsoft.com/dotnet/runtime:8.0-windowsservercore-ltsc2022 AS final
WORKDIR /app
COPY --from=build /app/publish .

# 5. Run the app
ENTRYPOINT ["dotnet", "EmotionApp.dll"]