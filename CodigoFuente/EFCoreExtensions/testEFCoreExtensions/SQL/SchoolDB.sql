CREATE DATABASE SchoolDB;

USE SchoolDB;

CREATE TABLE Students
(
  StudentId int IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  StudentName varchar(255) NOT NULL,
  CourseId int NOT NULL,
);

CREATE TABLE Courses
(
  CourseId int IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  CourseName varchar(255) NOT NULL
);
GO

CREATE PROCEDURE spLoadStudentsWithCourse
AS

SELECT Students.StudentId, Students.StudentName,
       Courses.CourseName
FROM Students
INNER JOIN Courses ON Courses.CourseId = Students.CourseId;
GO

CREATE PROCEDURE spCountStudents
AS

SELECT COUNT(1) AS nRecs
FROM Students
GO

INSERT INTO Course (CourseName) VALUES ('Curso 1');
INSERT INTO Course (CourseName) VALUES ('Curso 2');
INSERT INTO Course (CourseName) VALUES ('Curso 3');

INSERT INTO Students (Name, CourseId) VALUES ('Estudiante 1', 1);
INSERT INTO Students (Name, CourseId) VALUES ('Estudiante 2', 1);
INSERT INTO Students (Name, CourseId) VALUES ('Estudiante 3', 1);
INSERT INTO Students (Name, CourseId) VALUES ('Estudiante 4', 1);
INSERT INTO Students (Name, CourseId) VALUES ('Estudiante 5', 2);