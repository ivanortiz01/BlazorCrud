CREATE TABLE [dbo].[beer] (
    [Id]    INT           NOT NULL IDENTITY,
    [name]  VARCHAR (MAX) NULL,
    [maker] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

