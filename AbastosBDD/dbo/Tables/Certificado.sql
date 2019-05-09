CREATE TABLE [dbo].[Certificado] (
    [Alumno]          VARCHAR (9)  NOT NULL,
    [CursoCod]        VARCHAR (10) NOT NULL,
    [CursoNombre]     VARCHAR (50) NOT NULL,
    [FechaSolicitud]  DATETIME     NOT NULL,
    [FechaDisponible] DATETIME     NULL,
    [FechaRecogido]   DATETIME     NULL,
    [Pagado]          BIT          NULL,
    [EnTramite]       BIT          NULL,
    [Importe]         FLOAT (53)   NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [FechaSolicitud] ASC),
    CONSTRAINT [CertificadoAlumno] FOREIGN KEY ([Alumno]) REFERENCES [dbo].[Alumno] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [CertificadoCurso] FOREIGN KEY ([CursoCod], [CursoNombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

