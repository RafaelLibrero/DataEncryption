using DataEncryption.Data;
using DataEncryption.Helpers;
using DataEncryption.Models;
using Microsoft.EntityFrameworkCore;

namespace DataEncryption.Repositories
{
    public class RepositoryCryptography
    {
        private CryptographyContext context;

        public RepositoryCryptography(CryptographyContext context)
        {
            this.context = context;
        }

        public async Task<User> Register(string userName, string email, string password)
        {
            User user = new User();
            user.UserId = await this.context.Users.MaxAsync(x => x.UserId) + 1;
            user.UserName = userName;
            user.Email = email;
            user.Salt = HelperTools.GenerateSalt();
            user.PasswordHash = HelperCryptography.EncryptPasswordSHA(password, user.Salt);

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            User user = await
                this.context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }
            else
            {
                string salt = user.Salt;
                byte[] temp =
                    HelperCryptography.EncryptPasswordSHA(password, salt);
                byte[] passUser = user.PasswordHash;
                bool response =
                    HelperTools.CompareArrays(temp, passUser);
                if (response == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }


        }
    }
}
