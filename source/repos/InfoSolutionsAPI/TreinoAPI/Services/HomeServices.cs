using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TreinoAPI.Data;
using TreinoAPI.Data.Dto.User;
using TreinoAPI.Interfaces;
using TreinoAPI.Models;

namespace TreinoAPI.Services
{
    public class HomeServices : IHomeInterface
    {
        private IMapper _mapper;
        private DatabaseContext _context;

        public HomeServices(IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ReadUserDto CadastroMaster(CadastroUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);
            User usuario = _context.User.FirstOrDefault();
            foreach (var item in usuario.Usuario)
            {
                if (user.Usuario == usuario.Usuario)
                {
                    return null;
                }
            }
            _context.User.Add(user);
            _context.SaveChanges();
            return _mapper.Map<ReadUserDto>(user);
        }
        public ReadUserDto CadastroClientes(CadastroUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User usuario = _context.User.FirstOrDefault();
            foreach (var item in usuario.Usuario)
            {
                if (user.Usuario == usuario.Usuario)
                {
                    return null;
                }
            }
            _context.User.Add(user);
            _context.SaveChanges();
            CriaCarteira(user.Id);
            return _mapper.Map<ReadUserDto>(user);
        }
        public Ativo AdicionaAtivos(Ativo ativo, string usuario)
        {
            Carteira carteira = _context.Carteira.FirstOrDefault(carteira => carteira.User.Usuario == usuario);
            ativo.CarteiraId = carteira.Id;
            _context.Ativos.Add(ativo);
            _context.SaveChanges();
            return (ativo);
        }
        public ReadUserDto RecebeUsarioNome(string usuario)
        {
            User user = _context.User.FirstOrDefault(user => user.Usuario == usuario);
            if (user != null)
            {
                ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);

                return (userDto);
            }
            return null;
        }
        public Ativo RecuperaAtivos()
        {
            Ativo ativo = _context.Ativos.FirstOrDefault();
            return (ativo);
        }
        public ReadUserDto RecuperaClientes(string role)
        {
            var user = _context.User.Where(user => user.Role == "clientes");
            foreach (var item in user)
            {
                return _mapper.Map<ReadUserDto>(user);
            }
            return null;
        }
        public ReadUserDto RecuperaGerentes(string role)
        {
            var user = _context.User.Where(user => user.Role == "gerente");
            foreach (var item in user)
            {
                return _mapper.Map<ReadUserDto>(user);
            }
            return null;
        }
        public Carteira CriaCarteira(int id)
        {
            Carteira carteira = new Carteira();
            carteira.UserId = id;
            _context.Carteira.Add(carteira);
            _context.SaveChanges();
            return carteira;
        }
    }
}
