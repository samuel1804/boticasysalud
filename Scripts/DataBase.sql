CREATE DATABASE [BDBoticas]
GO
USE [BDBoticas]
GO
/****** Object:  Table [dbo].[ALP_CONSTANCIA_PREPARADO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ALP_CONSTANCIA_PREPARADO](
	[num_constancia_preparado] [int] NOT NULL,
	[num_orden_preparado] [int] NOT NULL,
	[fec_elaboracion] [date] NOT NULL,
	[motivo] [nvarchar](250) NULL,
	[estado] [char](2) NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[num_constancia_preparado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ALP_HOJA_MERMA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALP_HOJA_MERMA](
	[num_hoja_merma] [int] NOT NULL,
	[num_constancia_preparado] [int] NOT NULL,
	[cant_insumo_merma] [int] NOT NULL,
	[motivo] [nvarchar](250) NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[num_hoja_merma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ALP_INSUMO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ALP_INSUMO](
	[cod_insumo] [int] NOT NULL,
	[nom_insumo] [nvarchar](120) NOT NULL,
	[unidad_medida] [nvarchar](120) NOT NULL,
	[concentracion] [int] NOT NULL,
	[estado] [char](2) NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ALP_LIBRO_RECETA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALP_LIBRO_RECETA](
	[cod_libro_receta] [int] NOT NULL,
	[num_constancia_preparado] [int] NOT NULL,
	[cod_quimico_laboratorista] [int] NOT NULL,
	[fec_preparado] [date] NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_libro_receta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ALP_ORDEN_PREPARADO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ALP_ORDEN_PREPARADO](
	[num_orden_preparado] [int] NOT NULL,
	[cod_receta] [int] NOT NULL,
	[cod_sucursal] [int] NOT NULL,
	[cod_empleado] [int] NOT NULL,
	[fec_orden] [date] NOT NULL,
	[observacion] [nvarchar](250) NULL,
	[estado] [char](2) NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[num_orden_preparado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ALP_ORDEN_PREPARADO_INSUMO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALP_ORDEN_PREPARADO_INSUMO](
	[num_orden_preparado] [int] NOT NULL,
	[cod_insumo] [int] NOT NULL,
	[cant_insumo] [int] NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
 CONSTRAINT [pk_alp_orden_preparado_insumo] PRIMARY KEY CLUSTERED 
(
	[num_orden_preparado] ASC,
	[cod_insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ALP_RECETA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ALP_RECETA](
	[cod_receta] [int] NOT NULL,
	[nom_preparado] [nvarchar](120) NOT NULL,
	[desc_receta] [nvarchar](2000) NOT NULL,
	[nom_medico] [nvarchar](250) NOT NULL,
	[num_colegiatura] [int] NOT NULL,
	[motivo] [nvarchar](250) NULL,
	[fec_emision] [date] NOT NULL,
	[estado] [char](2) NOT NULL,
	[cod_usu_regi] [int] NOT NULL,
	[fec_usu_regi] [date] NOT NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_modi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_receta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_Control_Asignacion]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_Control_Asignacion](
	[Cod_control_asignacines] [int] IDENTITY(1,1) NOT NULL,
	[Cod_vehiculo] [int] NULL,
	[Cod_transportista] [int] NULL,
	[Fec_registro] [datetime] NULL,
	[Turno] [varchar](50) NULL,
	[Observacion] [varchar](255) NULL,
	[Estado] [varchar](50) NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Cod_control_asignacines] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_HojaRuta]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_HojaRuta](
	[Cod_hoja_ruta] [int] NOT NULL,
	[Cod_control_asignacines] [int] NULL,
	[Fec_creacion] [datetime] NULL,
	[Fec_despacho] [date] NULL,
	[Observacion] [varchar](250) NULL,
	[Estado] [int] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_HojaRuta] PRIMARY KEY CLUSTERED 
(
	[Cod_hoja_ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_HojaRutaDetalle]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIS_HojaRutaDetalle](
	[Cod_hoja_ruta_detalle] [int] NOT NULL,
	[Cod_hoja_ruta] [int] NULL,
	[Cod_pedido] [int] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Table_1_1] PRIMARY KEY CLUSTERED 
(
	[Cod_hoja_ruta_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DIS_Pedido]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[DIS_Pedido](
	[Cod_pedido] [int] NOT NULL,
	[Fec_pedido] [datetime] NULL,
	[Cod_sucursal] [int] NULL,
	[Tipo_prioridad] [varchar](50) NULL,
	[Observacion] [varchar](255) NULL,
	[Estado] [smallint] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[Cod_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_Pedido_Detalle]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[DIS_Pedido_Detalle](
	[Cod_detalle] [int] IDENTITY(1,1) NOT NULL,
	[Cod_pedido] [int] NULL,
	[Cod_producto] [int] NULL,
	[Cantidad] [int] NULL,
	[Peso] [decimal](18, 0) NULL,
	[Unidad_medida] [varchar](10) NULL,
	[Lote] [varchar](10) NULL,
	[Observacion] [varchar](250) NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Table1_1] PRIMARY KEY CLUSTERED 
(
	[Cod_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_PresentacionProducto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_PresentacionProducto](
	[Cod_presentacion_producto] [int] NOT NULL,
	[Des_presentacion_producto] [varchar](255) NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_PresentacionProducto] PRIMARY KEY CLUSTERED 
(
	[Cod_presentacion_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_Producto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[DIS_Producto](
	[Cod_producto] [int] IDENTITY(1,1) NOT NULL,
	[Nom_producto] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
	[Cod_tipo_producto] [int] NULL,
	[Cod_presentacion_producto] [int] NULL,
	[Peso_producto] [decimal](18, 0) NULL,
	[Unidad_medida] [varchar](50) NULL,
	[Estado] [int] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Cod_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_TipoProducto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_TipoProducto](
	[Cod_tipo_producto] [int] NOT NULL,
	[Des_tipo_producto] [varchar](50) NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_Transportista]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_Transportista](
	[Cod_transportista] [int] NOT NULL,
	[Cod_empleado] [int] NULL,
	[Num_licencia] [varchar](20) NULL,
	[Cat_licencia] [varchar](255) NULL,
	[Estado] [smallint] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Chofer] PRIMARY KEY CLUSTERED 
(
	[Cod_transportista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIS_Vehiculo]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIS_Vehiculo](
	[Cod_vehiculo] [int] NOT NULL,
	[Placa] [varchar](50) NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Tara] [int] NULL,
	[Descripcion] [varchar](255) NULL,
	[Estado] [smallint] NULL,
	[cod_usu_regi] [int] NULL,
	[cod_usu_modi] [int] NULL,
	[fec_usu_regi] [datetime] NULL,
	[fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Cod_vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_CLIENTE]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_CLIENTE](
	[Cod_cliente] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_doc_identidad] [varchar](3) NOT NULL,
	[Num_doc_identidad] [varchar](15) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Estado] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_GCC_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[Cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_CLIENTE_JURIDICO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_CLIENTE_JURIDICO](
	[Cod_cliente] [int] NOT NULL,
	[Razon_social] [varchar](150) NOT NULL,
	[Categoria] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_GCC_CLIENTE_JURIDICO] PRIMARY KEY CLUSTERED 
(
	[Cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_CLIENTE_NATURAL]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_CLIENTE_NATURAL](
	[Cod_cliente] [int] NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Fec_nacimiento] [smalldatetime] NOT NULL,
	[Sexo] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_GCC_CLIENTE_NATURAL] PRIMARY KEY CLUSTERED 
(
	[Cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_COMPROBANTE]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[GCC_COMPROBANTE](
	[Tipo_documento] [varchar](3) NOT NULL,
	[Num_documento] [varchar](15) NOT NULL,
	[Cod_cliente] [int] NOT NULL,
	[Fec_documento] [date] NOT NULL,
	[Fec_vencimiento] [date] NOT NULL,
	[Fec_pago] [date] NOT NULL,
	[Moneda] [varchar](3) NOT NULL,
	[Importe] [numeric](12, 2) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_comprobante] PRIMARY KEY CLUSTERED 
(
	[Tipo_documento] ASC,
	[Num_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_CONTRATO_CREDITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCC_CONTRATO_CREDITO](
	[Cod_contrato_credito] [int] IDENTITY(1,1) NOT NULL,
	[Cod_solicitud_credito] [int] NOT NULL,
	[Fec_inicio] [date] NOT NULL,
	[Fec_renovacion] [date] NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_contratoCredito] PRIMARY KEY CLUSTERED 
(
	[Cod_contrato_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GCC_CUENTA_CLIENTE]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_CUENTA_CLIENTE](
	[Cod_cuenta_cliente] [int] IDENTITY(1,1) NOT NULL,
	[Cod_contrato_credito] [int] NOT NULL,
	[Num_cuenta] [varchar](10) NOT NULL,
	[Linea_credito] [numeric](12, 2) NOT NULL,
	[Linea_disponible] [numeric](12, 2) NOT NULL,
	[Estado_cuenta] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_cuentaCliente] PRIMARY KEY CLUSTERED 
(
	[Cod_cuenta_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_DOCUMENTO_RECHAZO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_DOCUMENTO_RECHAZO](
	[Cod_documento_rechazo] [int] IDENTITY(1,1) NOT NULL,
	[Cod_informe_crediticio] [int] NOT NULL,
	[Fec_doc_rechazo] [date] NOT NULL,
	[Detalle_rechazo] [varchar](150) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_documentoRechazo] PRIMARY KEY CLUSTERED 
(
	[Cod_documento_rechazo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_EMPLEADO_INF_CREDITICIO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_EMPLEADO_INF_CREDITICIO](
	[Cod_registro] [int] IDENTITY(1,1) NOT NULL,
	[Cod_informe_crediticio] [int] NOT NULL,
	[Cod_empleado] [int] NOT NULL,
	[Fec_registro] [date] NOT NULL,
	[Estado] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_empleadoInformeCrediticio] PRIMARY KEY CLUSTERED 
(
	[Cod_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_EMPLEADO_SOL_CREDITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_EMPLEADO_SOL_CREDITO](
	[Cod_registro] [int] IDENTITY(1,1) NOT NULL,
	[Cod_solicitud_credito] [int] NOT NULL,
	[Cod_empleado] [int] NOT NULL,
	[Fec_registro] [date] NOT NULL,
	[Estado] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_empleadoSolicitudCredito] PRIMARY KEY CLUSTERED 
(
	[Cod_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_INFORME_CREDITICIO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_INFORME_CREDITICIO](
	[Cod_informe_crediticio] [int] IDENTITY(1,1) NOT NULL,
	[Cod_solicitud_credito] [int] NOT NULL,
	[Cod_politica_credito] [int] NOT NULL,
	[Fecha_informe] [date] NOT NULL,
	[Nivel_riesgo] [varchar](1) NOT NULL,
	[Capacidad_crediticia] [varchar](1) NOT NULL,
	[Fec_ultima_evaluacion] [date] NOT NULL,
	[Reporte_infocorp] [image] NOT NULL,
	[Monto_linea_credito_eval] [numeric](12, 2) NOT NULL,
	[Monto_linea_credito_aprob] [numeric](12, 2) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_informeCrediticio] PRIMARY KEY CLUSTERED 
(
	[Cod_informe_crediticio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_NOTIFICACION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_NOTIFICACION](
	[Cod_notificacion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_documento] [varchar](3) NOT NULL,
	[Num_documento] [varchar](15) NOT NULL,
	[Fec_notificacion] [date] NOT NULL,
	[Tipo_notificacion] [varchar](1) NOT NULL,
	[Desccripcion] [varchar](200) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
	[Cod_politica] [int] NOT NULL,
 CONSTRAINT [PK_notificacion] PRIMARY KEY CLUSTERED 
(
	[Cod_notificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_PLAN_CREDITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_PLAN_CREDITO](
	[Cod_plan_credito] [int] IDENTITY(1,1) NOT NULL,
	[Cod_plan] [varchar](10) NOT NULL,
	[Nombre_plan] [varchar](50) NOT NULL,
	[Rango_inicio] [numeric](12, 2) NOT NULL,
	[Rango_fin] [numeric](12, 2) NOT NULL,
	[Forma_pago] [varchar](150) NOT NULL,
	[Dias_credito] [int] NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_planCredito] PRIMARY KEY CLUSTERED 
(
	[Cod_plan_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_POLITICA_CREDITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_POLITICA_CREDITO](
	[Cod_politica_credito] [int] IDENTITY(1,1) NOT NULL,
	[Num_politica] [varchar](10) NOT NULL,
	[Nombre_politica] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Nivel_riesgo] [varchar](1) NOT NULL,
	[Cliente_nuevo] [bit] NOT NULL,
	[Num_movimientos] [int] NOT NULL,
	[Porcentaje_pago_fecha] [int] NOT NULL,
	[Capacidad_crediticia] [varchar](1) NOT NULL,
	[Cod_plan_credito] [int] NOT NULL,
	[Estado_resultante] [varchar](1) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_politicasCredito] PRIMARY KEY CLUSTERED 
(
	[Cod_politica_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_POLITICAS_NOTIFICACION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_POLITICAS_NOTIFICACION](
	[Cod_politica] [int] IDENTITY(1,1) NOT NULL,
	[Num_politica] [varchar](10) NOT NULL,
	[Nombre_politica] [varchar](50) NOT NULL,
	[Dias_vencimiento] [int] NOT NULL,
	[Tipo_mensaje] [varchar](1) NOT NULL,
	[Descripcion_mensaje] [varchar](200) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_politicasNotificacion] PRIMARY KEY CLUSTERED 
(
	[Cod_politica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GCC_SOLICITUD_CREDITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GCC_SOLICITUD_CREDITO](
	[Cod_solicitud_credito] [int] IDENTITY(1,1) NOT NULL,
	[Cod_cliente] [int] NOT NULL,
	[Fec_solicitud] [date] NOT NULL,
	[Num_solicitud] [varchar](10) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [date] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [date] NULL,
 CONSTRAINT [PK_solicitudCredito] PRIMARY KEY CLUSTERED 
(
	[Cod_solicitud_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ACCION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_ACCION](
	[Cod_accion] [int] NOT NULL,
	[Fec_accion] [datetime] NULL,
	[Evidencia] [varchar](50) NULL,
	[Observaciones] [varchar](150) NULL,
	[Cod_actividad_planificada] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ACCION] PRIMARY KEY CLUSTERED 
(
	[Cod_accion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ACTIVIDAD]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_ACTIVIDAD](
	[Cod_actividad] [int] NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Cod_tipo_actividad] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ACTIVIDAD] PRIMARY KEY CLUSTERED 
(
	[Cod_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ACTIVIDAD_PLANIFICADA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA](
	[Cod_actividad_planificada] [int] NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[Fec_planificacion] [datetime] NULL,
	[Fec_cierre_planificacion] [datetime] NULL,
	[Estado] [varchar](50) NULL,
	[Prioridad] [varchar](50) NULL,
	[Adjunto] [varchar](150) NULL,
	[Cod_empleado] [int] NULL,
	[Cod_actividad] [int] NULL,
	[Cod_solicitud_gestion_permiso] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ACTIVIDAD_PLANIFICADA] PRIMARY KEY CLUSTERED 
(
	[Cod_actividad_planificada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ADQUISICION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_ADQUISICION](
	[Cod_adquisicion] [int] NOT NULL,
	[Fec_programada_llegada] [datetime] NULL,
	[Fec_real_llegada] [datetime] NULL,
	[Cod_solicitud_importacion] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ADQUISICION] PRIMARY KEY CLUSTERED 
(
	[Cod_adquisicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_ALERTA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_ALERTA](
	[Cod_alerta] [int] NOT NULL,
	[Nombre_alerta] [varchar](50) NULL,
	[Disparador_estado_actividad] [varchar](50) NULL,
	[Disparador_fecha_cierre_planificado] [varchar](50) NULL,
	[Repetir_dia] [varchar](50) NULL,
	[Fec_inicio] [datetime] NULL,
	[Fec_fin] [datetime] NULL,
	[Cod_actividad_planificada] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ALERTA] PRIMARY KEY CLUSTERED 
(
	[Cod_alerta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ARTICULO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_ARTICULO](
	[Cod_articulo] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Fec_elaboracion] [datetime] NULL,
	[Precio_unitario] [decimal](18, 2) NULL,
	[Clasificacion] [varchar](50) NULL,
	[Indicaciones] [varchar](150) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ARTICULO] PRIMARY KEY CLUSTERED 
(
	[Cod_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_BITACORA_EVENTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_BITACORA_EVENTO](
	[Cod_bitacora_evento] [int] NOT NULL,
	[Cod_desaduanaje] [int] NULL,
	[Descripcion] [varchar](150) NULL,
	[Fec_evento] [datetime] NULL,
	[Observaciones] [varchar](150) NULL,
	[Cod_evento] [int] NULL,
	[Cod_pago_importacion] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_BITACORA_EVENTO] PRIMARY KEY CLUSTERED 
(
	[Cod_bitacora_evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_BL]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_BL](
	[Cod_bl] [int] NOT NULL,
	[Numero] [int] NULL,
	[Fecha] [datetime] NULL,
	[Consignador] [varchar](50) NULL,
	[Consignatario] [varchar](50) NULL,
	[Descripcion] [varbinary](150) NULL,
	[Archivo] [varbinary](150) NULL,
	[Cod_adquisicion] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_BL] PRIMARY KEY CLUSTERED 
(
	[Cod_bl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_CERTIFICADO_ISO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_CERTIFICADO_ISO](
	[Cod_certificado_iso] [int] NOT NULL,
	[Num_certificado_iso] [int] NULL,
	[Nombre] [varchar](150) NULL,
	[Fec_certificado_iso] [datetime] NULL,
	[Archivo] [varchar](150) NULL,
	[Cod_solicitud_gestio_permiso] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_CERTIFICADO_ISO] PRIMARY KEY CLUSTERED 
(
	[Cod_certificado_iso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_CERTIFICADO_MANUFACTURA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_CERTIFICADO_MANUFACTURA](
	[Cod_certificado_manufactura] [int] NOT NULL,
	[Num_certificado_manufactura] [int] NULL,
	[Fec_certificado_manufactura] [datetime] NULL,
	[Descripcion] [varchar](150) NULL,
	[Archivo] [varchar](150) NULL,
	[Cod_solicitud_gestion_permiso] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_CERTIFICADO_MANUFACTURA] PRIMARY KEY CLUSTERED 
(
	[Cod_certificado_manufactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_CONCEPTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_CONCEPTO](
	[Cod_concepto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](250) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_CONCEPTO] PRIMARY KEY CLUSTERED 
(
	[Cod_concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_DAM]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_DAM](
	[Cod_DAM] [int] NOT NULL,
	[Cod_desaduanaje] [int] NULL,
	[Descripcion] [varchar](150) NULL,
	[Observaciones] [varbinary](150) NULL,
	[Archivo] [varchar](150) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DAM] PRIMARY KEY CLUSTERED 
(
	[Cod_DAM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_DEPARTAMENTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_DEPARTAMENTO](
	[Cod_departamento] [char](2) NOT NULL,
	[Nombre] [char](25) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DEPARTAMENTO] PRIMARY KEY CLUSTERED 
(
	[Cod_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_DESADUANAJE]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_DESADUANAJE](
	[Cod_desaduanaje] [int] NOT NULL,
	[Cod_solicitud_importacion] [int] NULL,
	[Fec_inicio_desaduanaje] [datetime] NULL,
	[Fec_retiro_mercaderia] [datetime] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DESADUANAJE] PRIMARY KEY CLUSTERED 
(
	[Cod_desaduanaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_DETALLE_FACTURA_COMERCIAL]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_DETALLE_FACTURA_COMERCIAL](
	[Cod_detalle_factura_comercial] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
	[Cod_factura_comercial] [int] NULL,
	[Cod_articulo] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DETALLE_FACTURA_COMERCIAL] PRIMARY KEY CLUSTERED 
(
	[Cod_detalle_factura_comercial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_DETALLE_ORDEN_COMPRA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_DETALLE_ORDEN_COMPRA](
	[Cod_detalle_orden_compra] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Cod_orden_compra] [int] NULL,
	[Cod_articulo] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DETALLE_ORDEN_COMPRA] PRIMARY KEY CLUSTERED 
(
	[Cod_detalle_orden_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_DISTRITO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_DISTRITO](
	[Cod_departamento] [char](2) NOT NULL,
	[Cod_provincia] [char](2) NOT NULL,
	[Cod_distrito] [char](2) NOT NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_DISTRITO] PRIMARY KEY CLUSTERED 
(
	[Cod_departamento] ASC,
	[Cod_provincia] ASC,
	[Cod_distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_EVENTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_EVENTO](
	[Cod_evento] [int] NOT NULL,
	[Evento] [varbinary](50) NULL,
	[Cod_tipo_evento] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_EVENTO] PRIMARY KEY CLUSTERED 
(
	[Cod_evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_FACTURA_COMERCIAL]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_FACTURA_COMERCIAL](
	[Cod_factura_comercial] [int] NOT NULL,
	[Num_factura] [int] NULL,
	[Fec_factura] [datetime] NULL,
	[Razon_social] [varchar](150) NULL,
	[Importador] [varchar](50) NULL,
	[Archivo] [varchar](150) NULL,
	[Cod_adquisicion] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_FACTURA_COMERCIAL] PRIMARY KEY CLUSTERED 
(
	[Cod_factura_comercial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_ORDEN_COMPRA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_ORDEN_COMPRA](
	[Cod_orden_compra] [int] NOT NULL,
	[Num_orden_compra] [int] NULL,
	[Fec_orden_compra] [datetime] NULL,
	[Cod_proveedor] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_ORDEN_COMPRA] PRIMARY KEY CLUSTERED 
(
	[Cod_orden_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_PAGO_IMPORTACION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_PAGO_IMPORTACION](
	[Cod_pago_importacion] [int] NOT NULL,
	[Monto] [decimal](18, 2) NULL,
	[Fec_pago] [datetime] NULL,
	[Cod_solicitud_importacion] [int] NULL,
	[Cod_tipo_pago] [int] NULL,
	[Cod_tipo_moneda] [int] NULL,
	[Cod_tipo_cambio] [int] NULL,
	[Cod_concepto] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_PAGO_IMPORTACION] PRIMARY KEY CLUSTERED 
(
	[Cod_pago_importacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_PROVEEDOR]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_PROVEEDOR](
	[Cod_proveedor] [int] NOT NULL,
	[Ruc] [char](11) NULL,
	[Razon_social] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[Cod_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_PROVINCIA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_PROVINCIA](
	[Cod_departamento] [char](2) NOT NULL,
	[Cod_provincia] [char](2) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_PROVINCIA] PRIMARY KEY CLUSTERED 
(
	[Cod_departamento] ASC,
	[Cod_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_PUERTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_PUERTO](
	[Cod_puerto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_distrito] [char](2) NULL,
	[Cod_provincia] [char](2) NULL,
	[Cod_departamento] [char](2) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_PUERTO] PRIMARY KEY CLUSTERED 
(
	[Cod_puerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_RESOLUCION_DIGEMID]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_RESOLUCION_DIGEMID](
	[Cod_resolucion] [int] NOT NULL,
	[Num_resolucion] [int] NULL,
	[Fec_resolucion] [datetime] NULL,
	[Descripcion] [varchar](150) NULL,
	[Observaciones] [varchar](150) NULL,
	[Archivo] [varchar](150) NULL,
	[Cod_solicitud_gestio_permiso] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_RESOLUCION_DIGEMID] PRIMARY KEY CLUSTERED 
(
	[Cod_resolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_SOLICITUD]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_SOLICITUD](
	[Cod_solicitud] [int] NOT NULL,
	[Fec_emision] [datetime] NULL,
	[Descripcion] [varbinary](120) NULL,
	[Observaciones] [varchar](200) NULL,
	[Estado] [char](10) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_SOLICITUD] PRIMARY KEY CLUSTERED 
(
	[Cod_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_SOLICITUD_GESTION_PERMISO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_SOLICITUD_GESTION_PERMISO](
	[Cod_solicitud_gestion_permiso] [int] NOT NULL,
	[Fec_aprobacion] [datetime] NULL,
	[Cod_solicitud] [int] NULL,
	[Cod_articulo] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_SOLICITUD_GESTION_PERMISO] PRIMARY KEY CLUSTERED 
(
	[Cod_solicitud_gestion_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_SOLICITUD_IMPORTACION]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_SOLICITUD_IMPORTACION](
	[Cod_solicitudimportacion] [int] NOT NULL,
	[Cod_solicitud] [int] NULL,
	[Fec_inicio] [datetime] NULL,
	[Fec_cierre] [datetime] NULL,
	[Cod_proveedor] [int] NULL,
	[Cod_orden_compra] [int] NULL,
	[Cod_puerto] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_SOLICITUD_IMPORTACION] PRIMARY KEY CLUSTERED 
(
	[Cod_solicitudimportacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_TIPO_ACTIVIDAD]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_TIPO_ACTIVIDAD](
	[Cod_tipo_actividad] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_TIPO_ACTIVIDAD] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_TIPO_CAMBIO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMP_TIPO_CAMBIO](
	[Cod_tipo_cambio] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Valor_compra] [decimal](5, 2) NULL,
	[Valor_venta] [decimal](5, 2) NULL,
	[Cod_tipo_moneda] [int] NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_TIPO_CAMBIO] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_cambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IMP_TIPO_EVENTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_TIPO_EVENTO](
	[Cod_tipo_evento] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_TIPO_EVENTO] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_TIPO_MONEDA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_TIPO_MONEDA](
	[Cod_tipo_moneda] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_TIPO_MONEDA] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMP_TIPO_PAGO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IMP_TIPO_PAGO](
	[Cod_tipo_pago] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cod_usu_regi] [int] NOT NULL,
	[Fec_usu_regi] [datetime] NOT NULL,
	[Cod_usu_modi] [int] NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_IMP_TIPO_PAGO] PRIMARY KEY CLUSTERED 
(
	[Cod_tipo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_AlternativaAutoevaluacion]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_AlternativaAutoevaluacion](
	[Cod_alternativa_autoevaluacion] [int] NOT NULL,
	[Respuesta] [varchar](100) NULL,
	[Valor] [int] NULL,
	[Fec_creacion] [date] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
	[Cod_criterio] [int] NULL,
 CONSTRAINT [PK_RRH_AlternativaAutoevaluacion] PRIMARY KEY CLUSTERED 
(
	[Cod_alternativa_autoevaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_AlternativaEvaluacionTecnica]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_AlternativaEvaluacionTecnica](
	[Cod_alternativa_evaluaciontec] [int] NOT NULL,
	[Desc_Alternatica] [varchar](150) NULL,
	[Puntaje] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_RRH_RRH_AlternativaEvaluacionTecnica] PRIMARY KEY CLUSTERED 
(
	[Cod_alternativa_evaluaciontec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Area]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Area](
	[Cod_area] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Estado] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Cod_area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Candidato]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Candidato](
	[Cod_candidato] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ApellidoPaterno] [varchar](50) NOT NULL,
	[ApellidoMaterno] [varchar](50) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Direccion] [varchar](100) NULL,
	[Foto] [varchar](50) NULL,
	[Fec_postulacion] [date] NULL,
	[Cod_cv_cand] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Candidato] PRIMARY KEY CLUSTERED 
(
	[Cod_candidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Criterio]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Criterio](
	[Cod_criterio] [int] NOT NULL,
	[Desc_criterio] [varchar](150) NULL,
	[Fec_creacion] [date] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_RRH_Criterio] PRIMARY KEY CLUSTERED 
(
	[Cod_criterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_CurriculumVitae]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_CurriculumVitae](
	[Cod_cv_cand] [int] NOT NULL,
	[Estudios1_candidato] [varchar](50) NULL,
	[Universidad1_candidato] [varchar](50) NULL,
	[Estudios2_candidato] [varchar](50) NULL,
	[Universidad2_candidato] [varchar](50) NULL,
	[Estudios3_candidato] [varchar](50) NULL,
	[Universidad3_candidato] [varchar](50) NULL,
	[Expericiencialaboral1] [varchar](50) NULL,
	[Desc_experiencialaboral1] [varchar](250) NULL,
	[Expericiencialaboral2] [varchar](50) NULL,
	[Desc_experiencialaboral2] [varchar](250) NULL,
	[Anos_experiencialaboral] [int] NULL,
	[Referencia1] [varchar](50) NULL,
	[Desc_referencia1] [varchar](150) NULL,
	[Referencia2] [varchar](50) NULL,
	[Desc_referencia2] [varchar](150) NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_RRH_CurriculumVitae] PRIMARY KEY CLUSTERED 
(
	[Cod_cv_cand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Empleado]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Empleado](
	[Cod_empleado] [int] NOT NULL,
	[Nom_empleado] [varchar](50) NULL,
	[Ap_paterno] [varchar](50) NULL,
	[Ap_materno] [varchar](50) NULL,
	[Dni] [varchar](50) NULL,
	[Telefono] [varchar](12) NULL,
	[Direccion] [varchar](150) NULL,
	[Foto] [varchar](50) NULL,
	[Fec_Ingreso] [date] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
	[Cod_puesto] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Cod_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_OfertaLaboral]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_OfertaLaboral](
	[Cod_ofertalaboral] [int] NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[FuncionesAdicionales] [varchar](max) NULL,
	[TiempoValidez] [int] NULL,
	[Fec_creacion] [date] NULL,
	[Estado] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_OfertaLaboral] PRIMARY KEY CLUSTERED 
(
	[Cod_ofertalaboral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_OfertaLaboral_Candidato]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_OfertaLaboral_Candidato](
	[Cod_ofertalaboral_candidato] [int] NOT NULL,
	[Cod_ofertalaboral] [int] NULL,
	[Cod_candidato] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_OfertaLaboral_Candidato] PRIMARY KEY CLUSTERED 
(
	[Cod_ofertalaboral_candidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Perfil]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Perfil](
	[Cod_perfil] [int] NOT NULL,
	[Cod_puesto] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Desc_perfil] [varchar](max) NOT NULL,
	[Competencias] [varchar](max) NULL,
	[Caracteristicas] [varchar](max) NULL,
	[SueldoIni] [decimal](10, 2) NULL,
	[SueldoFin] [decimal](10, 2) NULL,
	[Estado] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Cod_perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_PreguntaEvaluacionTecnica]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_PreguntaEvaluacionTecnica](
	[Cod_preg_eva_tec] [int] NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Pregunta] [varchar](150) NULL,
	[Fec_creacion] [date] NULL,
	[Cod_criterio] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
	[Cod_alternativa_evaluaciontec] [int] NULL,
 CONSTRAINT [PK_RRH_PreguntaEvaluacionTecnica] PRIMARY KEY CLUSTERED 
(
	[Cod_preg_eva_tec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_PruebaAuotoevaluacion]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_PruebaAuotoevaluacion](
	[Cod_autoevaluacion] [int] NOT NULL,
	[Fec_evaluacion] [date] NULL,
	[VersionEvaluacion] [varchar](2) NULL,
	[ResultadoPreg1] [int] NULL,
	[ResultadoPreg2] [int] NULL,
	[ResultadoPreg3] [int] NULL,
	[ResultadoPreg4] [int] NULL,
	[ResultadoPreg5] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
	[Cod_empleado] [int] NULL,
	[Cod_alternativa_autoevaluacion] [int] NULL,
 CONSTRAINT [PK_RRH_PruebaAuotoevaluacion] PRIMARY KEY CLUSTERED 
(
	[Cod_autoevaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_PruebaEvaluacionTecnica]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_PruebaEvaluacionTecnica](
	[Cod_evaluaciontecnica] [int] NOT NULL,
	[Fec_evaluacion] [date] NULL,
	[VersionEvaluacion] [varchar](2) NULL,
	[Evaluador] [varchar](25) NULL,
	[Observacion] [varchar](150) NULL,
	[ResultadoPreg1] [int] NULL,
	[ResultadoPreg2] [int] NULL,
	[ResultadoPreg3] [int] NULL,
	[ResultadoPreg4] [int] NULL,
	[ResultadoPreg5] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
	[Cod_empleado] [int] NULL,
	[Cod_preg_eva_tec] [int] NULL,
 CONSTRAINT [PK_RRH_PruebaEvaluacionTecnica] PRIMARY KEY CLUSTERED 
(
	[Cod_evaluaciontecnica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Puesto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Puesto](
	[Cod_puesto] [int] NOT NULL,
	[Nom_puesto] [varchar](50) NULL,
	[Cod_area] [int] NULL,
	[Estado] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[Cod_puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRH_Sucursal]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRH_Sucursal](
	[Cod_sucursal] [int] NOT NULL,
	[Nom_sucursal] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[Estado] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_ACTARECEP_CAB]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_ACTARECEP_CAB](
	[NumActa] [int] IDENTITY(1,1) NOT NULL,
	[NumPedido] [int] NOT NULL,
	[Cod_Almacen] [int] NOT NULL,
	[FecActa] [datetime] NOT NULL,
	[CodVerificador] [int] NOT NULL,
	[Glosa] [nvarchar](200) NULL,
	[Fec_Usu_Regi] [datetime] NULL,
	[Fec_Usu_Modi] [datetime] NULL,
	[Cod_Usu_Regi] [nvarchar](max) NULL,
	[Cod_Usu_Modi] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_ACTARECEP_CAB] PRIMARY KEY CLUSTERED 
(
	[NumActa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_ACTARECEP_DET]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_ACTARECEP_DET](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cant] [int] NOT NULL,
	[Diferencia] [int] NOT NULL,
	[Observacion] [nvarchar](150) NULL,
	[Cod_Producto] [nvarchar](128) NOT NULL,
	[NumActa] [int] NOT NULL,
	[Lote] [nvarchar](15) NOT NULL,
	[UnidadMedida] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioCreacion] [nvarchar](max) NULL,
	[UsuarioModificacion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_ACTARECEP_DET] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_ALMACENES]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_ALMACENES](
	[Cod_Almacen] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Encargado] [nvarchar](100) NULL,
	[Fec_Usu_Regi] [datetime] NULL,
	[Fec_Usu_Modi] [datetime] NULL,
	[Cod_Usu_Regi] [nvarchar](max) NULL,
	[Cod_Usu_Modi] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_ALMACENES] PRIMARY KEY CLUSTERED 
(
	[Cod_Almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_LOTES]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RYA_LOTES](
	[Cod_Lote] [int] IDENTITY(1,1) NOT NULL,
	[COD_PRODUCTO] [varchar](10) NOT NULL,
	[Lote] [varchar](15) NOT NULL,
	[fch_fab] [datetime] NOT NULL,
	[fch_vto] [datetime] NOT NULL,
	[cantidad] [datetime] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_dbo.RYA_LOTES] PRIMARY KEY CLUSTERED 
(
	[Cod_Lote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_MOVALM_CAB]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RYA_MOVALM_CAB](
	[Cod_sucursal] [int] NOT NULL,
	[Cod_Almacen] [int] NOT NULL,
	[Cod_Tran] [varchar](2) NOT NULL,
	[TipoDoc] [int] NOT NULL,
	[NumDoc] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[TipoMov] [char](1) NOT NULL,
	[CodCliente] [int] NULL,
	[DocRef] [varchar](30) NULL,
	[FchRef] [datetime] NULL,
	[Glosa] [varchar](200) NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_dbo.RYA_MOVALM_CAB] PRIMARY KEY CLUSTERED 
(
	[NumDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_MOVALM_DET]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RYA_MOVALM_DET](
	[Cod_sucursal] [int] NOT NULL,
	[Cod_Almacen] [int] NOT NULL,
	[TipoDoc] [int] NOT NULL,
	[NumDoc] [int] NOT NULL,
	[item] [int] NOT NULL,
	[COD_PRODUCTO] [varchar](10) NOT NULL,
	[Lote] [varchar](15) NOT NULL,
	[UnidadMedida] [nvarchar](3) NULL,
	[Cant] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_MOVALM_DET] PRIMARY KEY CLUSTERED 
(
	[NumDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_PEDIDO_CAB]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_PEDIDO_CAB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumPedido] [nvarchar](max) NOT NULL,
	[FchPedido] [datetime] NOT NULL,
	[EstadoPedido] [int] NOT NULL,
	[CodSolicitante] [int] NOT NULL,
	[Cod_Sucursal] [int] NOT NULL,
	[Glosa] [nvarchar](200) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioCreacion] [nvarchar](max) NULL,
	[UsuarioModificacion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_PEDIDO_CAB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_PEDIDO_DET]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_PEDIDO_DET](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cant] [int] NOT NULL,
	[Cod_Producto] [nvarchar](128) NOT NULL,
	[NumPedido] [int] NOT NULL,
	[Lote] [nvarchar](15) NOT NULL,
	[UnidadMedida] [nvarchar](3) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioCreacion] [nvarchar](max) NULL,
	[UsuarioModificacion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_PEDIDO_DET] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_PRODUCTO]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_PRODUCTO](
	[Cod_producto] [nvarchar](128) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[UnidadMedida] [nvarchar](max) NULL,
	[Presentacion] [nvarchar](20) NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Fec_Usu_Regi] [datetime] NULL,
	[Fec_Usu_Modi] [datetime] NULL,
	[Cod_Usu_Regi] [nvarchar](max) NULL,
	[Cod_Usu_Modi] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[Cod_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_STOCK]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[RYA_STOCK](
	[Cod_sucursal] [int] NOT NULL,
	[Cod_Almacen] [int] NOT NULL,
	[COD_PRODUCTO] [varchar](10) NOT NULL,
	[Cod_Lote] [int] NOT NULL,
	[Cant] [int] NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_dbo.RYA_STOCK] PRIMARY KEY CLUSTERED 
(
	[Cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_SUCURSALES]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RYA_SUCURSALES](
	[Cod_sucursal] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Distrito] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Encargado] [nvarchar](max) NULL,
	[Fec_Usu_Regi] [datetime] NULL,
	[Fec_Usu_Modi] [datetime] NULL,
	[Cod_Usu_Regi] [nvarchar](max) NULL,
	[Cod_Usu_Modi] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RYA_SUCURSALES] PRIMARY KEY CLUSTERED 
(
	[Cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RYA_TRANSA_ALMA]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RYA_TRANSA_ALMA](
	[Cod_Tran] [varchar](2) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[tipo] [char](1) NOT NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_dbo.RYA_TRANSA_ALMA] PRIMARY KEY CLUSTERED 
(
	[Cod_Tran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RYA_UBICACIONES]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RYA_UBICACIONES](
	[Cod_Almacen] [int] NOT NULL,
	[Cod_Lote] [int] NOT NULL,
	[COD_PRODUCTO] [varchar](10) NOT NULL,
	[Lote] [varchar](15) NOT NULL,
	[Cant] [int] NOT NULL,
	[modulo] [varchar](20) NOT NULL,
	[columna] [int] NULL,
	[fila] [int] NULL,
	[Cod_usu_regi] [varchar](10) NULL,
	[Fec_usu_regi] [datetime] NULL,
	[Cod_usu_modi] [varchar](10) NULL,
	[Fec_usu_modi] [datetime] NULL,
 CONSTRAINT [PK_dbo.RYA_UBICACIONES] PRIMARY KEY CLUSTERED 
(
	[Cod_Almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/01/2016 01:13:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioCreacion] [nvarchar](max) NULL,
	[UsuarioModificacion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Cod_Almacen]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_Cod_Almacen] ON [dbo].[RYA_ACTARECEP_CAB]
(
	[Cod_Almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NumPedido]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_NumPedido] ON [dbo].[RYA_ACTARECEP_CAB]
(
	[NumPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Cod_Producto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_Cod_Producto] ON [dbo].[RYA_ACTARECEP_DET]
(
	[Cod_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NumActa]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_NumActa] ON [dbo].[RYA_ACTARECEP_DET]
(
	[NumActa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SucursalId]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_SucursalId] ON [dbo].[RYA_ALMACENES]
(
	[SucursalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cod_Sucursal]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_Cod_Sucursal] ON [dbo].[RYA_PEDIDO_CAB]
(
	[Cod_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Cod_Producto]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_Cod_Producto] ON [dbo].[RYA_PEDIDO_DET]
(
	[Cod_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NumPedido]    Script Date: 21/01/2016 01:13:19 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_NumPedido] ON [dbo].[RYA_PEDIDO_DET]
(
	[NumPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DIS_Control_Asignacion] ADD  CONSTRAINT [DF_Control_Asignacion_FechaReg]  DEFAULT (getdate()) FOR [Fec_registro]
GO
ALTER TABLE [dbo].[DIS_Producto] ADD  CONSTRAINT [DF_Producto_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[DIS_Transportista] ADD  CONSTRAINT [DF_Chofer_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[DIS_Vehiculo] ADD  CONSTRAINT [DF_Vehiculo_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[GCC_CLIENTE_JURIDICO] ADD  CONSTRAINT [DF_GCC_CLIENTE_JORIDICO_Categoria]  DEFAULT ('P') FOR [Categoria]
GO
ALTER TABLE [dbo].[ALP_CONSTANCIA_PREPARADO]  WITH CHECK ADD FOREIGN KEY([num_orden_preparado])
REFERENCES [dbo].[ALP_ORDEN_PREPARADO] ([num_orden_preparado])
GO
ALTER TABLE [dbo].[ALP_HOJA_MERMA]  WITH CHECK ADD FOREIGN KEY([num_constancia_preparado])
REFERENCES [dbo].[ALP_CONSTANCIA_PREPARADO] ([num_constancia_preparado])
GO
ALTER TABLE [dbo].[ALP_LIBRO_RECETA]  WITH CHECK ADD FOREIGN KEY([cod_quimico_laboratorista])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[ALP_LIBRO_RECETA]  WITH CHECK ADD FOREIGN KEY([num_constancia_preparado])
REFERENCES [dbo].[ALP_CONSTANCIA_PREPARADO] ([num_constancia_preparado])
GO
ALTER TABLE [dbo].[ALP_ORDEN_PREPARADO]  WITH CHECK ADD FOREIGN KEY([cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[ALP_ORDEN_PREPARADO]  WITH CHECK ADD FOREIGN KEY([cod_receta])
REFERENCES [dbo].[ALP_RECETA] ([cod_receta])
GO
ALTER TABLE [dbo].[ALP_ORDEN_PREPARADO]  WITH CHECK ADD FOREIGN KEY([cod_sucursal])
REFERENCES [dbo].[RRH_Sucursal] ([Cod_sucursal])
GO
ALTER TABLE [dbo].[ALP_ORDEN_PREPARADO_INSUMO]  WITH CHECK ADD FOREIGN KEY([cod_insumo])
REFERENCES [dbo].[ALP_INSUMO] ([cod_insumo])
GO
ALTER TABLE [dbo].[ALP_ORDEN_PREPARADO_INSUMO]  WITH CHECK ADD FOREIGN KEY([num_orden_preparado])
REFERENCES [dbo].[ALP_ORDEN_PREPARADO] ([num_orden_preparado])
GO
ALTER TABLE [dbo].[DIS_Control_Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Control_Asignacion_Chofer] FOREIGN KEY([Cod_transportista])
REFERENCES [dbo].[DIS_Transportista] ([Cod_transportista])
GO
ALTER TABLE [dbo].[DIS_Control_Asignacion] CHECK CONSTRAINT [FK_Control_Asignacion_Chofer]
GO
ALTER TABLE [dbo].[DIS_Control_Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Control_Asignacion_Vehiculo] FOREIGN KEY([Cod_vehiculo])
REFERENCES [dbo].[DIS_Vehiculo] ([Cod_vehiculo])
GO
ALTER TABLE [dbo].[DIS_Control_Asignacion] CHECK CONSTRAINT [FK_Control_Asignacion_Vehiculo]
GO
ALTER TABLE [dbo].[DIS_HojaRuta]  WITH CHECK ADD  CONSTRAINT [FK_HojaRuta_Control_Asignacion] FOREIGN KEY([Cod_control_asignacines])
REFERENCES [dbo].[DIS_Control_Asignacion] ([Cod_control_asignacines])
GO
ALTER TABLE [dbo].[DIS_HojaRuta] CHECK CONSTRAINT [FK_HojaRuta_Control_Asignacion]
GO
ALTER TABLE [dbo].[DIS_HojaRutaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_HojaRutaDetalle_HojaRuta] FOREIGN KEY([Cod_hoja_ruta])
REFERENCES [dbo].[DIS_HojaRuta] ([Cod_hoja_ruta])
GO
ALTER TABLE [dbo].[DIS_HojaRutaDetalle] CHECK CONSTRAINT [FK_HojaRutaDetalle_HojaRuta]
GO
ALTER TABLE [dbo].[DIS_HojaRutaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_HojaRutaDetalle_Pedido] FOREIGN KEY([Cod_pedido])
REFERENCES [dbo].[DIS_Pedido] ([Cod_pedido])
GO
ALTER TABLE [dbo].[DIS_HojaRutaDetalle] CHECK CONSTRAINT [FK_HojaRutaDetalle_Pedido]
GO
ALTER TABLE [dbo].[DIS_Pedido]  WITH CHECK ADD FOREIGN KEY([Cod_sucursal])
REFERENCES [dbo].[RRH_Sucursal] ([Cod_sucursal])
GO
ALTER TABLE [dbo].[DIS_Pedido_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Detalle_Pedido] FOREIGN KEY([Cod_pedido])
REFERENCES [dbo].[DIS_Pedido] ([Cod_pedido])
GO
ALTER TABLE [dbo].[DIS_Pedido_Detalle] CHECK CONSTRAINT [FK_Pedido_Detalle_Pedido]
GO
ALTER TABLE [dbo].[DIS_Pedido_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Detalle_Producto] FOREIGN KEY([Cod_producto])
REFERENCES [dbo].[DIS_Producto] ([Cod_producto])
GO
ALTER TABLE [dbo].[DIS_Pedido_Detalle] CHECK CONSTRAINT [FK_Pedido_Detalle_Producto]
GO
ALTER TABLE [dbo].[DIS_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_PresentacionProducto] FOREIGN KEY([Cod_presentacion_producto])
REFERENCES [dbo].[DIS_PresentacionProducto] ([Cod_presentacion_producto])
GO
ALTER TABLE [dbo].[DIS_Producto] CHECK CONSTRAINT [FK_Producto_PresentacionProducto]
GO
ALTER TABLE [dbo].[DIS_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([Cod_tipo_producto])
REFERENCES [dbo].[DIS_TipoProducto] ([Cod_tipo_producto])
GO
ALTER TABLE [dbo].[DIS_Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
ALTER TABLE [dbo].[GCC_CLIENTE_JURIDICO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_CLIENTE_JORIDICO_GCC_CLIENTE] FOREIGN KEY([Cod_cliente])
REFERENCES [dbo].[GCC_CLIENTE] ([Cod_cliente])
GO
ALTER TABLE [dbo].[GCC_CLIENTE_JURIDICO] CHECK CONSTRAINT [FK_GCC_CLIENTE_JORIDICO_GCC_CLIENTE]
GO
ALTER TABLE [dbo].[GCC_CLIENTE_NATURAL]  WITH CHECK ADD  CONSTRAINT [FK_GCC_CLIENTE_NATURAL_GCC_CLIENTE] FOREIGN KEY([Cod_cliente])
REFERENCES [dbo].[GCC_CLIENTE] ([Cod_cliente])
GO
ALTER TABLE [dbo].[GCC_CLIENTE_NATURAL] CHECK CONSTRAINT [FK_GCC_CLIENTE_NATURAL_GCC_CLIENTE]
GO
ALTER TABLE [dbo].[GCC_COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_GCC_COMPROBANTE_GCC_CLIENTE] FOREIGN KEY([Cod_cliente])
REFERENCES [dbo].[GCC_CLIENTE] ([Cod_cliente])
GO
ALTER TABLE [dbo].[GCC_COMPROBANTE] CHECK CONSTRAINT [FK_GCC_COMPROBANTE_GCC_CLIENTE]
GO
ALTER TABLE [dbo].[GCC_CONTRATO_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_CONTRATO_CREDITO_GCC_SOLICITUD_CREDITO] FOREIGN KEY([Cod_solicitud_credito])
REFERENCES [dbo].[GCC_SOLICITUD_CREDITO] ([Cod_solicitud_credito])
GO
ALTER TABLE [dbo].[GCC_CONTRATO_CREDITO] CHECK CONSTRAINT [FK_GCC_CONTRATO_CREDITO_GCC_SOLICITUD_CREDITO]
GO
ALTER TABLE [dbo].[GCC_CUENTA_CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK_GCC_CUENTA_CLIENTE_GCC_CONTRATO_CREDITO] FOREIGN KEY([Cod_contrato_credito])
REFERENCES [dbo].[GCC_CONTRATO_CREDITO] ([Cod_contrato_credito])
GO
ALTER TABLE [dbo].[GCC_CUENTA_CLIENTE] CHECK CONSTRAINT [FK_GCC_CUENTA_CLIENTE_GCC_CONTRATO_CREDITO]
GO
ALTER TABLE [dbo].[GCC_DOCUMENTO_RECHAZO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_DOCUMENTO_RECHAZO_GCC_INFORME_CREDITICIO] FOREIGN KEY([Cod_informe_crediticio])
REFERENCES [dbo].[GCC_INFORME_CREDITICIO] ([Cod_informe_crediticio])
GO
ALTER TABLE [dbo].[GCC_DOCUMENTO_RECHAZO] CHECK CONSTRAINT [FK_GCC_DOCUMENTO_RECHAZO_GCC_INFORME_CREDITICIO]
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_INF_CREDITICIO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_EMPLEADO_INF_CREDITICIO_GCC_INFORME_CREDITICIO] FOREIGN KEY([Cod_informe_crediticio])
REFERENCES [dbo].[GCC_INFORME_CREDITICIO] ([Cod_informe_crediticio])
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_INF_CREDITICIO] CHECK CONSTRAINT [FK_GCC_EMPLEADO_INF_CREDITICIO_GCC_INFORME_CREDITICIO]
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_INF_CREDITICIO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_EMPLEADO_INF_CREDITICIO_RRH_EMPLEADO] FOREIGN KEY([Cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_INF_CREDITICIO] CHECK CONSTRAINT [FK_GCC_EMPLEADO_INF_CREDITICIO_RRH_EMPLEADO]
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_SOL_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_EMPLEADO_SOL_CREDITO_GCC_SOLICITUD_CREDITO] FOREIGN KEY([Cod_solicitud_credito])
REFERENCES [dbo].[GCC_SOLICITUD_CREDITO] ([Cod_solicitud_credito])
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_SOL_CREDITO] CHECK CONSTRAINT [FK_GCC_EMPLEADO_SOL_CREDITO_GCC_SOLICITUD_CREDITO]
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_SOL_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_EMPLEADO_SOL_CREDITO_RRH_EMPLEADO] FOREIGN KEY([Cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[GCC_EMPLEADO_SOL_CREDITO] CHECK CONSTRAINT [FK_GCC_EMPLEADO_SOL_CREDITO_RRH_EMPLEADO]
GO
ALTER TABLE [dbo].[GCC_INFORME_CREDITICIO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_INFORME_CREDITICIO_GCC_POLITICA_CREDITO] FOREIGN KEY([Cod_politica_credito])
REFERENCES [dbo].[GCC_POLITICA_CREDITO] ([Cod_politica_credito])
GO
ALTER TABLE [dbo].[GCC_INFORME_CREDITICIO] CHECK CONSTRAINT [FK_GCC_INFORME_CREDITICIO_GCC_POLITICA_CREDITO]
GO
ALTER TABLE [dbo].[GCC_INFORME_CREDITICIO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_INFORME_CREDITICIO_GCC_SOLICITUD_CREDITO] FOREIGN KEY([Cod_solicitud_credito])
REFERENCES [dbo].[GCC_SOLICITUD_CREDITO] ([Cod_solicitud_credito])
GO
ALTER TABLE [dbo].[GCC_INFORME_CREDITICIO] CHECK CONSTRAINT [FK_GCC_INFORME_CREDITICIO_GCC_SOLICITUD_CREDITO]
GO
ALTER TABLE [dbo].[GCC_NOTIFICACION]  WITH CHECK ADD  CONSTRAINT [FK_GCC_NOTIFICACION_GCC_COMPROBANTE] FOREIGN KEY([Tipo_documento], [Num_documento])
REFERENCES [dbo].[GCC_COMPROBANTE] ([Tipo_documento], [Num_documento])
GO
ALTER TABLE [dbo].[GCC_NOTIFICACION] CHECK CONSTRAINT [FK_GCC_NOTIFICACION_GCC_COMPROBANTE]
GO
ALTER TABLE [dbo].[GCC_NOTIFICACION]  WITH CHECK ADD  CONSTRAINT [FK_GCC_NOTIFICACION_GCC_POLITICAS_NOTIFICACION] FOREIGN KEY([Cod_politica])
REFERENCES [dbo].[GCC_POLITICAS_NOTIFICACION] ([Cod_politica])
GO
ALTER TABLE [dbo].[GCC_NOTIFICACION] CHECK CONSTRAINT [FK_GCC_NOTIFICACION_GCC_POLITICAS_NOTIFICACION]
GO
ALTER TABLE [dbo].[GCC_POLITICA_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_POLITICA_CREDITO_GCC_PLAN_CREDITO] FOREIGN KEY([Cod_plan_credito])
REFERENCES [dbo].[GCC_PLAN_CREDITO] ([Cod_plan_credito])
GO
ALTER TABLE [dbo].[GCC_POLITICA_CREDITO] CHECK CONSTRAINT [FK_GCC_POLITICA_CREDITO_GCC_PLAN_CREDITO]
GO
ALTER TABLE [dbo].[GCC_SOLICITUD_CREDITO]  WITH CHECK ADD  CONSTRAINT [FK_GCC_SOLICITUD_CREDITO_GCC_CLIENTE_JURIDICO] FOREIGN KEY([Cod_cliente])
REFERENCES [dbo].[GCC_CLIENTE_JURIDICO] ([Cod_cliente])
GO
ALTER TABLE [dbo].[GCC_SOLICITUD_CREDITO] CHECK CONSTRAINT [FK_GCC_SOLICITUD_CREDITO_GCC_CLIENTE_JURIDICO]
GO
ALTER TABLE [dbo].[IMP_ACCION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ACCION_IMP_ACTIVIDAD_PLANIFICADA] FOREIGN KEY([Cod_actividad_planificada])
REFERENCES [dbo].[IMP_ACTIVIDAD_PLANIFICADA] ([Cod_actividad_planificada])
GO
ALTER TABLE [dbo].[IMP_ACCION] CHECK CONSTRAINT [FK_IMP_ACCION_IMP_ACTIVIDAD_PLANIFICADA]
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ACTIVIDAD_IMP_TIPO_ACTIVIDAD] FOREIGN KEY([Cod_tipo_actividad])
REFERENCES [dbo].[IMP_TIPO_ACTIVIDAD] ([Cod_tipo_actividad])
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD] CHECK CONSTRAINT [FK_IMP_ACTIVIDAD_IMP_TIPO_ACTIVIDAD]
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_IMP_ACTIVIDAD] FOREIGN KEY([Cod_actividad])
REFERENCES [dbo].[IMP_ACTIVIDAD] ([Cod_actividad])
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA] CHECK CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_IMP_ACTIVIDAD]
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_IMP_SOLICITUD_GESTION_PERMISO] FOREIGN KEY([Cod_solicitud_gestion_permiso])
REFERENCES [dbo].[IMP_SOLICITUD_GESTION_PERMISO] ([Cod_solicitud_gestion_permiso])
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA] CHECK CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_IMP_SOLICITUD_GESTION_PERMISO]
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_RRH_Empleado] FOREIGN KEY([Cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[IMP_ACTIVIDAD_PLANIFICADA] CHECK CONSTRAINT [FK_IMP_ACTIVIDAD_PLANIFICADA_RRH_Empleado]
GO
ALTER TABLE [dbo].[IMP_ADQUISICION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ADQUISICION_IMP_SOLICITUD_IMPORTACION] FOREIGN KEY([Cod_solicitud_importacion])
REFERENCES [dbo].[IMP_SOLICITUD_IMPORTACION] ([Cod_solicitudimportacion])
GO
ALTER TABLE [dbo].[IMP_ADQUISICION] CHECK CONSTRAINT [FK_IMP_ADQUISICION_IMP_SOLICITUD_IMPORTACION]
GO
ALTER TABLE [dbo].[IMP_ALERTA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ALERTA_IMP_ACTIVIDAD_PLANIFICADA] FOREIGN KEY([Cod_actividad_planificada])
REFERENCES [dbo].[IMP_ACTIVIDAD_PLANIFICADA] ([Cod_actividad_planificada])
GO
ALTER TABLE [dbo].[IMP_ALERTA] CHECK CONSTRAINT [FK_IMP_ALERTA_IMP_ACTIVIDAD_PLANIFICADA]
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_DESADUANAJE] FOREIGN KEY([Cod_desaduanaje])
REFERENCES [dbo].[IMP_DESADUANAJE] ([Cod_desaduanaje])
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO] CHECK CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_DESADUANAJE]
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_EVENTO] FOREIGN KEY([Cod_evento])
REFERENCES [dbo].[IMP_EVENTO] ([Cod_evento])
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO] CHECK CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_EVENTO]
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_PAGO_IMPORTACION] FOREIGN KEY([Cod_pago_importacion])
REFERENCES [dbo].[IMP_PAGO_IMPORTACION] ([Cod_pago_importacion])
GO
ALTER TABLE [dbo].[IMP_BITACORA_EVENTO] CHECK CONSTRAINT [FK_IMP_BITACORA_EVENTO_IMP_PAGO_IMPORTACION]
GO
ALTER TABLE [dbo].[IMP_BL]  WITH CHECK ADD  CONSTRAINT [FK_IMP_BL_IMP_ADQUISICION] FOREIGN KEY([Cod_adquisicion])
REFERENCES [dbo].[IMP_ADQUISICION] ([Cod_adquisicion])
GO
ALTER TABLE [dbo].[IMP_BL] CHECK CONSTRAINT [FK_IMP_BL_IMP_ADQUISICION]
GO
ALTER TABLE [dbo].[IMP_CERTIFICADO_ISO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_CERTIFICADO_ISO_IMP_SOLICITUD_GESTION_PERMISO] FOREIGN KEY([Cod_solicitud_gestio_permiso])
REFERENCES [dbo].[IMP_SOLICITUD_GESTION_PERMISO] ([Cod_solicitud_gestion_permiso])
GO
ALTER TABLE [dbo].[IMP_CERTIFICADO_ISO] CHECK CONSTRAINT [FK_IMP_CERTIFICADO_ISO_IMP_SOLICITUD_GESTION_PERMISO]
GO
ALTER TABLE [dbo].[IMP_CERTIFICADO_MANUFACTURA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_CERTIFICADO_MANUFACTURA_IMP_SOLICITUD_GESTION_PERMISO] FOREIGN KEY([Cod_solicitud_gestion_permiso])
REFERENCES [dbo].[IMP_SOLICITUD_GESTION_PERMISO] ([Cod_solicitud_gestion_permiso])
GO
ALTER TABLE [dbo].[IMP_CERTIFICADO_MANUFACTURA] CHECK CONSTRAINT [FK_IMP_CERTIFICADO_MANUFACTURA_IMP_SOLICITUD_GESTION_PERMISO]
GO
ALTER TABLE [dbo].[IMP_DAM]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DAM_IMP_DESADUANAJE] FOREIGN KEY([Cod_desaduanaje])
REFERENCES [dbo].[IMP_DESADUANAJE] ([Cod_desaduanaje])
GO
ALTER TABLE [dbo].[IMP_DAM] CHECK CONSTRAINT [FK_IMP_DAM_IMP_DESADUANAJE]
GO
ALTER TABLE [dbo].[IMP_DESADUANAJE]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DESADUANAJE_IMP_SOLICITUD_IMPORTACION] FOREIGN KEY([Cod_solicitud_importacion])
REFERENCES [dbo].[IMP_SOLICITUD_IMPORTACION] ([Cod_solicitudimportacion])
GO
ALTER TABLE [dbo].[IMP_DESADUANAJE] CHECK CONSTRAINT [FK_IMP_DESADUANAJE_IMP_SOLICITUD_IMPORTACION]
GO
ALTER TABLE [dbo].[IMP_DETALLE_FACTURA_COMERCIAL]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DETALLE_FACTURA_COMERCIAL_IMP_ARTICULO] FOREIGN KEY([Cod_articulo])
REFERENCES [dbo].[IMP_ARTICULO] ([Cod_articulo])
GO
ALTER TABLE [dbo].[IMP_DETALLE_FACTURA_COMERCIAL] CHECK CONSTRAINT [FK_IMP_DETALLE_FACTURA_COMERCIAL_IMP_ARTICULO]
GO
ALTER TABLE [dbo].[IMP_DETALLE_FACTURA_COMERCIAL]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DETALLE_FACTURA_COMERCIAL_IMP_FACTURA_COMERCIAL] FOREIGN KEY([Cod_factura_comercial])
REFERENCES [dbo].[IMP_FACTURA_COMERCIAL] ([Cod_factura_comercial])
GO
ALTER TABLE [dbo].[IMP_DETALLE_FACTURA_COMERCIAL] CHECK CONSTRAINT [FK_IMP_DETALLE_FACTURA_COMERCIAL_IMP_FACTURA_COMERCIAL]
GO
ALTER TABLE [dbo].[IMP_DETALLE_ORDEN_COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DETALLE_ORDEN_COMPRA_IMP_ARTICULO] FOREIGN KEY([Cod_articulo])
REFERENCES [dbo].[IMP_ARTICULO] ([Cod_articulo])
GO
ALTER TABLE [dbo].[IMP_DETALLE_ORDEN_COMPRA] CHECK CONSTRAINT [FK_IMP_DETALLE_ORDEN_COMPRA_IMP_ARTICULO]
GO
ALTER TABLE [dbo].[IMP_DETALLE_ORDEN_COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DETALLE_ORDEN_COMPRA_IMP_ORDEN_COMPRA] FOREIGN KEY([Cod_orden_compra])
REFERENCES [dbo].[IMP_ORDEN_COMPRA] ([Cod_orden_compra])
GO
ALTER TABLE [dbo].[IMP_DETALLE_ORDEN_COMPRA] CHECK CONSTRAINT [FK_IMP_DETALLE_ORDEN_COMPRA_IMP_ORDEN_COMPRA]
GO
ALTER TABLE [dbo].[IMP_DISTRITO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_DISTRITO_IMP_PROVINCIA] FOREIGN KEY([Cod_departamento], [Cod_provincia])
REFERENCES [dbo].[IMP_PROVINCIA] ([Cod_departamento], [Cod_provincia])
GO
ALTER TABLE [dbo].[IMP_DISTRITO] CHECK CONSTRAINT [FK_IMP_DISTRITO_IMP_PROVINCIA]
GO
ALTER TABLE [dbo].[IMP_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_EVENTO_IMP_TIPO_EVENTO] FOREIGN KEY([Cod_tipo_evento])
REFERENCES [dbo].[IMP_TIPO_EVENTO] ([Cod_tipo_evento])
GO
ALTER TABLE [dbo].[IMP_EVENTO] CHECK CONSTRAINT [FK_IMP_EVENTO_IMP_TIPO_EVENTO]
GO
ALTER TABLE [dbo].[IMP_FACTURA_COMERCIAL]  WITH CHECK ADD  CONSTRAINT [FK_IMP_FACTURA_COMERCIAL_IMP_ADQUISICION] FOREIGN KEY([Cod_adquisicion])
REFERENCES [dbo].[IMP_ADQUISICION] ([Cod_adquisicion])
GO
ALTER TABLE [dbo].[IMP_FACTURA_COMERCIAL] CHECK CONSTRAINT [FK_IMP_FACTURA_COMERCIAL_IMP_ADQUISICION]
GO
ALTER TABLE [dbo].[IMP_ORDEN_COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_ORDEN_COMPRA_IMP_PROVEEDOR] FOREIGN KEY([Cod_proveedor])
REFERENCES [dbo].[IMP_PROVEEDOR] ([Cod_proveedor])
GO
ALTER TABLE [dbo].[IMP_ORDEN_COMPRA] CHECK CONSTRAINT [FK_IMP_ORDEN_COMPRA_IMP_PROVEEDOR]
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_CONCEPTO] FOREIGN KEY([Cod_concepto])
REFERENCES [dbo].[IMP_CONCEPTO] ([Cod_concepto])
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION] CHECK CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_CONCEPTO]
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_SOLICITUD_IMPORTACION] FOREIGN KEY([Cod_solicitud_importacion])
REFERENCES [dbo].[IMP_SOLICITUD_IMPORTACION] ([Cod_solicitudimportacion])
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION] CHECK CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_SOLICITUD_IMPORTACION]
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_CAMBIO] FOREIGN KEY([Cod_tipo_cambio])
REFERENCES [dbo].[IMP_TIPO_CAMBIO] ([Cod_tipo_cambio])
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION] CHECK CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_CAMBIO]
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_MONEDA] FOREIGN KEY([Cod_tipo_moneda])
REFERENCES [dbo].[IMP_TIPO_MONEDA] ([Cod_tipo_moneda])
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION] CHECK CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_MONEDA]
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_PAGO] FOREIGN KEY([Cod_tipo_pago])
REFERENCES [dbo].[IMP_TIPO_PAGO] ([Cod_tipo_pago])
GO
ALTER TABLE [dbo].[IMP_PAGO_IMPORTACION] CHECK CONSTRAINT [FK_IMP_PAGO_IMPORTACION_IMP_TIPO_PAGO]
GO
ALTER TABLE [dbo].[IMP_PROVINCIA]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PROVINCIA_IMP_DEPARTAMENTO] FOREIGN KEY([Cod_departamento])
REFERENCES [dbo].[IMP_DEPARTAMENTO] ([Cod_departamento])
GO
ALTER TABLE [dbo].[IMP_PROVINCIA] CHECK CONSTRAINT [FK_IMP_PROVINCIA_IMP_DEPARTAMENTO]
GO
ALTER TABLE [dbo].[IMP_PUERTO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_PUERTO_IMP_DISTRITO] FOREIGN KEY([Cod_departamento], [Cod_provincia], [Cod_distrito])
REFERENCES [dbo].[IMP_DISTRITO] ([Cod_departamento], [Cod_provincia], [Cod_distrito])
GO
ALTER TABLE [dbo].[IMP_PUERTO] CHECK CONSTRAINT [FK_IMP_PUERTO_IMP_DISTRITO]
GO
ALTER TABLE [dbo].[IMP_RESOLUCION_DIGEMID]  WITH CHECK ADD  CONSTRAINT [FK_IMP_RESOLUCION_DIGEMID_IMP_SOLICITUD_GESTION_PERMISO] FOREIGN KEY([Cod_solicitud_gestio_permiso])
REFERENCES [dbo].[IMP_SOLICITUD_GESTION_PERMISO] ([Cod_solicitud_gestion_permiso])
GO
ALTER TABLE [dbo].[IMP_RESOLUCION_DIGEMID] CHECK CONSTRAINT [FK_IMP_RESOLUCION_DIGEMID_IMP_SOLICITUD_GESTION_PERMISO]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_GESTION_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_GESTION_PERMISO_IMP_ARTICULO] FOREIGN KEY([Cod_articulo])
REFERENCES [dbo].[IMP_ARTICULO] ([Cod_articulo])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_GESTION_PERMISO] CHECK CONSTRAINT [FK_IMP_SOLICITUD_GESTION_PERMISO_IMP_ARTICULO]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_GESTION_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_GESTION_PERMISO_IMP_SOLICITUD] FOREIGN KEY([Cod_solicitud])
REFERENCES [dbo].[IMP_SOLICITUD] ([Cod_solicitud])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_GESTION_PERMISO] CHECK CONSTRAINT [FK_IMP_SOLICITUD_GESTION_PERMISO_IMP_SOLICITUD]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_ORDEN_COMPRA] FOREIGN KEY([Cod_orden_compra])
REFERENCES [dbo].[IMP_ORDEN_COMPRA] ([Cod_orden_compra])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION] CHECK CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_ORDEN_COMPRA]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_PROVEEDOR] FOREIGN KEY([Cod_proveedor])
REFERENCES [dbo].[IMP_PROVEEDOR] ([Cod_proveedor])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION] CHECK CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_PROVEEDOR]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_PUERTO] FOREIGN KEY([Cod_puerto])
REFERENCES [dbo].[IMP_PUERTO] ([Cod_puerto])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION] CHECK CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_PUERTO]
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION]  WITH CHECK ADD  CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_SOLICITUD] FOREIGN KEY([Cod_solicitud])
REFERENCES [dbo].[IMP_SOLICITUD] ([Cod_solicitud])
GO
ALTER TABLE [dbo].[IMP_SOLICITUD_IMPORTACION] CHECK CONSTRAINT [FK_IMP_SOLICITUD_IMPORTACION_IMP_SOLICITUD]
GO
ALTER TABLE [dbo].[IMP_TIPO_CAMBIO]  WITH CHECK ADD  CONSTRAINT [FK_IMP_TIPO_CAMBIO_IMP_TIPO_MONEDA] FOREIGN KEY([Cod_tipo_moneda])
REFERENCES [dbo].[IMP_TIPO_MONEDA] ([Cod_tipo_moneda])
GO
ALTER TABLE [dbo].[IMP_TIPO_CAMBIO] CHECK CONSTRAINT [FK_IMP_TIPO_CAMBIO_IMP_TIPO_MONEDA]
GO
ALTER TABLE [dbo].[RRH_AlternativaAutoevaluacion]  WITH CHECK ADD  CONSTRAINT [FK_RRH_AlternativaAutoevaluacion_RRH_Criterio] FOREIGN KEY([Cod_criterio])
REFERENCES [dbo].[RRH_Criterio] ([Cod_criterio])
GO
ALTER TABLE [dbo].[RRH_AlternativaAutoevaluacion] CHECK CONSTRAINT [FK_RRH_AlternativaAutoevaluacion_RRH_Criterio]
GO
ALTER TABLE [dbo].[RRH_Candidato]  WITH CHECK ADD  CONSTRAINT [FK_RRH_Candidato_RRH_CurriculumVitae] FOREIGN KEY([Cod_cv_cand])
REFERENCES [dbo].[RRH_CurriculumVitae] ([Cod_cv_cand])
GO
ALTER TABLE [dbo].[RRH_Candidato] CHECK CONSTRAINT [FK_RRH_Candidato_RRH_CurriculumVitae]
GO
ALTER TABLE [dbo].[RRH_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_RRH_Empleado_RRH_Puesto] FOREIGN KEY([Cod_puesto])
REFERENCES [dbo].[RRH_Puesto] ([Cod_puesto])
GO
ALTER TABLE [dbo].[RRH_Empleado] CHECK CONSTRAINT [FK_RRH_Empleado_RRH_Puesto]
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_OfertaLaboral_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[RRH_Perfil] ([Cod_perfil])
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral] CHECK CONSTRAINT [FK_OfertaLaboral_Perfil]
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_OfertaLaboral_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[RRH_Sucursal] ([Cod_sucursal])
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral] CHECK CONSTRAINT [FK_OfertaLaboral_Sucursal]
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral_Candidato]  WITH CHECK ADD  CONSTRAINT [FK_OfertaLaboral_Candidato_Candidato] FOREIGN KEY([Cod_candidato])
REFERENCES [dbo].[RRH_Candidato] ([Cod_candidato])
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral_Candidato] CHECK CONSTRAINT [FK_OfertaLaboral_Candidato_Candidato]
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral_Candidato]  WITH CHECK ADD  CONSTRAINT [FK_OfertaLaboral_Candidato_OfertaLaboral] FOREIGN KEY([Cod_ofertalaboral])
REFERENCES [dbo].[RRH_OfertaLaboral] ([Cod_ofertalaboral])
GO
ALTER TABLE [dbo].[RRH_OfertaLaboral_Candidato] CHECK CONSTRAINT [FK_OfertaLaboral_Candidato_OfertaLaboral]
GO
ALTER TABLE [dbo].[RRH_Perfil]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Puesto] FOREIGN KEY([Cod_puesto])
REFERENCES [dbo].[RRH_Puesto] ([Cod_puesto])
GO
ALTER TABLE [dbo].[RRH_Perfil] CHECK CONSTRAINT [FK_Perfil_Puesto]
GO
ALTER TABLE [dbo].[RRH_PreguntaEvaluacionTecnica]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PreguntaEvaluacionTecnica_RRH_AlternativaEvaluacionTecnica] FOREIGN KEY([Cod_alternativa_evaluaciontec])
REFERENCES [dbo].[RRH_AlternativaEvaluacionTecnica] ([Cod_alternativa_evaluaciontec])
GO
ALTER TABLE [dbo].[RRH_PreguntaEvaluacionTecnica] CHECK CONSTRAINT [FK_RRH_PreguntaEvaluacionTecnica_RRH_AlternativaEvaluacionTecnica]
GO
ALTER TABLE [dbo].[RRH_PreguntaEvaluacionTecnica]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PreguntaEvaluacionTecnica_RRH_Criterio] FOREIGN KEY([Cod_criterio])
REFERENCES [dbo].[RRH_Criterio] ([Cod_criterio])
GO
ALTER TABLE [dbo].[RRH_PreguntaEvaluacionTecnica] CHECK CONSTRAINT [FK_RRH_PreguntaEvaluacionTecnica_RRH_Criterio]
GO
ALTER TABLE [dbo].[RRH_PruebaAuotoevaluacion]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PruebaAuotoevaluacion_RRH_AlternativaAutoevaluacion] FOREIGN KEY([Cod_alternativa_autoevaluacion])
REFERENCES [dbo].[RRH_AlternativaAutoevaluacion] ([Cod_alternativa_autoevaluacion])
GO
ALTER TABLE [dbo].[RRH_PruebaAuotoevaluacion] CHECK CONSTRAINT [FK_RRH_PruebaAuotoevaluacion_RRH_AlternativaAutoevaluacion]
GO
ALTER TABLE [dbo].[RRH_PruebaAuotoevaluacion]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PruebaAuotoevaluacion_RRH_Empleado] FOREIGN KEY([Cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[RRH_PruebaAuotoevaluacion] CHECK CONSTRAINT [FK_RRH_PruebaAuotoevaluacion_RRH_Empleado]
GO
ALTER TABLE [dbo].[RRH_PruebaEvaluacionTecnica]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PruebaEvaluacionTecnica_RRH_Empleado] FOREIGN KEY([Cod_empleado])
REFERENCES [dbo].[RRH_Empleado] ([Cod_empleado])
GO
ALTER TABLE [dbo].[RRH_PruebaEvaluacionTecnica] CHECK CONSTRAINT [FK_RRH_PruebaEvaluacionTecnica_RRH_Empleado]
GO
ALTER TABLE [dbo].[RRH_PruebaEvaluacionTecnica]  WITH CHECK ADD  CONSTRAINT [FK_RRH_PruebaEvaluacionTecnica_RRH_PreguntaEvaluacionTecnica] FOREIGN KEY([Cod_preg_eva_tec])
REFERENCES [dbo].[RRH_PreguntaEvaluacionTecnica] ([Cod_preg_eva_tec])
GO
ALTER TABLE [dbo].[RRH_PruebaEvaluacionTecnica] CHECK CONSTRAINT [FK_RRH_PruebaEvaluacionTecnica_RRH_PreguntaEvaluacionTecnica]
GO
ALTER TABLE [dbo].[RRH_Puesto]  WITH CHECK ADD  CONSTRAINT [FK_Puesto_Area] FOREIGN KEY([Cod_area])
REFERENCES [dbo].[RRH_Area] ([Cod_area])
GO
ALTER TABLE [dbo].[RRH_Puesto] CHECK CONSTRAINT [FK_Puesto_Area]
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_CAB]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_ACTARECEP_CAB_dbo.RYA_ALMACENES_Cod_Almacen] FOREIGN KEY([Cod_Almacen])
REFERENCES [dbo].[RYA_ALMACENES] ([Cod_Almacen])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_CAB] CHECK CONSTRAINT [FK_dbo.RYA_ACTARECEP_CAB_dbo.RYA_ALMACENES_Cod_Almacen]
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_CAB]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_ACTARECEP_CAB_dbo.RYA_PEDIDO_CAB_NumPedido] FOREIGN KEY([NumPedido])
REFERENCES [dbo].[RYA_PEDIDO_CAB] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_CAB] CHECK CONSTRAINT [FK_dbo.RYA_ACTARECEP_CAB_dbo.RYA_PEDIDO_CAB_NumPedido]
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_DET]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_ACTARECEP_DET_dbo.RYA_ACTARECEP_CAB_NumActa] FOREIGN KEY([NumActa])
REFERENCES [dbo].[RYA_ACTARECEP_CAB] ([NumActa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_DET] CHECK CONSTRAINT [FK_dbo.RYA_ACTARECEP_DET_dbo.RYA_ACTARECEP_CAB_NumActa]
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_DET]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_ACTARECEP_DET_dbo.RYA_PRODUCTO_Cod_Producto] FOREIGN KEY([Cod_Producto])
REFERENCES [dbo].[RYA_PRODUCTO] ([Cod_producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_ACTARECEP_DET] CHECK CONSTRAINT [FK_dbo.RYA_ACTARECEP_DET_dbo.RYA_PRODUCTO_Cod_Producto]
GO
ALTER TABLE [dbo].[RYA_ALMACENES]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_ALMACENES_dbo.RYA_SUCURSALES_SucursalId] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[RYA_SUCURSALES] ([Cod_sucursal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_ALMACENES] CHECK CONSTRAINT [FK_dbo.RYA_ALMACENES_dbo.RYA_SUCURSALES_SucursalId]
GO
ALTER TABLE [dbo].[RYA_PEDIDO_CAB]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_PEDIDO_CAB_dbo.RYA_SUCURSALES_Cod_Sucursal] FOREIGN KEY([Cod_Sucursal])
REFERENCES [dbo].[RYA_SUCURSALES] ([Cod_sucursal])
GO
ALTER TABLE [dbo].[RYA_PEDIDO_CAB] CHECK CONSTRAINT [FK_dbo.RYA_PEDIDO_CAB_dbo.RYA_SUCURSALES_Cod_Sucursal]
GO
ALTER TABLE [dbo].[RYA_PEDIDO_DET]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_PEDIDO_DET_dbo.RYA_PEDIDO_CAB_NumPedido] FOREIGN KEY([NumPedido])
REFERENCES [dbo].[RYA_PEDIDO_CAB] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_PEDIDO_DET] CHECK CONSTRAINT [FK_dbo.RYA_PEDIDO_DET_dbo.RYA_PEDIDO_CAB_NumPedido]
GO
ALTER TABLE [dbo].[RYA_PEDIDO_DET]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RYA_PEDIDO_DET_dbo.RYA_PRODUCTO_Cod_Producto] FOREIGN KEY([Cod_Producto])
REFERENCES [dbo].[RYA_PRODUCTO] ([Cod_producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RYA_PEDIDO_DET] CHECK CONSTRAINT [FK_dbo.RYA_PEDIDO_DET_dbo.RYA_PRODUCTO_Cod_Producto]
GO
USE [master]
GO
ALTER DATABASE [BDBoticas] SET  READ_WRITE 
GO
