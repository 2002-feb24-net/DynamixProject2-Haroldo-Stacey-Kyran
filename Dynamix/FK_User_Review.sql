ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_User_Review] FOREIGN KEY([CreatorUserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_User_Review]
GO

