ALTER TABLE "public"."rjo_project_person" DROP CONSTRAINT "FK_rjo_person_project_person_id";
ALTER TABLE "public"."rjo_project_person" DROP CONSTRAINT "FK_rjo_project_person_project_id";
DROP TABLE IF EXISTS "public"."rjo_person";
DROP TABLE IF EXISTS "public"."rjo_project";
DROP TABLE IF EXISTS "public"."rjo_project_person";
CREATE TABLE "public"."rjo_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "rjo_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rjo_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "rjo_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rjo_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "rjo_project_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."rjo_person" ("person_name") VALUES ('Robert');
INSERT INTO "public"."rjo_person" ("person_name") VALUES ('Tina');
INSERT INTO "public"."rjo_person" ("person_name") VALUES ('Neil');
INSERT INTO "public"."rjo_person" ("person_name") VALUES ('William');
INSERT INTO "public"."rjo_person" ("person_name") VALUES ('Maria');
INSERT INTO "public"."rjo_project" ("project_name") VALUES ('Foxbank');
INSERT INTO "public"."rjo_project" ("project_name") VALUES ('APIs');
INSERT INTO "public"."rjo_project" ("project_name") VALUES ('Database');
INSERT INTO "public"."rjo_project" ("project_name") VALUES ('Website');
INSERT INTO "public"."rjo_project" ("project_name") VALUES ('SQL');
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 5);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (4, 3, 8);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (4, 3, 5);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (2, 3, 4);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (2, 3, 1);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 5);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (2, 1, 2);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (4, 5, 5);
INSERT INTO "public"."rjo_project_person" ("project_id", "person_id", "hours") VALUES (5, 1, 3);
ALTER TABLE "public"."rjo_project_person" ADD CONSTRAINT "FK_rjo_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."rjo_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."rjo_project_person" ADD CONSTRAINT "FK_rjo_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."rjo_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
