using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Services.Interface
{
    public interface IUserService
    {
        Task<IList<User>> GetAsync();
        Task<User> CreateAsync(CreateUserRequest user);
        Task<User> UpdateAsync(UpdateUserRequest user);
        Task<User> DeleteAsync(string userId);
        Task<User> GetAsync(string userId);
    }
}
