CREATE TABLE [dbo].[Departamento] (
    [Cod]    VARCHAR (10) NOT NULL,
    [Nombre] TEXT         NOT NULL,
    [Num]    VARCHAR (2)  NULL,
    [Piso]   VARCHAR (2)  NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC),
    CONSTRAINT [DepartamentoAula] FOREIGN KEY ([Num], [Piso]) REFERENCES [dbo].[Aula] ([Num], [Piso]) ON DELETE CASCADE ON UPDATE CASCADE
);

