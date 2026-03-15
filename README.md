#  Task Management System Microservice (Task Tracker API)

This repository contains a professional implementation of a Task Management Microservice, developed as a Midterm Assignment. The project demonstrates advanced C# features, SOLID principles, and containerization.

## 🛠 Features & Architecture

### 1. Domain Layer (OOP & Logic)
- **Advanced Encapsulation**: Implemented a `BaseTask` abstract class where `Id` and `CreatedAt` are immutable after object creation (using private setters/init).
- **Polymorphism**: Developed specific task types: `BugReportTask` (with Severity) and `FeatureRequestTask` (with Estimation).
- **Event-Driven Design**: Integrated a `delegate` and `OnTaskCompleted` event within the base class. The event triggers automatically when a task is marked as finished.

### 2. Service & Repository Layer
- **LINQ Mastery**: Created a `TaskFilterService` that performs complex data processing:
  - Filters and sorts high-priority bugs by date (Descending).
  - Calculates aggregate metrics (Total Estimated Hours) for features.
- **Dependency Injection (DI)**: Followed the DI pattern to decouple the controller from the data storage via `ITaskRepository`.
- **In-Memory Storage**: Thread-safe repository for rapid testing and development.

### 3. Web API (REST)
- **Swagger/OpenAPI**: Fully documented interactive API for testing endpoints.
- **Endpoints**:
  - `GET /api/tasks`: Retrieve all tasks.
  - `POST /api/tasks/bug`: Create new bug reports.
  - `PUT /api/tasks/{id}/complete`: Business logic execution that triggers domain events.

### 4. DevOps & Containerization
- **Multi-Stage Dockerfile**: Optimized for performance and small image size (separate SDK build and Runtime stages).
- **Orchestration**: `docker-compose.yml` included for one-click deployment.

