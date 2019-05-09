CREATE TABLE [dbo].[Eso] (
    [Cod]    VARCHAR (10) NOT NULL,
    [Nombre] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Nombre] ASC, [Cod] ASC),
    CONSTRAINT [EsoCurso] FOREIGN KEY ([Cod], [Nombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

