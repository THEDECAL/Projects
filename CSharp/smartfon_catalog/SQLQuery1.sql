CREATE DATABASE smartfone_catalog
USE smartfone_catalog
GO

CREATE TABLE smartfones(
	Id int primary key identity,
	Brand nvarchar(100),
    Name nvarchar(100),
    [Image] image,
    CommStd nvarchar(100),
    ScrDiag nvarchar(100),
    ScrResol nvarchar(100),
    MatrixType nvarchar(100),
    CntSIMCards nvarchar(100),
    SIMType nvarchar(100),
    RAM nvarchar(100),
    BMEM nvarchar(100),
    MemCardsType nvarchar(100),
    OS nvarchar(100),
    QualityFrontalCamera nvarchar(100),
    QualityGeneralCamera nvarchar(100),
    BatteryCapp nvarchar(100),
    Color nvarchar(100)
)
GO

SELECT * FROM smartfones;