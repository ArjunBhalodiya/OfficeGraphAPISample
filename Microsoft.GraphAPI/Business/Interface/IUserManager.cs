using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business.Interface
{
    internal interface IUserManager
    {
        Task<IList<User>> ListUsersAsync();
        Task<User> CreateUserAsync(CreateUserRequest user);
        Task<User> UpdateUserAsync(UpdateUserRequest user);
        Task<User> DeleteUsersAsync(string userId);
        Task<User> GetUserAsync(string userId);
    }
}