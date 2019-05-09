CREATE TABLE [dbo].[Superior] (
    [Cod]            VARCHAR (10) NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [ReglasProyecto] TEXT         NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC, [Nombre] ASC),
    CONSTRAINT [SuperiorCiclo] FOREIGN KEY ([Cod], [Nombre]) REFERENCES [dbo].[Ciclo] ([Cod], [Nombre]) ON DELETE CASCADE ON UPDATE CASCADE
);

