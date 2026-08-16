# Instrucciones de Desarrollo Backend - Aupad.DesarrolloApiNet

## 1. Objetivo General
Establecer las reglas de arquitectura, estándares de codificación y procedimientos de despliegue para completar el backend en .NET (ASP.NET Core) del proyecto **Aupad.DesarrolloApiNet**.
La solución se diseña estrictamente en una **Arquitectura en N Capas (NCAPAS)** y se destina a ser desplegada en **Microsoft Internet Information Services (IIS)** en entornos Windows Server, manteniendo cero dependencias de servicios o infraestructura externa.

---

## 2. Requisitos Mandatorios

1. **Idioma:** Todo el código, comentarios, documentación, DTOs, nombres de clases y mensajes deben estar exclusivamente en **Español**.
2. **Arquitectura:** Debe respetarse rigurosamente la separación de responsabilidades mediante la arquitectura en N Capas existente (`Modelos`, `Repositorio`, `Negocio`, `Api`).
3. **Despliegue IIS:** Compatibilidad nativa e in-process con IIS (`AspNetCoreModuleV2`). Queda estrictamente prohibido usar Docker, Redis, RabbitMQ, Kafka, servicios cloud o librerías que requieran componentes externos instalados en el servidor.
4. **Stack Tecnológico:**
   - **Lenguaje / Framework:** C# / ASP.NET Core (.NET 8+).
   - **Acceso a Datos:** Entity Framework Core (DbContext & Migraciones).
   - **Base de Datos:** SQL Server / MySQL (configurable en `appsettings.json`).
   - **Documentación API:** Swagger / OpenAPI nativo de ASP.NET Core.

---

## 3. Estructura de Arquitectura en N Capas (NCAPAS)

La solución se divide en 4 proyectos estructurados de la siguiente manera:

```
Aupad.DesarrolloApiNet/
├── Aupad.DesarrolloApiNet.Modelos/      # Capa 1: Dominio y Entidades
├── Aupad.DesarrolloApiNet.Repositorio/  # Capa 2: Infraestructura y Acceso a Datos (EF Core)
├── Aupad.DesarrolloApiNet.Negocio/      # Capa 3: Aplicación y Lógica de Negocio
└── Aupad.DesarrolloApiNet.Api/          # Capa 4: Presentación y Controladores REST
```

### Capa 1: Dominio y Entidades (`Aupad.DesarrolloApiNet.Modelos`)
- Contiene las entidades POCO que mapean las tablas del sistema:
  - `TipoDocumento.cs`
  - `CategoriaSeguro.cs`
  - `CompaniasSeguro.cs`
  - `Clientes.cs`
- Contiene los Enums, DTOs y clases de transferencia de datos de entrada/salida.
- **Regla:** No debe depender de ninguna otra capa ni de frameworks de persistencia o controladores.

### Capa 2: Infraestructura y Acceso a Datos (`Aupad.DesarrolloApiNet.Repositorio`)
- Contiene `AupadDbContext.cs`, mapeos de tablas mediante `OnModelCreating`, y migraciones de Entity Framework Core.
- Contiene las interfaces y sus implementaciones concretas para la manipulación de datos:
  - `ITipoDocumentoRepositorio` / `TipoDocumentoRepositorio`
  - `ICategoriaSeguroRepositorio` / `CategoriaSeguroRepositorio`
  - `ICompaniaSeguroRepositorio` / `CompaniaSeguroRepositorio`
  - `IClienteRepositorio` / `ClienteRepositorio`
- **Regla:** Solo responde a la capa de Negocio e implementa operaciones asíncronas (`async`/`await`).

### Capa 3: Lógica de Negocio (`Aupad.DesarrolloApiNet.Negocio`)
- Orquesta las reglas de negocio, validaciones y casos de uso de la aplicación:
  - `ITipoDocumentoNegocio` / `TipoDocumentoNegocio`
  - `ICategoriaSeguroNegocio` / `CategoriaSeguroNegocio`
  - `ICompaniaSeguroNegocio` / `CompaniaSeguroNegocio`
  - `IClienteNegocio` / `ClienteNegocio` (Pendiente por completar)
- **Regla:** Ningún controlador debe comunicarse directamente con la capa de `Repositorio`. La capa de `Negocio` actúa como mediador obligatorio.

### Capa 4: Presentación y API REST (`Aupad.DesarrolloApiNet.Api`)
- Expone los endpoints HTTP a través de controladores ASP.NET Core:
  - `TipoDocumentoController.cs`
  - `CategoriaSeguroControllers.cs`
  - `CompaniaSeguroControllers.cs`
  - `ClienteController.cs` (Pendiente por completar)
- Contiene `Program.cs` para el registro de Inyección de Dependencias, Middlewares y `appsettings.json`.
- Mantiene el archivo `web.config` para despliegue directo en IIS.

---

## 4. Normas y Estándares de Código C#

1. **Inyección de Dependencias:**
   - Todas las dependencias entre capas deben estar desacopladas mediante Interfaces.
   - Registrar servicios en `Program.cs` usando `builder.Services.AddScoped<I..., ...>()`.
2. **Programación Asíncrona:**
   - Usar `async` y `await` en todos los métodos de controladores, servicios de negocio y repositorios de EF Core.
3. **Manejo de Respuestas y Errores:**
   - Retornar tipos `ActionResult<T>` estructurados en los controladores.
   - Retornar códigos de estado HTTP adecuados (`200 OK`, `201 Created`, `400 Bad Request`, `404 Not Found`, `500 Internal Server Error`).
   - Evitar fugas de información sensible en los mensajes de error en producción.
4. **Nombres y Convenciones:**
   - Clases, métodos y propiedades en PascalCase (ej. `ObtenerPorIdAsync`, `ClienteRepositorio`).
   - Parámetros y variables locales en camelCase (ej. `numeroDocumento`, `filasAfectadas`).
   - Interfaces iniciadas con `I` (ej. `IClienteNegocio`).

---

## 5. Guía de Despliegue en IIS

Para publicar la aplicación en IIS de Windows Server sin herramientas externas:

1. **Prerrequisitos en el Servidor:**
   - Habilitar el rol de **IIS (Internet Information Services)** en Windows Server.
   - Instalar el paquete **ASP.NET Core Hosting Bundle** oficial de Microsoft.

2. **Compilación y Publicación:**
   ```bash
   dotnet publish D:\Aupad.DesarrolloApiNet\Aupad.DesarrolloApiNet.Api\Aupad.DesarrolloApiNet.Api.csproj -c Release -o D:\Aupad.DesarrolloApiNet\publish
   ```

3. **Configuración de `web.config`:**
   Asegurar que el proyecto generado incluya un `web.config` con el módulo de ASP.NET Core:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <location path="." inheritInChildApplications="false">
       <system.webServer>
         <handlers>
           <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
         </handlers>
         <aspNetCore processPath="dotnet" arguments=".\Aupad.DesarrolloApiNet.Api.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
       </system.webServer>
     </location>
   </configuration>
   ```

4. **Permisos de Archivos:**
   - Otorgar permisos de lectura y ejecución a `IIS_IUSRS` y `AppPoolIdentity` sobre la carpeta publicada.

---

## 6. Lista de Tareas Pendientes para Finalizar el Backend

- [ ] **Completar Capa Negocio:** Crear `IClienteNegocio` e implementar `ClienteNegocio.cs`.
- [ ] **Completar Capa API:** Crear `ClienteController.cs` con endpoints CRUD (`GET`, `POST`, `PUT`, `DELETE`).
- [ ] **Limpiar Program.cs:** Remover endpoints de prueba (`/weatherforecast`) y asegurar el registro de todos los servicios Scoped.
- [ ] **Verificar y Ejecutar Migraciones:** Probar la conectividad del `AupadDbContext` y asegurar la actualización de esquemas.
- [ ] **Validación de Compilación y Pruebas:** Compilar la solución en modo Release y validar que no existan advertencias ni errores.