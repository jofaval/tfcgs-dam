CREATE TABLE [dbo].[Proyecto] (
    [Alumno]         VARCHAR (9)   NOT NULL,
    [SuperiorCod]    VARCHAR (10)  NOT NULL,
    [SuperiorNombre] VARCHAR (50)  NOT NULL,
    [FechaInicio]    DATETIME      NOT NULL,
    [FechaEntrega]   DATETIME      NULL,
    [Memoria]        VARCHAR (100) NULL,
    [Contenido]      VARCHAR (100) NULL,
    [Tutor]          VARCHAR (9)   NULL,
    [Nota]           FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [SuperiorCod] ASC, [SuperiorNombre] ASC, [FechaInicio] ASC),
    CONSTRAINT [ProyectoAlumno] FOREIGN KEY ([Alumno]) REFERENCES [dbo].[Alumno] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [ProyectoSuperior] FOREIGN KEY ([SuperiorCod], [SuperiorNombre]) REFERENCES [dbo].[Superior] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

