select * from location

select * from EmojiRating

select * from Review

select * from users

insert into Review
(Title,ReviewText,ReviewImageURL,RatingEmojiID,LocationID,CreatorUserID)
Values
('Trip to the Vatican with my frienemies',
'It was great going to visit such a historic city, but I will not visit again. It was so uncrowded
that it was easy to get anywhere. There were no long lines so I realized the vatican is really small
Ehhhh. Pass',
'https://romesoyouseeit.files.wordpress.com/2013/04/thevaticanmuseumsinterior_fb.jpg',
2,
1,
1)