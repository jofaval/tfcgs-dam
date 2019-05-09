CREATE TABLE [dbo].[Usuario] (
    [Persona]               VARCHAR (9)  NOT NULL,
    [Username]              VARCHAR (16) NOT NULL,
    [Contrasenya]           VARCHAR (32) NOT NULL,
    [Nombre]                VARCHAR (50) NOT NULL,
    [PermisoAdministrativo] BIT          NOT NULL,
    [PermisoAdmin]          BIT          NOT NULL,
    [PermisProfesor]        BIT          NOT NULL,
    [PermisoAlumno]         BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC, [Username] ASC, [Nombre] ASC, [PermisoAdministrativo] ASC, [PermisoAdmin] ASC, [PermisProfesor] ASC, [PermisoAlumno] ASC),
    CONSTRAINT [UsuarioPermisosUsuario] FOREIGN KEY ([Nombre], [PermisoAdministrativo], [PermisoAdmin], [PermisProfesor], [PermisoAlumno]) REFERENCES [dbo].[PermisosUsuario] ([Nombre], [PermisoAdministrativo], [PermisoAdmin], [PermisProfesor], [PermisoAlumno]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [UsuarioPersona] FOREIGN KEY ([Persona]) REFERENCES [dbo].[Persona] ([Dni]) ON DELETE CASCADE ON UPDATE CASCADE
);

