﻿using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PermissaoBLL
    {
        public void Inserir(Permissao _permissao)
        {
            ValidarDados(_permissao);

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Inserir(_permissao);

        }
        public void Alterar(Permissao _permissao)
        {
            ValidarDados(_permissao);

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);
        }
        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }
        public List<Permissao> BuscarTodos()
        {
            return new PermissaoDAL().BuscarTodos();
        }
        public Permissao BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }
        private void ValidarDados(Permissao _permissao)
        {
            if (_permissao.Descricao.Length <= 20)
                throw new Exception("A descrição deve ter mais de 20 caracteres.");
        }
    }
}
