using System;
using System.Collections.Generic;
using Assignment4.Core;
using System.Linq;

namespace Assignment4.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly KanbanContext _context;

        public UserRepository(KanbanContext context)
        {
            _context = context;
        }

        public (Response Response, int UserId) Create(UserCreateDTO user)
        {
            var entity = new User { Name = user.Name };

            _context.Users.Add(entity);

            _context.SaveChanges();

            var _user = new UserDTO(entity.Id, entity.Name, entity.Email);

            return (Response.Created, _user.Id);
        }

        public IReadOnlyCollection<UserDTO> ReadAll(){
            throw new NotImplementedException();
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

        public Response Update(UserUpdateDTO user){
            throw new NotImplementedException();
        }

        public Response Delete(int userId, bool force = false){
            throw new NotImplementedException();
        }
    }
}