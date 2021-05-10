use Membership
create table Library (LibraryId int primary key identity not null,
					  Department nvarchar(50) not null)
						
create table Student (StudentId int primary key identity not null,
						Name nvarchar(50) not null,
						LibraryId int not null Foreign key references Library(LibraryId))

						insert into Library (Department) values('Comic'),('Melody')
						insert into Student (Name,LibraryId) values('Test',10)
select * from Library
select * from Student

delete from Library where LibraryId=1

alter table Student
alter column LibraryId int not null