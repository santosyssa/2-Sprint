CREATE  DATABASE  T_BookStore ;

USE T_BookStore;

CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Descricao  VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Titulo             VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);


insert into Generos values 
	 ('Terror')
	,('Biografia')
	,('Fantasia')


select * from Generos

insert into Autores (Nome, Email, Ativo, DataNascimento) values
		('Sophia Abrahão', 'sp@gmail.com',1,'22/05/1991')
	   ,('Carolina de Jesus','cj@gmail.com',0,'14/05/1914')
	   ,('Stephen King','sk@gmail.com',1,'21/09/1947' )

select * from Autores

insert into Livros (Titulo, IdAutor,IdGenero)
			values ('It - A Coisa',3,1)
				  ,('O Mundo das Vozes Silenciadas',1,3)
				  ,('O Diário de Bitita',2,2)

select * from Livros