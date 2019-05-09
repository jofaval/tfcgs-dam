CREATE TABLE [dbo].[Alumno] (
    [Persona]            VARCHAR (9)  NOT NULL,
    [NumExpediente]      VARCHAR (9)  NOT NULL,
    [Tutor]              VARCHAR (9)  NULL,
    [FechaMatriculacion] DATETIME     NOT NULL,
    [CursoCod]           VARCHAR (10) NULL,
    [CursoNombre]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC),
    CONSTRAINT [AlumnoPersona] FOREIGN KEY ([Persona]) REFERENCES [dbo].[Persona] ([Dni]) ON DELETE CASCADE ON UPDATE CASCADE
);

