# 🗃️ Administrador de Productos en C# con SQL Server

Aplicación de escritorio desarrollada en C# con Windows Forms que permite gestionar productos dentro de una base de datos SQL Server. Es una herramienta simple para realizar operaciones CRUD (crear, leer, actualizar y eliminar), incluye además una búsqueda dinámica por descripción.
<br>
<br>

## 📋 Funcionalidades principales

- Alta, baja y modificación de productos
- Búsqueda por parte de la descripción
- Visualización de los productos en una grilla
- Carga automática del formulario al seleccionar un producto
<br>

## 🚀 Tecnologías utilizadas

- Lenguaje: C#
- Framework: .NET Framework / Windows Forms
- Base de datos: SQL Server
- Acceso a datos: ADO.NET (`SqlConnection`, `SqlCommand`, etc.)
- Stored Procedures para `Load` y `Remove`
<br>

## 📦 Estructura del proyecto

- `Form1`: interfaz principal del sistema
- `ADOPersister`: clase que gestiona toda la lógica de persistencia (inserción, consulta, actualización y eliminación)
- `Producto`: clase modelo que representa la entidad Producto
- `ProductoDB`: base de datos que contiene la tabla `Producto`
<br>

## ⚙️ Cómo ejecutar el proyecto

1. Cloná el repositorio:
```
   git clone https://github.com/YCastEmm/Admin-de-productos-en-C-con-Windows-Forms-y-ADO.NET
```
1. Abrí la solución en Visual Studio.

2. Configurá el string de conexión ubicado en ADOPersister.cs para que coincida con tu instancia de SQL Server:
  ```
  @"Data Source=TU_SERVIDOR; Initial Catalog=ProductoDB;Integrated Security=True;TrustServerCertificate=True;";
  ```


4. Creá la base de datos y la tabla ejecutando el siguiente script en SQL Server Management Studio (SSMS) o herramienta similar:


```sql
CREATE DATABASE ProductoDB;
GO

USE ProductoDB;
GO

CREATE TABLE Producto (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100),
    Marca NVARCHAR(100),
    Precio FLOAT,
    Stock INT
);
```

5. Creá los store procedures

```sql
CREATE PROCEDURE Producto_sel
    @id INT
AS
BEGIN
    SELECT * FROM Producto WHERE ID = @id;
END;
GO

CREATE PROCEDURE Producto_del
    @id INT
AS
BEGIN
    DELETE FROM Producto WHERE ID = @id;
END;
GO
```

5. Ejecutá el proyecto desde Visual Studio


<br>

## 💻 Autor
Desarrollado por Yair Castagnola
<br>
<br>
📧 yair.castagnola@gmail.com
