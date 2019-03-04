using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Core.Interface;
using Microsoft.GraphAPI.Messages.Models;

namespace Microsoft.GraphAPI.Messages.Business
{
    internal class UserManager : IUserManager
    {
        private readonly IHttpCall _call;

        public UserManager(IHttpCall call)
        {
            _call = call;
        }

        public async Task<IList<User>> ListUsersAsync()
        {
            return await _call.GetAsync<IList<User>>($"users").ConfigureAwait(false);
        }

        public async Task<User> CreateUserAsync(CreateUserRequest user)
        {
            return await _call.PostAsync<User, CreateUserRequest>($"users", user).ConfigureAwait(false);
        }

        public async Task<User> UpdateUserAsync(UpdateUserRequest user)
        {
            return await _call.PostAsync<User, UpdateUserRequest>($"users/{user.Id}", user).ConfigureAwait(false);
        }

        public async Task<User> DeleteUsersAsync(string userId)
        {
            return await _call.DeleteAsync<User>($"users/{userId}").ConfigureAwait(false);
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return await _call.GetAsync<User>($"users/{userId}").ConfigureAwait(false);
        }
    }
}
