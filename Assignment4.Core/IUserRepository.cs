using System;
using System.Collections.Generic;

namespace Assignment4.Core
{
    public interface IUserRepository : IDisposable
    {
        UserDTO Create(UserCreateDTO user);

        UserDTO Read(int UserId);

        IReadOnlyCollection<UserDTO> Read();
        
        UserDTO Update(UserCreateDTO user);

        UserDTO Delete(UserCreateDTO user);
    }
}