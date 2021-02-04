BEGIN TRANSACTION;

ALTER TABLE "GlobalConfigs" ADD "Key" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210204000020_AddKeyToGlobalConfigs', '5.0.2');

COMMIT;


