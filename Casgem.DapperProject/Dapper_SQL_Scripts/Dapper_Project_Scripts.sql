CREATE DATABASE CasgemDBDapper;
USE CasgemDBDapper;

CREATE TABLE Headings(
	HeadingId INT PRIMARY KEY IDENTITY(1,1),
	HeadingName NVARCHAR(50),
	HeadingStatus BIT,
);

CREATE TABLE Comments(
	CommentId INT PRIMARY KEY IDENTITY(1,1),
	CommentContent NVARCHAR(250),
	CommentAuthor NVARCHAR(100),
	CommetStatus BIT,
	CommentDate DATE,
	CommentHeading INT
);