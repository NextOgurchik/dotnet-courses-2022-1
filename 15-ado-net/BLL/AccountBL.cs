using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBL : IAccountBL
    {
        private readonly IAccountDAO _accountDAO;

        public AccountBL(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        // ==================== РЕГИСТРАЦИЯ ====================

        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            return await _accountDAO.IsUsernameExistsAsync(username);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _accountDAO.IsEmailExistsAsync(email);
        }

        public async Task<Account> RegisterAsync(string username, string email, string password)
        {
            if (await _accountDAO.IsUsernameExistsAsync(username))
                throw new InvalidOperationException("Пользователь с таким именем уже существует");

            if (await _accountDAO.IsEmailExistsAsync(email))
                throw new InvalidOperationException("Пользователь с таким email уже зарегистрирован");

            string passwordHash = HashPassword(password);

            var account = new Account
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            return await _accountDAO.CreateAsync(account);
        }

        // ==================== ВХОД ====================

        public async Task<Account> LoginAsync(string username, string password)
        {
            var account = await _accountDAO.GetByUsernameAsync(username);

            if (account == null)
                return null;

            if (!VerifyPassword(password, account.PasswordHash))
                return null;

            return account;
        }

        // ==================== ХЕЛПЕРЫ ДЛЯ ПАРОЛЕЙ ====================

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = deriveBytes.GetBytes(256 / 8);

            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hash = Convert.FromBase64String(parts[1]);

            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] testHash = deriveBytes.GetBytes(256 / 8);

            return CryptographicOperations.FixedTimeEquals(hash, testHash);
        }

        // ==================== КАПЧА ====================

        public (string Expression, int Result) GenerateCaptcha()
        {
            var rand = new Random();
            int a = rand.Next(1, 10);
            int b = rand.Next(1, 10);
            return ($"{a} + {b} = ?", a + b);
        }

        public bool IsCaptchaValid(string userAnswer, int expectedResult)
        {
            return userAnswer == expectedResult.ToString();
        }

        // ==================== ДОПОЛНИТЕЛЬНЫЕ МЕТОДЫ ====================

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _accountDAO.GetByIdAsync(id);
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _accountDAO.GetByUsernameAsync(username);
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            return await _accountDAO.UpdateAsync(account);
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            return await _accountDAO.DeleteAsync(id);
        }
    }
}
