ALTER TABLE [dbo].[LocationVisitor]  WITH CHECK ADD  CONSTRAINT [FK_User_LocationVisitor] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[LocationVisitor] CHECK CONSTRAINT [FK_User_LocationVisitor]
GO

