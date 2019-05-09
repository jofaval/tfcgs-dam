CREATE TABLE [dbo].[Aula] (
    [Num]    VARCHAR (2) NOT NULL,
    [Piso]   VARCHAR (2) NOT NULL,
    [Estado] TEXT        NULL,
    PRIMARY KEY CLUSTERED ([Num] ASC, [Piso] ASC)
);

