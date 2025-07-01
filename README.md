
# ElyssaBack

Solución ASP.NET Core Web API profesionalizada para gestión de usuarios, roles y permisos, con arquitectura por capas, seguridad JWT, acceso real a PostgreSQL (Supabase) y documentación Swagger.

---

## Descripción General
ElyssaBack es un backend modular y seguro para la gestión de usuarios, roles y permisos, pensado para empresas que requieren control de acceso granular (RBAC). Incluye:
- Creación y autenticación de usuarios (JWT).
- Definición de roles y asociación de permisos.
- Protección de rutas por permisos y roles.
- Acceso a base de datos PostgreSQL (Supabase) mediante EF Core.
- Documentación interactiva con Swagger.

## Estructura del Proyecto
- **ApiProject/**: Web API principal (endpoints REST, configuración Swagger, autenticación y autorización).
- **Domain/**: Modelos y entidades de negocio (`User`, `Role`, `Permission`).
- **Application/**: Lógica de negocio y servicios (`UserService`, etc.).
- **Infrastructure/**: Acceso a datos y persistencia (EF Core, `AppDbContext`).
- **Domain.Tests/** y **Application.Tests/**: Pruebas unitarias para cada capa.
- **Script-SQL-ElyssaApp.sql**: Script de creación de tablas para PostgreSQL.

## Requisitos del Sistema
- .NET 8 SDK
- Acceso a una base de datos PostgreSQL (recomendado: Supabase)
- Windows, Linux o macOS

## Instalación y Primeros Pasos
1. Clona el repositorio y accede a la carpeta raíz del proyecto.
2. Restaura y compila la solución:
   ```sh
   dotnet build
   ```
3. Configura la cadena de conexión en `ApiProject/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=...;Port=5432;Database=...;Username=...;Password=..."
   }
   ```
   - Usa los datos de tu instancia de Supabase/PostgreSQL.
4. Aplica el script SQL (`Script-SQL-ElyssaApp.sql`) en tu base de datos para crear las tablas necesarias.
   - Puedes ejecutarlo desde la consola de Supabase, PgAdmin o usando `psql`:
     ```sh
     psql "host=HOST user=USUARIO dbname=DB password=CLAVE port=5432" -f Script-SQL-ElyssaApp.sql
     ```
   - En Supabase: ve a la sección SQL Editor y copia el contenido del script para ejecutarlo.
5. Ejecuta la API:
   ```sh
   dotnet run --project ApiProject
   ```
6. Accede a la documentación interactiva en Swagger:
   - [http://localhost:5257/swagger](http://localhost:5257/swagger) (o el puerto configurado)
7. Ejecuta los tests:
   ```sh
   dotnet test
   ```

## Migraciones y Base de Datos
- El modelo de datos está preparado para EF Core y PostgreSQL.
- Puedes usar el script `Script-SQL-ElyssaApp.sql` para inicializar la base de datos.
- Ejemplo de inicialización en Supabase:
  1. Ve al panel de Supabase > SQL Editor.
  2. Copia y ejecuta el contenido de `Script-SQL-ElyssaApp.sql`.
  3. Verifica que las tablas `users`, `roles`, `permissions` y `role_permissions` se hayan creado.
- Si deseas usar migraciones de EF Core:
  ```sh
  dotnet ef migrations add InitialCreate --project Infrastructure --startup-project ApiProject
  dotnet ef database update --project Infrastructure --startup-project ApiProject
  ```
- Asegúrate de tener instalada la herramienta EF Core CLI:
  ```sh
  dotnet tool install --global dotnet-ef
  ```

## Configuración de Seguridad (JWT)
En `appsettings.json` configura la clave, emisor y audiencia:
```json
"Jwt": {
  "Key": "TU_CLAVE_SECRETA",
  "Issuer": "ElyssaApp",
  "Audience": "ElyssaAppUsers"
}
```
**No uses claves triviales en producción.**

### Advertencias de Seguridad
- **Nunca subas tu archivo `appsettings.json` con contraseñas reales a un repositorio público.**
- Usa variables de entorno o secretos de usuario para datos sensibles en producción.
- Cambia la clave JWT y las credenciales de la base de datos antes de desplegar.
- Limita el CORS y usa HTTPS en producción.
- Revisa los permisos de los roles y usuarios en tu base de datos.

## Endpoints Principales
- `POST /api/auth/login` — Login (devuelve JWT)
- `GET /api/auth/me` — Perfil del usuario autenticado
- `POST /api/users` — Crear usuario
- `GET /api/users` — Listar usuarios (requiere JWT)
- `POST /api/roles` — Crear rol *(a implementar)*
- `GET /api/roles` — Listar roles *(a implementar)*
- `POST /api/permissions` — Crear permiso *(a implementar)*
- `GET /api/permissions` — Listar permisos *(a implementar)*

## Ejemplo de Uso de la API
```http
POST /api/auth/login
Content-Type: application/json
{
  "email": "admin@demo.com",
  "password": "1234"
}

POST /api/users
Authorization: Bearer {jwt}
Content-Type: application/json
{
  "email": "nuevo@demo.com",
  "name": "Nuevo",
  "password": "1234",
  "roleId": "{role-guid}"
}
```

## Pruebas Unitarias
El proyecto incluye tests para las capas Domain y Application:
```sh
dotnet test
```

## Documentación Interactiva
Swagger está habilitado por defecto en entorno de desarrollo. Accede a `/swagger` para ver y probar los endpoints.

## Notas de Arquitectura
- Separación estricta de capas (Domain, Application, Infrastructure, API).
- Inyección de dependencias y configuración centralizada.
- Código limpio, validaciones y buenas prácticas.
- Preparado para despliegue en cualquier entorno compatible con .NET 8.

## Seguridad y Recomendaciones
- Usa contraseñas seguras y variables de entorno para datos sensibles.
- Cambia la clave JWT antes de producción.
- Limita el CORS y configura HTTPS en producción.
- Revisa y ajusta los permisos y roles según tus necesidades.

### Troubleshooting (Conexión a la base de datos)
- Si tienes problemas de conexión:
  - Verifica que el host, usuario y contraseña sean correctos.
  - Prueba la conectividad con:
    ```sh
    psql "host=HOST user=USUARIO dbname=DB password=CLAVE port=5432"
    ```
  - Si usas Supabase, revisa que tu IP tenga acceso y que el servicio esté activo.
  - Si el error es de DNS, prueba desde otra red o con VPN.

## Créditos y Licencia
Desarrollado como base para pruebas técnicas y proyectos empresariales.
Licencia MIT.
