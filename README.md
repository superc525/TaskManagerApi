# Sistema de Gestión de Tareas API

Una API para gestionar tareas, desarrollada en .NET.  
Incluye los proyectos: 
- `TaskManager` (API principal)  
- `TaskManager.Data` (Persistencia y Migracion)  
- `TaskManager.Domain` (Clases y Dtos)  
- `TaskManager.Service` (Aqui se agregan reglas de negocio)  
- `TaskManager.Utilities` (Aqui se agrega el mapeo de datos)  

## Requisitos

- [.NET 8 SDK] o superior
- SQL Server / Base de datos compatible
- Visual Studio 2022 o VS Code

## Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/superc525/TaskManagerApi.git
cd TaskManagerApi

2. Base de datos:
  Se debe cambiar el dominio para el mapeo de la base de datos. Esto de debe hacer en el Proyecto/TaskManager/appsettings.json:
   "Data Source=**FuenteDeDatos**; Initial Catalog=TaskManager; Integrated Security=true; TrustServerCertificate=True"
3. El sistema esta hecho para generar la base de datos con las tablas necesarias al momento de dar ejecutar
4. Migraciones
   Con los compandos en Consola de administración de paquetes.(Como el proyecto esta desacoplado debe posicionarse en TaskManager.Domain)
   Add-Migration Migra tíos
   Update-Database