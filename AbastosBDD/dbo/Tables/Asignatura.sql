CREATE TABLE [dbo].[Asignatura] (
    [Cod]    VARCHAR (9)  NOT NULL,
    [Nombre] VARCHAR (50) NOT NULL,
    [Rama]   VARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC),
    UNIQUE NONCLUSTERED ([Nombre] ASC)
);

