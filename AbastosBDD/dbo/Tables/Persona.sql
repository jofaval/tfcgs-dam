CREATE TABLE [dbo].[Persona] (
    [Dni]             VARCHAR (9)   NOT NULL,
    [Nif]             VARCHAR (9)   NOT NULL,
    [Calle]           VARCHAR (100) NOT NULL,
    [CodigoPostal]    VARCHAR (6)   NOT NULL,
    [Patio]           VARCHAR (4)   NOT NULL,
    [Piso]            VARCHAR (3)   NOT NULL,
    [Puerta]          VARCHAR (4)   NOT NULL,
    [Nombre]          VARCHAR (50)  NOT NULL,
    [Apellidos]       VARCHAR (100) NOT NULL,
    [FechaNacimiento] DATETIME      NOT NULL,
    [Email]           VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Dni] ASC),
    UNIQUE NONCLUSTERED ([Nif] ASC),
    UNIQUE NONCLUSTERED ([Nif] ASC)
);

