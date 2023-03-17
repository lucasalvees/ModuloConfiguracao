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
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL= new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
                
        }
        public void Alterar(Usuario _usuario) 
        {
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }
        public void Excluir(int _id)
        {
            new UsuarioDAL().Excluir(_id);
        }
        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public Usuario BuscarPorCPF(string _cPF)
        {
            return new UsuarioDAL().BuscarPorCPF(_cPF);
        }
        public List<Usuario> BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
        private void ValidarDados(Usuario _usuario)
        {
            if(_usuario.Senha.Length <= 3)
                throw new Exception("A senha deve ter mais de 3 caracteres.");

            if (_usuario.Nome.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres.");
        }
    }
}
