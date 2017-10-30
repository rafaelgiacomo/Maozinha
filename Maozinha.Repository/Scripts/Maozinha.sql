USE [master]
GO

CREATE DATABASE [Maozinha]
GO

USE [Maozinha]
GO

create table Arquivo(
	[Id] [int],
	[Titulo] [varchar](max) NOT NULL,
	[Descricao] [varchar](max),
	[Caminho] [varchar](max) NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
	CONSTRAINT [PK_dbo.Arquivo] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table ArquivoEntidade(
	[ArquivoId] [int] NOT NULL,
	[EntidadeId] [int] NOT NULL,
	CONSTRAINT [PK_dbo.ArquivoEntidade] PRIMARY KEY CLUSTERED
	(
		[EntidadeId] ASC,
		[ArquivoId] ASC		
	)
)
GO

create table ArquivoVoluntario(
	[ArquivoId] [int] NOT NULL,
	[VoluntarioId] [int] NOT NULL,
	CONSTRAINT [PK_dbo.ArquivoVoluntario] PRIMARY KEY CLUSTERED
	(
		[VoluntarioId] ASC,
		[ArquivoId] ASC		
	)
)
GO

create table TipoUsuario(
	[Id] [int],
	[Descricao] [varchar](max) NOT NULL,
	CONSTRAINT [PK_dbo.TipoUsuario] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Usuario(
	[Id] [int] identity(1,1),
	[Nome] [varchar](max) NOT NULL,
	[Uf] [varchar](max),
	[Cidade] [varchar](max),
	[Endereco] [varchar](max),
	[Email] [varchar](max) NOT NULL,
	[Telefone] [varchar](max),
	[Login] [varchar](max) NOT NULL,
	[Senha] [varchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ArquivoId] [int],
	[Descriminador] [int],
	[Descricao][varchar](max),
	CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Entidade(
	[UsuarioId] [int] NOT NULL,
	[Cnpj] [varchar](max) NOT NULL,
	CONSTRAINT [PK_dbo.Entidade] PRIMARY KEY CLUSTERED
	(
		[UsuarioId] ASC
	)
)
GO

create table Voluntario(
	[UsuarioId] [int] NOT NULL,
	[Cpf] [varchar](max) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	CONSTRAINT [PK_dbo.Voluntario] PRIMARY KEY CLUSTERED
	(
		[UsuarioId] ASC
	)
)
GO

create table CategoriaProjeto(
	[Id] [int] identity(1,1),
	[Descricao] [varchar](max) NOT NULL,
	CONSTRAINT [PK_dbo.CategoriaProjeto] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table Projeto(
	[Id] [int] identity(1,1),
	[EntidadeId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Descricao] [varchar](max) NOT NULL,
	[DataInicio] [date],
	[DataFim] [date],
	[Uf] [varchar](max),
	[Cidade] [varchar](max),
	[Endereco] [varchar](max),
	[QtdVagas] [int] NOT NULL,
	[ArquivoId] [int],
	CONSTRAINT [PK_dbo.Projeto] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)
)
GO

create table VoluntarioProjeto(
	[VoluntarioId] [int],
	[ProjetoId] [int],
	CONSTRAINT [PK_dbo.VoluntarioProjeto] PRIMARY KEY CLUSTERED
	(
		[VoluntarioId] ASC,
		[ProjetoId] ASC
	)
)
GO

--Definindo Chaves Estrangeiras
--===========================================================

--Tabela Usuario
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Usuario_dbo.Arquivo_ArquivoId] FOREIGN KEY([ArquivoId])
REFERENCES [dbo].[Arquivo] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_dbo.Usuario_dbo.Arquivo_ArquivoId]
GO

--Tabela Entidade
ALTER TABLE [dbo].[Entidade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Entidade_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Entidade] CHECK CONSTRAINT [FK_dbo.Entidade_dbo.Usuario_UsuarioId]
GO

--Tabela Voluntario
ALTER TABLE [dbo].[Voluntario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Voluntario_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Voluntario] CHECK CONSTRAINT [FK_dbo.Voluntario_dbo.Usuario_UsuarioId]
GO

--Tabela Projeto
ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Projeto_dbo.Entidade_EntidadeId] FOREIGN KEY([EntidadeId])
REFERENCES [dbo].[Entidade] ([UsuarioId])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_dbo.Projeto_dbo.Entidade_EntidadeId]
GO

ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Projeto_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[CategoriaProjeto] ([Id])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_dbo.Projeto_dbo.Categoria_CategoriaId]
GO

ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Projeto_dbo.Arquivo_ArquivoId] FOREIGN KEY([ArquivoId])
REFERENCES [dbo].[Arquivo] ([Id])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_dbo.Projeto_dbo.Arquivo_ArquivoId]
GO

--Tabela Voluntario Projeto
ALTER TABLE [dbo].[VoluntarioProjeto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VoluntarioProjeto_dbo.Projeto_ProjetoId] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projeto] ([Id])
GO
ALTER TABLE [dbo].[VoluntarioProjeto] CHECK CONSTRAINT [FK_dbo.VoluntarioProjeto_dbo.Projeto_ProjetoId]
GO

ALTER TABLE [dbo].[VoluntarioProjeto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VoluntarioProjeto_dbo.Voluntario_VoluntarioId] FOREIGN KEY([VoluntarioId])
REFERENCES [dbo].[Voluntario] ([UsuarioId])
GO
ALTER TABLE [dbo].[VoluntarioProjeto] CHECK CONSTRAINT [FK_dbo.VoluntarioProjeto_dbo.Voluntario_VoluntarioId]
GO

--Tabela ArquivoEntidade
ALTER TABLE [dbo].[ArquivoEntidade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArquivoEntidade_dbo.Arquivo_ArquivoId] FOREIGN KEY([ArquivoId])
REFERENCES [dbo].[Arquivo] ([Id])
GO
ALTER TABLE [dbo].[ArquivoEntidade] CHECK CONSTRAINT [FK_dbo.ArquivoEntidade_dbo.Arquivo_ArquivoId]
GO

ALTER TABLE [dbo].[ArquivoEntidade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArquivoEntidade_dbo.Entidade_EntidadeId] FOREIGN KEY([EntidadeId])
REFERENCES [dbo].[Entidade] ([UsuarioId])
GO
ALTER TABLE [dbo].[ArquivoEntidade] CHECK CONSTRAINT [FK_dbo.ArquivoEntidade_dbo.Entidade_EntidadeId]
GO

--Tabela ArquivoVoluntario
ALTER TABLE [dbo].[ArquivoVoluntario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArquivoVoluntario_dbo.Arquivo_ArquivoId] FOREIGN KEY([ArquivoId])
REFERENCES [dbo].[Arquivo] ([Id])
GO
ALTER TABLE [dbo].[ArquivoVoluntario] CHECK CONSTRAINT [FK_dbo.ArquivoVoluntario_dbo.Arquivo_ArquivoId]
GO

ALTER TABLE [dbo].[ArquivoVoluntario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArquivoVoluntario_dbo.Voluntatio_VoluntarioId] FOREIGN KEY([VoluntarioId])
REFERENCES [dbo].[Voluntario] ([UsuarioId])
GO
ALTER TABLE [dbo].[ArquivoVoluntario] CHECK CONSTRAINT [FK_dbo.ArquivoVoluntario_dbo.Voluntatio_VoluntarioId]
GO

--Populando base de dados para uso inicial
--===============================================================================================================
INSERT INTO TipoUsuario (Id, Descricao) VALUES (1, 'Voluntario');
GO
INSERT INTO TipoUsuario (Id, Descricao) VALUES (2, 'Entidade');
GO
INSERT INTO TipoUsuario (Id, Descricao) VALUES (3, 'Admin');
GO

INSERT INTO CategoriaProjeto(Descricao) VALUES ('Eventos Festivos');
GO
INSERT INTO CategoriaProjeto(Descricao) VALUES ('Eventos Esportivos');
GO
INSERT INTO CategoriaProjeto(Descricao) VALUES ('Projeto Social');
GO
INSERT INTO CategoriaProjeto(Descricao) VALUES ('Arrecadação de alimentos');
GO
INSERT INTO CategoriaProjeto(Descricao) VALUES ('Arrecadação financeira');
GO