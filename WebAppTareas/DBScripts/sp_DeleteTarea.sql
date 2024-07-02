/****** Object:  StoredProcedure [dbo].[DeleteTarea]    Script Date: 02-07-2024 9:57:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Jorge Luis Silva
-- Create Date: 25.06.2024
-- Description: SP para eliminar Tareas por id
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTarea]
    @id INT,
    @error INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
        BEGIN TRANSACTION

			DELETE FROM [dbo].[tarea]
			WHERE id = @id

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No se encontró el registro', 16, 1)
        END

        SET @error = 0

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SET @error = ERROR_NUMBER()
    END CATCH
END
GO

