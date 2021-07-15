USE Membership
IF COL_LENGTH('Member','FileName') IS NULL
BEGIN 
	ALTER TABLE Member
	ADD FileName nvarchar(50) null
END
