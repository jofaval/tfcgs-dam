CREATE TABLE [dbo].[Impartimiento] (
    [Profesor]      VARCHAR (9)  NOT NULL,
    [CursoCod]      VARCHAR (10) NOT NULL,
    [CursoNombre]   VARCHAR (50) NOT NULL,
    [CodAsignatura] VARCHAR (9)  NOT NULL,
    [HoraInicio]    DATE         NOT NULL,
    [Dia]           INT          NOT NULL,
    [Anyo]          INT          NOT NULL,
    [HoraFinal]     INT          NOT NULL,
    [AulaNum]       VARCHAR (2)  NOT NULL,
    [AulaPiso]      VARCHAR (2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Profesor] ASC, [CursoCod] ASC, [CursoNombre] ASC, [CodAsignatura] ASC, [HoraInicio] ASC, [Dia] ASC, [Anyo] ASC, [HoraFinal] ASC, [AulaNum] ASC, [AulaPiso] ASC),
    CONSTRAINT [AulaImpartimiento] FOREIGN KEY ([AulaNum], [AulaPiso]) REFERENCES [dbo].[Aula] ([Num], [Piso]),
    CONSTRAINT [ProfesorHorarioHorario] FOREIGN KEY ([CursoCod], [CursoNombre], [CodAsignatura], [HoraInicio], [Dia], [Anyo], [HoraFinal]) REFERENCES [dbo].[Horario] ([CursoCod], [CursoNombre], [CodAsignatura], [HoraInicio], [Dia], [Anyo], [HoraFinal]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [ProfesorHorarioProfesor] FOREIGN KEY ([Profesor]) REFERENCES [dbo].[Profesor] ([Trabajador]) ON DELETE CASCADE ON UPDATE CASCADE
);

