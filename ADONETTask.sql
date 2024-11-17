CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(25) NOT NULL,
Surname VARCHAR(25),
Age INT CHECK(Age BETWEEN 0 AND 100) NOT NULL
)
INSERT INTO Students(Name,Surname,Age)
VALUES('Tom','Hardy',27),('Jim','Hopper',25),('Jennifer','Anniston',22)