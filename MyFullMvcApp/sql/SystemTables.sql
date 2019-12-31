IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Suppliers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Document] varchar(14) NOT NULL,
    [SupplierType] int NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Addresses] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [Street] varchar(200) NOT NULL,
    [Number] varchar(50) NOT NULL,
    [Complement] varchar(250) NULL,
    [PostalCode] varchar(8) NOT NULL,
    [District] varchar(100) NOT NULL,
    [City] varchar(100) NOT NULL,
    [State] varchar(50) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresses_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Description] varchar(1000) NOT NULL,
    [Image] varchar(100) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Addresses_SupplierId] ON [Addresses] ([SupplierId]);

GO

CREATE INDEX [IX_Products_SupplierId] ON [Products] ([SupplierId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191231021020_Initial', N'2.2.4-servicing-10062');

GO

