# ElyssaBack

Solución ASP.NET Core Web API para autenticación y autorización basada en roles y permisos.

## Descripción General
ElyssaBack es un backend modular para la gestión de usuarios, roles y permisos, pensado para empresas que requieren control de acceso granular. Permite:
- Crear usuarios con un único rol asignado.
- Definir roles y asociarles permisos.
- Autenticación mediante email y contraseña.
- Protección de rutas según permisos del usuario autenticado (modelo RBAC).
- Uso de JWT para autenticación y autorización.

## Estructura del proyecto
- **ElyssaBack.API**: Proyecto principal Web API (endpoints REST, configuración Swagger, autenticación).
- **ElyssaBack.Domain**: Modelos y entidades de negocio (User, Role, Permission).
- **ElyssaBack.Application**: Lógica de negocio y servicios (gestión de usuarios, roles, permisos).
- **ElyssaBack.Infrastructure**: Acceso a datos y persistencia (preparado para EF Core).
- **ElyssaBack.Domain.Tests**: Pruebas unitarias para Domain.
- **ElyssaBack.Application.Tests**: Pruebas unitarias para Application.

## Requisitos del sistema
- .NET 8 SDK
- Windows, Linux o macOS

## Instalación y primeros pasos
1. Clona el repositorio y accede a la carpeta raíz del proyecto.
2. Compila la solución:
   ```
   dotnet build
   ```
3. Ejecuta la API:
   ```
   dotnet run --project ElyssaBack.API
   ```
4. Accede a la documentación interactiva en Swagger:
   - [http://localhost:5257/swagger](http://localhost:5257/swagger) (o el puerto configurado)
5. Ejecuta los tests:
   ```
   dotnet test
   ```

## Endpoints principales (ejemplo)
- `POST /api/users` — Crear usuario
- `GET /api/users` — Listar usuarios
- `POST /api/auth/login` — Login (devuelve JWT) *(a implementar)*
- `GET /api/profile` — Perfil del usuario autenticado *(a implementar)*
- `POST /api/roles` — Crear rol *(a implementar)*
- `GET /api/roles` — Listar roles *(a implementar)*
- `POST /api/permissions` — Crear permiso *(a implementar)*
- `GET /api/permissions` — Listar permisos *(a implementar)*

## Ejemplo de uso de la API
```http
POST /api/users
Content-Type: application/json
{
  "email": "admin@demo.com",
  "name": "Admin",
  "password": "1234",
  "roleId": "{role-guid}"
}
```

## Credenciales de prueba sugeridas
- Usuario: `admin@demo.com`
- Contraseña: `1234`
- Rol: `Admin` (con todos los permisos)

## Notas de arquitectura
- Separación estricta de capas (Domain, Application, Infrastructure, API).
- Uso de inyección de dependencias.
- Preparado para EF Core y JWT.
- Código limpio, nombres descriptivos y validaciones básicas.

## Seguridad
- Autenticación y autorización basada en JWT *(a implementar)*.
- Protección de endpoints por permisos y roles *(a implementar)*.

## Documentación interactiva
Swagger está habilitado por defecto en entorno de desarrollo. Accede a `/swagger` para ver y probar los endpoints.

---

> **Nota:** Este proyecto es una base para la prueba técnica. Algunos endpoints y la lógica de autenticación/autorización están preparados para ser implementados.
