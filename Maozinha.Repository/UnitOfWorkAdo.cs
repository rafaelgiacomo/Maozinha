﻿using Maozinha.Interface;
using System;

namespace Maozinha.Repository
{
    public class UnitOfWorkAdo : IUnitOfWork, IDisposable
    {

        #region Propriedades

        private readonly string _connectionString;
        private readonly Context _context;

        #pragma warning disable 649
        private UsuarioRep _usuarioRep;
        private EntidadeRep _entidadeRep;
        private VoluntarioRep _voluntarioRep;
        private TipoUsuarioRep _tipoUsuarioRep;
        private ProjetoRep _projetoRep;
        #pragma warning restore 649

        public TipoUsuarioRep TiposUsuario
        {
            get
            {
                if (_tipoUsuarioRep == null)
                {
                    _tipoUsuarioRep = new TipoUsuarioRep(_context);
                }
                return _tipoUsuarioRep;
            }
        }

        public UsuarioRep Usuarios
        {
            get
            {
                if (_usuarioRep == null)
                {
                    _usuarioRep = new UsuarioRep(_context);
                }
                return _usuarioRep;
            }
        }

        public EntidadeRep Entidades
        {
            get
            {
                if (_entidadeRep == null)
                {
                    _entidadeRep = new EntidadeRep(_context);
                }
                return _entidadeRep;
            }
        }

        public VoluntarioRep Voluntarios
        {
            get
            {
                if (_voluntarioRep == null)
                {
                    _voluntarioRep = new VoluntarioRep(_context);
                }
                return _voluntarioRep;
            }
        }

        public ProjetoRep Projetos
        {
            get
            {
                if (_projetoRep == null)
                {
                    _projetoRep = new ProjetoRep(_context);
                }
                return _projetoRep;
            }
        }
        #endregion

        #region Metodos Publicos

        public void AbrirTransacao()
        {
            _context.OpenTransaction();
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void RollBack()
        {
            _context.RollBack();
        }

        public void AbrirConexao()
        {
            _context.AbrirConexao();
        }

        public void FecharConexao()
        {
            _context.FecharConexao();
        }

        public void Dispose()
        {
            _context.FecharConexao();
        }

        #endregion

        public UnitOfWorkAdo(string connectionString)
        {
            _connectionString = connectionString;
            _context = new Context(connectionString);
            _context.AbrirConexao();
        }

    }
}
