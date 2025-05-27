
-- SQL schema
CREATE TABLE Persons (
    Id INTEGER PRIMARY KEY,
    Name TEXT,
    BirthDate TEXT,
    Role TEXT
);

CREATE TABLE Groups (
    Id INTEGER PRIMARY KEY,
    Name TEXT
);

CREATE TABLE Students (
    PersonId INTEGER PRIMARY KEY,
    GroupId INTEGER,
    FOREIGN KEY(PersonId) REFERENCES Persons(Id),
    FOREIGN KEY(GroupId) REFERENCES Groups(Id)
);

CREATE TABLE Teachers (
    PersonId INTEGER PRIMARY KEY,
    FOREIGN KEY(PersonId) REFERENCES Persons(Id)
);

CREATE TABLE Courses (
    Id INTEGER PRIMARY KEY,
    Name TEXT,
    TeacherId INTEGER,
    FOREIGN KEY(TeacherId) REFERENCES Teachers(PersonId)
);

CREATE TABLE ScheduleEntries (
    Id INTEGER PRIMARY KEY,
    GroupId INTEGER,
    CourseId INTEGER,
    Day TEXT,
    Time TEXT,
    FOREIGN KEY(GroupId) REFERENCES Groups(Id),
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);

CREATE TABLE Marks (
    Id INTEGER PRIMARY KEY,
    StudentId INTEGER,
    CourseId INTEGER,
    Value INTEGER,
    FOREIGN KEY(StudentId) REFERENCES Students(PersonId),
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);
