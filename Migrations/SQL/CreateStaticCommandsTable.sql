BEGIN TRANSACTION;

CREATE TABLE "StaticCommands" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StaticCommands" PRIMARY KEY AUTOINCREMENT,
    "Keyword" TEXT NULL,
    "Text" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210215235415_CreateStaticCommandsTable', '5.0.2');

COMMIT;


