USE [GallowayTechDB]
GO

INSERT INTO Albums
VALUES ('2010 - Mascots Album', '2010 - Mascots Album', 'We no longer have a cat...Our dog Tacoma passed away some years ago but Buddy has been a great dog.', 'Buddy Tacoma', 1, GETDATE(), GETDATE()),
('2007 - Peru',	'2007 - Peru', 'My wife, brother and I went to Peru and met up with my sister in law.  We visited several sites including Machu Pichu.', 'Peru Machu Pichu', 1, GETDATE(), GETDATE()),
('2011 - San Francisco Fleet Week', '2011 - San Francisco Fleet Week', 'We were able to watch the air show in San Francisco aboard the USS O''Brien.', 'Air Show', 1, GETDATE(), GETDATE()),
('2012 - Death Valley', '2012 - Death Valley', 'Another trip where my wife and I went with her sister.  Death Valley was actually pretty cool.', 'Death Valley', 1, GETDATE(), GETDATE())

SELECT * FROM Albums

