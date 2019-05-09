ALTER ROLE [db_owner] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_accessadmin] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_securityadmin] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_ddladmin] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_backupoperator] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_datareader] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_denydatareader] ADD MEMBER [NT Service\MSSQLSERVER];


GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [NT Service\MSSQLSERVER];

