CREATE TABLE [dbo].[Baja] (
    [Trabajador]  VARCHAR (9) NOT NULL,
    [FechaInicio] DATETIME    NOT NULL,
    [FechaFinal]  DATETIME    NULL,
    [Causa]       TEXT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Trabajador] ASC, [FechaInicio] ASC),
    CONSTRAINT [BajaTrabajador] FOREIGN KEY ([Trabajador]) REFERENCES [dbo].[Trabajador] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE
);

