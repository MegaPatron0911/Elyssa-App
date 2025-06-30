# ElyssaBack

Solución ASP.NET Core Web API para autenticación y autorización basada en roles y permisos.

## Estructura del proyecto
- ElyssaBack.API: Proyecto principal Web API
- ElyssaBack.Domain: Modelos y entidades
- ElyssaBack.Application: Lógica de negocio y servicios
- ElyssaBack.Infrastructure: Acceso a datos y persistencia
- ElyssaBack.Domain.Tests: Pruebas unitarias para Domain
- ElyssaBack.Application.Tests: Pruebas unitarias para Application

## Primeros pasos
1. Compila la solución:
   ```
   dotnet build
   ```
2. Ejecuta la API:
   ```
   dotnet run --project ElyssaBack.API
   ```
3. Ejecuta los tests:
   ```
   dotnet test
   ```

## Descripción
Esta solución está preparada para implementar un sistema de autenticación y autorización con JWT, roles y permisos, siguiendo buenas prácticas de arquitectura limpia.
