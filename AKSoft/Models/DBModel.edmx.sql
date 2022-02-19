alter table unitcode drop column code
alter table unitcode add code int


-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2022 22:26:49
-- Generated from EDMX file: D:\My-Git\AKSoft\AKSoft\Models\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TopSoft];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__BranchCod__UserI__3A6CA48E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BranchCode] DROP CONSTRAINT [FK__BranchCod__UserI__3A6CA48E];
GO
IF OBJECT_ID(N'[dbo].[FK__CustomerC__TownS__671F4F74]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerCode] DROP CONSTRAINT [FK__CustomerC__TownS__671F4F74];
GO
IF OBJECT_ID(N'[dbo].[FK__CustomerC__Websi__662B2B3B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerCode] DROP CONSTRAINT [FK__CustomerC__Websi__662B2B3B];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[FK__DealerCod__AddUs__542C7691]', 'F') IS NOT NULL
    ALTER TABLE [TopSoftModelStoreContainer].[DealerCode] DROP CONSTRAINT [FK__DealerCod__AddUs__542C7691];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[FK__DealerCod__TownS__55209ACA]', 'F') IS NOT NULL
    ALTER TABLE [TopSoftModelStoreContainer].[DealerCode] DROP CONSTRAINT [FK__DealerCod__TownS__55209ACA];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__Group__1975C517]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__Group__1975C517];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__ItemS__1C5231C2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__ItemS__1C5231C2];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__Store__1A69E950]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__Store__1A69E950];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__Suppl__1D4655FB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__Suppl__1D4655FB];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__UnitS__1B5E0D89]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__UnitS__1B5E0D89];
GO
IF OBJECT_ID(N'[dbo].[FK__HSales__Customer__23F3538A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK__HSales__Customer__23F3538A];
GO
IF OBJECT_ID(N'[dbo].[FK__SectorCod__UserI__3D491139]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SectorCode] DROP CONSTRAINT [FK__SectorCod__UserI__3D491139];
GO
IF OBJECT_ID(N'[dbo].[FK__SupplierC__TownS__6AEFE058]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SupplierCode] DROP CONSTRAINT [FK__SupplierC__TownS__6AEFE058];
GO
IF OBJECT_ID(N'[dbo].[FK__SupplierC__Websi__69FBBC1F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SupplierCode] DROP CONSTRAINT [FK__SupplierC__Websi__69FBBC1F];
GO
IF OBJECT_ID(N'[dbo].[FK__UserInfo__Branch__420DC656]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK__UserInfo__Branch__420DC656];
GO
IF OBJECT_ID(N'[dbo].[FK__UserInfo__Sector__4301EA8F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK__UserInfo__Sector__4301EA8F];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupSerial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK_GroupSerial];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCode_GroupCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCode] DROP CONSTRAINT [FK_ItemCode_GroupCode];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCode_StoreCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCode] DROP CONSTRAINT [FK_ItemCode_StoreCode];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCode_UnitCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCode] DROP CONSTRAINT [FK_ItemCode_UnitCode];
GO
IF OBJECT_ID(N'[dbo].[FK_itemSerial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK_itemSerial];
GO
IF OBJECT_ID(N'[dbo].[FK_StoreSerial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK_StoreSerial];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitSerial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK_UnitSerial];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BranchCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BranchCode];
GO
IF OBJECT_ID(N'[dbo].[CountryCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryCode];
GO
IF OBJECT_ID(N'[dbo].[CustomerCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerCode];
GO
IF OBJECT_ID(N'[dbo].[GroupCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupCode];
GO
IF OBJECT_ID(N'[dbo].[HPurchase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HPurchase];
GO
IF OBJECT_ID(N'[dbo].[HSales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HSales];
GO
IF OBJECT_ID(N'[dbo].[ItemCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemCode];
GO
IF OBJECT_ID(N'[dbo].[SectorCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SectorCode];
GO
IF OBJECT_ID(N'[dbo].[StoreCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreCode];
GO
IF OBJECT_ID(N'[dbo].[SupplierCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SupplierCode];
GO
IF OBJECT_ID(N'[dbo].[TownCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TownCode];
GO
IF OBJECT_ID(N'[dbo].[UnitCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitCode];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[DealerCode]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[DealerCode];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GroupCode'
CREATE TABLE [dbo].[GroupCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [Code] int  NULL,
    [ArabicName] nvarchar(150)  NULL,
    [EnglishName] nvarchar(150)  NULL,
    [DescName] nvarchar(150)  NULL,
    [Description] nvarchar(150)  NULL,
    [ColorName] nvarchar(50)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'ItemCode'
CREATE TABLE [dbo].[ItemCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [Code] int  NULL,
    [ArabicName] nvarchar(150)  NULL,
    [EnglishName] nvarchar(150)  NULL,
    [DescName] nvarchar(150)  NULL,
    [Description] nvarchar(150)  NULL,
    [SerialGroup] int  NULL,
    [Unit1] int  NULL,
    [Unit2] int  NULL,
    [Unit3] int  NULL,
    [PricePurchase1Unit1] float  NULL,
    [PricePurchase1Unit2] float  NULL,
    [PriceSale1Unit1] float  NULL,
    [PriceSale1Unit2] float  NULL,
    [StoreID] int  NULL,
    [Counts] float  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'StoreCode'
CREATE TABLE [dbo].[StoreCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [Code] int  NULL,
    [ArabicName] nvarchar(150)  NULL,
    [EnglishName] nvarchar(150)  NULL,
    [DescName] nvarchar(150)  NULL,
    [Address] nvarchar(150)  NULL,
    [Description] nvarchar(150)  NULL,
    [NumberOfLeans] int  NULL,
    [Phone1] nvarchar(20)  NULL,
    [StoreKeeper] nvarchar(150)  NULL,
    [Phone2] nvarchar(20)  NULL,
    [Phone3] nvarchar(20)  NULL,
    [Phone4] nvarchar(20)  NULL,
    [AreaStock] nvarchar(20)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'UnitCode'
CREATE TABLE [dbo].[UnitCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [Code] int  NULL,
    [ArabicName] nvarchar(150)  NULL,
    [EnglishName] nvarchar(150)  NULL,
    [DescName] nvarchar(150)  NULL,
    [Description] nvarchar(150)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(100)  NULL,
    [MiddleName] nvarchar(100)  NULL,
    [LastName] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NULL,
    [Password] nvarchar(100)  NULL,
    [RePassword] nvarchar(100)  NULL,
    [Role] int  NULL,
    [AddUserDate] datetime  NULL,
    [BranchSerial] int  NULL,
    [SectorSerial] int  NULL
);
GO

-- Creating table 'CountryCode'
CREATE TABLE [dbo].[CountryCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Notes] nvarchar(150)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'CustomerCode'
CREATE TABLE [dbo].[CustomerCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Description] nvarchar(150)  NULL,
    [Address1] nvarchar(150)  NULL,
    [Address2] nvarchar(150)  NULL,
    [Telephone1] nvarchar(50)  NULL,
    [Telephone2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [CountrySerial] int  NULL,
    [TownSerial] int  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'SupplierCode'
CREATE TABLE [dbo].[SupplierCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Description] nvarchar(150)  NULL,
    [Address1] nvarchar(150)  NULL,
    [Address2] nvarchar(150)  NULL,
    [Telephone1] nvarchar(50)  NULL,
    [Telephone2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [CountrySerial] int  NULL,
    [TownSerial] int  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'TownCode'
CREATE TABLE [dbo].[TownCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Notes] nvarchar(150)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'HPurchase'
CREATE TABLE [dbo].[HPurchase] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [BranchCode] int  NULL,
    [Code] int  NULL,
    [Date] datetime  NULL,
    [CurrencyCode] int  NULL,
    [Factor] float  NULL,
    [StoreSerial] int  NULL,
    [DealerCode] int  NULL,
    [RegionCode] int  NULL,
    [ItemSerial] int  NULL,
    [UnitSerial] int  NULL,
    [Quantity] float  NULL,
    [Price] float  NULL,
    [Discount] float  NULL,
    [Tax] float  NULL,
    [Total] float  NULL,
    [TotalAfterDisc] float  NULL,
    [DiscValue] float  NULL,
    [GroupSerial] int  NULL,
    [SupplierSerial] int  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'HSales'
CREATE TABLE [dbo].[HSales] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [BranchCode] int  NULL,
    [Code] int  NULL,
    [Date] datetime  NULL,
    [CurrencyCode] int  NULL,
    [Factor] float  NULL,
    [StoreSerial] int  NULL,
    [DealerCode] int  NULL,
    [RegionCode] int  NULL,
    [FirstPayment] float  NULL,
    [Paid] float  NULL,
    [ItemSerial] int  NULL,
    [UnitSerial] int  NULL,
    [Quantity] float  NULL,
    [Price] float  NULL,
    [Discount] float  NULL,
    [Tax] float  NULL,
    [Total] float  NULL,
    [TotalAfterDisc] float  NULL,
    [DiscValue] float  NULL,
    [GroupSerial] int  NULL,
    [CustomerSerial] int  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'BranchCode'
CREATE TABLE [dbo].[BranchCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Notes] nvarchar(150)  NULL,
    [UserId] int  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'SectorCode'
CREATE TABLE [dbo].[SectorCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Notes] nvarchar(150)  NULL,
    [UserId] int  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- Creating table 'DealerCode'
CREATE TABLE [dbo].[DealerCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [Code] int  NULL,
    [Id] int  NULL,
    [ArabicName] nvarchar(100)  NULL,
    [EnglishName] nvarchar(100)  NULL,
    [DescName] nvarchar(100)  NULL,
    [Description] nvarchar(150)  NULL,
    [Address1] nvarchar(150)  NULL,
    [Address2] nvarchar(150)  NULL,
    [Telephone1] nvarchar(50)  NULL,
    [Telephone2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [CountrySerial] int  NULL,
    [TownSerial] int  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [AddUserDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Serial] in table 'GroupCode'
ALTER TABLE [dbo].[GroupCode]
ADD CONSTRAINT [PK_GroupCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'ItemCode'
ALTER TABLE [dbo].[ItemCode]
ADD CONSTRAINT [PK_ItemCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'StoreCode'
ALTER TABLE [dbo].[StoreCode]
ADD CONSTRAINT [PK_StoreCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'UnitCode'
ALTER TABLE [dbo].[UnitCode]
ADD CONSTRAINT [PK_UnitCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Serial] in table 'CountryCode'
ALTER TABLE [dbo].[CountryCode]
ADD CONSTRAINT [PK_CountryCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'CustomerCode'
ALTER TABLE [dbo].[CustomerCode]
ADD CONSTRAINT [PK_CustomerCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'SupplierCode'
ALTER TABLE [dbo].[SupplierCode]
ADD CONSTRAINT [PK_SupplierCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'TownCode'
ALTER TABLE [dbo].[TownCode]
ADD CONSTRAINT [PK_TownCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [PK_HPurchase]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [PK_HSales]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'BranchCode'
ALTER TABLE [dbo].[BranchCode]
ADD CONSTRAINT [PK_BranchCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'SectorCode'
ALTER TABLE [dbo].[SectorCode]
ADD CONSTRAINT [PK_SectorCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [Serial] in table 'DealerCode'
ALTER TABLE [dbo].[DealerCode]
ADD CONSTRAINT [PK_DealerCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SerialGroup] in table 'ItemCode'
ALTER TABLE [dbo].[ItemCode]
ADD CONSTRAINT [FK_ItemCode_GroupCode]
    FOREIGN KEY ([SerialGroup])
    REFERENCES [dbo].[GroupCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCode_GroupCode'
CREATE INDEX [IX_FK_ItemCode_GroupCode]
ON [dbo].[ItemCode]
    ([SerialGroup]);
GO

-- Creating foreign key on [StoreID] in table 'ItemCode'
ALTER TABLE [dbo].[ItemCode]
ADD CONSTRAINT [FK_ItemCode_StoreCode]
    FOREIGN KEY ([StoreID])
    REFERENCES [dbo].[StoreCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCode_StoreCode'
CREATE INDEX [IX_FK_ItemCode_StoreCode]
ON [dbo].[ItemCode]
    ([StoreID]);
GO

-- Creating foreign key on [Unit1] in table 'ItemCode'
ALTER TABLE [dbo].[ItemCode]
ADD CONSTRAINT [FK_ItemCode_UnitCode]
    FOREIGN KEY ([Unit1])
    REFERENCES [dbo].[UnitCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCode_UnitCode'
CREATE INDEX [IX_FK_ItemCode_UnitCode]
ON [dbo].[ItemCode]
    ([Unit1]);
GO

-- Creating foreign key on [CountrySerial] in table 'CustomerCode'
ALTER TABLE [dbo].[CustomerCode]
ADD CONSTRAINT [FK__CustomerC__Websi__662B2B3B]
    FOREIGN KEY ([CountrySerial])
    REFERENCES [dbo].[CountryCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CustomerC__Websi__662B2B3B'
CREATE INDEX [IX_FK__CustomerC__Websi__662B2B3B]
ON [dbo].[CustomerCode]
    ([CountrySerial]);
GO

-- Creating foreign key on [CountrySerial] in table 'SupplierCode'
ALTER TABLE [dbo].[SupplierCode]
ADD CONSTRAINT [FK__SupplierC__Websi__69FBBC1F]
    FOREIGN KEY ([CountrySerial])
    REFERENCES [dbo].[CountryCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SupplierC__Websi__69FBBC1F'
CREATE INDEX [IX_FK__SupplierC__Websi__69FBBC1F]
ON [dbo].[SupplierCode]
    ([CountrySerial]);
GO

-- Creating foreign key on [TownSerial] in table 'CustomerCode'
ALTER TABLE [dbo].[CustomerCode]
ADD CONSTRAINT [FK__CustomerC__TownS__671F4F74]
    FOREIGN KEY ([TownSerial])
    REFERENCES [dbo].[TownCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CustomerC__TownS__671F4F74'
CREATE INDEX [IX_FK__CustomerC__TownS__671F4F74]
ON [dbo].[CustomerCode]
    ([TownSerial]);
GO

-- Creating foreign key on [TownSerial] in table 'SupplierCode'
ALTER TABLE [dbo].[SupplierCode]
ADD CONSTRAINT [FK__SupplierC__TownS__6AEFE058]
    FOREIGN KEY ([TownSerial])
    REFERENCES [dbo].[TownCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SupplierC__TownS__6AEFE058'
CREATE INDEX [IX_FK__SupplierC__TownS__6AEFE058]
ON [dbo].[SupplierCode]
    ([TownSerial]);
GO

-- Creating foreign key on [GroupSerial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__Group__1975C517]
    FOREIGN KEY ([GroupSerial])
    REFERENCES [dbo].[GroupCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__Group__1975C517'
CREATE INDEX [IX_FK__HPurchase__Group__1975C517]
ON [dbo].[HPurchase]
    ([GroupSerial]);
GO

-- Creating foreign key on [ItemSerial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__ItemS__1C5231C2]
    FOREIGN KEY ([ItemSerial])
    REFERENCES [dbo].[ItemCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__ItemS__1C5231C2'
CREATE INDEX [IX_FK__HPurchase__ItemS__1C5231C2]
ON [dbo].[HPurchase]
    ([ItemSerial]);
GO

-- Creating foreign key on [StoreSerial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__Store__1A69E950]
    FOREIGN KEY ([StoreSerial])
    REFERENCES [dbo].[StoreCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__Store__1A69E950'
CREATE INDEX [IX_FK__HPurchase__Store__1A69E950]
ON [dbo].[HPurchase]
    ([StoreSerial]);
GO

-- Creating foreign key on [SupplierSerial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__Suppl__1D4655FB]
    FOREIGN KEY ([SupplierSerial])
    REFERENCES [dbo].[SupplierCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__Suppl__1D4655FB'
CREATE INDEX [IX_FK__HPurchase__Suppl__1D4655FB]
ON [dbo].[HPurchase]
    ([SupplierSerial]);
GO

-- Creating foreign key on [UnitSerial] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__UnitS__1B5E0D89]
    FOREIGN KEY ([UnitSerial])
    REFERENCES [dbo].[UnitCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__UnitS__1B5E0D89'
CREATE INDEX [IX_FK__HPurchase__UnitS__1B5E0D89]
ON [dbo].[HPurchase]
    ([UnitSerial]);
GO

-- Creating foreign key on [CustomerSerial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK__HSales__Customer__23F3538A]
    FOREIGN KEY ([CustomerSerial])
    REFERENCES [dbo].[CustomerCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HSales__Customer__23F3538A'
CREATE INDEX [IX_FK__HSales__Customer__23F3538A]
ON [dbo].[HSales]
    ([CustomerSerial]);
GO

-- Creating foreign key on [GroupSerial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK_GroupSerial]
    FOREIGN KEY ([GroupSerial])
    REFERENCES [dbo].[GroupCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupSerial'
CREATE INDEX [IX_FK_GroupSerial]
ON [dbo].[HSales]
    ([GroupSerial]);
GO

-- Creating foreign key on [ItemSerial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK_itemSerial]
    FOREIGN KEY ([ItemSerial])
    REFERENCES [dbo].[ItemCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_itemSerial'
CREATE INDEX [IX_FK_itemSerial]
ON [dbo].[HSales]
    ([ItemSerial]);
GO

-- Creating foreign key on [StoreSerial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK_StoreSerial]
    FOREIGN KEY ([StoreSerial])
    REFERENCES [dbo].[StoreCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StoreSerial'
CREATE INDEX [IX_FK_StoreSerial]
ON [dbo].[HSales]
    ([StoreSerial]);
GO

-- Creating foreign key on [UnitSerial] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK_UnitSerial]
    FOREIGN KEY ([UnitSerial])
    REFERENCES [dbo].[UnitCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitSerial'
CREATE INDEX [IX_FK_UnitSerial]
ON [dbo].[HSales]
    ([UnitSerial]);
GO

-- Creating foreign key on [UserId] in table 'BranchCode'
ALTER TABLE [dbo].[BranchCode]
ADD CONSTRAINT [FK__BranchCod__UserI__3A6CA48E]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__BranchCod__UserI__3A6CA48E'
CREATE INDEX [IX_FK__BranchCod__UserI__3A6CA48E]
ON [dbo].[BranchCode]
    ([UserId]);
GO

-- Creating foreign key on [BranchSerial] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK__UserInfo__Branch__420DC656]
    FOREIGN KEY ([BranchSerial])
    REFERENCES [dbo].[BranchCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserInfo__Branch__420DC656'
CREATE INDEX [IX_FK__UserInfo__Branch__420DC656]
ON [dbo].[UserInfo]
    ([BranchSerial]);
GO

-- Creating foreign key on [UserId] in table 'SectorCode'
ALTER TABLE [dbo].[SectorCode]
ADD CONSTRAINT [FK__SectorCod__UserI__3D491139]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SectorCod__UserI__3D491139'
CREATE INDEX [IX_FK__SectorCod__UserI__3D491139]
ON [dbo].[SectorCode]
    ([UserId]);
GO

-- Creating foreign key on [SectorSerial] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK__UserInfo__Sector__4301EA8F]
    FOREIGN KEY ([SectorSerial])
    REFERENCES [dbo].[SectorCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserInfo__Sector__4301EA8F'
CREATE INDEX [IX_FK__UserInfo__Sector__4301EA8F]
ON [dbo].[UserInfo]
    ([SectorSerial]);
GO

-- Creating foreign key on [CountrySerial] in table 'DealerCode'
ALTER TABLE [dbo].[DealerCode]
ADD CONSTRAINT [FK__DealerCod__Websi__1EC48A19]
    FOREIGN KEY ([CountrySerial])
    REFERENCES [dbo].[CountryCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DealerCod__Websi__1EC48A19'
CREATE INDEX [IX_FK__DealerCod__Websi__1EC48A19]
ON [dbo].[DealerCode]
    ([CountrySerial]);
GO

-- Creating foreign key on [TownSerial] in table 'DealerCode'
ALTER TABLE [dbo].[DealerCode]
ADD CONSTRAINT [FK__DealerCod__TownS__1FB8AE52]
    FOREIGN KEY ([TownSerial])
    REFERENCES [dbo].[TownCode]
        ([Serial])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DealerCod__TownS__1FB8AE52'
CREATE INDEX [IX_FK__DealerCod__TownS__1FB8AE52]
ON [dbo].[DealerCode]
    ([TownSerial]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------