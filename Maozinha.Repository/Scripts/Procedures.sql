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

--Selecionar Entidade por login
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

--Selecionar Voluntario por login
--===============================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_VOLUNTARIO_LOGIN]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_LOGIN]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_LOGIN]
	@Login varchar(max)
AS
BEGIN
	SELECT * FROM [Usuario] u, [Voluntario] e WHERE u.Id = e.UsuarioId AND [Login] = @Login
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

--Alterar Entidade
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ALTERAR_ENTIDADE]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ALTERAR_ENTIDADE]
GO

CREATE PROCEDURE [DBO].[SP_ALTERAR_ENTIDADE]
	@Id int,
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
BEGIN TRANSACTION

	BEGIN TRY
		UPDATE [Usuario] SET [Nome] = @Nome, [Uf] = @Uf, [Cidade] = @Cidade, [Endereco] = @Endereco, [Email] = @Email, [Telefone] = @Telefone, [Login] = @Login, 
		[Senha] = @Senha, [RoleId] = @RoleId, [Descriminador] = @Descriminador, [Descricao]	= @Descricao WHERE [Id] = @Id

		UPDATE [Entidade] SET [Cnpj] = @Cnpj WHERE [UsuarioId] = @Id

		COMMIT

	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH	
	
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
	@DataNascimento varchar(max),
	@Cpf varchar(max)
AS
BEGIN
	INSERT INTO [Usuario]([Nome], [Uf], [Cidade], [Endereco], [Email], [Telefone], [Login], [Senha], [RoleId], [Descriminador], [Descricao])
		VALUES (@Nome, @Uf, @Cidade, @Endereco, @Email, @Telefone, @Login, @Senha, @RoleId, @Descriminador, @Descricao)

	DECLARE @ULTIMO_ID INT
	 
	SET @ULTIMO_ID = Scope_identity()

	INSERT INTO [Voluntario]([UsuarioId], [Cpf], [DataNascimento]) VALUES (@ULTIMO_ID, @Cpf, @DataNascimento)
END
GO

--Selecionar Voluntario por Id
--===============================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_VOLUNTARIO_ID]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_ID]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_ID]
	@UsuarioId varchar(max)
AS
BEGIN
	SELECT * FROM [Usuario] u, [Voluntario] e WHERE u.Id = e.UsuarioId AND e.[UsuarioId] = @UsuarioId
END
GO

--Listar Voluntario por Projeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_VOLUNTARIOS_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_VOLUNTARIOS_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_VOLUNTARIOS_PROJETO]
	@ProjetoId int
AS
BEGIN
	SELECT * FROM [Usuario] u, [Voluntario] v, [VoluntarioProjeto] vp WHERE u.Id = v.UsuarioId AND v.UsuarioId = vp.VoluntarioId AND vp.ProjetoId = @ProjetoId AND vp.Selecionado = 0
END
GO

--Listar Voluntarios Selecionados por Projeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_VOLUNTARIOS_SELECIONADOS_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_VOLUNTARIOS_SELECIONADOS_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_VOLUNTARIOS_SELECIONADOS_PROJETO]
	@ProjetoId int
AS
BEGIN
	SELECT * FROM [Usuario] u, [Voluntario] v, [VoluntarioProjeto] vp WHERE u.Id = v.UsuarioId AND v.UsuarioId = vp.VoluntarioId AND vp.ProjetoId = @ProjetoId AND vp.Selecionado = 1
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

--Alterar Imagem do Projeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ALTERAR_IMAGEM_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ALTERAR_IMAGEM_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_ALTERAR_IMAGEM_PROJETO]
	@Id int,
	@ArquivoId int = NULL
AS
BEGIN
	UPDATE [Projeto] SET [ArquivoId] = @ArquivoId WHERE [Id] = @Id
END
GO

--Listar Projetos Entidade
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


--Listar Projetos Disponiveis
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_PROJETOS_DISPONIVEIS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_PROJETOS_DISPONIVEIS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_PROJETOS_DISPONIVEIS]
AS
BEGIN
	SELECT * FROM [Projeto] WHERE [QtdVagas] > 0 AND [DataFim] > CONVERT(date, GETDATE())
END
GO

--Listar Projetos Voluntario Atuais
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_ATUAIS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_ATUAIS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_ATUAIS]
	@VoluntarioId int
AS
BEGIN
	SELECT * FROM [Projeto] p, [VoluntarioProjeto] v WHERE p.Id = v.ProjetoId AND v.VoluntarioId = @VoluntarioId AND p.DataFim > CONVERT(date, GETDATE()) AND v.Aprovado = 1
END
GO

--Listar Projetos Voluntario Pendentes
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_PENDENTES]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_PENDENTES]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_PENDENTES]
	@VoluntarioId int
AS
BEGIN
	SELECT * FROM [Projeto] p, [VoluntarioProjeto] v WHERE p.Id = v.ProjetoId AND v.VoluntarioId = @VoluntarioId AND v.Aprovado = 0 AND p.DataFim > CONVERT(date, GETDATE())
END
GO

--Listar Projetos Voluntario Concluidos
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_CONCLUIDOS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_CONCLUIDOS]
GO

CREATE PROCEDURE [DBO].[SP_LISTAR_PROJETOS_VOLUNTARIO_CONCLUIDOS]
	@VoluntarioId int
AS
BEGIN
	SELECT * FROM [Projeto] p, [VoluntarioProjeto] v WHERE p.Id = v.ProjetoId AND v.VoluntarioId = @VoluntarioId AND p.DataFim < CONVERT(date, GETDATE()) AND v.Aprovado = 1
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
	@Id int,
	@Titulo varchar(max),
	@Descricao varchar(max) = NULL,
	@Caminho varchar(max),
	@EntidadeId int,
	@Tipo nvarchar(10)
AS
BEGIN
	BEGIN TRANSACTION

		BEGIN TRY

			INSERT INTO [Arquivo]([Id], [Titulo], [Descricao], [Caminho], [Tipo]) VALUES (@Id, @Titulo, @Descricao, @Caminho, @Tipo)

			INSERT INTO [ArquivoEntidade]([EntidadeId], [ArquivoId]) VALUES (@EntidadeId, @Id)

			COMMIT

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

--Salvar Arquivos de Voluntario
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_ARQUIVO_VOLUNTARIO]
	@Id int,
	@Titulo varchar(max),
	@Descricao varchar(max) = NULL,
	@Caminho varchar(max),
	@Tipo nvarchar(10),
	@VoluntarioId int
AS
BEGIN
	BEGIN TRANSACTION

		BEGIN TRY

			INSERT INTO [Arquivo]([Id], [Titulo], [Descricao], [Caminho], [Tipo]) VALUES (@Id, @Titulo, @Descricao, @Caminho, @Tipo)

			INSERT INTO [ArquivoVoluntario]([VoluntarioId], [ArquivoId]) VALUES (@VoluntarioId, @Id)

			COMMIT

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH	
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

			COMMIT

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
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

			COMMIT

		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

--DEFINIR PROXIMO ID
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_DEFINIR_ID_ARQUIVO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_DEFINIR_ID_ARQUIVO]
GO

CREATE PROCEDURE [DBO].[SP_DEFINIR_ID_ARQUIVO]
AS
BEGIN
	SELECT (MAX(Id) + 1) FROM [Arquivo]
END
GO


--==========================================================TABELA VoluntarioProjeto========================================================================

--Salvar VoluntarioProjeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SALVAR_VOLUNTARIO_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SALVAR_VOLUNTARIO_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_SALVAR_VOLUNTARIO_PROJETO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	INSERT INTO [VoluntarioProjeto] (ProjetoId, VoluntarioId, Aprovado, Selecionado) VALUES (@ProjetoId, @VoluntarioId, 0, 0)
END
GO

--Excluir VoluntarioProjeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_EXCLUIR_VOLUNTARIO_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_EXCLUIR_VOLUNTARIO_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_EXCLUIR_VOLUNTARIO_PROJETO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	DELETE FROM [VoluntarioProjeto] WHERE [ProjetoId] = @ProjetoId AND [VoluntarioId] = @VoluntarioId
END
GO

--Verificar VoluntarioProjeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_VERIFICAR_VOLUNTARIO_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_VERIFICAR_VOLUNTARIO_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_VERIFICAR_VOLUNTARIO_PROJETO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	SELECT * FROM [VoluntarioProjeto] WHERE [ProjetoId] = @ProjetoId AND [VoluntarioId] = @VoluntarioId
END
GO

--Verificar VoluntarioProjeto Selecionado
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_VERIFICAR_VOLUNTARIO_SELECIONADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_VERIFICAR_VOLUNTARIO_SELECIONADO]
GO

CREATE PROCEDURE [DBO].[SP_VERIFICAR_VOLUNTARIO_SELECIONADO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	SELECT * FROM [VoluntarioProjeto] WHERE [ProjetoId] = @ProjetoId AND [VoluntarioId] = @VoluntarioId AND [Selecionado] = 1
END
GO

--Selecionar VoluntarioProjeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_SELECIONAR_VOLUNTARIO_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_SELECIONAR_VOLUNTARIO_PROJETO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	UPDATE [VoluntarioProjeto] SET [Selecionado] = 1 WHERE [ProjetoId] = @ProjetoId AND [VoluntarioId] = @VoluntarioId
END
GO

--Selecionar VoluntarioProjeto
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_REMOVER_VOLUNTARIO_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_REMOVER_VOLUNTARIO_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_REMOVER_VOLUNTARIO_PROJETO]
	@VoluntarioId int,
	@ProjetoId int
AS
BEGIN
	UPDATE [VoluntarioProjeto] SET [Selecionado] = 0 WHERE [ProjetoId] = @ProjetoId AND [VoluntarioId] = @VoluntarioId
END
GO

--Quantidade Candidatos Selecionados
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_VER_QTD_VOLUNTARIOS_SELECIONADOS]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_VER_QTD_VOLUNTARIOS_SELECIONADOS]
GO

CREATE PROCEDURE [DBO].[SP_VER_QTD_VOLUNTARIOS_SELECIONADOS]
	@ProjetoId int
AS
BEGIN
	SELECT COUNT(*) FROM [VoluntarioProjeto] WHERE [ProjetoId] = @ProjetoId AND [Selecionado] = 1
END
GO

--ENCERRAR PROJETO
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_ENCERRAR_PROJETO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_ENCERRAR_PROJETO]
GO

CREATE PROCEDURE [DBO].[SP_ENCERRAR_PROJETO]
	@ProjetoId int
AS
BEGIN
	UPDATE [VoluntarioProjeto] SET [Aprovado] = 1 WHERE [ProjetoId] = @ProjetoId AND [Selecionado] = 1
END
GO

--VERIFICAR PROJETO ENCERRADO
--======================================================================================================
IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[SP_VERIFICAR_PROJETO_ENCERRADO]')
	AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
	DROP PROCEDURE [DBO].[SP_VERIFICAR_PROJETO_ENCERRADO]
GO

CREATE PROCEDURE [DBO].[SP_VERIFICAR_PROJETO_ENCERRADO]
	@ProjetoId int
AS
BEGIN
	SELECT COUNT(*) FROM [VoluntarioProjeto] WHERE [Aprovado] = 1 AND [ProjetoId] = @ProjetoId
END
GO