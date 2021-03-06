USE [ServicioTecnico]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[domicilio] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] NOT NULL,
	[tipo] [nvarchar](50) NULL,
	[modelo] [nvarchar](50) NULL,
	[marca] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[dispositivo] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[estado] [nvarchar](50) NULL,
	[fechaDeIngreso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_ToTable] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_ToTable]
GO
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditarCliente](
@Id int,
@nombre nvarchar(50),
@domicilio nvarchar(50),
@telefono nvarchar(50)
)
as
begin
    update Cliente set nombre = @nombre, domicilio = @domicilio, telefono = @telefono where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[EditarServicio]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditarServicio](
@Id int,
@idCliente int,
@dispositivo nvarchar(50),
@descripcion nvarchar(50),
@estado nvarchar(50),
@fechaDeIngreso datetime
)
as
begin
    update Servicio set idCliente = @idCliente, dispositivo = @dispositivo, descripcion = @descripcion, estado = @estado, fechaDeIngreso = @fechaDeIngreso where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EliminarCliente](
@Id int
)
as
begin
     delete from Cliente where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarServicio]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EliminarServicio](
@Id int
)
as
begin
     delete from Servicio where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[IngresarCliente]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[IngresarCliente](
@nombre nvarchar(50),
@domicilio nvarchar(50),
@telefono nvarchar(50)
)
as
begin
     insert into Cliente(nombre, domicilio, telefono) values (@nombre, @domicilio, @telefono)
end
GO
/****** Object:  StoredProcedure [dbo].[IngresarServicio]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[IngresarServicio](
@idCliente int,
@dispositivo nvarchar(50),
@descripcion nvarchar(50),
@estado nvarchar(50),
@fechaDeIngreso datetime
)
as
begin
     insert into Servicio(idCliente, dispositivo, descripcion, estado, fechaDeIngreso) values (@idCliente, @dispositivo, @descripcion, @estado, @fechaDeIngreso)
end
GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListarClientes]
as	
begin
    select*from Cliente
end
GO
/****** Object:  StoredProcedure [dbo].[ListarServicios]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListarServicios]
as
begin
    select*from Servicio
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCliente]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCliente](
@IdCliente int)
as
begin
    select*from Cliente where Id =@IdCliente
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerServicio]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerServicio](
@IdServicio int)
as
begin
    select*from Servicio where Id =@IdServicio
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerServiciosDe]    Script Date: 9/6/2022 18:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerServiciosDe](
@IdCliente int)
as
begin
    select*from Servicio where idCliente =@IdCliente
end
GO
