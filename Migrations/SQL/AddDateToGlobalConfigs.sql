BEGIN TRANSACTION;

ALTER TABLE "GlobalConfigs" ADD "DateUpdated" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210202005330_AddDateToGlobalConfigs', '5.0.2');

COMMIT;


