INSERT INTO RYA_SUCURSALES([Descripcion], [Direccion], [Estado]) VALUES('Sucursal 01', 'Direccion 01', 1)
GO
INSERT INTO RYA_SUCURSALES([Descripcion], [Direccion], [Estado]) VALUES('Sucursal 02', 'Direccion 02', 1)
GO
INSERT INTO RYA_SUCURSALES([Descripcion], [Direccion], [Estado]) VALUES('Sucursal 03', 'Direccion 02', 1)
GO

INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, [EstadoPedido], Cod_Sucursal, CodSolicitante, [Estado]) VALUES('OP000001', GETDATE(), 1, 1, 1, 1)
GO
INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, [EstadoPedido], Cod_Sucursal, CodSolicitante, [Estado]) VALUES('OP000002', GETDATE(), 1, 1, 1, 1)
GO
INSERT INTO RYA_PEDIDO_CAB(NumPedido, FchPedido, [EstadoPedido], Cod_Sucursal, CodSolicitante, [Estado]) VALUES('OP000003', GETDATE(), 1, 1, 1, 1)
GO


INSERT INTO RYA_ALMACENES([Descripcion], [SucursalId], [Estado]) VALUES('Almacen 01', 1, 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], [SucursalId], [Estado]) VALUES('Almacen 02', 1, 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], [SucursalId], [Estado]) VALUES('Almacen 01', 2, 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], [SucursalId], [Estado]) VALUES('Almacen 02', 2, 1)
GO
INSERT INTO RYA_ALMACENES([Descripcion], [SucursalId], [Estado]) VALUES('Almacen 01', 3, 1)
GO


INSERT INTO RYA_PRODUCTO(Cod_producto, [Nombre], [UnidadMedida], [Precio], [Estado]) VALUES('1', 'Articulo 01', 'Kg', 15.00, 1)
GO
INSERT INTO RYA_PRODUCTO(Cod_producto, [Nombre], [UnidadMedida], [Precio], [Estado]) VALUES('2', 'Articulo 02', 'Kg', 20.00, 1)
GO								
INSERT INTO RYA_PRODUCTO(Cod_producto, [Nombre], [UnidadMedida], [Precio], [Estado]) VALUES('3', 'Articulo 03', 'Kg', 30.00, 1)
GO


INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('1', 1, 2, 'A', 1)
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('2', 1, 1, 'A', 1)
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('3', 1, 3, 'A', 1)
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('1', 2, 5, 'A', 1)
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('2', 2, 20, 'A', 1)
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('3', 2, 15, 'A', 1)
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('1', 3, 14, 'A', 1)
GO
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('2', 3, 5, 'A', 1)
GO									
INSERT INTO RYA_PEDIDO_DET(Cod_producto, NumPedido, Cant, Lote, [Estado]) VALUES('3', 3, 6, 'A', 1)
GO