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
    Color nvarchar(MAX)
)
GO

--CREATE TRIGGER DuplicateExclusion ON smartfones for insert
--AS
--BEGIN
--	DECLARE @DUPLICATE_COUNT INT, @INSERTED_NAME NVARCHAR(MAX)

--	SELECT TOP 1 @INSERTED_NAME = inserted.Name FROM inserted
--	SET @DUPLICATE_COUNT = (SELECT COUNT(*) FROM smartfones WHERE @INSERTED_NAME = smartfones.Name)

--	if(@DUPLICATE_COUNT > 1) rollback tran
--END
--GO

TRUNCATE TABLE smartfones
GO

SELECT * FROM smartfones ORDER BY Brand,Name
SELECT * FROM smartfones where Name='P smart+ Black' and Brand='Huawei'
select count(*) from smartfones
GO