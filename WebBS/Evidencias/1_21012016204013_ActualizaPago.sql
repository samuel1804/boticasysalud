BEGIN TRAN PAGO

BEGIN TRY
	/***TRANSACCION***/
	SET NOCOUNT ON
/*actualiza pagos a no utilizados*/
UPDATE PGO.PAGO
SET ESTADO_APLICACION = '2'
WHERE ESTADO_APLICACION = '4' AND 
CODIGO_PAGO IN(
1156640,
1156641,
1156642,
1156643,
1156644,
1156645,
1156646,
1156647,
1156648,
1156649,
1156650,
1156651,
1156652,
1156653,
1156654,
1156656,
1156657,
1156658,
1156659,
1156660,
1156661,
1156662,
1156663,
1156664,
1156665,
1156666,
1156667,
1156668,
1156669,
1156670,
1156671,
1156672,
1156673,
1156674,
1156675,
1156676,
1156677,
1156679,
1156680,
1156681,
1156682,
1156683,
1156684,
1156685,
1156686,
1156687,
1156688,
1156689,
1121244
)
/***TRANSACCION***/
	COMMIT TRAN PAGO
	print 'Transacci�n ejecutada con �xito'
	SET NOCOUNT OFF
END TRY
BEGIN CATCH 
	ROLLBACK TRAN PAGO
SELECT ERROR_MESSAGE() as Error
END CATCH
