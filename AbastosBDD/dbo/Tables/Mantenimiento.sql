CREATE TABLE [dbo].[Mantenimiento] (
    [Trabajador] VARCHAR (9)   NOT NULL,
    [Horario]    TEXT          NULL,
    [Funcion]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Trabajador] ASC),
    CONSTRAINT [MantenimientoTrabajador] FOREIGN KEY ([Trabajador]) REFERENCES [dbo].[Trabajador] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE
);

