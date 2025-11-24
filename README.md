# PPT_API

Este proyecto es una API, desarrollada en **.NET Core 8.0** con una arquitectura modular. El proyecto está organizado en capas para mantener la separación de responsabilidades y facilitar la escalabilidad y mantenibilidad.

## Estructura del Proyecto
```
│── API
│   ├── PPT.API
│   ├── Controllers       Endpoints expuestos al cliente
│   ├── Extensions        Métodos de extensión
│   ├── appsettings.json  Configuración de la aplicación
│   ├── Program.cs        Punto de entrada principal de la API
│
│── Application
│   ├── PPT.Application
│   ├── DTO               Objetos de transferencia de datos
│   ├── Interfaces        Interfaces de servicios que definen el contrato
│   ├── Mappings          Configuración de AutoMapper
│   ├── Services          Implementación de la lógica de aplicación
│
│── Domain
│   ├── PPT.Domain
│   ├── Entities          Entidades del dominio
│   ├── Interfaces        Interfaces del dominio
│
│── Infrastructure
│   ├── PPT.Infrastructure
│   ├── Data              Contexto de base de datos (EF Core DbContext)
│   ├── Repositories      Implementaciones concretas de acceso a datos
│   ├── Migrations        Migraciones de Entity Framework Core
```

## Funcionamiento
- Antes de ejecutar el proyecto, configurar la conexión a la base de datos "SQLConnection" en appsettings.json
- Al ejecutar la aplicación se ejecuta la migracion "InitialTables" la cual crea la base de datos con sus 
  respectivas tablas.
- También se crean datos de ejemplos en las tablas Jugadores y Batallas
