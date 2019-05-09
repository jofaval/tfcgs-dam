CREATE TABLE [dbo].[Convocatoria] (
    [Alumno]        VARCHAR (9)  NOT NULL,
    [CursoCod]      VARCHAR (10) NOT NULL,
    [CursoNombre]   VARCHAR (50) NOT NULL,
    [CodAsignatura] VARCHAR (9)  NOT NULL,
    [Num]           INT          NOT NULL,
    [Renunciada]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [Num] ASC),
    CONSTRAINT [ConvocatoriaAlumno] FOREIGN KEY ([Alumno]) REFERENCES [dbo].[Alumno] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [ConvocatoriaAsignatura] FOREIGN KEY ([CodAsignatura]) REFERENCES [dbo].[Asignatura] ([Cod]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [ConvocatoriaCurso] FOREIGN KEY ([CursoCod], [CursoNombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

