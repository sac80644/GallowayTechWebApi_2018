USE [GallowayTechDB]
GO

UPDATE Photos
SET URL = 'http://gallowaytech.com/gallowaytechAngularJs/Photos/Poster/', DateUpdated = getdate()

SELECT * FROM Photos

