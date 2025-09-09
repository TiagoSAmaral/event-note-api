# Etapa de build e runtime juntos (para desenvolvimento)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev
WORKDIR /app

# Copia arquivos de projeto e restaura dependências
COPY *.sln ./
COPY event-list.csproj ./
RUN dotnet restore event-list.csproj

# Copia todo o código-fonte
COPY . ./

# Porta do ambiente de dev (Swagger ativo)
EXPOSE 5185

# Comando padrão roda em modo desenvolvimento
ENV DOTNET_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_HOST_PATH=/usr/share/dotnet/dotnet
ENV DOTNET_WATCH=1
ENV DOTNET_URLS=http://+:5185

ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile", "--urls", "http://0.0.0.0:5185"]