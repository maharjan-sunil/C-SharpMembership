--step to create aspnet_role db
--drive:\WINDOWS\Microsoft.NET\Framework\versionNumber run aspnet_regsql.exe

IF DB_ID('Membership') IS NULL
BEGIN
	CREATE DATABASE Membership
END

USE Membership

DECLARE @applicationId NVARCHAR(50)
SET @applicationId = (SELECT ApplicationId FROM aspnet_Applications)

--automatic entry for application
--insert into aspnet_Applications values ('WaterFront','waterfront','562CFBFD-A865-431C-81B2-57BBB62485B4','water front')

INSERT INTO aspnet_Roles VALUES(@applicationId,'2070450E-F560-4719-A1E3-7E3628EBDE64','SuperAdmin','superadmin','superadmin')
INSERT INTO aspnet_Roles VALUES(@applicationId,'6CAF15EA-094E-4D50-BF04-F9F7C9C4FFFB','Admin','admin','admin')
INSERT INTO aspnet_Roles VALUES(@applicationId,'83111363-6EE8-4F46-9294-F94838246A6B','Staff','staff','staff')

