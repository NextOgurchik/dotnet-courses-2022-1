using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAccountBL
    {
        Task<bool> IsUsernameExistsAsync(string username);
        Task<bool> IsEmailExistsAsync(string email);
        Task<Account> RegisterAsync(string username, string email, string password);
        Task<Account> LoginAsync(string username, string password);
        string HashPassword(string password);
        bool VerifyPassword(string password, string storedHash);
        (string Expression, int Result) GenerateCaptcha();
        bool IsCaptchaValid(string userAnswer, int expectedResult);
        Task<Account> GetAccountByIdAsync(int id);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int id);
    }
}
