CREATE TABLE [dbo].[Profesor] (
    [Trabajador]         VARCHAR (9)  NOT NULL,
    [FechaIncorporacion] DATETIME     NOT NULL,
    [Departamento]       VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Trabajador] ASC),
    CONSTRAINT [ProfesorDepartamento] FOREIGN KEY ([Trabajador]) REFERENCES [dbo].[Trabajador] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [ProfesorTrabajador] FOREIGN KEY ([Departamento]) REFERENCES [dbo].[Departamento] ([Cod]) ON DELETE CASCADE ON UPDATE CASCADE
);

