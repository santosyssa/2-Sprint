CREATE DATABASE T_Filmes;

USE T_Filmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

INSERT INTO Generos VALUES
	('Suspense')
	,('Ação')


INSERT INTO Filmes (Titulo, IdGenero) VALUES
	('Velozes e Furiosos 8', 2)
	,('A Morte Está de Parabéns', 1)

SELECT * FROM Generos 
SELECT * FROM Filmes 