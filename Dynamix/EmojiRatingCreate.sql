/****** Object:  Table [dbo].[EmojiRating]    Script Date: 4/20/2020 8:34:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmojiRating](
	[EmojiRatingID] [int] IDENTITY(1,1) NOT NULL,
	[EmojiPicture] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_EmojiRating] PRIMARY KEY CLUSTERED 
(
	[EmojiRatingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

