/****** Object:  StoredProcedure [dbo].[UpdateTarea]    Script Date: 02-07-2024 9:58:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Jorge Luis Silva
-- Create Date: 25.06.2024
-- Description: SP para modificar Tareas por id
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTarea]
    @id INT,
    @titulo VARCHAR(100),
    @descripcion VARCHAR(250),
    @estado BIT,
    @error INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
        BEGIN TRAN

			UPDATE [dbo].[tarea]
			   SET [titulo] = @titulo
				  ,[descripcion] = @descripcion
				  ,[estado] = @estado
			 WHERE [id] = @id

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No se encontró el registro', 16, 1)
        END

        SET @error = 0
		COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
		SET @error = ERROR_NUMBER()
    END CATCH
END
GO

