using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAccountDAO
    {
        // ==================== ПОЛУЧЕНИЕ ДАННЫХ ====================

        /// <summary>
        /// Получает аккаунт по ID
        /// </summary>
        Task<Account> GetByIdAsync(int id);

        /// <summary>
        /// Получает аккаунт по имени пользователя
        /// </summary>
        Task<Account> GetByUsernameAsync(string username);

        /// <summary>
        /// Получает аккаунт по email
        /// </summary>
        Task<Account> GetByEmailAsync(string email);

        /// <summary>
        /// Получает все аккаунты
        /// </summary>
        Task<IEnumerable<Account>> GetAllAsync();

        // ==================== ПРОВЕРКИ ====================

        /// <summary>
        /// Проверяет, существует ли аккаунт с таким именем
        /// </summary>
        Task<bool> IsUsernameExistsAsync(string username);

        /// <summary>
        /// Проверяет, существует ли аккаунт с таким email
        /// </summary>
        Task<bool> IsEmailExistsAsync(string email);

        // ==================== CRUD ====================

        /// <summary>
        /// Создаёт новый аккаунт
        /// </summary>
        Task<Account> CreateAsync(Account account);

        /// <summary>
        /// Обновляет аккаунт
        /// </summary>
        Task<bool> UpdateAsync(Account account);

        /// <summary>
        /// Удаляет аккаунт по ID
        /// </summary>
        Task<bool> DeleteAsync(int id);
    }
}
