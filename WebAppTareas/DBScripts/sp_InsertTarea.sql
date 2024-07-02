/****** Object:  StoredProcedure [dbo].[InsertTarea]    Script Date: 02-07-2024 9:58:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Jorge Luis Silva
-- Create Date: 25.06.2024
-- Description: SP para insertar Tareas 
-- =============================================
CREATE PROCEDURE [dbo].[InsertTarea]
    @titulo VARCHAR(100),
    @descripcion VARCHAR(250),
    @estado BIT,
    @id INT OUTPUT,
    @error INT OUTPUT

AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
        BEGIN TRAN

		INSERT INTO [dbo].[tarea]
				   ([titulo]
				   ,[descripcion]
				   ,[fechacreacion]
				   ,[estado])
			 VALUES
				   (@titulo
				   ,@descripcion
				   ,GETUTCDATE()
				   ,0)

        SET @id = SCOPE_IDENTITY()
        SET @error = 0

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN

        SET @error = ERROR_NUMBER()
        SET @id = NULL

    END CATCH
END
GO

