using System;
using System.Collections.Generic;
using Assignment4.Core;
using System.Linq;

namespace Assignment4.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly IKanbanContext _context;

        public UserRepository(IKanbanContext context)
        {
            _context = context;
        }

        public UserDTO Create(UserCreateDTO user)
        {
            var entity = new User { Name = user.Name };

            _context.Users.Add(entity);

            _context.SaveChanges();

            return new UserDTO(entity.Id, entity.Name, entity.Email);
        }

        public void Dispose()
        {

        }

        public UserDTO Read(int userId)
        {
            var users = from u in _context.Users
                where u.Id == userId
                select new UserDTO(u.Id, u.Name, u.Email);

            return users.FirstOrDefault();
        }

        public IReadOnlyCollection<UserDTO> Read()
        {
            throw new NotImplementedException();
        }

        public UserDTO Update(UserCreateDTO user)
        {
            throw new NotImplementedException();

        }

        public UserDTO Delete(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }
    }
}