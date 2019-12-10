Create Database M_OpFlix_2019;

Use M_OpFlix_2019;


Create table TiposUsuarios(
	IdTipo int primary key identity not null,
	Nome varchar(255) not null unique
);

Create table Usuarios(
	IdUsuario int primary key identity not null,
	Nome varchar(255) not null,
	Senha varchar(255) not null,
	Email varchar(255) not null unique,
	IdTipo int foreign key references TiposUsuarios(IdTipo)
);

CREATE TABLE [dbo].[Categorias](
	[IdCat] [int] IDENTITY(1,1) NOT NULL,
	[NomeCat] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NomeCat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Plataformas](
	[IdPlataforma] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TiposSF](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[DescricaoTipo] [char](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DescricaoTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SFs](
	[IdSF] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[DataLancamento] [datetime] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Sinopse] [text] NOT NULL,
	[IdCat] [int] NOT NULL,
	[TempoD] [varchar](255) NOT NULL,
	[FaixaEtaria] [int] NULL default (14),
	[Descricao] [text] NULL default ('Sem descrição disponível'),
	[Plataforma] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Titulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [dbo].[SFs]  WITH CHECK ADD FOREIGN KEY([IdCat])
REFERENCES [dbo].[Categorias] ([IdCat])
GO

ALTER TABLE [dbo].[SFs]  WITH CHECK ADD FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TiposSF] ([IdTipo])
GO

ALTER TABLE [dbo].[SFs]  WITH CHECK ADD FOREIGN KEY([Plataforma])
REFERENCES [dbo].[Plataformas] ([IdPlataforma])
GO

CREATE TABLE [dbo].[Favoritos](
	[IdUsuario] [int] NULL,
	[IdSF] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Favoritos]  WITH CHECK ADD FOREIGN KEY([IdSF])
REFERENCES [dbo].[SFs] ([IdSF])
GO

ALTER TABLE [dbo].[Favoritos]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO

