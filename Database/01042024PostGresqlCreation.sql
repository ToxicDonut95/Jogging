-- Drop tables if they exist
DROP TABLE IF EXISTS Jogging.PersoonUitslag;
DROP TABLE IF EXISTS Jogging.Inschrijving;
DROP TABLE IF EXISTS Jogging.WedstrijdPerCategorie;
DROP TABLE IF EXISTS Jogging.Wedstrijd;
DROP TABLE IF EXISTS Jogging.LeeftijdCategorie;
DROP TABLE IF EXISTS Jogging.Account;
DROP TABLE IF EXISTS Jogging.Persoon;
DROP TABLE IF EXISTS Jogging.Adress;
DROP TABLE IF EXISTS Jogging.School;

-- Create schema Jogging if it doesn't exist
CREATE SCHEMA IF NOT EXISTS Jogging;

-- Create tables within the Jogging schema
CREATE TABLE Jogging.School
(
    Id   INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam VARCHAR(100) NOT NULL
);

CREATE TABLE Jogging.Adress
(
    Id    INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Straat VARCHAR(100) NOT NULL,
    Stad  VARCHAR(100) NOT NULL
);

CREATE TABLE Jogging.Persoon
(
    Id            INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Naam          VARCHAR(50) not null,
    GeboorteDatum TIMESTAMP(0) not null,
    IBANNummer    VARCHAR(30),
    SchoolId      INT,
    AdressId      INT,
    FOREIGN KEY (School

