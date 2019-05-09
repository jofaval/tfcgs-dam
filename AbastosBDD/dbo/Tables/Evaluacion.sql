CREATE TABLE [dbo].[Evaluacion] (
    [Alumno]          VARCHAR (9)  NOT NULL,
    [CursoCod]        VARCHAR (10) NOT NULL,
    [CursoNombre]     VARCHAR (50) NOT NULL,
    [CodAsignatura]   VARCHAR (9)  NOT NULL,
    [ConvocatoriaNum] INT          NOT NULL,
    [EvaluacionNum]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [ConvocatoriaNum] ASC, [EvaluacionNum] ASC),
    CONSTRAINT [EvaluacionConvocatoria] FOREIGN KEY ([Alumno], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum]) REFERENCES [dbo].[Convocatoria] ([Alumno], [CursoCod], [CursoNombre], [CodAsignatura], [Num]) ON DELETE CASCADE ON UPDATE CASCADE
);

