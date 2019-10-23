

--Desenvolvido por Victor Ivanovich Bormotoff
--Programa : OpFlix
--Cliente: Tadeu
-- :)

--DDL--

USE M_OpFlix_2019;
BACKUP DATABASE M_OpFlix_2019
	To Disk = 'C:\Users\45579480814\Desktop\DocumentosOpFlix'
	With format,
	Medianame = 'OpFlixSet1',
	Name = 'M_OpFlix';

CREATE DATABASE M_OpFlix_2019;
CREATE TABLE TiposUsuarios(
	IdTipo INT PRIMARY KEY NOT NULL IDENTITY
	,Nome VARCHAR(150) NOT NULL UNIQUE
);
CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY NOT NULL IDENTITY
	,Nome VARCHAR (255) NOT NULL
	,Senha VARCHAR (40) NOT NULL
	,Email VARCHAR (200) NOT NULL UNIQUE
	,IdTipo INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipo)
);
CREATE TABLE Categorias(
	IdCat INT PRIMARY KEY NOT NULL IDENTITY
	,NomeCat VARCHAR(200) NOT NULL UNIQUE
);
CREATE TABLE TiposSF(
	IdTipo INT PRIMARY KEY NOT NULL IDENTITY
	,DescricaoTipo CHAR (5) NOT NULL UNIQUE
);
CREATE TABLE SFs(
	IdSF INT PRIMARY KEY NOT NULL IDENTITY
	,Titulo VARCHAR(200) NOT NULL UNIQUE
	,DataLancamento Datetime NOT NULL
	,IdTipo INT FOREIGN KEY REFERENCES TiposSF(IdTipo) NOT NULL
	,Sinopse TEXT NOT NULL
	,IdCat INT FOREIGN KEY REFERENCES Categorias(IdCat) NOT NULL
	,TempoD VARCHAR (255) NOT NULL
);
ALTER Table SFs
Add FaixaEtaria INT Default (14);

ALTER Table SFs
Add Descricao TEXT Default('Sem descrição disponível');

Alter table SFs
Add Plataforma INT FOREIGN KEY REFERENCES Plataformas(IdPlataforma);

CREATE TABLE Plataformas(
	IdPlataforma INT PRIMARY KEY IDENTITY
	,Nome varchar(200) not null unique
);

CREATE TABLE Favoritos(
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
	,IdSF INT FOREIGN KEY REFERENCES SFs(IdSF)
);

--DDL--

--DML--

Insert TiposUsuarios (Nome)
	VALUES ('Comum'),('Administrador');

Insert TiposSF (DescricaoTipo)
	Values ('Filme'),('Série');

Insert Usuarios (Nome,Senha,Email,IdTipo)
	Values ('Jorge','321','JorgeAlmeida@gmail.com',1),('TestBot','123','NotABot@adsasdasda.com',2);

Insert Usuarios (Nome,Senha,Email,IdTipo)
	Values ('Erik','123456','erik@email.com',2),('Cassiana','123456','cassiana@email.com',2),('Helena','123456','helena@email.com',1),('Roberto','3110','rob@email.com',1);
Insert Categorias(NomeCat)
	Values ('Horror'),('Suspense'),('Comédia'),('Ação'),('Romance'),('Aventura'),('Futuristico'),('Ficção');
Insert Categorias (NomeCat)
	Values ('Documentário'),('Drama');
Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD)
	Values ('Anabelle - Back at home','2019-08-18T12:00:00','Um filme de ''Terror'', quase meme da SAM',14,1,1,'160 minutos');

Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('Indiana Jones','2019-08-23T12:00:00','Conta a aventura do famoso Indiana Jones',12,4,1,'200 minutos','Ganhador de vários Oscars',3);

Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('Teste','2019-08-10T12:00:00','Teste',12,4,1,'200 minutos','Ganhador de vários Oscars',3);

Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('Deuses Americanos','2019-08-10T12:00:00','Deuses americanos na terra',16,8,2,'200 minutos','2 Temporadas',2);	

Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('La Casa de Papel 3 temp','2019-08-10T12:00:00','La Casa de Papel',16,4,2,'200 minutos','3 Temporadas',2);

Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('Rei Leão', '2019-08-10T12:00:00','Lendário Rei Leão',10,6,1,'150 minutos','Filme ganhador de Oscars',3);

	Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('Who is your hero', '2019-08-10T12:00:00','Filme de anime',10,8,1,'150 minutos','Filme sobre um anime',3);

	Insert SFs (Titulo,DataLancamento,Sinopse,FaixaEtaria,IdCat,IdTipo,TempoD,Descricao,Plataforma)
	Values ('VELOZES E FURIOSOS: HOBBS & SHAW', '2019-08-10T12:00:00','Velozes e Furiosos',10,4,1,'150 minutos','Filme ganhador de Oscars',3);

Update SFs
	SET SFs.Titulo = 'La Casa de Papel - 3º Temporada'
	Where SFs.IdSF = 6;

Update SFs
	Set SFs.DataLancamento = '1994-06-15T12:00:00.000'
	Where SFs.IdSF = 7;
Update SFs
	SET SFs.Descricao = 'Filminho de terror'
	Where SFs.TempoD = '160 minutos'
Update SFs
	SET SFs.Plataforma = 2
	Where SFS.IdCat = 1;



Delete SFs
	Where SFs.Titulo = 'Deuses Americanos';

Insert Favoritos (IdSF,IdUsuario)
	Values (1,1),(1,2);

Delete Favoritos
	Where Favoritos.IdUsuario = 2;

Insert Plataformas (Nome)
	Values('Amazon'),('Netflix'),('Cinemark');

Update Usuarios
	set IdTipo = 2
	where Usuarios.IdUsuario = 5;

--DML--

--DQL--

Select * from Usuarios;
Select * from Plataformas;
Select Usuarios.Nome,Usuarios.Email,TiposUsuarios.Nome
From Usuarios
Join TiposUsuarios
On Usuarios.IdTipo = TiposUsuarios.IdTipo;

Select * from TiposSF;
Select * from TiposUsuarios order by TiposUsuarios.IdTipo asc;
Select * from SFs;


Select SF.Titulo,SF.DataLancamento,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,T.DescricaoTipo,P.Nome
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma;

--Lançamento--
Select SF.Titulo, Case When DateDiff(day,SF.DataLancamento,GetDate()) > 0 Then 'Disponivel para assistir' Else CAST(DATEDIFF(Day,GetDate(),SF.DataLancamento) AS varchar(200))+' dias até o lançamento' END,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,P.Nome,T.DescricaoTipo
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma;

--Lançamento sem duplicação
Select distinct SF.Titulo, Case When DateDiff(day,SF.DataLancamento,GetDate()) > 0 Then 'Disponivel para assistir' Else CAST(DATEDIFF(Day,GetDate(),SF.DataLancamento) AS varchar(200))+' dias até o lançamento' END,SF.TempoD,SF.FaixaEtaria,C.NomeCat,P.Nome,T.DescricaoTipo
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
Where (SF.Titulo = SF.Titulo);

Select * from Categorias;
Select * from Favoritos;

--Lançamento asc--
Select SF.Titulo,SF.DataLancamento,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,T.DescricaoTipo,P.Nome
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
order by SF.DataLancamento asc;


--Categoria asc--
Select SF.Titulo,SF.DataLancamento,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,T.DescricaoTipo,P.Nome
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
order by C.NomeCat asc;

--Categoria e Lançamento asc--
Select SF.Titulo,SF.DataLancamento,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,T.DescricaoTipo,P.Nome
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
order by SF.DataLancamento, C.NomeCat  asc;

--Favoritos--
Select U.Nome,SF.Titulo
From Usuarios U
Join Favoritos F
On U.IdUsuario = F.IdUsuario
Join SFs SF
On SF.IdSF = F.IdSF;

--Filtro por mês--
Select SF.Titulo, Case When DateDiff(day,SF.DataLancamento,GetDate()) > 0 Then 'Disponivel para assistir' Else CAST(DATEDIFF(Day,GetDate(),SF.DataLancamento) AS varchar(200))+' dias até o lançamento' END,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,P.Nome,T.DescricaoTipo
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
--Filtragem por mês--
Where DATEPART(Month,SF.DataLancamento) = 08



--Filtro por Categoria
Select SF.Titulo, Case When DateDiff(day,SF.DataLancamento,GetDate()) > 0 Then 'Disponivel para assistir' Else CAST(DATEDIFF(Day,GetDate(),SF.DataLancamento) AS varchar(200))+' dias até o lançamento' END,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,P.Nome,T.DescricaoTipo
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
--Filtragem por Categoria (Id)--
Where C.IdCat = 4

--Filtro por Categoria nome
Select SF.Titulo, Case When DateDiff(day,SF.DataLancamento,GetDate()) > 0 Then 'Disponivel para assistir' Else CAST(DATEDIFF(Day,GetDate(),SF.DataLancamento) AS varchar(200))+' dias até o lançamento' END,SF.Sinopse,SF.TempoD,SF.FaixaEtaria,C.NomeCat,SF.Descricao,P.Nome,T.DescricaoTipo
From SFs SF
Join Categorias C
On SF.IdCat = C.IdCat
Join TiposSF T
On T.IdTipo = SF.IdTipo
Join Plataformas P
On P.IdPlataforma = SF.Plataforma
--Filtragem por Categoria (Nome)--
Where C.NomeCat = 'Horror'

--Mostra todas as categorias e os filmes vinculados
Select Categorias.NomeCat, SFs.Titulo
from Categorias
left Join SFs
on Categorias.IdCat = SFs.IdCat;

--Mostra as plataformas e suas devidas categorias, sem duplicação, mesmo que a categoria seja nula
Select Distinct Categorias.NomeCat, Plataformas.Nome
from Categorias
left Join SFs
on Categorias.IdCat = SFs.IdCat
right join Plataformas
on Plataformas.IdPlataforma = SFs.Plataforma;

--Mostra todas as plataformas e os filmes vinculados
Select Plataformas.Nome,SFs.Titulo
From Plataformas
left join SFs
On Plataformas.IdPlataforma = SFs.Plataforma;

--DQL--


