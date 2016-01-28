INSERT INTO RRH_Sucursal(Nom_Sucursal, [Direccion]) VALUES('Sucursal 01', 'Direccion 01')
GO
INSERT INTO RRH_Sucursal(Nom_Sucursal, [Direccion]) VALUES('Sucursal 02', 'Direccion 02')
GO
INSERT INTO RRH_Sucursal(Nom_Sucursal, [Direccion]) VALUES('Sucursal 03', 'Direccion 02')
GO


INSERT INTO RRH_Area(Nombre, Estado) VALUES('Area 01', 1)
GO


INSERT INTO RRH_Puesto(Nom_Puesto, Cod_Area, Estado) VALUES('Puesto 01', 1, 1)
GO


INSERT INTO RRH_Empleado(Nom_Empleado, Fec_Ingreso, Cod_Puesto) VALUES('Empleado 01', GETDATE(), 1)
GO


INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, FchEntrega, Estado, Cod_Sucursal, CodSolicitante) VALUES('OP000001', GETDATE(), GETDATE(), '1', 1, 1)
GO
INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, FchEntrega, Estado, Cod_Sucursal, CodSolicitante) VALUES('OP000002', GETDATE(), GETDATE(), '1', 1, 1)
GO
INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, FchEntrega, Estado, Cod_Sucursal, CodSolicitante) VALUES('OP000003', GETDATE(), GETDATE(), '1', 1, 1)
GO


INSERT INTO RYA_ALMACENES([Descripcion], Cod_sucursal) VALUES('Almacen 01', 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], Cod_sucursal) VALUES('Almacen 02', 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], Cod_sucursal) VALUES('Almacen 01', 2)
GO
INSERT INTO RYA_ALMACENES([Descripcion], Cod_sucursal) VALUES('Almacen 02', 2)
GO
INSERT INTO RYA_ALMACENES([Descripcion], Cod_sucursal) VALUES('Almacen 01', 3)
GO


INSERT INTO DIS_TipoProducto(Des_Tipo_Producto) VALUES('Tipo 01')
GO


INSERT INTO DIS_PresentacionProducto(Des_Presentacion_Producto) VALUES('Presentacion 01')
GO


INSERT INTO DIS_Producto(Nom_Producto, Cod_Tipo_Producto, Cod_presentacion_Producto, [Estado]) VALUES('Articulo 01', 1, 1, 1)
GO
INSERT INTO DIS_Producto(Nom_Producto, Cod_Tipo_Producto, Cod_presentacion_Producto, [Estado]) VALUES('Articulo 02', 1, 1, 1)
GO						
INSERT INTO DIS_Producto(Nom_Producto, Cod_Tipo_Producto, Cod_presentacion_Producto, [Estado]) VALUES('Articulo 03', 1, 1, 1)
GO


INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(1, 1, 2, 2, 2, 'Kg')
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(2, 1, 1, 1, 1, 'Kg')
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(3, 1, 3, 3, 3, 'Kg')
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(1, 2, 5, 5, 5, 'Kg')
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(2, 2, 20, 20, 20, 'Kg')
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(3, 2, 15, 15, 15, 'Kg')
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(1, 3, 14, 14, 14, 'Kg')
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(2, 3, 5, 5, 5, 'Kg')
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Cant_Aprob, Cant_Atendida, UnidadMedida) VALUES(3, 3, 6, 6, 6, 'Kg')
GO