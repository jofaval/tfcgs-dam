CREATE TABLE [dbo].[Trabajador] (
    [Persona]            VARCHAR (9) NOT NULL,
    [Sueldo]             FLOAT (53)  NOT NULL,
    [FechaIncorporacion] DATETIME    NOT NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC),
    CONSTRAINT [TrabajadorPersona] FOREIGN KEY ([Persona]) REFERENCES [dbo].[Persona] ([Dni]) ON DELETE CASCADE ON UPDATE CASCADE
);

