SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserSerials] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [UserId]   NVARCHAR (128) NULL,
    [SerialId] INT            NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserSerials]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SerialId]
    ON [dbo].[UserSerials]([SerialId] ASC);


GO
ALTER TABLE [dbo].[UserSerials]
    ADD CONSTRAINT [PK_dbo.UserSerials] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[UserSerials]
    ADD CONSTRAINT [FK_dbo.UserSerials_dbo.Serials_SerialId] FOREIGN KEY ([SerialId]) REFERENCES [dbo].[Serials] ([SerialId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[UserSerials]
    ADD CONSTRAINT [FK_dbo.UserSerials_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);


