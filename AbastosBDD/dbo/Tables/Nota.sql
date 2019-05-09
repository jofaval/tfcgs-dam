CREATE TABLE [dbo].[Nota] (
    [Alumno]          VARCHAR (9)   NOT NULL,
    [CursoCod]        VARCHAR (10)  NOT NULL,
    [CursoNombre]     VARCHAR (50)  NOT NULL,
    [CodAsignatura]   VARCHAR (9)   NOT NULL,
    [ConvocatoriaNum] INT           NOT NULL,
    [EvaluacionNum]   INT           NOT NULL,
    [Valoracion]      FLOAT (53)    NOT NULL,
    [Observaciones]   VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [ConvocatoriaNum] ASC, [EvaluacionNum] ASC),
    CONSTRAINT [NotaEvaluacion] FOREIGN KEY ([Alumno], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum]) REFERENCES [dbo].[Evaluacion] ([Alumno], [CursoCod], [CursoNombre], [CodAsignatura], [ConvocatoriaNum], [EvaluacionNum]) ON DELETE CASCADE ON UPDATE CASCADE
);

