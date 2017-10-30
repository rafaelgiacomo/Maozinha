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
	@DataInicio varchar(max) = NULL,
	@DataFim varchar(max) = NULL,
	@Uf varchar(max) = NULL,
	@Cidade varchar(max) = NULL,
	@Endereco varchar(max) = NULL,
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

--Alterar Projeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ALTERAR_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ALTERAR_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_ALTERAR_PROJETO]
	@Id int,
	@Nome varchar(max),
	@Descricao varchar(max),
	@DataInicio varchar(max) = NULL,
	@DataFim varchar(max) = NULL,
	@Uf varchar(max) = NULL,
	@Cidade varchar(max) = NULL,
	@Endereco varchar(max) = NULL,
	@QtdVagas int,
	@EntidadeId int,
	@CategoriaId int,
	@ArquivoId int = NULL
AS
BEGIN
	UPDATE [Projeto] SET [Nome] = @Nome, [Descricao] = @Descricao, [DataInicio] = @DataInicio, [DataFim] = @DataFim, 
		[Uf] = @Uf, [Cidade] = @Cidade, [Endereco] = @Endereco, [QtdVagas] = @QtdVagas, [EntidadeId] = @EntidadeId, 
		[CategoriaId] = @CategoriaId, [ArquivoId] = @ArquivoId WHERE [Id] = @Id
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

--Selecionar Projeto por Id
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_PROJETO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_PROJETO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_PROJETO_ID]
	@Id int
AS
BEGIN
	SELECT * FROM [Projeto] WHERE [Id] = @Id
END
GO

--Excluir Projeto por Id
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_PROJETO]
	@Id int
AS
BEGIN
	DELETE FROM [Projeto] WHERE [Id] = @Id
END
GO


--====================================================== PROCEDURES TABELA CATEFORIA DE PROJETO =======================================================================

--Listar Categorias
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_TODAS_CATEGORIAS_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_TODAS_CATEGORIAS_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_TODAS_CATEGORIAS_PROJETO]
AS
BEGIN
	SELECT * FROM [CategoriaProjeto]
END
GO

--Selecionar Categoria por Id
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_CATEGORIA_PROJETO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_CATEGORIA_PROJETO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_CATEGORIA_PROJETO_ID]
	@Id int
AS
BEGIN
	SELECT * FROM [CategoriaProjeto] WHERE [Id] = @Id
END
GO


--====================================================== PROCEDURES TABELA ARQUIVO =======================================================================

--SELECIONAR ARQUIVO POR ID
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_ARQUIVO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_ARQUIVO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_ARQUIVO_ID]
	@Id int
AS
BEGIN
	SELECT * FROM [Arquivo] WHERE Id = @Id
END
GO

--LISTAR ARQUIVOS DE ENTIDADE
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_ARQUIVOS_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_ARQUIVOS_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_ARQUIVOS_ENTIDADE]
	@EntidadeId int
AS
BEGIN
	SELECT * FROM [Arquivo] a, [ArquivoEntidade] ae WHERE a.Id = ae.ArquivoId AND ae.EntidadeId = @EntidadeId
END
GO

--LISTAR ARQUIVOS DE VOLUNTARIO
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_ARQUIVOS_VOLUNTARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_ARQUIVOS_VOLUNTARIO]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_ARQUIVOS_VOLUNTARIO]
	@VoluntarioId int
AS
BEGIN
	SELECT * FROM [Arquivo] a, [ArquivoVoluntario] ae WHERE a.Id = ae.ArquivoId AND ae.VoluntarioId = @VoluntarioId
END
GO

--Salvar Arquivos de Entidade
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_ARQUIVO_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_ENTIDADE]
	@Titulo varchar(max),
	@Descricao varchar(max) = NULL,
	@Caminho varchar(max),
	@EntidadeId int
AS
BEGIN
	
	BEGIN TRANSACTION

		BEGIN TRY

			INSERT INTO [Arquivo]([Titulo], [Descricao], [Caminho]) VALUES (@Titulo, @Descricao, @Caminho)

			DECLARE @ULTIMO_ID INT 
			SET @ULTIMO_ID = Scope_identity()

			INSERT INTO [ArquivoEntidade]([EntidadeId], [ArquivoId]) VALUES (@EntidadeId, @ULTIMO_ID)

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH

	COMMIT
END
GO

--Salvar Arquivos de Voluntario
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]
	@Titulo varchar(max),
	@Descricao varchar(max) = NULL,
	@Caminho varchar(max),
	@VoluntarioId int
AS
BEGIN
	
	BEGIN TRANSACTION

		BEGIN TRY

			INSERT INTO [Arquivo]([Titulo], [Descricao], [Caminho]) VALUES (@Titulo, @Descricao, @Caminho)

			DECLARE @ULTIMO_ID INT 
			SET @ULTIMO_ID = Scope_identity()

			INSERT INTO [ArquivoVoluntario]([VoluntarioId], [ArquivoId]) VALUES (@VoluntarioId, @ULTIMO_ID)

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH

	COMMIT
END
GO

--Excluir Arquivos de Entidade
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_ARQUIVO_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_ARQUIVO_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_ARQUIVO_ENTIDADE]
	@Id int,
	@EntidadeId int
AS
BEGIN
	BEGIN TRANSACTION

		BEGIN TRY

			DELETE FROM [ArquivoEntidade] WHERE [EntidadeId] = @EntidadeId AND [ArquivoId] = @Id

			DELETE FROM [Arquivo] WHERE [Id] = @Id

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH

	COMMIT
END
GO

--Excluir Arquivos de Voluntario
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_ARQUIVO_VOLUNTARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_ARQUIVO_VOLUNTARIO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_ARQUIVO_VOLUNTARIO]
	@Id int,
	@VoluntarioId int
AS
BEGIN
	BEGIN TRANSACTION

		BEGIN TRY

			DELETE FROM [ArquivoVoluntario] WHERE [VoluntarioId] = @VoluntarioId AND [ArquivoId] = @Id

			DELETE FROM [Arquivo] WHERE [Id] = @Id

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH

	COMMIT
END
GO