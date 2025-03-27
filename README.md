# Guía para Ejecutar la Aplicación ASP.NET Core con SQL Server y Angular en Docker

Este proyecto es una aplicación web construida con **ASP.NET Core** para el backend, **SQL Server** como base de datos, y **Angular** para el frontend. Todos los componentes se ejecutan en contenedores Docker.

## Requisitos

Antes de comenzar, asegúrate de tener instalados los siguientes programas:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/)
- [Node.js](https://nodejs.org/) (Recomendado: versión 16 o superior)

## Pasos para Ejecutar la Aplicación

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local:

```bash
git clone https://github.com/rober-ucb/BovIQ_E2.git
cd BovIQ_E2
```
### 2. Ejecutar el comando docker compose
```bash
docker-compose up --build
```

### 3. Acceder a las URLS
[API](https://localhost:5001/scalar/v1) Para ver la documentacion del API
[Angular](https://localhost:4200) Para acceder a la aplicacion angular
