USE [master]
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'H5_PermissionsDB')
BEGIN
	CREATE DATABASE [H5_PermissionsDB]
END

GO

USE [H5_PermissionsDB]
GO
IF OBJECT_ID(N'[dbo].[PermissionTypes]', N'U') IS NULL
BEGIN
	CREATE TABLE [dbo].[PermissionTypes](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Descripcion] [varchar](200) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END
GO


IF OBJECT_ID(N'[dbo].[Permissions]', N'U') IS NULL
BEGIN
	CREATE TABLE [dbo].[Permissions](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[NombreEmpleado] [varchar](200) NULL,
		[ApellidoEmpleado] [varchar](200) NULL,
		[TipoPermiso] [int] NULL,
		[FechaPermiso] [datetime] NULL,
	 CONSTRAINT [PK_Permissions__Id] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	

	ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD FOREIGN KEY([TipoPermiso])
	REFERENCES [dbo].[PermissionTypes] ([ID])
END
GO