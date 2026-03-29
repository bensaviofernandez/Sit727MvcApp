# SIT727 Task 2.3D

This project is a simple ASP.NET Core MVC application using SQLite, containerised with Docker, and deployed to Kubernetes.

## Prerequisites

- .NET 8 SDK
- Docker Desktop running
- Kubernetes enabled in Docker Desktop
- `kubectl` available in the terminal

## Run Locally

Open a terminal in this folder and run:

```powershell
dotnet restore
dotnet build
dotnet run
```

Open the local URL shown in the terminal, typically:

```text
http://localhost:5039
```

## Build And Run With Docker

From this folder, run:

```powershell
docker build -t sit727-mvc-app:v1 .
docker run --name sit727-mvc-test -p 8080:8080 sit727-mvc-app:v1
```

Open:

```text
http://localhost:8080
```

To stop and remove the test container after checking it:

```powershell
docker rm -f sit727-mvc-test
```

## Deploy To Kubernetes

Apply the manifests:

```powershell
kubectl apply -f k8s/deployment.yaml
kubectl apply -f k8s/service.yaml
```

Check deployment status:

```powershell
kubectl get all
kubectl logs deployment/sit727-mvc-app
```

Open the app through Kubernetes:

```text
http://localhost:30080
```

- If a port is already in use, stop the existing process or container before retrying.
