﻿using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario)
        {
            ValidarPermissao(2);
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL= new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
                
        }
        public void Alterar(Usuario _usuario) 
        {
            ValidarPermissao(3);
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }
        public void Excluir(int _id)
        {
            ValidarPermissao(4);
            new UsuarioDAL().Excluir(_id);
        }
        public List<Usuario> BuscarTodos()
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public Usuario BuscarPorCPF(string _cPF)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorCPF(_cPF);
        }
        public List<Usuario> BuscarPorNome(string _nome)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
        private void ValidarDados(Usuario _usuario)
        {
            if(_usuario.Senha.Length <= 3)
                throw new Exception("A senha deve ter mais de 3 caracteres.");

            if (_usuario.Nome.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres.");
        }
        public void ValidarPermissao(int _idPermissao)
        {
            if (!new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado, _idPermissao))
                throw new Exception("Você não tem permissão de realizar essa operação. Procure o administrador do sistema.");
        }
    }
}
