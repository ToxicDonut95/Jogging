-- Drop tables if they exist
DROP TABLE IF EXISTS PersoonUitslag;
DROP TABLE IF EXISTS Inschrijving;
DROP TABLE IF EXISTS WedstrijdPerCategorie;
DROP TABLE IF EXISTS Wedstrijd;
DROP TABLE IF EXISTS LeeftijdCategorie;
DROP TABLE IF EXISTS Account;
DROP TABLE IF EXISTS Persoon;
DROP TABLE IF EXISTS Adress;
DROP TABLE IF EXISTS School;
-- Create tables
CREATE TABLE IF NOT EXISTS School (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Naam VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Adress (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Straat VARCHAR(100) NOT NULL,
    Stad VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Persoon (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Naam VARCHAR(50) NOT NULL,
    GeboorteDatum TEXT NOT NULL,
    IBANNummer VARCHAR(30),
    SchoolId INTEGER,
    AdressId INTEGER,
    FOREIGN KEY (SchoolId) REFERENCES School(Id),
    FOREIGN KEY (AdressId) REFERENCES Adress(Id)
);

CREATE TABLE IF NOT EXISTS Account (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Email VARCHAR(50) NOT NULL,
    Password VARCHAR(50),
    PersoonId INTEGER,
    Rechten CHAR(1) NOT NULL,
    FOREIGN KEY (PersoonId) REFERENCES Persoon(Id)
);

CREATE TABLE IF NOT EXISTS LeeftijdCategorie (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Naam VARCHAR(100) NOT NULL,
    MinimumLeeftijd INT NOT NULL,
    MaximumLeeftijd INT NOT NULL
);

CREATE TABLE IF NOT EXISTS Wedstrijd (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Naam VARCHAR(100) NOT NULL,
    Datum TEXT NOT NULL,
    AdressId INTEGER,
    FOREIGN KEY (AdressId) REFERENCES Adress(Id)
);

CREATE TABLE IF NOT EXISTS WedstrijdPerCategorie (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Geslacht CHAR(1),
    AfstandNaam VARCHAR(30),
    AfstandInKm INT,
    LeeftijdCategorieId INTEGER,
    WedstrijdId INTEGER NOT NULL,
    Guntime Text,
    FOREIGN KEY (LeeftijdCategorieId) REFERENCES LeeftijdCategorie(Id),
    FOREIGN KEY (WedstrijdId) REFERENCES Wedstrijd(Id)
);

CREATE TABLE IF NOT EXISTS Inschrijving (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    LoopNummer SMALLINT,
    EindTijd TEXT,
    WedstrijdPerCategorieId INTEGER NOT NULL,
    FOREIGN KEY (WedstrijdPerCategorieId) REFERENCES WedstrijdPerCategorie(Id)
);

CREATE TABLE IF NOT EXISTS PersoonUitslag (
    PersoonId INTEGER NOT NULL,
    UitslagId INTEGER NOT NULL,
    FOREIGN KEY (PersoonId) REFERENCES Persoon(Id),
    FOREIGN KEY (UitslagId) REFERENCES Inschrijving(Id)
);