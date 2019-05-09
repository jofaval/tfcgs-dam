CREATE TABLE [dbo].[AsistenciaSemanaAsignatura] (
    [Persona]         VARCHAR (9)  NOT NULL,
    [CursoCod]        VARCHAR (10) NOT NULL,
    [CursoNombre]     VARCHAR (50) NOT NULL,
    [CodAsignatura]   VARCHAR (9)  NOT NULL,
    [ConvocatoriaNum] INT          NOT NULL,
    [EvaluacionNum]   INT          NOT NULL,
    [SemanaNum]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [ConvocatoriaNum] ASC, [EvaluacionNum] ASC, [SemanaNum] ASC),
    CONSTRAINT [AsistenciaSemanaAsignaturaEvaluacion] FOREIGN KEY ([Persona], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum]) REFERENCES [dbo].[Evaluacion] ([Alumno], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum]) ON DELETE CASCADE ON UPDATE CASCADE
);

