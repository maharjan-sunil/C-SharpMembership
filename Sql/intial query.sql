create database Membership
use Membership
insert into aspnet_Applications values ('WaterFront','waterfront',NEWID(),'water front')
--447A733D-6FB1-4DB4-82F7-2233E0328F38

insert into aspnet_Roles values('447A733D-6FB1-4DB4-82F7-2233E0328F38', NEWID(),'SuperAdmin','superadmin','superadmin')
insert into aspnet_Roles values('447A733D-6FB1-4DB4-82F7-2233E0328F38', NEWID(),'Admin','admin','admin')
insert into aspnet_Roles values('447A733D-6FB1-4DB4-82F7-2233E0328F38', NEWID(),'Staff','staff','staff')
--2070450E-F560-4719-A1E3-7E3628EBDE64 superAdmin
--6CAF15EA-094E-4D50-BF04-F9F7C9C4FFFB admin
--83111363-6EE8-4F46-9294-F94838246A6B staff

select * from aspnet_Users
