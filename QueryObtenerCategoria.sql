select C.NombreCategoria from Instrumento I
inner join Categoria C on I.IdCategoria = C.Id
where I.Id = 3;


select M.NombreMarca from Instrumento I
inner join Marca M on I.IdMarca = M.Id
where I.Id =3


select T.NombreInstrumento from Instrumento I
inner join TipoInstrumento T on I.IdTipo = T.Id
where I.Id =3

