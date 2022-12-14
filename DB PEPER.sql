USE [FAST_FOOD_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_CategoriaPlatillo]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_CategoriaPlatillo](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADO] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_CategoriaPlatillo] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Compra]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Compra](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NUMFACTURA] [varchar](50) NOT NULL,
	[FECHACOMPRA] [int] NOT NULL,
	[FKPROVEEDOR] [int] NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[ESTADO] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_Compra] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_DetalleCompra]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_DetalleCompra](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FKCOMPRA] [int] NOT NULL,
	[FKINGREDIENTE] [int] NOT NULL,
	[CANTIDADUNIDAD] [int] NOT NULL,
	[ESTADO] [bit] NOT NULL,
	[PRECIO] [money] NOT NULL,
 CONSTRAINT [PK_Tbl_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_DetallePedido]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_DetallePedido](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FKPEDIDO] [int] NOT NULL,
	[FKPLATILLOBEBIDA] [int] NOT NULL,
	[CANTIDAD] [int] NOT NULL,
	[PRECIO] [money] NOT NULL,
	[SUBTOTAL] [money] NOT NULL,
 CONSTRAINT [PK_Tbl_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Horarios]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Horarios](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FECHAMARCACION] [date] NULL,
	[HORAENTRADA] [time](7) NULL,
	[HORASALIDA] [time](7) NULL,
	[FINALIZADO] [bit] NULL,
	[USERNAME] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Horarios] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Ingrediente]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Ingrediente](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADO] [bit] NOT NULL,
	[FKUNIDADMEDIDA] [int] NOT NULL,
	[CANTIDADPORUNIDAD] [float] NOT NULL,
	[MINIMOSTOCK] [float] NOT NULL,
 CONSTRAINT [PK_Tbl_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_IngredientePlatillo]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_IngredientePlatillo](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FKINGREDIENTE] [int] NOT NULL,
	[FKPLATILLO] [int] NOT NULL,
	[CANTIDADUNIDAD] [float] NOT NULL,
 CONSTRAINT [PK_Tbl_IngredientePlatillo] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Inventario]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Inventario](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FKINGREDIENTE] [int] NOT NULL,
	[CANTIDADSTOCK] [float] NOT NULL,
 CONSTRAINT [PK_Tbl_Inventario] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Pedido]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Pedido](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[FECHAPEDIDO] [datetime] NOT NULL,
	[NOMBRECLIENTE] [varchar](50) NOT NULL,
	[ANULADO] [bit] NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Pedido] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_PlatilloBebida]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_PlatilloBebida](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](500) NOT NULL,
	[PRECIO] [money] NOT NULL,
	[IMAGEN] [varchar](50) NOT NULL,
	[FKCATEGORIAPLATILLO] [int] NULL,
 CONSTRAINT [PK_Tbl_PlatilloBebida] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Proveedor]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Proveedor](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[TELEFONO] [int] NULL,
	[DIRECCION] [varchar](500) NULL,
	[ESTADO] [bit] NULL,
 CONSTRAINT [PK_Tbl_Proveedor] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_UnidadMedida]    Script Date: 26/10/2022 11:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UnidadMedida](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADO] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.19')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4284ebad-d258-42ff-90b1-4da76421c6a0', N'marcos@gmail.com', N'MARCOS@GMAIL.COM', N'marcos@gmail.com', N'MARCOS@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOweME16Ncp3lsCWwhThCooj0YuY+GBul2dV8tgcN6kILRC0FYdcebSTHDrzFZRspg==', N'R357P336JG2B3RZOMTNFGQF4WW33Q6PH', N'7939e714-c18e-417c-9e04-03171c61c33d', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Tbl_CategoriaPlatillo] ON 

INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (0, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (2, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1002, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1003, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1004, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1005, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1006, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1007, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1008, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1009, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1010, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1011, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1012, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1013, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1014, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1015, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1016, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1017, N'Nuevo', 1)
INSERT [dbo].[Tbl_CategoriaPlatillo] ([PK], [NOMBRE], [ESTADO]) VALUES (1018, N'Nuevo', 1)
SET IDENTITY_INSERT [dbo].[Tbl_CategoriaPlatillo] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Proveedor] ON 

INSERT [dbo].[Tbl_Proveedor] ([PK], [NOMBRE], [TELEFONO], [DIRECCION], [ESTADO]) VALUES (1, N'Proveedor ', 3423423, N'dfdsfd', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_UnidadMedida] ON 

INSERT [dbo].[Tbl_UnidadMedida] ([PK], [NOMBRE], [ESTADO]) VALUES (1, N'Unidad2', 1)
SET IDENTITY_INSERT [dbo].[Tbl_UnidadMedida] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Tbl_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Compra_Tbl_Proveedor] FOREIGN KEY([FECHACOMPRA])
REFERENCES [dbo].[Tbl_Proveedor] ([PK])
GO
ALTER TABLE [dbo].[Tbl_Compra] CHECK CONSTRAINT [FK_Tbl_Compra_Tbl_Proveedor]
GO
ALTER TABLE [dbo].[Tbl_DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_DetalleCompra_Tbl_Compra] FOREIGN KEY([FKCOMPRA])
REFERENCES [dbo].[Tbl_Compra] ([PK])
GO
ALTER TABLE [dbo].[Tbl_DetalleCompra] CHECK CONSTRAINT [FK_Tbl_DetalleCompra_Tbl_Compra]
GO
ALTER TABLE [dbo].[Tbl_DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_DetalleCompra_Tbl_Ingrediente] FOREIGN KEY([FKINGREDIENTE])
REFERENCES [dbo].[Tbl_Ingrediente] ([PK])
GO
ALTER TABLE [dbo].[Tbl_DetalleCompra] CHECK CONSTRAINT [FK_Tbl_DetalleCompra_Tbl_Ingrediente]
GO
ALTER TABLE [dbo].[Tbl_DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_DetallePedido_Tbl_Pedido] FOREIGN KEY([FKPEDIDO])
REFERENCES [dbo].[Tbl_Pedido] ([PK])
GO
ALTER TABLE [dbo].[Tbl_DetallePedido] CHECK CONSTRAINT [FK_Tbl_DetallePedido_Tbl_Pedido]
GO
ALTER TABLE [dbo].[Tbl_DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_DetallePedido_Tbl_PlatilloBebida] FOREIGN KEY([FKPLATILLOBEBIDA])
REFERENCES [dbo].[Tbl_PlatilloBebida] ([PK])
GO
ALTER TABLE [dbo].[Tbl_DetallePedido] CHECK CONSTRAINT [FK_Tbl_DetallePedido_Tbl_PlatilloBebida]
GO
ALTER TABLE [dbo].[Tbl_Ingrediente]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Ingrediente_Tbl_UnidadMedida] FOREIGN KEY([FKUNIDADMEDIDA])
REFERENCES [dbo].[Tbl_UnidadMedida] ([PK])
GO
ALTER TABLE [dbo].[Tbl_Ingrediente] CHECK CONSTRAINT [FK_Tbl_Ingrediente_Tbl_UnidadMedida]
GO
ALTER TABLE [dbo].[Tbl_IngredientePlatillo]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_IngredientePlatillo_Tbl_Ingrediente] FOREIGN KEY([FKINGREDIENTE])
REFERENCES [dbo].[Tbl_Ingrediente] ([PK])
GO
ALTER TABLE [dbo].[Tbl_IngredientePlatillo] CHECK CONSTRAINT [FK_Tbl_IngredientePlatillo_Tbl_Ingrediente]
GO
ALTER TABLE [dbo].[Tbl_IngredientePlatillo]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_IngredientePlatillo_Tbl_PlatilloBebida] FOREIGN KEY([FKPLATILLO])
REFERENCES [dbo].[Tbl_PlatilloBebida] ([PK])
GO
ALTER TABLE [dbo].[Tbl_IngredientePlatillo] CHECK CONSTRAINT [FK_Tbl_IngredientePlatillo_Tbl_PlatilloBebida]
GO
ALTER TABLE [dbo].[Tbl_Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Inventario_Tbl_Ingrediente] FOREIGN KEY([FKINGREDIENTE])
REFERENCES [dbo].[Tbl_Ingrediente] ([PK])
GO
ALTER TABLE [dbo].[Tbl_Inventario] CHECK CONSTRAINT [FK_Tbl_Inventario_Tbl_Ingrediente]
GO
ALTER TABLE [dbo].[Tbl_PlatilloBebida]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_PlatilloBebida_Tbl_CategoriaPlatillo] FOREIGN KEY([FKCATEGORIAPLATILLO])
REFERENCES [dbo].[Tbl_CategoriaPlatillo] ([PK])
GO
ALTER TABLE [dbo].[Tbl_PlatilloBebida] CHECK CONSTRAINT [FK_Tbl_PlatilloBebida_Tbl_CategoriaPlatillo]
GO
