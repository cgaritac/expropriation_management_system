# Expropriation Management System

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?logo=asp.net)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0-512BD4?logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-CC2927?logo=microsoft-sql-server)

Web system developed in ASP.NET Core 8.0 for comprehensive management of expropriation processes. It allows managing files, owners, expropriated properties, appraisals, paperwork, and projects, facilitating the tracking and control of all phases of the expropriation process.

## 📋 Table of Contents

- [Main Features](#-main-features)
- [Technologies Used](#-technologies-used)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Configuration](#-configuration)
- [Project Structure](#-project-structure)
- [Functionality](#-functionality)
- [Data Models](#-data-models)
- [API Endpoints](#-api-endpoints)
- [Development](#-development)

## ✨ Main Features

- **Project Management**: Complete administration of expropriation projects
- **File Management**: Control and tracking of files associated with projects
- **Owner Management**: Registration and administration of owners (individuals and legal entities)
- **Property Management**: Control of expropriated properties with cadastral information
- **Appraisal Management**: Administration of property appraisals and evaluations
- **Paperwork Management**: Tracking of paperwork and legal documentation
- **Phase System**: Control of 19 different phases of the expropriation process
- **Google Authentication**: Integration with Google OAuth for user authentication
- **Reporting System**: Generation of reports and queries
- **Soft Delete**: Logical deletion system to preserve history
- **Auditing**: Automatic recording of creator and creation date of records

## 🛠️ Technologies Used

- **.NET 8.0**: Main framework
- **ASP.NET Core MVC**: Web framework
- **Entity Framework Core 9.0.1**: ORM for data access
- **SQL Server**: Relational database
- **Google OAuth 2.0**: Authentication with Google
- **Razor Views**: View engine for user interface
- **Dependency Injection**: Native .NET dependency injection

## 📦 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or higher
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Google Cloud Platform account with OAuth 2.0 configured (for authentication)

## 🚀 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/expropriation_management_system.git
   cd expropriation_management_system
   ```

2. **Restore NuGet dependencies**
   ```bash
   cd GestionExpropaciones
   dotnet restore
   ```

3. **Configure the database**
   - Create a database in SQL Server
   - Update the connection string in `appsettings.json`

4. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

   The application will be available at `https://localhost:5001` or `http://localhost:5000` (according to configuration).

## ⚙️ Configuration

### `appsettings.json` File

```json
{
  "ConnectionStrings": {
    "AppConnection": "Server=YOUR_SERVER;Database=GestionExpropaciones;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
  },
  "GoogleKeys": {
    "ClientId": "YOUR_GOOGLE_CLIENT_ID",
    "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Google OAuth Configuration

1. Access [Google Cloud Console](https://console.cloud.google.com/)
2. Create a new project or select an existing one
3. Enable the Google+ API (if necessary)
4. Create OAuth 2.0 credentials
5. Add authorized redirect URLs:
   - `https://localhost:5001/signin-google` (development)
   - Your production URL (production)
6. Copy the `ClientId` and `ClientSecret` into `appsettings.json`

## 📁 Project Structure

```
GestionExpropaciones/
├── Common/                    # Common classes and utilities
│   ├── AppSettings.cs        # Application configuration
│   ├── Constants.cs          # System constants
│   ├── Enums/                # Enumerations (Phases, Status, Types, etc.)
│   ├── Exceptions/           # Custom exceptions
│   └── Helpers/              # Helper classes
├── Configurations/           # Service and dependency configuration
│   └── DependencyInjection.cs
├── Controllers/              # MVC and API controllers
│   ├── AuthController.cs
│   ├── ProjectController.cs
│   ├── FilesController.cs
│   ├── OwnerController.cs
│   ├── ExpropiatedPropertyController.cs
│   ├── AppraisalController.cs
│   ├── PaperWorkController.cs
│   └── ReportsController.cs
├── Data/                     # Database context
│   └── DBContext.cs
├── Extensions/               # Application and pipeline extensions
│   ├── ApplicationOfExtensions.cs
│   └── AppPipelineExtensions.cs
├── Interceptors/             # EF Core interceptors
│   └── SoftDeleteInterceptor.cs
├── Interfaces/               # Service and repository contracts
│   ├── IServices/
│   └── IRepositories/
├── Middleware/               # Custom middleware
│   ├── EmailDomainMiddleware.cs
│   └── InvalidateCookiesMiddleware.cs
├── Migrations/               # Entity Framework migrations
├── Models/                   # Domain models
│   ├── ProjectModel.cs
│   ├── FileModel.cs
│   ├── OwnerModel.cs
│   ├── ExpropiatedPropertyModel.cs
│   ├── AppraisalModel.cs
│   ├── PaperWorkModel.cs
│   └── OwnerPropertyModel.cs
├── Repositories/             # Repository implementations
├── Services/                 # Business logic
├── Views/                    # Razor views
├── wwwroot/                  # Static files (CSS, JS, images)
└── Program.cs                # Application entry point
```

## 🎯 Functionality

### Project Management
- Create, edit, and delete projects
- Associate files with projects
- Track active projects

### File Management
- Complete file control
- Tracking of 19 phases of the expropriation process:
  - Opening
  - Management
  - Mandate Annotation
  - Public Interest Declaration
  - Declaration Publication (DIP)
  - Administrative Appraisal
  - Appraisal and DIP Notification
  - Resolutions
  - Appraisal Funds Request
  - Appraisal Deposit
  - Certifications
  - Measurements and Boundaries
  - Liens Report
  - Legal Entity
  - Prosecutor's Office Notary
  - Prosecutor's Office Court
  - Public Deed
  - Judicial Possession Takeover
  - Other

- File statuses:
  - Created
  - In Progress
  - Stopped
  - Dismissed
  - Finalized (EPJ)
  - Finalized (PNE)
  - Other

### Owner Management
- Owner registration (individuals and legal entities)
- Contact information (phones, emails, addresses)
- Association with files

### Expropriated Property Management
- Cadastral information registration (folio, cadastral map, area)
- Geographic information (province, canton, district)
- Comments and additional notes

### Appraisal Management
- Property appraisal registration
- Evaluation tracking

### Paperwork Management
- Control of paperwork and legal documentation
- Administrative process tracking

### Reporting System
- Report generation and queries
- Information export

## 📊 Data Models

### Main Entities

- **Project**: Expropriation projects
- **File**: Files associated with projects
- **Owner**: Owners (individuals and legal entities)
- **OwnerProperty**: Properties associated with owners
- **ExpropiatedProperty**: Expropriated properties with cadastral information
- **Appraisal**: Property appraisals
- **PaperWork**: Paperwork and legal documentation

### Relationships

- A **Project** can have multiple **Files**
- A **File** can have multiple **Owners**
- A **File** can have multiple **Expropriated Properties**
- A **File** can have multiple **Appraisals**
- A **File** can have multiple **Paperwork**
- An **Owner** can have multiple **Properties**

## 🔌 API Endpoints

### Authentication
- `POST /Auth/Login` - Login
- `POST /Auth/Logout` - Logout

### Projects
- `GET /Project` - List projects
- `GET /Project/{id}` - Get project by ID
- `POST /Project` - Create project
- `PUT /Project/{id}` - Update project
- `DELETE /Project/{id}` - Delete project

### Files
- `GET /Files` - List files
- `GET /Files/{id}` - Get file by ID
- `POST /Files` - Create file
- `PUT /Files/{id}` - Update file
- `DELETE /Files/{id}` - Delete file

### Owners
- `GET /Owner` - List owners
- `GET /Owner/{id}` - Get owner by ID
- `POST /Owner` - Create owner
- `PUT /Owner/{id}` - Update owner
- `DELETE /Owner/{id}` - Delete owner

### Expropriated Properties
- `GET /ExpropiatedProperty` - List properties
- `GET /ExpropiatedProperty/{id}` - Get property by ID
- `POST /ExpropiatedProperty` - Create property
- `PUT /ExpropiatedProperty/{id}` - Update property
- `DELETE /ExpropiatedProperty/{id}` - Delete property

### Appraisals
- `GET /Appraisal` - List appraisals
- `GET /Appraisal/{id}` - Get appraisal by ID
- `POST /Appraisal` - Create appraisal
- `PUT /Appraisal/{id}` - Update appraisal
- `DELETE /Appraisal/{id}` - Delete appraisal

### Paperwork
- `GET /PaperWork` - List paperwork
- `GET /PaperWork/{id}` - Get paperwork by ID
- `POST /PaperWork` - Create paperwork
- `PUT /PaperWork/{id}` - Update paperwork
- `DELETE /PaperWork/{id}` - Delete paperwork

### Reports
- `GET /Reports` - Generate reports

## 💻 Development

### Architecture Pattern

The project uses a layered architecture with separation of concerns:

- **Controllers**: Handle HTTP requests and coordinate responses
- **Services**: Contain business logic
- **Repositories**: Abstract data access
- **Models**: Represent domain entities
- **Data**: Entity Framework Core context

### Implemented Patterns

- **Repository Pattern**: Data access abstraction
- **Dependency Injection**: Native dependency injection
- **Soft Delete**: Logical record deletion
- **Unit of Work**: Transaction management (implicit with EF Core)

### Create a New Migration

```bash
dotnet ef migrations add MigrationName --project GestionExpropaciones
```

### Rollback a Migration

```bash
dotnet ef database update PreviousMigrationName --project GestionExpropaciones
```

### Run Tests (if any)

```bash
dotnet test
```

## 📝 Additional Notes

- The system uses logical deletion (Soft Delete) to preserve data history
- All records include auditing information (created by, creation date)
- Authentication is performed through Google OAuth 2.0
- The system includes custom middleware for email domain validation

## 🤝 Contributing

Contributions are welcome. Please:

1. Fork the project
2. Create a branch for your feature (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is private and owned by **CGC**. All rights reserved.

## 👨‍💻 Author

Developed by **CGC**

---

**Note**: This system is designed as a non real example of how the expropriation processes could be manage in Costa Rica, it do not apply to other countries or in real scenarios.
