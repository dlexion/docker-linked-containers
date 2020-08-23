# Docker linked containers

Example of linking docker containers. Container created with ASP.NET Core Web API is connected with MSSQL database container to perform simple CRUD operations.

## How to run locally

---

- Download and start mssql server container

  ```powershell
  docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Testing123' -p 1433:1433   --name sqlserver -d microsoft/mssql-server-linux
  ```

- Publish the application and its dependencies to a folder for deployment to a hosting system

  ```powershell
  dotnet publish -c Release -o out
  ```

- Build container for application

  ```powershell
  docker build -t cities-api .
  ```

- Run created container and link with ms sql container

  ```powershell
  docker run -it --rm -p 5000:5000 --link sqlserver -e   SQLSERVER_HOST=sqlserver cities-api
  ```

## How to use application

---

- HTTP GET method
  - For console or bash

    ```console
    curl http://localhost:5000/api/cities
    ```

  - For Powershell

    ```powershell
    Invoke-RestMethod http://localhost:5000/api/cities
    ```

- HTTP POST method
  - For bash

    ```console
    curl -i -H "Content-Type: application/json" -X POST -d '{"name": "Minsk", "country": "Belarus", "population": 1800000}' http://localhost:5000/api/cities
    ```

  - For console

    ```console
    curl -i -H "Content-Type:application/json" -X POST -d "{\"name\": \"Minsk\", \"country\": \"Belarus\", \"population\": 1800000}" http://localhost:5000/api/cities
    ```

  - For Powershell

    ```powershell
    Invoke-RestMethod -Uri 'http://localhost:5000/api/cities' -Method Post -ContentType 'application/json' -Body '{"name": "Minsk", "country": "Belarus", "population": 1800000}'
    ```
