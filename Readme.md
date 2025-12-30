# InventoryManagement.Api

A backend Inventory Management system built with ASP.NET Core Web API, Entity Framework Core, and PostgreSQL.  
The project follows clean architecture principles and is containerized using Docker.

---

## 🚀 Tech Stack

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- PostgreSQL
- Docker & Docker Compose
- Clean Architecture (Controllers, Services, DTOs)

---

## 📦 Features

- Category management
- Product management
- Inventory stock tracking
- Global exception handling middleware
- RESTful API design
- Dockerized setup (API + Database)

---

## 🧱 Project Structure

Controllers
Data
Dtos
Models
Services
Middlewares
Migrations


---

## 🐳 Run with Docker (Recommended)

### Prerequisites
- Docker Desktop installed

### Steps

```bash
docker compose up --build

API will run on: http://localhost:8080

PostgreSQL runs inside Docker


🧪 API Endpoints (Sample)

POST /api/categories

GET /api/products

POST /api/inventory

GET /api/inventory/product/{productId}

PUT /api/inventory/product/{productId}

📌 Notes

Inventory is managed separately from products

Global exception middleware handles unexpected errors

Designed as a realistic backend system for learning and interviews


👤 Author

Ezaj Shaikh
Backend .NET Developer


----

