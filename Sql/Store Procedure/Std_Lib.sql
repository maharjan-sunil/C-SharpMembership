USE Membership;  
GO  
CREATE PROCEDURE Std_Lib
    @StudentName nvarchar(50),   
    @Department nvarchar(50)   
AS   
    SELECT Student.StudentId,Student.Name,Library.Department  
    FROM Student INNER JOIN Library
	ON Student.LibraryId  = Library.LibraryId
    WHERE Student.Name = @StudentName AND Library.Department = @Department;
GO  
