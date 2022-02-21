
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/21/2022 16:01:17
-- Generated from EDMX file: F:\Folder\AKSoft\AKSoft\Models\DBModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK__DealerCod__TownS__1FB8AE52]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DealerCode] DROP CONSTRAINT [FK__DealerCod__TownS__1FB8AE52];
GO
IF OBJECT_ID(N'[dbo].[FK__DealerCod__Websi__1EC48A19]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DealerCode] DROP CONSTRAINT [FK__DealerCod__Websi__1EC48A19];
GO
IF OBJECT_ID(N'[dbo].[FK__HPurchase__Deale__59B045BD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HPurchase] DROP CONSTRAINT [FK__HPurchase__Deale__59B045BD];
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
IF OBJECT_ID(N'[dbo].[FK__HSales__DealerCo__5AA469F6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK__HSales__DealerCo__5AA469F6];
GO
IF OBJECT_ID(N'[dbo].[FK__HSales__DealerCo__5DB5E0CB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HSales] DROP CONSTRAINT [FK__HSales__DealerCo__5DB5E0CB];
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
IF OBJECT_ID(N'[dbo].[FK__UserInfo__Role__5EAA0504]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK__UserInfo__Role__5EAA0504];
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
IF OBJECT_ID(N'[dbo].[DealerCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DealerCode];
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
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[ItemCard]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[ItemCard];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptCustomers]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptCustomers];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptDealers]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptDealers];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptPurchase]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptPurchase];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptSales]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptSales];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptSuppliers]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptSuppliers];
GO
IF OBJECT_ID(N'[TopSoftModelStoreContainer].[RptUsers]', 'U') IS NOT NULL
    DROP TABLE [TopSoftModelStoreContainer].[RptUsers];
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

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL
);
GO

-- Creating table 'UnitCode'
CREATE TABLE [dbo].[UnitCode] (
    [Serial] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [ArabicName] nvarchar(150)  NULL,
    [EnglishName] nvarchar(150)  NULL,
    [DescName] nvarchar(150)  NULL,
    [Description] nvarchar(150)  NULL,
    [AddUserDate] datetime  NULL,
    [Code] int  NULL
);
GO

-- Creating table 'ItemCard'
CREATE TABLE [dbo].[ItemCard] (
    [ItemCode] int  NOT NULL,
    [ItemCode2] int  NULL,
    [ItemName] nvarchar(150)  NULL,
    [ItemEName] nvarchar(150)  NULL,
    [ItemDescName] nvarchar(150)  NULL,
    [ItemDescription] nvarchar(150)  NULL,
    [ItemPurchase1Unit1] float  NULL,
    [ItemPurchase1Unit2] float  NULL,
    [ItemSales1Unit1] float  NULL,
    [ItemSales1Unit2] float  NULL,
    [Unit1] int  NULL,
    [Unit2] int  NULL,
    [Unit3] int  NULL,
    [GroupCode] int  NULL,
    [GroupCode2] int  NULL,
    [GroupName] nvarchar(150)  NULL,
    [GroupEName] nvarchar(150)  NULL,
    [GroupDescName] nvarchar(150)  NULL,
    [GroupDescription] nvarchar(150)  NULL,
    [GroupColorName] nvarchar(50)  NULL,
    [UnitCode] int  NULL,
    [UnitCode2] int  NULL,
    [UnitName] nvarchar(150)  NULL,
    [UnitEName] nvarchar(150)  NULL,
    [UnitDescName] nvarchar(150)  NULL,
    [UnitDescription] nvarchar(150)  NULL,
    [StoreCode] int  NULL,
    [StoreCode2] int  NULL,
    [StoreName] nvarchar(150)  NULL,
    [StoreEName] nvarchar(150)  NULL,
    [StoreDescName] nvarchar(150)  NULL,
    [StoreDescription] nvarchar(150)  NULL,
    [StoreNumLeans] int  NULL,
    [StoreAddress] nvarchar(150)  NULL,
    [StoreArea] nvarchar(20)  NULL,
    [StorePhone1] nvarchar(20)  NULL,
    [StorePhone2] nvarchar(20)  NULL,
    [StorePhone3] nvarchar(20)  NULL,
    [StorePhone4] nvarchar(20)  NULL,
    [StoreKeeper] nvarchar(150)  NULL,
    [HpurchaseCode] int  NULL,
    [HpurchaseCode2] int  NULL,
    [HpurchaseCurrency] int  NULL,
    [HpurchaseDate] datetime  NULL,
    [HpurchaseDealerCode] int  NULL,
    [HpurchaseDiscount] float  NULL,
    [HpurchaseDiscValue] float  NULL,
    [HpurchaseFactor] float  NULL,
    [HpurchasePrice] float  NULL,
    [HpurchaseQuantity] float  NULL,
    [HpurchaseTax] float  NULL,
    [HpurchaseTotal] float  NULL,
    [HpurchaseTotalAfter] float  NULL,
    [HSalesCode] int  NULL,
    [HSalesCode2] int  NULL,
    [HSalesCurrency] int  NULL,
    [HSalesDate] datetime  NULL,
    [HSalesDealerCode] int  NULL,
    [HSalesDiscount] float  NULL,
    [HSalesDiscValue] float  NULL,
    [HSalesFactor] float  NULL,
    [HSalesPrice] float  NULL,
    [HSalesQuantity] float  NULL,
    [HSalesTax] float  NULL,
    [HSalesTotal] float  NULL,
    [HSalesTotalAfter] float  NULL
);
GO

-- Creating table 'RptCustomers'
CREATE TABLE [dbo].[RptCustomers] (
    [CustomerCode] int  NOT NULL,
    [CustomerCode2] int  NULL,
    [CustomerName] nvarchar(100)  NULL,
    [CustomerEname] nvarchar(100)  NULL,
    [CustomerAddress1] nvarchar(150)  NULL,
    [CustomerAddress2] nvarchar(150)  NULL,
    [CustomerTel1] nvarchar(50)  NULL,
    [CustomerTel2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [Description] nvarchar(150)  NULL,
    [CountryCode] int  NULL,
    [CountryCode2] int  NULL,
    [CountryName] nvarchar(100)  NULL,
    [CountryEName] nvarchar(100)  NULL,
    [CountryDescName] nvarchar(100)  NULL,
    [CountryNotes] nvarchar(150)  NULL,
    [TownCode] int  NULL,
    [TownCode2] int  NULL,
    [TownName] nvarchar(100)  NULL,
    [TownEname] nvarchar(100)  NULL,
    [TownDescname] nvarchar(100)  NULL,
    [Townnotes] nvarchar(150)  NULL
);
GO

-- Creating table 'RptDealers'
CREATE TABLE [dbo].[RptDealers] (
    [DealerCode] int  NOT NULL,
    [DealerCode2] int  NULL,
    [DealerName] nvarchar(100)  NULL,
    [DealerEname] nvarchar(100)  NULL,
    [DealerAddress1] nvarchar(150)  NULL,
    [DealerAddress2] nvarchar(150)  NULL,
    [DealerTel1] nvarchar(50)  NULL,
    [DealerTel2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [Description] nvarchar(150)  NULL,
    [CountryCode] int  NULL,
    [CountryCode2] int  NULL,
    [CountryName] nvarchar(100)  NULL,
    [CountryEName] nvarchar(100)  NULL,
    [CountryDescName] nvarchar(100)  NULL,
    [CountryNotes] nvarchar(150)  NULL,
    [TownCode] int  NULL,
    [TownCode2] int  NULL,
    [TownName] nvarchar(100)  NULL,
    [TownEname] nvarchar(100)  NULL,
    [TownDescname] nvarchar(100)  NULL,
    [Townnotes] nvarchar(150)  NULL,
    [hsalesCode] int  NULL,
    [HsalesCode2] int  NULL,
    [HsalesCurrency] int  NULL,
    [HsalesDate] datetime  NULL,
    [HsalesDealerCode] int  NULL,
    [HsalesDiscount] float  NULL,
    [HsalesDiscValue] float  NULL,
    [HsalesFactor] float  NULL,
    [HsalesPrice] float  NULL,
    [HsalesQuantity] float  NULL,
    [FirstPayment] float  NULL,
    [HsalesTax] float  NULL,
    [HsalesTotal] float  NULL,
    [HsalesTotalAfter] float  NULL,
    [HpurchaseCode] int  NULL,
    [HpurchaseCode2] int  NULL,
    [HpurchaseCurrency] int  NULL,
    [HpurchaseDate] datetime  NULL,
    [HpurchaseDealerCode] int  NULL,
    [HpurchaseDiscount] float  NULL,
    [HpurchaseDiscValue] float  NULL,
    [HpurchaseFactor] float  NULL,
    [HpurchasePrice] float  NULL,
    [HpurchaseQuantity] float  NULL,
    [HpurchaseTax] float  NULL,
    [HpurchaseTotal] float  NULL,
    [HpurchaseTotalAfter] float  NULL
);
GO

-- Creating table 'RptPurchase'
CREATE TABLE [dbo].[RptPurchase] (
    [ItemCode] int  NULL,
    [ItemCode2] int  NULL,
    [ItemName] nvarchar(150)  NULL,
    [ItemEName] nvarchar(150)  NULL,
    [ItemDescName] nvarchar(150)  NULL,
    [ItemDescription] nvarchar(150)  NULL,
    [ItemPurchase1Unit1] float  NULL,
    [ItemPurchase1Unit2] float  NULL,
    [ItemSales1Unit1] float  NULL,
    [ItemSales1Unit2] float  NULL,
    [Unit1] int  NULL,
    [Unit2] int  NULL,
    [Unit3] int  NULL,
    [HpurchaseCode] int  NOT NULL,
    [HpurchaseCode2] int  NULL,
    [HpurchaseCurrency] int  NULL,
    [HpurchaseDate] datetime  NULL,
    [HpurchaseDiscount] float  NULL,
    [HpurchaseDiscValue] float  NULL,
    [HpurchaseFactor] float  NULL,
    [HpurchasePrice] float  NULL,
    [HpurchaseQuantity] float  NULL,
    [HpurchaseTax] float  NULL,
    [HpurchaseTotal] float  NULL,
    [HpurchaseTotalAfter] float  NULL,
    [GroupCode] int  NULL,
    [GroupCode2] int  NULL,
    [GroupName] nvarchar(150)  NULL,
    [GroupEName] nvarchar(150)  NULL,
    [GroupDescName] nvarchar(150)  NULL,
    [GroupDescription] nvarchar(150)  NULL,
    [GroupColorName] nvarchar(50)  NULL,
    [UnitCode] int  NULL,
    [UnitCode2] int  NULL,
    [UnitName] nvarchar(150)  NULL,
    [UnitEName] nvarchar(150)  NULL,
    [UnitDescName] nvarchar(150)  NULL,
    [UnitDescription] nvarchar(150)  NULL,
    [StoreCode] int  NULL,
    [StoreCode2] int  NULL,
    [StoreName] nvarchar(150)  NULL,
    [StoreEName] nvarchar(150)  NULL,
    [StoreDescName] nvarchar(150)  NULL,
    [StoreDescription] nvarchar(150)  NULL,
    [StoreNumLeans] int  NULL,
    [StoreAddress] nvarchar(150)  NULL,
    [StoreArea] nvarchar(20)  NULL,
    [StorePhone1] nvarchar(20)  NULL,
    [StorePhone2] nvarchar(20)  NULL,
    [StorePhone3] nvarchar(20)  NULL,
    [StorePhone4] nvarchar(20)  NULL,
    [StoreKeeper] nvarchar(150)  NULL,
    [SupplierCode] int  NULL,
    [SupplierCode2] int  NULL,
    [SupplierName] nvarchar(100)  NULL,
    [SupplierEName] nvarchar(100)  NULL,
    [SupplierDescName] nvarchar(100)  NULL,
    [SupplierAddress1] nvarchar(150)  NULL,
    [SupplierAddress2] nvarchar(150)  NULL,
    [DealerCode] int  NULL,
    [DealerCode2] int  NULL,
    [DealerName] nvarchar(100)  NULL,
    [DealerEName] nvarchar(100)  NULL,
    [DealerDescName] nvarchar(100)  NULL,
    [DealerAddress1] nvarchar(150)  NULL,
    [DealerAddress2] nvarchar(150)  NULL
);
GO

-- Creating table 'RptSales'
CREATE TABLE [dbo].[RptSales] (
    [hsalesCode] int  NOT NULL,
    [HsalesCode2] int  NULL,
    [HsalesCurrency] int  NULL,
    [HsalesDate] datetime  NULL,
    [HsalesDealerCode] int  NULL,
    [HsalesDiscount] float  NULL,
    [HsalesDiscValue] float  NULL,
    [HsalesFactor] float  NULL,
    [HsalesPrice] float  NULL,
    [HsalesQuantity] float  NULL,
    [FirstPayment] float  NULL,
    [HsalesTax] float  NULL,
    [HsalesTotal] float  NULL,
    [HsalesTotalAfter] float  NULL,
    [ItemCode] int  NULL,
    [ItemCode2] int  NULL,
    [ItemName] nvarchar(150)  NULL,
    [ItemEName] nvarchar(150)  NULL,
    [ItemDescName] nvarchar(150)  NULL,
    [ItemDescription] nvarchar(150)  NULL,
    [ItemPurchase1Unit1] float  NULL,
    [ItemPurchase1Unit2] float  NULL,
    [ItemSales1Unit1] float  NULL,
    [ItemSales1Unit2] float  NULL,
    [Unit1] int  NULL,
    [Unit2] int  NULL,
    [Unit3] int  NULL,
    [GroupCode] int  NULL,
    [GroupCode2] int  NULL,
    [GroupName] nvarchar(150)  NULL,
    [GroupEName] nvarchar(150)  NULL,
    [GroupDescName] nvarchar(150)  NULL,
    [GroupDescription] nvarchar(150)  NULL,
    [GroupColorName] nvarchar(50)  NULL,
    [UnitCode] int  NULL,
    [UnitCode2] int  NULL,
    [UnitName] nvarchar(150)  NULL,
    [UnitEName] nvarchar(150)  NULL,
    [UnitDescName] nvarchar(150)  NULL,
    [UnitDescription] nvarchar(150)  NULL,
    [StoreCode] int  NULL,
    [StoreCode2] int  NULL,
    [StoreName] nvarchar(150)  NULL,
    [StoreEName] nvarchar(150)  NULL,
    [StoreDescName] nvarchar(150)  NULL,
    [StoreDescription] nvarchar(150)  NULL,
    [StoreNumLeans] int  NULL,
    [StoreAddress] nvarchar(150)  NULL,
    [StoreArea] nvarchar(20)  NULL,
    [StorePhone1] nvarchar(20)  NULL,
    [StorePhone2] nvarchar(20)  NULL,
    [StorePhone3] nvarchar(20)  NULL,
    [StorePhone4] nvarchar(20)  NULL,
    [StoreKeeper] nvarchar(150)  NULL,
    [CustomerCode] int  NULL,
    [CustomerCode2] int  NULL,
    [CustomerName] nvarchar(100)  NULL,
    [CustomerEName] nvarchar(100)  NULL,
    [CustomerDescName] nvarchar(100)  NULL,
    [CustomerAddress1] nvarchar(150)  NULL,
    [CustomerAddress2] nvarchar(150)  NULL,
    [DealerCode] int  NULL,
    [DealerCode2] int  NULL,
    [DealerName] nvarchar(100)  NULL,
    [DealerEName] nvarchar(100)  NULL,
    [DealerDescName] nvarchar(100)  NULL,
    [DealerAddress1] nvarchar(150)  NULL,
    [DealerAddress2] nvarchar(150)  NULL
);
GO

-- Creating table 'RptSuppliers'
CREATE TABLE [dbo].[RptSuppliers] (
    [SupplierCode] int  NOT NULL,
    [SupplierCode2] int  NULL,
    [SupplierName] nvarchar(100)  NULL,
    [SupplierEname] nvarchar(100)  NULL,
    [SupplierAddress1] nvarchar(150)  NULL,
    [SupplierAddress2] nvarchar(150)  NULL,
    [SupplierTel1] nvarchar(50)  NULL,
    [SupplierTel2] nvarchar(50)  NULL,
    [Telephone3] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(30)  NULL,
    [Description] nvarchar(150)  NULL,
    [CountryCode] int  NULL,
    [CountryCode2] int  NULL,
    [CountryName] nvarchar(100)  NULL,
    [CountryEName] nvarchar(100)  NULL,
    [CountryDescName] nvarchar(100)  NULL,
    [CountryNotes] nvarchar(150)  NULL,
    [TownCode] int  NULL,
    [TownCode2] int  NULL,
    [TownName] nvarchar(100)  NULL,
    [TownEname] nvarchar(100)  NULL,
    [TownDescname] nvarchar(100)  NULL,
    [Townnotes] nvarchar(150)  NULL
);
GO

-- Creating table 'RptUsers'
CREATE TABLE [dbo].[RptUsers] (
    [UserId] int  NOT NULL,
    [FirstName] nvarchar(100)  NULL,
    [MiddleName] nvarchar(100)  NULL,
    [LastName] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NULL,
    [Password] nvarchar(100)  NULL,
    [BranchCode] int  NULL,
    [BranchName] nvarchar(100)  NULL,
    [SectorCode] int  NULL,
    [SectorName] nvarchar(100)  NULL,
    [RoleName] nvarchar(50)  NULL
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

-- Creating primary key on [RoleId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Serial] in table 'UnitCode'
ALTER TABLE [dbo].[UnitCode]
ADD CONSTRAINT [PK_UnitCode]
    PRIMARY KEY CLUSTERED ([Serial] ASC);
GO

-- Creating primary key on [ItemCode] in table 'ItemCard'
ALTER TABLE [dbo].[ItemCard]
ADD CONSTRAINT [PK_ItemCard]
    PRIMARY KEY CLUSTERED ([ItemCode] ASC);
GO

-- Creating primary key on [CustomerCode] in table 'RptCustomers'
ALTER TABLE [dbo].[RptCustomers]
ADD CONSTRAINT [PK_RptCustomers]
    PRIMARY KEY CLUSTERED ([CustomerCode] ASC);
GO

-- Creating primary key on [DealerCode] in table 'RptDealers'
ALTER TABLE [dbo].[RptDealers]
ADD CONSTRAINT [PK_RptDealers]
    PRIMARY KEY CLUSTERED ([DealerCode] ASC);
GO

-- Creating primary key on [HpurchaseCode] in table 'RptPurchase'
ALTER TABLE [dbo].[RptPurchase]
ADD CONSTRAINT [PK_RptPurchase]
    PRIMARY KEY CLUSTERED ([HpurchaseCode] ASC);
GO

-- Creating primary key on [hsalesCode] in table 'RptSales'
ALTER TABLE [dbo].[RptSales]
ADD CONSTRAINT [PK_RptSales]
    PRIMARY KEY CLUSTERED ([hsalesCode] ASC);
GO

-- Creating primary key on [SupplierCode] in table 'RptSuppliers'
ALTER TABLE [dbo].[RptSuppliers]
ADD CONSTRAINT [PK_RptSuppliers]
    PRIMARY KEY CLUSTERED ([SupplierCode] ASC);
GO

-- Creating primary key on [UserId] in table 'RptUsers'
ALTER TABLE [dbo].[RptUsers]
ADD CONSTRAINT [PK_RptUsers]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
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

-- Creating foreign key on [DealerCode] in table 'HSales'
ALTER TABLE [dbo].[HSales]
ADD CONSTRAINT [FK__HSales__DealerCo__5DB5E0CB]
    FOREIGN KEY ([DealerCode])
    REFERENCES [dbo].[DealerCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HSales__DealerCo__5DB5E0CB'
CREATE INDEX [IX_FK__HSales__DealerCo__5DB5E0CB]
ON [dbo].[HSales]
    ([DealerCode]);
GO

-- Creating foreign key on [Role] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK__UserInfo__Role__5EAA0504]
    FOREIGN KEY ([Role])
    REFERENCES [dbo].[UserRole]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserInfo__Role__5EAA0504'
CREATE INDEX [IX_FK__UserInfo__Role__5EAA0504]
ON [dbo].[UserInfo]
    ([Role]);
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

-- Creating foreign key on [DealerCode] in table 'HPurchase'
ALTER TABLE [dbo].[HPurchase]
ADD CONSTRAINT [FK__HPurchase__Deale__59B045BD]
    FOREIGN KEY ([DealerCode])
    REFERENCES [dbo].[DealerCode]
        ([Serial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HPurchase__Deale__59B045BD'
CREATE INDEX [IX_FK__HPurchase__Deale__59B045BD]
ON [dbo].[HPurchase]
    ([DealerCode]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------