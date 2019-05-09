CREATE TABLE [dbo].[Reclamacion] (
    [Alumno]        VARCHAR (9)  NOT NULL,
    [NumParte]      INT          NOT NULL,
    [Asunto]        VARCHAR (50) NOT NULL,
    [Contenido]     TEXT         NOT NULL,
    [DirigidoA]     VARCHAR (9)  NULL,
    [FechaEnvio]    DATETIME     NULL,
    [FechaRevision] DATETIME     NULL,
    [Respuesta]     TEXT         NULL,
    [Revisor]       VARCHAR (9)  NULL,
    [EnTramite]     BIT          NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [NumParte] ASC),
    CONSTRAINT [ReclamacionAlumno] FOREIGN KEY ([Alumno]) REFERENCES [dbo].[Alumno] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE
);

