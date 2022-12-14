using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Application.Services
{
    public  class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            Expression<Func<Usuario, bool>> expression = item => item.Id == usuario.Id;
            var usuarios = await _unitOfWork.UsuarioRepository.FindByCondition(expression);
            if (usuarios.Any(item => item.Id == usuario.Id))
                throw new Exception("Este producto ya ha sido registrado");


            await _unitOfWork.UsuarioRepository.Add(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Update(usuario);
        }
    }
}
