CREATE DATABASE smartfone_catalog
GO

USE smartfone_catalog
GO

CREATE TABLE smartfones(
	Id int primary key identity,
	Brand nvarchar(MAX),
    Name nvarchar(MAX),
    [Image] varbinary(MAX),
    CommStd nvarchar(MAX),
    ScrDiag nvarchar(MAX),
    ScrResol nvarchar(MAX),
    MatrixType nvarchar(MAX),
    CntSIMCards nvarchar(MAX),
    SIMType nvarchar(MAX),
    RAM nvarchar(MAX),
    BMEM nvarchar(MAX),
    MemCardsType nvarchar(MAX),
    OS nvarchar(MAX),
    QualityFrontalCamera nvarchar(MAX),
    QualityGeneralCamera nvarchar(MAX),
    BatteryCapp nvarchar(MAX),
    Color nvarchar(100)
)
GO

TRUNCATE TABLE smartfones
GO

SELECT * FROM smartfones ORDER BY Brand,Name
SELECT * FROM smartfones where Name='P smart+ Black' and Brand='Huawei'
select count(*) from smartfones
GO