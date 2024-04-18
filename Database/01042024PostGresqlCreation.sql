-- Drop tables if they exist
DROP TABLE IF EXISTS public."PersonResult";
DROP TABLE IF EXISTS public."Registration";
DROP TABLE IF EXISTS public."CompetitionPerCategory";
DROP TABLE IF EXISTS public."Competition";
DROP TABLE IF EXISTS public."AgeCategory";
DROP TABLE IF EXISTS public."Person";
DROP TABLE IF EXISTS public."Address";
DROP TABLE IF EXISTS public."School";

-- Create tables within the public schema
CREATE TABLE public."School"
(
    "Id"   INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "Name" VARCHAR(100) NOT NULL
);

CREATE TABLE public."Address"
(
    "Id"     INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "Street" VARCHAR(100) NOT NULL,
    "City"   VARCHAR(100) NOT NULL
);

CREATE TABLE public."Person"
(
    "Id"         INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "LastName"   VARCHAR(50)  NOT NULL,
    "FirstName"  VARCHAR(50)  NOT NULL,
    "BirthDate"  TIMESTAMP(0) NOT NULL,
    "IBANNumber" VARCHAR(30),
    "SchoolId"   INT,
    "AddressId"  INT,
    "UserId"     UUID         NOT NULL UNIQUE,
    FOREIGN KEY ("SchoolId") REFERENCES public."School" ("Id"),
    FOREIGN KEY ("AddressId") REFERENCES public."Address" ("Id"),
    FOREIGN KEY ("UserId") REFERENCES auth."users" ("id")
);

CREATE TABLE public."AgeCategory"
(
    "Id"         INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "Name"       VARCHAR(100) not null,
    "MinimumAge" INT,
    "MaximumAge" INT
);

CREATE TABLE public."Competition"
(
    "Id"        INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "Name"      VARCHAR(100) not null,
    "Date"      TIMESTAMP(0),
    "AddressId" INT,
    "Active"    BOOLEAN      not null default true,
        FOREIGN KEY ("AddressId") REFERENCES public."Address" ("Id")
);

CREATE TABLE public."CompetitionPerCategory"
(
    "Id"            INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "Gender"        CHAR(1),
    "DistanceName"  VARCHAR(30),
    "DistanceInKm"  INT,
    "AgeCategoryId" INT,
    "CompetitionId" INT,
    "GunTime"       TIMESTAMP(0),
    FOREIGN KEY ("AgeCategoryId") REFERENCES public."AgeCategory" ("Id"),
    FOREIGN KEY ("CompetitionId") REFERENCES public."Competition" ("Id")
);

CREATE TABLE public."Registration"
(
    "Id"                       INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    "RunNumber"                SMALLINT,
    "FinishTime"               TIMESTAMP(0),
    "CompetitionPerCategoryId" INT,
    FOREIGN KEY ("CompetitionPerCategoryId") REFERENCES public."CompetitionPerCategory" ("Id")
);

CREATE TABLE public."PersonResult"
(
    "PersonId" INT,
    "ResultId" INT,
    FOREIGN KEY ("PersonId") REFERENCES public."Person" ("Id"),
    FOREIGN KEY ("ResultId") REFERENCES public."Registration" ("Id")
);