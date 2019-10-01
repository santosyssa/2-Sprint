use T_Gufos

insert into Usuarios (Nome, Email, Senha, Permissao)
	values ('Uwellyntom','Uwe@gmai.com','1234','Administrador')

insert into Usuarios (Nome, Email, Senha, Permissao)
	values ('Rayssa','rayssa@gmail.com','r1234','Aluno')

	insert into Usuarios (Nome, Email, Senha, Permissao)
	values ('Tiago','t@gmail.com','123456','Administrador')

select * from Usuarios


insert into Categorias (Nome)
values ('Jogos') , ('Meetup'), ('Futebol');

select * from Categorias order by IdCategoria asc

insert into Eventos(Titulo, Descricao, DataEvento, Ativo, Localizacao, IdCategoria)
values ('Campeonato de Ping-Pong', 'Campeonato entre as turmas de tec. redes e dev', '2019-08-06 16:33:22.440', 1, 'Alameda Barão de Limeira, 539',1);


insert into Eventos(Titulo, Descricao, DataEvento, Localizacao, IdCategoria)
values ('Meetup', 'BD Relacionais', '2019-08-06T00:00:00', 'Alameda Barão de Limeira, 539',2);

insert into Eventos(Titulo, Descricao, DataEvento, Localizacao, IdCategoria)
values ('Futebol no terraço', 'Do Núcle Desenvolvimento Senai', '2019-08-06T00:00:00', 'Alameda Barão de Limeira, 539', 2);

select* from Eventos

insert into Presencas (IdEvento,IdUsuario) VALUES (1,2) , (1,1), (2,2)
select* from Presencas

update Eventos set IdCategoria = 3 where IdEvento = 4