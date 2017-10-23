USE [Maozinha]
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS OFF
GO

--====================================================== PROCEDURES TABELA USUARIO =======================================================================

--Selecionar Usuario por login
--===============================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_USUARIO_LOGIN]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_USUARIO_LOGIN]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_USUARIO_LOGIN]
	@Login varchar(max)
AS
BEGIN
	SELECT * FROM [Usuario] WHERE [Login] = @Login
END
GO

--Selecionar Usuario por login
--===============================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_ENTIDADE_LOGIN]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_ENTIDADE_LOGIN]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_ENTIDADE_LOGIN]
	@Login varchar(max)
AS
BEGIN
	SELECT * FROM [Usuario] u, [Entidade] e WHERE u.Id = e.UsuarioId AND [Login] = @Login
END
GO


--====================================================== PROCEDURES TABELA TIPO USUARIO =======================================================================

--Selecionar Tipo Usuario por Descricao
--===============================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_TIPO_USUARIO_DESCRICAO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_TIPO_USUARIO_DESCRICAO]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_TIPO_USUARIO_DESCRICAO]
	@Descricao varchar(max)
AS
BEGIN
	SELECT * FROM [TipoUsuario] WHERE [Descricao] = @Descricao
END
GO


--====================================================== PROCEDURES TABELA ENTIDADE =======================================================================

--Salvar Entidade
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_ENTIDADE]
	@Nome varchar(max),
	@Uf varchar(max) = NULL,
	@Cidade varchar(max) = NULL,
	@Endereco varchar(max) = NULL,
	@Email varchar(max),
	@Telefone varchar(max) = NULL,
	@Login varchar(max),
	@Senha varchar(max),
	@RoleId int,
	@ArquivoId int = NULL,
	@Descriminador int,
	@Descricao varchar(max) = NULL,
	@Cnpj varchar(max)
AS
BEGIN
	INSERT INTO [Usuario]([Nome], [Uf], [Cidade], [Endereco], [Email], [Telefone], [Login], [Senha], [RoleId], [Descriminador], [Descricao])
		VALUES (@Nome, @Uf, @Cidade, @Endereco, @Email, @Telefone, @Login, @Senha, @RoleId, @Descriminador, @Descricao)

	DECLARE @ULTIMO_ID INT
	 
	SET @ULTIMO_ID = Scope_identity()

	INSERT INTO [Entidade]([UsuarioId], [Cnpj]) VALUES (@ULTIMO_ID, @Cnpj)
END
GO

--====================================================== PROCEDURES TABELA VOLUNTARIO =======================================================================

--Salvar Voluntario
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_VOLUNTARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_VOLUNTARIO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_VOLUNTARIO]
	@Nome varchar(max),
	@Uf varchar(max) = NULL,
	@Cidade varchar(max) = NULL,
	@Endereco varchar(max) = NULL,
	@Email varchar(max),
	@Telefone varchar(max) = NULL,
	@Login varchar(max),
	@Senha varchar(max),
	@RoleId int,
	@ArquivoId int = NULL,
	@Descriminador int,
	@Descricao varchar(max) = NULL,
	@Cpf varchar(max)
AS
BEGIN
	INSERT INTO [Usuario]([Nome], [Uf], [Cidade], [Endereco], [Email], [Telefone], [Login], [Senha], [RoleId], [Descriminador], [Descricao])
		VALUES (@Nome, @Uf, @Cidade, @Endereco, @Email, @Telefone, @Login, @Senha, @RoleId, @Descriminador, @Descricao)

	DECLARE @ULTIMO_ID INT
	 
	SET @ULTIMO_ID = Scope_identity()

	INSERT INTO [Voluntario]([UsuarioId], [Cpf]) VALUES (@ULTIMO_ID, @Cpf)
END
GO


--====================================================== PROCEDURES TABELA PROJETO =======================================================================

--Salvar Projeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_PROJETO]
	@Nome varchar(max),
	@Descricao varchar(max),
	@DataInicio varchar(max),
	@DataFim varchar(max),
	@Uf varchar(max),
	@Cidade varchar(max),
	@Endereco varchar(max),
	@QtdVagas int,
	@EntidadeId int,
	@CategoriaId int,
	@ArquivoId int = NULL
AS
BEGIN
	INSERT INTO [Projeto]([Nome], [Descricao], [DataInicio], [DataFim], [Uf], [Cidade], [Endereco], [QtdVagas], 
		[EntidadeId], [CategoriaId], [ArquivoId])
		VALUES (@Nome, @Descricao, @DataInicio, @DataFim, @Uf, @Cidade, @Endereco, @QtdVagas, @EntidadeId, 
		@CategoriaId, @ArquivoId)
END
GO

--Listar Projetos Cliente
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_PROJETOS_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_PROJETOS_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_PROJETOS_ENTIDADE]
	@EntidadeId int
AS
BEGIN
	SELECT * FROM [Projeto] WHERE [EntidadeId] = @EntidadeId
END
GO