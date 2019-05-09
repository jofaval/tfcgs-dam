CREATE TABLE [dbo].[Bachiller] (
    [Cod]             VARCHAR (10) NOT NULL,
    [Nombre]          VARCHAR (50) NOT NULL,
    [Especializacion] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC, [Nombre] ASC),
    CONSTRAINT [BachillerCurso] FOREIGN KEY ([Cod], [Nombre]) REFERENCES [dbo].[Curso] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

