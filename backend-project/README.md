# Proyecto Backend

Este proyecto es una aplicación backend desarrollada en ASP.NET Core. Su objetivo es proporcionar una API que pueda ser consumida por aplicaciones frontend o servicios externos.

## Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

- **src/Backend.Api**: Contiene el código fuente de la aplicación.
  - **Program.cs**: Punto de entrada de la aplicación, donde se configura el servidor y se inicializa la aplicación.
  - **appsettings.json**: Archivo de configuración que contiene cadenas de conexión y otras configuraciones específicas del entorno.
  - **Backend.Api.csproj**: Archivo de proyecto que define las dependencias y configuraciones necesarias para compilar y ejecutar la aplicación.

- **gemini.instruction.backend.md**: Instrucciones específicas para el backend, siguiendo el formato NCAPAS.

- **README.md**: Documentación general del proyecto.

- **.gitignore**: Especifica los archivos y carpetas que deben ser ignorados por Git.

## Instrucciones de Instalación

1. Clona el repositorio en tu máquina local.
2. Abre una terminal y navega hasta la carpeta del proyecto.
3. Ejecuta el siguiente comando para restaurar las dependencias:
   ```
   dotnet restore
   ```
4. Para ejecutar la aplicación, utiliza el siguiente comando:
   ```
   dotnet run --project src/Backend.Api/Backend.Api.csproj
   ```

## Despliegue en IIS

Para desplegar la aplicación en IIS, sigue estos pasos:

1. Publica la aplicación utilizando el siguiente comando:
   ```
   dotnet publish --configuration Release --output ./publish
   ```
2. Copia el contenido de la carpeta `./publish` al directorio donde deseas alojar la aplicación en el servidor IIS.
3. Configura un nuevo sitio en IIS apuntando al directorio donde copiaste los archivos.
4. Asegúrate de que el módulo ASP.NET Core esté instalado y configurado en IIS.
5. Inicia el sitio y verifica que la aplicación esté funcionando correctamente.

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT.