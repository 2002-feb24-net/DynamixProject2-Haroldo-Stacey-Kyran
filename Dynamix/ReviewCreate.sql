/****** Object:  Table [dbo].[Review]    Script Date: 4/20/2020 8:32:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ReviewText] [nvarchar](max) NULL,
	[ReviewImageURL] [nvarchar](max) NULL,
	[RatingEmojiID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[CreatorUserID] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_EmojiRating_Review] FOREIGN KEY([RatingEmojiID])
REFERENCES [dbo].[EmojiRating] ([EmojiRatingID])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_EmojiRating_Review]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Location_Review] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Location_Review]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_User_Review] FOREIGN KEY([CreatorUserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_User_Review]
GO

