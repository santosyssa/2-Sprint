use T_Gufos

select * from Categorias order by IdCategoria desc
select * from Usuarios
select * from Eventos
select * from Presencas

select E.*, C.* from Eventos as E
join Categorias as C
on E.IdCategoria = C.IdCategoria;

select P.*, U.*, E.*
from Presencas P
join Usuarios U
on P.IdEvento = U.IdUsuario
join Eventos E
on P.IdEvento = E.IdEvento

select P.*, U.*, E.*, C.*
from Presencas P
inner join Usuarios U
on P.IdUsuario = U.IdUsuario
inner join Eventos E
on P.IdEvento = E.IdEvento
inner join Categorias C
on E.IdCategoria = C.IdCategoria;