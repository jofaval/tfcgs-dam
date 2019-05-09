CREATE TABLE [dbo].[CertificadoNotas] (
    [Alumno]         VARCHAR (9)  NOT NULL,
    [CursoCod]       VARCHAR (10) NOT NULL,
    [CursoNombre]    VARCHAR (50) NOT NULL,
    [FechaSolicitud] DATETIME     NOT NULL,
    [NotaMeDia]      FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Alumno] ASC, [CursoCod] ASC, [CursoNombre] ASC, [FechaSolicitud] ASC),
    CONSTRAINT [CertificadoNotasCertificado] FOREIGN KEY ([Alumno], [CursoCod], [CursoNombre], [FechaSolicitud]) REFERENCES [dbo].[Certificado] ([Alumno], [CursoCod], [CursoNombre], [FechaSolicitud]) ON DELETE CASCADE ON UPDATE CASCADE
);

