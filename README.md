# ProductManager Application 

Es un proyecto API en NET Core , el cual expone metodos para realizar un CRUD de productos, se implementa autenticacion JWT y auroizacion de roles para la ejecucion.

## Tabla de Contenidos

- [Uso](#uso)
- [Instalación](#instalación)

## Uso

- Datos de la API 
  URL : http://www.applicationmanagement.somee.com/swagger/index.html
- Documentacion Postman
  https://documenter.getpostman.com/view/5392679/2sA3QngZLZ
- El repositoriodel codigo se encuentra en la siguiente ruta:
  https://github.com/ado4320/ProductManager
- Datos necesarios para su uso:
    - Autenticación: Utilice estos usuarios para autenticarse en la API.
        - Usuario Administrador: adolfoapp - Contraseña: test2024
        - Usuario Generico: usuario1 - Contraseña: test2024 
        - Para crear un nuevo producto, el Id de la categoría es: CCB7C456-9CB1-4F2C-A4C1-120D257BF8CD   (Tecnologia)
                                                                  3FA85F64-5717-4562-B3FC-2C963F66AFA6       (Hogar)

## Instalación

Descargar el proyecto en el repositorio publico adjiunto
Crear la base de datos con el siguiente script en su servidor de base de datos Sql Server:
```sql
CREATE DATABASE [ProductManager]
GO

USE [ProductManager]
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 20/05/2024 11:29:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20/05/2024 11:29:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20/05/2024 11:29:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRole] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/05/2024 11:29:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[IdRol] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240520172030_FirtsMigration', N'6.0.30')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'ccb7c456-9cb1-4f2c-a4c1-120d257bf8cd', N'Tecnologia', N'Productos de tecnologia')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'Hogar', N'Productos hogar')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'e4316ce0-0adc-4720-bb36-5bf30f339039', N'Asesoria', N'Productos de asesoria')
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Quantity]) VALUES (N'463dcb37-b894-4d37-a694-1357c6237393', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'Celular', N'Celulares', CAST(800000.00 AS Decimal(18, 2)), 50)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Quantity]) VALUES (N'dbdf8eb1-fbd3-404e-9a28-23f3c1a99801', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'TV', N'Televisor', CAST(1000.00 AS Decimal(18, 2)), 50)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Quantity]) VALUES (N'402118b0-ed05-4956-bed8-2b715e7359c1', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Quantity]) VALUES (N'98f2c992-866f-498e-a101-3d537ae8fd0e', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'testToken', N'test', CAST(4.00 AS Decimal(18, 2)), 4)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Quantity]) VALUES (N'bc8187b1-0d1e-4637-9ed0-a1cb05a20c3f', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'Nevera', N'Nevera 20lt', CAST(1000.00 AS Decimal(18, 2)), 50)
GO
INSERT [dbo].[Roles] ([IdRole], [Name], [Description]) VALUES (N'a39f6ff5-d2cb-4fe8-998b-690b6e8f2a97', N'generico', N'Perfil generico de la aplicación')
GO
INSERT [dbo].[Roles] ([IdRole], [Name], [Description]) VALUES (N'e1d09b7c-f8e0-41cc-9d42-a4cb182e27db', N'Administrador', N'Perfil Aministrador de la aplicación')
GO
INSERT [dbo].[Users] ([Id], [IdRol], [Password]) VALUES (N'adolfoapp', N'e1d09b7c-f8e0-41cc-9d42-a4cb182e27db', N'test2024')
GO
INSERT [dbo].[Users] ([Id], [IdRol], [Password]) VALUES (N'usuario1', N'a39f6ff5-d2cb-4fe8-998b-690b6e8f2a97', N'test2024')
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 20/05/2024 11:29:53 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_IdRol]    Script Date: 20/05/2024 11:29:53 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Users_IdRol] ON [dbo].[Users]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_IdRol]
GO
```

Autenticacion y Autorizacion :
Usuarios Autenticacion para generacion token:

    - Usuario Administrador: adolfoapp 
    - Contraseña: test2024 
      
    - Usuario Generico: usuario1
    - Contraseña: test2024 

Autorizacion: Copiar el token generado para realizar la autorizacion que permita la ejecucion de los metodos del API segun rol de usuario.
