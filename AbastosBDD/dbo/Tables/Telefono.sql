CREATE TABLE [dbo].[Telefono] (
    [Persona]    VARCHAR (9)   NOT NULL,
    [Telefono]   VARCHAR (9)   NOT NULL,
    [Comentario] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Persona] ASC, [Telefono] ASC),
    CONSTRAINT [TelefonosPersona] FOREIGN KEY ([Persona]) REFERENCES [dbo].[Persona] ([Dni]) ON DELETE CASCADE ON UPDATE CASCADE
);

