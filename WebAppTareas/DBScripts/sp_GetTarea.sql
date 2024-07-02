/****** Object:  StoredProcedure [dbo].[GetTarea]    Script Date: 02-07-2024 9:57:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      Jorge Luis Silva López
-- Create Date: 25.06.2024
-- Description: SP para Obtener una Tarea por id
-- =============================================
CREATE PROCEDURE  [dbo].[GetTarea]
    @id INT
AS
BEGIN
    BEGIN TRY
      SELECT [id]
			,[titulo]
			,[descripcion]
			,[fechacreacion]
			,[estado]
	 FROM [dbo].[tarea]
     WHERE [id] = @id
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumero,
            ERROR_MESSAGE() AS MensajeError;
    END CATCH
END
GO

