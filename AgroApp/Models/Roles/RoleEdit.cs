using Microsoft.AspNetCore.Identity;
namespace AgroApp.Models.Roles
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<UserModel> Members { get; set; }
        public IEnumerable<UserModel> NonMembers { get; set; }
    }
}
