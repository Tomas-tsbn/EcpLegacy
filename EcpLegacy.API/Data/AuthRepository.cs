using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcpLegacy.API.Models;

namespace EcpLegacy.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EcpLegacyContext _context;

        public AuthRepository(EcpLegacyContext context)
        {
            _context = context;            
        }
        public async Task<Associate> Login(string username, string password)
        {
            var user = await _context.Associate.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;
            
            if (!VeryfyPasswordHash(password, user.Password, user.PasswordSalt))
                return null;
            
            return user;
        }

        private bool VeryfyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<Associate> Register(Associate associate, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            associate.Password = passwordHash;
            associate.PasswordSalt = passwordSalt;

            await _context.Associate.AddAsync(associate);
            await _context.SaveChangesAsync();

            return associate;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Associate.AnyAsync(x => x.Username == username))
                return true;
            
            return false;
        }
    }
}