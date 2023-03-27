using DAL;
using Models;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
            ValidarDados(_grupoUsuario);

            GrupoUsuarioDAL usuarioDAL = new GrupoUsuarioDAL();
            usuarioDAL.Inserir(_grupoUsuario);

        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            ValidarDados(_grupoUsuario);

            GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
            grupoUsuarioDAL.Alterar(_grupoUsuario);
        }
        public void Excluir(int _id)
        {
            new GrupoUsuarioDAL().Excluir(_id);
        }
        public List<GrupoUsuario> BuscarTodos()
        {
            return new GrupoUsuarioDAL().BuscarTodos();
        }
        public GrupoUsuario BuscarPorId(int _id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }
        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            return new GrupoUsuarioDAL().BuscarPorNomeGrupo(_nomeGrupo);
        }
        private void ValidarDados(GrupoUsuario _grupoUsuario)
        {
            if (_grupoUsuario.NomeGrupo.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres.");
        }
        public void AdicionarPermissao(int _idPermissao, int _idGrupoUsuario)
        {
            if (!new GrupoUsuarioDAL().PermissaoPertenceAoGrupo(_idPermissao, _idGrupoUsuario))
                new GrupoUsuarioDAL().AdicionarPermissao(_idPermissao, _idGrupoUsuario);
        }
        public void RemoverPermissao(int _idPermissao, int _idGrupoUsuario)
        {
            new GrupoUsuarioDAL().RemoverPermissao(_idPermissao, _idGrupoUsuario);
        }
    }
}
