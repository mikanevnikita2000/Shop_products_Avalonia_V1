BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "main" (
	"idmain"	INTEGER NOT NULL UNIQUE,
	"data"	TEXT NOT NULL,
	"products"	INTEGER NOT NULL,
	"price"	INTEGER NOT NULL,
	"category"	TEXT NOT NULL,
	PRIMARY KEY("idmain" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "products" (
	"id_products"	INTEGER NOT NULL UNIQUE,
	"products"	TEXT NOT NULL,
	PRIMARY KEY("id_products" AUTOINCREMENT)
);
INSERT INTO "main" VALUES (1,'2022-05-14',1,123,'продукт');
INSERT INTO "main" VALUES (2,'2022-05-14',1,234,'продукт');
INSERT INTO "main" VALUES (3,'2022-05-14',2,567,'продукт');
INSERT INTO "main" VALUES (4,'2022-05-14',1,246,'продукт');
INSERT INTO "main" VALUES (5,'2022-05-14',1,246,'продукт');
INSERT INTO "main" VALUES (6,'2022-05-14',1,246,'продукт');
INSERT INTO "main" VALUES (7,'2022-05-14',3,246,'продукт');
INSERT INTO "main" VALUES (8,'2022-05-19',1,234,'продукт');
INSERT INTO "main" VALUES (9,'2022-05-19',1,67,'продукт');
INSERT INTO "main" VALUES (10,'2022-05-19',4,5476,'продукт');
INSERT INTO "main" VALUES (11,'2022-05-19',1,6764,'продукт');
INSERT INTO "main" VALUES (12,'2022-05-19',3,456,'продукт');
INSERT INTO "products" VALUES (1,'Молоко');
INSERT INTO "products" VALUES (2,'уксус');
INSERT INTO "products" VALUES (3,'Кифир');
INSERT INTO "products" VALUES (4,'Кетчуп');
COMMIT;
