ALTER DATABASE [GuardsEarnings] SET EMERGENCY;
GO

ALTER DATABASE [GuardsEarnings] set single_user
GO

DBCC CHECKDB ([GuardsEarnings], REPAIR_ALLOW_DATA_LOSS) WITH ALL_ERRORMSGS;
GO 

ALTER DATABASE [GuardsEarnings] set multi_user
GO