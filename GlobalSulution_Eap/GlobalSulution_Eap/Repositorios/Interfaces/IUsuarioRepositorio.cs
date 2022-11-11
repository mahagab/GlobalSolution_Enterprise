﻿using GlobalSulution_Eap.Models;

namespace GlobalSulution_Eap.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        Task<bool> Apagar(int id);
    }
}
