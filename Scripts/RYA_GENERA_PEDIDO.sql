--CREATE PROC [dbo].[RYA_GENERA_PEDIDO_DEL_DIA]
---AS

DECLARE	@usuario int, @sucursal int, @diasGracia int

set @sucursal = 1
set @diasGracia = 180
set @usuario = 1

/* Creamos tablas temporales para ir insertando los registros que encontrmos sin stock*/
CREATE TABLE #TMP_PEDIDO_DET(
	[item] [int] NOT NULL,
	[COD_PRODUCTO] [int] NOT NULL,
	[UnidadMedida] [nvarchar](3) NULL,
	[Cant] [int] NOT NULL,
	[Cant_aprob] [int] NOT NULL,
	[Cant_atendida] [int] NOT NULL,
	[obs] [varchar](120) NULL
)

CREATE TABLE #TMP_PEDIDO_CAB(
	[FchPedido] [datetime] NOT NULL,
	[FchEntrega] [datetime] NOT NULL,
	[Cod_sucursal] [int] NOT NULL,
	[CodSolicitante] [int] NOT NULL,
	[Glosa] [varchar](200) NULL,
	[Estado] [char](1) NOT NULL
)


/* Revisamos que productos no tienen stock o estan por debajo del stock minimo */
INSERT #TMP_PEDIDO_DET( item, COD_PRODUCTO, UnidadMedida, Cant, Cant_aprob, Cant_atendida, obs)
SELECT	ROW_NUMBER() OVER ( ORDER BY pro.cod_producto ) AS item, 
		pro.Cod_producto,
		pro.Unidad_medida,
		( lot.stock_max - stk.COD_PRODUCTO ),
		0,
		0,
		''
FROM	DIS_PRODUCTO PRO,
		(
		SELECT	COD_PRODUCTO,
				SUM(Cant) as stock
		FROM	dbo.RYA_STOCK
		WHERE	Cod_sucursal = @sucursal 
		GROUP BY COD_PRODUCTO
		)STK,
		RYA_LOGISTICO LOT
WHERE	( PRO.Cod_producto = 	STK.Cod_producto )
		AND ( PRO.Cod_producto = LOT.cod_producto )
		AND ( STK.stock < = LOT.stock_min )	
ORDER BY pro.cod_producto

/* Revisamos que productos estan proximos a vencer y que podrian afectar el stock minimo */

INSERT #TMP_PEDIDO_DET( item, COD_PRODUCTO, UnidadMedida, Cant, Cant_aprob, Cant_atendida, obs)
SELECT	ROW_NUMBER() OVER ( ORDER BY pro.cod_producto ) AS item, 
		pro.Cod_producto,
		pro.Unidad_medida,
		( loi.stock_max -  stk.COD_PRODUCTO ),
		0,
		0,
		'Lote por Vencer : ' + lot.Lote + '  Vcto : ' + SUBSTRING(CONVERT(VARCHAR, lot.fch_vto, 103 ),1,10)

FROM	dbo.RYA_LOTES LOT,
		dbo.RYA_LOGISTICO LOI,
		dbo.RYA_STOCK STK,
		dbo.DIS_Producto PRO
WHERE	( pro.cod_producto = loi.cod_producto ) 
		AND ( lot.cod_producto = loi.cod_producto ) 
		AND ( STK.cod_producto = loi.cod_producto ) 
		AND ( STK.Cod_Lote = lot.Cod_Lote )
		AND ( lot.fch_vto < ( GETDATE() + @diasGracia ))
ORDER BY pro.cod_producto

DECLARE @ULTIMO INT, @LINEAS INT

SET @LINEAS = ( SELECT COUNT(*) FROM #TMP_PEDIDO_DET )

IF @LINEAS > 0
	
	BEGIN
			/* Insertamos la cabecera del pedido */
			DECLARE @newPedido varchar(10)

			Select @newPedido = 'OP'+substring(cast(1000000 + MAX(id)+1 as varchar),2,6) from RYA_PEDIDO_CAB 

			INSERT INTO [BDBoticas].[dbo].[RYA_PEDIDO_CAB] ([NumPedido], [FchPedido],[FchEntrega],[Cod_sucursal],[CodSolicitante],[Glosa],[Estado]) 
			VALUES (@newPedido, GETDATE(),GETDATE(),@sucursal,@usuario,'','2')

			/* Identificamos el ultimo registro insertado */

			SET @ULTIMO = @@IDENTITY

			/* Insertamos los detalles del pedido */
			INSERT INTO [BDBoticas].[dbo].[RYA_PEDIDO_DET] ([NumPedido],[COD_PRODUCTO],[UnidadMedida],[Cant],[Cant_aprob],[Cant_atendida],[obs]) 
			SELECT @ULTIMO,COD_PRODUCTO,UnidadMedida,Cant,Cant_aprob,Cant_atendida,obs FROM #TMP_PEDIDO_DET


			drop table #TMP_PEDIDO_CAB
			drop table #TMP_PEDIDO_DET



			/*
			select * from RYA_STOCK	
			select * from RYA_LOGISTICO	

			SELECT * FROM RYA_PEDIDO_CAB
			SELECT * FROM RYA_PEDIDO_DET
			*/	
			
	END

GO