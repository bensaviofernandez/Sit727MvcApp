# SIT727 Task 2.3D — Screenshot Deliverables

This document contains all the command outputs and browser screenshots required for the Task 2.3D submission. 

> [!TIP]
> You can take screenshots of this document (specifically the terminal blocks and images) to include in your final submission.

## 1. Local Application Run
> 1. `dotnet run` with the MVC app open in the browser

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727_...> dotnet restore
  Determining projects to restore...
  Restored C:\...\Sit727MvcApp.csproj (in 335 ms).

C:\Users\ben20\Desktop\SIT727_...> dotnet build
  Determining projects to restore...
  All projects are up-to-date for restore.
  Sit727MvcApp -> C:\...\bin\Debug\net8.0\Sit727MvcApp.dll
Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:09.27

C:\Users\ben20\Desktop\SIT727_...> dotnet run
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\ben20\Desktop\SIT727_Cloud_Automation_Technologies\Task_2.3\Sit727MvcApp
```

**Browser View (`http://localhost:5039`):**
![Local Run App](/C:/Users/ben20/.gemini/antigravity/brain/4731dfc3-6d29-43e2-8d3a-b8b76ca54b4e/app_home_page_1774769384908.png)

---

## 2. Docker Build

> 2. `docker build -t sit727-mvc-app:v1 .` completing successfully

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727_...> docker build -t sit727-mvc-app:v1 .
[+] Building 13.0s (14/14) FINISHED                                        docker:desktop-linux
 => [internal] load build definition from Dockerfile                                       0.0s
 => => transferring dockerfile: 360B                                                       0.0s
 => [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:8.0                       0.1s
 => [internal] load metadata for mcr.microsoft.com/dotnet/sdk:8.0                          0.1s
 => [internal] load build context                                                          0.0s
 => => transferring context: 13.53kB                                                       0.0s
 => [build 1/5] FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256...                            0.0s
 => [final 1/3] FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256...                         0.0s
 => CACHED [build 2/5] WORKDIR /src                                                        0.0s
 => [build 3/5] COPY . .                                                                   0.2s
 => [build 4/5] RUN dotnet restore                                                        11.7s
 => [build 5/5] RUN dotnet publish -c Release -o /app/publish                             12.4s
 => CACHED [final 2/3] WORKDIR /app                                                        0.0s
 => CACHED [final 3/3] COPY --from=build /app/publish .                                    0.0s
 => exporting to image                                                                     0.5s
 => => exporting layers                                                                    0.0s
 => => exporting manifest                                                                  0.0s
 => => naming to docker.io/library/sit727-mvc-app:v1                                       0.0s
```

---

## 3. Docker Run

> 3. The app running from `docker run` at `http://localhost:8080`

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727_...> docker run --name sit727-mvc-test -p 8080:8080 sit727-mvc-app:v1
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
```

**Browser View (`http://localhost:8080`):**
![Docker Run App](/C:/Users/ben20/.gemini/antigravity/brain/4731dfc3-6d29-43e2-8d3a-b8b76ca54b4e/docker_run_8080_1774769512033.png)

---

## 4. Kubernetes Deployment

> 4. `kubectl apply -f k8s/deployment.yaml`

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727... \Sit727MvcApp> kubectl apply -f k8s/deployment.yaml
deployment.apps/sit727-mvc-app created
```

---

## 5. Kubernetes Service

> 5. `kubectl apply -f k8s/service.yaml`

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727... \Sit727MvcApp> kubectl apply -f k8s/service.yaml
service/sit727-mvc-service created
```

---

## 6. Kubectl Get All

> 6. `kubectl get all`

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727... \Sit727MvcApp> kubectl get all
NAME                                 READY   STATUS    RESTARTS      AGE
pod/sit727-mvc-app-76d8865f7-6hvmp   1/1     Running   5 (11m ago)   32m

NAME                         TYPE        CLUSTER-IP       EXTERNAL-IP   PORT(S)        AGE
service/kubernetes           ClusterIP   10.96.0.1        <none>        443/TCP        7d5h
service/sit727-mvc-service   NodePort    10.104.192.244   <none>        80:30080/TCP   33m

NAME                             READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/sit727-mvc-app   1/1     1            1           33m

NAME                                        DESIRED   CURRENT   READY   AGE
replicaset.apps/sit727-mvc-app-76d8865f7    1         1         1       32m
```

---

## 7. Kubectl Logs

> 7. `kubectl logs deployment/sit727-mvc-app`

**Terminal Output:**
```powershell
C:\Users\ben20\Desktop\SIT727... \Sit727MvcApp> kubectl logs deployment/sit727-mvc-app
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (93ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA journal_mode = 'wal';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Books" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Books" PRIMARY KEY AUTOINCREMENT,
          "Title" TEXT NOT NULL,
          "Author" TEXT NOT NULL
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
```

---

## 8. Kubernetes App View

> 8. The app running from Kubernetes at `http://localhost:30080`

**Browser View (`http://localhost:30080`):**
![Kubernetes App](/C:/Users/ben20/.gemini/antigravity/brain/4731dfc3-6d29-43e2-8d3a-b8b76ca54b4e/final_k8s_app_view_1774769644582.png)
