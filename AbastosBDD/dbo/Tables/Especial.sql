CREATE TABLE [dbo].[Especial] (
    [Trabajador] VARCHAR (9)   NOT NULL,
    [Funcion]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Trabajador] ASC),
    CONSTRAINT [EspecialTrabajador] FOREIGN KEY ([Trabajador]) REFERENCES [dbo].[Trabajador] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE
);

