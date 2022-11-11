using GlobalSulution_Eap.Data;
using GlobalSulution_Eap.Models;
using GlobalSulution_Eap.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GlobalSulution_Eap.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio


    {
        private readonly SistemaEstacionamentoDBContext _dbContext;

        public UsuarioRepositorio(SistemaEstacionamentoDBContext sistemaEstacionamentoDBContext)
        {
            _dbContext = sistemaEstacionamentoDBContext;
        } 

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbContext.Usuarios.AddAsync(usuario);
           await _dbContext.SaveChangesAsync();


            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {

            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuario == null)
            {
                throw new Exception($"O usuário com o id: {id} não foi encontrado em nosso sistema");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }


        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário com o id: {id} não foi encontrado em nosso sistema");
            }


            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
