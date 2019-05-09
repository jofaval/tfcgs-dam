CREATE TABLE [dbo].[Ordenador] (
    [Num]              VARCHAR (2)  NOT NULL,
    [Piso]             VARCHAR (2)  NOT NULL,
    [Estado]           TEXT         NULL,
    [CodOrdenadorAula] VARCHAR (5)  NOT NULL,
    [Ip]               VARCHAR (40) NULL,
    [SistemaOperativo] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Num] ASC, [Piso] ASC, [CodOrdenadorAula] ASC),
    CONSTRAINT [OrdenadorAula] FOREIGN KEY ([Num], [Piso]) REFERENCES [dbo].[Aula] ([Num], [Piso]) ON DELETE CASCADE ON UPDATE CASCADE
);

