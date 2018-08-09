USE [GallowayTechDB]
GO

INSERT INTO Albums
VALUES ('2010 - Mascots Album', '2010 - Mascots Album', 'Buddy Tacoma',  1, getdate(), getdate()),
('2007 - Peru	1', '2007 - Peru	1', '', 1, getdate(), getdate()),
('2011 - San Francisco Fleet Week', '2011 - San Francisco Fleet Week', '', 1, getdate(), getdate()),
('2012 - Death Valley (In Progress)', '2012 - Death Valley (In Progress)', '', 1, getdate(), getdate())

SELECT * FROM Albums
