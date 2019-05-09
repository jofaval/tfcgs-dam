CREATE TABLE [dbo].[Administrativo] (
    [Trabajador]   VARCHAR (9)   NOT NULL,
    [Departamento] VARCHAR (10)  NULL,
    [Funcion]      VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Trabajador] ASC),
    CONSTRAINT [AdministrativoDepartamento] FOREIGN KEY ([Departamento]) REFERENCES [dbo].[Departamento] ([Cod]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [AdministrativoTrabajador] FOREIGN KEY ([Trabajador]) REFERENCES [dbo].[Trabajador] ([Persona]) ON DELETE CASCADE ON UPDATE CASCADE
);

