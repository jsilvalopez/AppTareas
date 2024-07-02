/****** Object:  StoredProcedure [dbo].[SelectTareas]    Script Date: 02-07-2024 9:58:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      Jorge Luis Silva López
-- Create Date: 25.06.2024
-- Description: SP para Obtener una Tareas
-- =============================================
CREATE PROCEDURE  [dbo].[SelectTareas]
AS
BEGIN
    BEGIN TRY
      SELECT [id]
			,[titulo]
			,[descripcion]
			,[fechacreacion]
			,[estado]
	 FROM [dbo].[tarea]
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumero,
            ERROR_MESSAGE() AS MensajeError;
    END CATCH
END
GO

