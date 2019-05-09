CREATE TABLE [dbo].[Curso] (
    [Cod]                VARCHAR (10) NOT NULL,
    [Nombre]             VARCHAR (50) NOT NULL,
    [Tutor]              VARCHAR (9)  NULL,
    [FechaMatriculacion] DATETIME     NULL,
    [TurnoTarde]         BIT          NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC, [Nombre] ASC)
);

