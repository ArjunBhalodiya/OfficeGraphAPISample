using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.GraphAPI.Messages.Business.Interface;
using Microsoft.GraphAPI.Messages.Models;
using Microsoft.GraphAPI.Messages.Services.Interface;

namespace Microsoft.GraphAPI.Messages.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserManager _officeUserManager;

        public UserService(IUserManager officeUserManager)
        {
            _officeUserManager = officeUserManager;
        }

        /// <summary>
        /// This method will used to get all user
        /// </summary>
        /// <returns></returns>
        public async Task<IList<User>> GetAsync()
        {
            return await _officeUserManager.ListUsersAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateAsync(CreateUserRequest user)
        {
            return await _officeUserManager.CreateUserAsync(user).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateAsync(UpdateUserRequest user)
        {
            return await _officeUserManager.UpdateUserAsync(user).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to delete user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> DeleteAsync(string userId)
        {
            return await _officeUserManager.DeleteUsersAsync(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// This method will used to get user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetAsync(string userId)
        {
            return await _officeUserManager.GetUserAsync(userId).ConfigureAwait(false);
        }
    }
}