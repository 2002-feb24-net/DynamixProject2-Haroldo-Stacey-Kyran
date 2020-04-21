/****** Object:  Table [dbo].[LocationVisitor]    Script Date: 4/20/2020 8:32:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LocationVisitor](
	[LocationVisitorID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ReviewID] [int] NOT NULL,
 CONSTRAINT [PK_LocationVisit_1] PRIMARY KEY CLUSTERED 
(
	[LocationVisitorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LocationVisitor]  WITH CHECK ADD  CONSTRAINT [FK_Location_LocationVisitor] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO

ALTER TABLE [dbo].[LocationVisitor] CHECK CONSTRAINT [FK_Location_LocationVisitor]
GO

ALTER TABLE [dbo].[LocationVisitor]  WITH CHECK ADD  CONSTRAINT [FK_LocationVisitor_Review] FOREIGN KEY([ReviewID])
REFERENCES [dbo].[Review] ([ReviewID])
GO

ALTER TABLE [dbo].[LocationVisitor] CHECK CONSTRAINT [FK_LocationVisitor_Review]
GO

ALTER TABLE [dbo].[LocationVisitor]  WITH CHECK ADD  CONSTRAINT [FK_User_LocationVisitor] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[LocationVisitor] CHECK CONSTRAINT [FK_User_LocationVisitor]
GO

