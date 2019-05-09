CREATE TABLE [dbo].[Titulo] (
    [Alumno]         VARCHAR (9)  NOT NULL,
    [CursoCod]       VARCHAR (10) NOT NULL,
    [CursoNombre]    VARCHAR (50) NOT NULL,
    [FechaSolicitud] DATETIME     NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [Firmado]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [FechaSolicitud] ASC),
    CONSTRAINT [TituloCertificado] FOREIGN KEY ([Alumno], [CursoCod], [CursoNombre], [FechaSolicitud]) REFERENCES [dbo].[Certificado] ([Alumno], [CursoCod], [CursoNombre], [FechaSolicitud]) ON DELETE CASCADE ON UPDATE CASCADE
);

