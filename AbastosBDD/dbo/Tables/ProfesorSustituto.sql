CREATE TABLE [dbo].[ProfesorSustituto] (
    [Sustituido]        VARCHAR (9) NOT NULL,
    [FechaFinalizacion] DATETIME    NULL,
    PRIMARY KEY CLUSTERED ([Sustituido] ASC),
    CONSTRAINT [SustitutoProfesor] FOREIGN KEY ([Sustituido]) REFERENCES [dbo].[Profesor] ([Trabajador]) ON DELETE CASCADE ON UPDATE CASCADE
);

