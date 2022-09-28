using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TreinoAPI.Data.Dto.User;
using TreinoAPI.Models;

namespace TreinoAPI.Interfaces
{
    public interface IHomeInterface
    {
        public ReadUserDto CadastroMaster(CadastroUserDto userDto);
        public ReadUserDto CadastroClientes(CadastroUserDto userDto);
        public Ativo AdicionaAtivos(Ativo ativo, string usuario);
        public ReadUserDto RecebeUsarioNome(string usuario);
        public Ativo RecuperaAtivos();
        public ReadUserDto RecuperaClientes(string role);
        public ReadUserDto RecuperaGerentes(string role);

    }
}
