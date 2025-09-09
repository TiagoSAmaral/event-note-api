#!/bin/bash
# Nome do script: start-app-docker.sh
# Descrição: Realiza build, executa o projeto no docker.
# pré-requisito: Requer permissão de execução. Execute o comando: chmod +x start-app-docker.sh
# Autor: Tiago Amaral
# Data: 2025-09-08

# Criar a imagem
docker build -t event-list-api .

# Rodar a imagem em produção
docker run -d -p 5185:5185 --name event-list-api event-list-api