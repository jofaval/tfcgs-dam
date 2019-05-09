CREATE TABLE [dbo].[PermisosUsuario] (
    [Nombre]                VARCHAR (50)  NOT NULL,
    [Descripcion]           VARCHAR (255) NULL,
    [PermisoAdministrativo] BIT           NOT NULL,
    [PermisoAdmin]          BIT           NOT NULL,
    [PermisProfesor]        BIT           NOT NULL,
    [PermisoAlumno]         BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Nombre] ASC, [PermisoAdministrativo] ASC, [PermisoAdmin] ASC, [PermisProfesor] ASC, [PermisoAlumno] ASC)
);

