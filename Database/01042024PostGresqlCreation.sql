-- Drop tables if they exist
DROP TABLE IF EXISTS public.PersoonUitslag;
DROP TABLE IF EXISTS public.Inschrijving;
DROP TABLE IF EXISTS public.WedstrijdPerCategorie;
DROP TABLE IF EXISTS public.Wedstrijd;
DROP TABLE IF EXISTS public.LeeftijdCategorie;
DROP TABLE IF EXISTS public.Persoon;
DROP TABLE IF EXISTS public.Adress;
DROP TABLE IF EXISTS public.School;

-- Create tables within the public schema
CREATE TABLE public.School
(
    Id   INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam VARCHAR(100) NOT NULL
);

CREATE TABLE public.Adress
(
    Id    INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Staat VARCHAR(100) NOT NULL,
    Stad  VARCHAR(100) NOT NULL
);

CREATE TABLE public.Persoon
(
    Id            INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam          VARCHAR(50),
    GeboorteDatum TIMESTAMP(0),
    IBANNummer    VARCHAR(30),
    SchoolId      INT  NOT NULL,
    AdressId      INT  NOT NULL,
    UserId        UUID NOT NULL,
    FOREIGN KEY (SchoolId) REFERENCES public.School (Id),
    FOREIGN KEY (AdressId) REFERENCES public.Adress (Id),
    FOREIGN KEY (UserId) REFERENCES auth.users(id)
);

CREATE TABLE public.LeeftijdCategorie
(
    Id              INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam            VARCHAR(100),
    MinimumLeeftijd INT,
    MaximumLeeftijd INT
);

CREATE TABLE public.Wedstrijd
(
    Id       INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam     VARCHAR(100),
    Datum    TIMESTAMP(0),
    AdressId INT,
    FOREIGN KEY (AdressId) REFERENCES public.Adress (Id)
);

CREATE TABLE public.WedstrijdPerCategorie
(
    Id                  INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Geslacht            CHAR(1),
    AfstandNaam         VARCHAR(30),
    AfstandInKm         INT,
    LeeftijdCategorieId INT,
    WedstrijdId         INT,
    FOREIGN KEY (LeeftijdCategorieId) REFERENCES public.LeeftijdCategorie (Id),
    FOREIGN KEY (WedstrijdId) REFERENCES public.Wedstrijd (Id)
);

CREATE TABLE public.Inschrijving
(
    Id                      INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    LoopNummer              SMALLINT,
    EindTijd                TIMESTAMP(0),
    WedstrijdPerCategorieId INT,
    FOREIGN KEY (WedstrijdPerCategorieId) REFERENCES public.WedstrijdPerCategorie (Id)
);

CREATE TABLE public.PersoonUitslag
(
    PersoonId INT,
    UitslagId INT,
    FOREIGN KEY (PersoonId) REFERENCES public.Persoon (Id),
    FOREIGN KEY (UitslagId) REFERENCES public.Inschrijving (Id)
);