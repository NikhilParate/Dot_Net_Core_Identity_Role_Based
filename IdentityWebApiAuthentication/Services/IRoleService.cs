using IdentityWebApiAuthentication.Model;

namespace IdentityWebApiAuthentication.Services
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRolesAsync();

        Task<List<string>> GetUserRolesAsync(string emailId);

        Task<List<string>> AddRolesAsync(string[] roles);

        Task<bool> AddUserRolesAsync(string userEmail, string[] roles);
    }
}
