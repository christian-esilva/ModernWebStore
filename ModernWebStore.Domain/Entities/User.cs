using ModernWebStore.Domain.Scopes;
using ModernWebStore.SharedKernel.Helpers;

namespace ModernWebStore.Domain.Entities
{
    public class User
    {
        protected User(){}

        public User(string email, string password, bool isAdmin)
        {
            Email = email;
            Password = StringHelper.Encrypt(password);
            IsAdmin = isAdmin;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public void Register()
        {
            this.RegisterUserScopeIsValid();
        }

        public void Authenticate(string email, string password)
        {
            this.AuthenticateUserScopeIsValid(email, password);
        }

        public void GrantAdmin()
        {
            IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            IsAdmin = false;
        }
    }
}
