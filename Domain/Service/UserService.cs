using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class UserService : BaseService<User>
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _userRepository = userRepository;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _userRepository.GetByUsernameAndPassword(username, password);
        }

        public void DeleteLogic(int id)
        {
            var entity = _baseRepository.GetById(id);
            //if (entity != null)
            //{
            //    entity.Status = UserStatus.Inactive;
            //    Update<UserValidator>(entity);
            //}

            throw new Exception("Esse produto não existe no banco de dados!");
        }
    }
}
