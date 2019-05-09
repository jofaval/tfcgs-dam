CREATE TABLE [dbo].[Horario] (
    [CursoCod]      VARCHAR (10) NOT NULL,
    [CursoNombre]   VARCHAR (50) NOT NULL,
    [CodAsignatura] VARCHAR (9)  NOT NULL,
    [HoraInicio]    DATE         NOT NULL,
    [Dia]           INT          NOT NULL,
    [Anyo]          INT          NOT NULL,
    [HoraFinal]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [HoraInicio] ASC, [Dia] ASC, [Anyo] ASC, [HoraFinal] ASC),
    CONSTRAINT [HorarioAsignatura] FOREIGN KEY ([CodAsignatura]) REFERENCES [dbo].[Asignatura] ([Cod]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [HorarioCurso] FOREIGN KEY ([CursoCod], [CursoNombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

