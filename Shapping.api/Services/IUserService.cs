using Shapping.api.Entities;
using System.Collections.Generic;

namespace Shapping.api.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
