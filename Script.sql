USE [GorilaXam]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CiudadID] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Estilo] [varchar](150) NULL,
	[Tamaño] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[Valoracion] [int] NULL,
	[Precio] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[PedidoID] [int] NOT NULL,
	[TiendaID] [int] NULL,
	[FechaPedido] [date] NULL,
	[FechaEntrega] [date] NULL,
	[ProductoID] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[PedidoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comuna]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comuna](
	[ComunaID] [int] NOT NULL,
	[CiudadID] [int] NULL,
	[Nombre] [varchar](150) NULL,
 CONSTRAINT [PK_Comuna] PRIMARY KEY CLUSTERED 
(
	[ComunaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] NOT NULL,
	[ComunaID] [int] NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](150) NULL,
	[Rut] [varchar](12) NULL,
	[Direccion] [varchar](500) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tienda](
	[TiendaID] [int] NOT NULL,
	[ComunaID] [int] NULL,
	[Fecha] [date] NULL,
	[PedidoID] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Tienda] PRIMARY KEY CLUSTERED 
(
	[TiendaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 06/18/2020 10:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraID] [int] NOT NULL,
	[UsuarioID] [int] NULL,
	[FechaCompra] [date] NULL,
	[MontoPago] [int] NULL,
	[TipoPago] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[PedidoID] [int] NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Compra_Pedido]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Pedido] FOREIGN KEY([PedidoID])
REFERENCES [dbo].[Pedido] ([PedidoID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Pedido]
GO
/****** Object:  ForeignKey [FK_Compra_Usuario]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Usuario]
GO
/****** Object:  ForeignKey [FK_Comuna_Ciudad]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Comuna]  WITH CHECK ADD  CONSTRAINT [FK_Comuna_Ciudad] FOREIGN KEY([CiudadID])
REFERENCES [dbo].[Ciudad] ([CiudadID])
GO
ALTER TABLE [dbo].[Comuna] CHECK CONSTRAINT [FK_Comuna_Ciudad]
GO
/****** Object:  ForeignKey [FK_Pedido_Producto]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Producto] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Producto]
GO
/****** Object:  ForeignKey [FK_Tienda_Comuna]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Tienda]  WITH CHECK ADD  CONSTRAINT [FK_Tienda_Comuna] FOREIGN KEY([ComunaID])
REFERENCES [dbo].[Comuna] ([ComunaID])
GO
ALTER TABLE [dbo].[Tienda] CHECK CONSTRAINT [FK_Tienda_Comuna]
GO
/****** Object:  ForeignKey [FK_Tienda_Pedido]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Tienda]  WITH CHECK ADD  CONSTRAINT [FK_Tienda_Pedido] FOREIGN KEY([PedidoID])
REFERENCES [dbo].[Pedido] ([PedidoID])
GO
ALTER TABLE [dbo].[Tienda] CHECK CONSTRAINT [FK_Tienda_Pedido]
GO
/****** Object:  ForeignKey [FK_Usuario_Comuna]    Script Date: 06/18/2020 10:23:27 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Comuna] FOREIGN KEY([ComunaID])
REFERENCES [dbo].[Comuna] ([ComunaID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Comuna]
GO
