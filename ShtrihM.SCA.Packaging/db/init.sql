DROP TABLE Users
go
CREATE TABLE Users
    (
      UserId BIGINT PRIMARY KEY
                    IDENTITY
    , FullName NVARCHAR(500) NOT NULL
    , RoleId BIGINT NOT NULL
    , PASSWORD NVARCHAR(10) NOT NULL
    )

go

INSERT  INTO [dbo].[Users]
        ( [FullName], [RoleId], [PASSWORD] )
VALUES  ( 'вася пупкин', -- FullName - nvarchar(500)
          3, -- RoleId - bigint
          '1'  -- PASSWORD - nvarchar(10)
          )
          ,
        ( 'тема', 3, '2' )
          ,
        ( 'admin', 1, '3' )
          ,
        ( 'Master', 2, '4' )
go

SELECT  *
FROM    [dbo].[Users]          

go

DROP PROCEDURE SotrAuth

go

CREATE PROCEDURE SotrAuth
    (
      @UserID BIGINT
    , @Password VARCHAR(10)
    )
AS 
    BEGIN

        SELECT  ISNULL(( SELECT TOP ( 1 )
                                [RoleId]
                         FROM   Users
                         WHERE  @UserId = [UserId]
                                AND [PASSWORD] = @Password
                       ), 0)

    END

GO

EXEC [dbo].[SotrAuth] @UserID = 1, -- bigint
    @Password = '1'
 -- varchar(10)

GO


DROP PROC getFIO
go

CREATE PROCEDURE getFIO
AS 
    BEGIN
        SELECT  [UserId] AS ID
              , [FullName] AS FIO
        FROM    [dbo].[Users]
    END

GO

EXEC getFIO	

GO

DROP PROC [dbo].SotrOut

go


CREATE PROCEDURE SotrOut
    (
      @UserID BIGINT
    )
AS 
    BEGIN
        --tofo
		select 1
    END
    
GO

DROP PROC SetAction

go

CREATE PROC SetAction(@ActionID BIGINT, @UserID BIGINT )
AS
BEGIN
	SELECT 1	
END

go

DROP TABLE Prods

go

CREATE TABLE Prods
    (
      SSCCNumber CHAR(20) NOT NULL
                          PRIMARY KEY
    , PalletID BIGINT
    , OrderNumber CHAR(15)
    , SpecNumber CHAR(10)
    , CustName VARCHAR(100)
    , ProdName VARCHAR(100)
    , Qty INT
    )
    
go

SELECT * FROM Prods

go

INSERT INTO [dbo].[Prods]
        ( [SSCCNumber]
        , [PalletID]
        , [OrderNumber]
        , [SpecNumber]
        , [CustName]
        , [ProdName]
        , [Qty]
        )
VALUES  ( '1'
        , -- SSCCNumber - char(20)
          1
        , -- PalletID - bigint
          '1'
        , -- OrderNumber - char(15)
          '1'
        , -- SpecNumber - char(10)
          '1'
        , -- CustName - varchar(100)
          '1'
        , -- ProdName - varchar(100)
          1 -- Qty - int
        ),
        ( '2'
        , -- SSCCNumber - char(20)
          2
        , -- PalletID - bigint
          '2'
        , -- OrderNumber - char(15)
          '2'
        , -- SpecNumber - char(10)
          '2'
        , -- CustName - varchar(100)
          '2'
        , -- ProdName - varchar(100)
          2 -- Qty - int
        )
              
GO

DROP TABLE Bins

go

CREATE TABLE Bins (
	PalletID BIGINT NOT NULL PRIMARY KEY
	, BinName nvarchar(10) NULL
	, PalletNumber INT
    , NOPallets INT
    , [Status] VARCHAR(20)
)

go

DELETE FROM [dbo].[Bins]

go

INSERT INTO [dbo].[Bins]
        ( [PalletID]
        , [BinName]
        , [PalletNumber]
        , [NOPallets]
        , [Status]
        )
VALUES  ( 1
        , -- PalletID - bigint
          '1'
        , -- BinName - nvarchar(10)
          1
        , -- PalletNumber - int
          5
        , -- NOPallets - int
          'Произведена'  -- Status - varchar(20)
        ),
        ( 2
        , -- PalletID - bigint
          NULL
        , -- BinName - nvarchar(10)
          2
        , -- PalletNumber - int
          7
        , -- NOPallets - int
          'Оприходована'  -- Status - varchar(20)
        )



go


DROP PROC GetFromProd 
go

CREATE PROC GetFromProd ( @SSCCNumber CHAR(20) )
AS 
    BEGIN
        SELECT  p.PalletID
              , OrderNumber
              , SpecNumber
              , CustName
              , ProdName
              , Qty
              , b.PalletNumber
              , b.NOPallets
              , b.[Status]
              , b.BinName
        FROM    Prods AS p
        LEFT JOIN Bins AS b ON b.PalletID = p.[PalletID]
        WHERE   [SSCCNumber] = @SSCCNumber
 
    END

go

EXEC  [dbo].[GetFromProd] @SSCCNumber = '1' -- char(20)


go

DROP PROC PutToStockBin

go


CREATE PROC PutToStockBin(@PalletID bigint, @BinName nvarchar(10), @UserID bigint )
AS
BEGIN
	SELECT 1;
END

go 

DROP PROC GetForMove

go

CREATE PROC GetForMove
    (
      @SSCCNumber CHAR(20)
    , @UserID BIGINT
    )
AS 
    BEGIN
        SELECT  p.PalletID
              , OrderNumber
              , SpecNumber
              , CustName
              , ProdName
              , Qty
              , b.PalletNumber
              , b.NOPallets
              , 92 AS Stock
        FROM    Prods AS p
        LEFT JOIN Bins AS b ON b.PalletID = p.[PalletID]
        WHERE   [SSCCNumber] = @SSCCNumber
	
    END


go

DROP PROC MoveBin

go


CREATE PROC MoveBin
    (
      @BinID BIGINT
    , @UserID BIGINT
    )
AS 
    BEGIN
        SELECT  0
    END 
    
GO

DROP PROC LoadPickingList

go

CREATE PROC LoadPickingList
    (
      @PickingListID BIGINT
    , @ActionID BIGINT
    , @UserID BIGINT
    )
AS 
    BEGIN
        SELECT  CAST (1 AS BIGINT) AS TaskListID
              , CAST('1' AS CHAR(20)) AS SSCCNumber
              , CAST('1' AS CHAR(5)) AS BinName
              , 1 AS [status]
		union
		SELECT CAST (1 AS BIGINT) AS TaskListID
              , CAST('2' AS CHAR(20)) AS SSCCNumber
              , CAST('2' AS CHAR(5)) AS BinName
              , 1 AS [status]
        UNION 
        SELECT CAST (1 AS BIGINT) AS TaskListID
              , CAST('3' AS CHAR(20)) AS SSCCNumber
              , CAST('3' AS CHAR(5)) AS BinName
              , 1 AS [status]
       UNION 
        SELECT CAST (1 AS BIGINT) AS TaskListID
              , CAST('4' AS CHAR(20)) AS SSCCNumber
              , CAST('4' AS CHAR(5)) AS BinName
              , 1 AS [status]
    END 
    
    
GO

DROP PROC CheckPallet

go

CREATE PROC CheckPallet(@TaskListID bigint , @SSCCNumber char(20), @UserID BIGINT)
AS BEGIN
   	SELECT 3
   END
   
GO

DROP PROC EndOfPickingList

GO

CREATE PROC EndOfPickingList(@PickingListID bigint, @Status int, @UserID bigint)
AS BEGIN
   	PRINT 'EndOfPickingList'
END		