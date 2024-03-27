IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE TABLE [BookWriters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_BookWriters] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE TABLE [BookCovers] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [BookWriterId] int NOT NULL,
        CONSTRAINT [PK_BookCovers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BookCovers_BookWriters_BookWriterId] FOREIGN KEY ([BookWriterId]) REFERENCES [BookWriters] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE TABLE [Books] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [BookUrl] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ISBNNUMBER] nvarchar(max) NOT NULL,
        [BookCoverId] int NULL,
        [BookWriterId] int NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Books_BookCovers_BookCoverId] FOREIGN KEY ([BookCoverId]) REFERENCES [BookCovers] ([Id]),
        CONSTRAINT [FK_Books_BookWriters_BookWriterId] FOREIGN KEY ([BookWriterId]) REFERENCES [BookWriters] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE INDEX [IX_BookCovers_BookWriterId] ON [BookCovers] ([BookWriterId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE INDEX [IX_Books_BookCoverId] ON [Books] ([BookCoverId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    CREATE INDEX [IX_Books_BookWriterId] ON [Books] ([BookWriterId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240319123922_init01'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240319123922_init01', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240320062556_addTrendingBooks'
)
BEGIN
    ALTER TABLE [Books] ADD [Trending] bit NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240320062556_addTrendingBooks'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240320062556_addTrendingBooks', N'8.0.3');
END;
GO

COMMIT;
GO

