CREATE TABLE Projects (
    ProjectId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    CustomerName NVARCHAR(255) NOT NULL,
    ProjectManager NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Service NVARCHAR(255) NOT NULL,
    TotalCost INT NOT NULL
);