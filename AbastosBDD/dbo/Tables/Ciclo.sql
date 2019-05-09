CREATE TABLE [dbo].[Ciclo] (
    [Cod]           VARCHAR (10) NOT NULL,
    [Nombre]        VARCHAR (50) NOT NULL,
    [Basica]        BIT          NOT NULL,
    [HorasPractica] INT          NOT NULL,
    [Rama]          VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC, [Nombre] ASC),
    CONSTRAINT [CicloCurso] FOREIGN KEY ([Cod], [Nombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

