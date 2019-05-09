CREATE TABLE [dbo].[AsistenciaDiaAsignatura] (
    [Persona]                      VARCHAR (9)  NOT NULL,
    [CursoCod]                     VARCHAR (10) NOT NULL,
    [CursoNombre]                  VARCHAR (50) NOT NULL,
    [CodAsignatura]                VARCHAR (9)  NOT NULL,
    [ConvocatoriaNum]              INT          NOT NULL,
    [EvaluacionNum]                INT          NOT NULL,
    [SemanaNombre]                 INT          NOT NULL,
    [DiaNombre]                    INT          NOT NULL,
    [FaltasAsistencia]             INT          NULL,
    [FaltasAsistenciaJustificadas] INT          NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [ConvocatoriaNum] ASC, [EvaluacionNum] ASC, [DiaNombre] ASC),
    CONSTRAINT [AsistenciaDiaAsignaturaAsistenciaSemanaAsignatura] FOREIGN KEY ([Persona], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum], [DiaNombre]) REFERENCES [dbo].[AsistenciaSemanaAsignatura] ([Persona], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum], [SemanaNum]) ON DELETE CASCADE ON UPDATE CASCADE
);

