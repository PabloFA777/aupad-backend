# Instrucciones para el Backend del Proyecto

## Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

- **src/Backend.Api**: Contiene el código fuente de la API.
  - **Program.cs**: Punto de entrada de la aplicación, donde se configura el servidor y se inicializa la aplicación ASP.NET Core.
  - **appsettings.json**: Archivo de configuración en formato JSON que contiene cadenas de conexión y configuraciones específicas del entorno.
  - **Backend.Api.csproj**: Archivo de configuración del proyecto que define las dependencias y configuraciones necesarias para compilar y ejecutar la aplicación.

## Despliegue en IIS

Para desplegar la aplicación en IIS, sigue estos pasos:

1. **Instalación de IIS**: Asegúrate de que IIS esté instalado en tu servidor. Puedes habilitarlo a través de "Activar o desactivar características de Windows".

2. **Configuración del sitio**:
   - Abre el Administrador de IIS.
   - Crea un nuevo sitio web y asigna una carpeta física donde se publicará la aplicación.
   - Configura el nombre del sitio y el puerto.

3. **Publicación de la aplicación**:
   - Abre una terminal y navega hasta la carpeta del proyecto.
   - Ejecuta el siguiente comando para publicar la aplicación:
     ```
     dotnet publish -c Release -o ./publish
     ```
   - Copia el contenido de la carpeta `publish` a la carpeta física que configuraste en IIS.

4. **Configuración de la aplicación**:
   - Asegúrate de que el módulo ASP.NET Core esté instalado en IIS.
   - Configura el archivo `web.config` en la carpeta de publicación si es necesario. Este archivo debe contener la configuración para redirigir las solicitudes a la aplicación ASP.NET Core.

5. **Permisos**:
   - Asegúrate de que la cuenta de usuario que ejecuta el proceso de IIS tenga permisos de lectura y ejecución en la carpeta de la aplicación.

6. **Iniciar el sitio**:
   - En el Administrador de IIS, selecciona el sitio y haz clic en "Iniciar".

## Mantenimiento y Desarrollo

- Para realizar cambios en la aplicación, edita los archivos en `src/Backend.Api` y vuelve a publicar la aplicación siguiendo los pasos anteriores.
- Utiliza el archivo `README.md` para documentar cualquier cambio significativo en la aplicación o en el proceso de despliegue.

## Notas Adicionales

- Asegúrate de que todas las dependencias estén correctamente configuradas en el archivo `Backend.Api.csproj`.
- Mantén el archivo `appsettings.json` actualizado con las configuraciones necesarias para el entorno de producción.