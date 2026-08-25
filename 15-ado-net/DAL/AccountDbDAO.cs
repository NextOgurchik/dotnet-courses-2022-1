using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UsersRewardsWeb.DAL
{
    public class AccountDbDAO : IAccountDAO
    {
        private readonly string _connectionString;

        public AccountDbDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ==================== ПОЛУЧЕНИЕ ДАННЫХ ====================

        public async Task<Account> GetByIdAsync(int id)
        {
            Account account = null;
            string sql = "SELECT Id, Username, Email, PasswordHash, CreatedAt FROM accounts WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        account = MapToAccount(reader);
                    }
                }
            }

            return account;
        }

        public async Task<Account> GetByUsernameAsync(string username)
        {
            Account account = null;
            string sql = "SELECT Id, Username, Email, PasswordHash, CreatedAt FROM accounts WHERE Username = @Username";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        account = MapToAccount(reader);
                    }
                }
            }

            return account;
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            Account account = null;
            string sql = "SELECT Id, Username, Email, PasswordHash, CreatedAt FROM accounts WHERE Email = @Email";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        account = MapToAccount(reader);
                    }
                }
            }

            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = new List<Account>();
            string sql = "SELECT Id, Username, Email, PasswordHash, CreatedAt FROM accounts ORDER BY Username";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accounts.Add(MapToAccount(reader));
                    }
                }
            }

            return accounts;
        }

        // ==================== ПРОВЕРКИ ====================

        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            string sql = "SELECT COUNT(1) FROM accounts WHERE Username = @Username";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();

                return Convert.ToInt32(result) > 0;
            }
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            string sql = "SELECT COUNT(1) FROM accounts WHERE Email = @Email";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();

                return Convert.ToInt32(result) > 0;
            }
        }

        // ==================== CRUD ====================

        public async Task<Account> CreateAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            string sql = @"
                INSERT INTO accounts (Username, Email, PasswordHash, CreatedAt)
                VALUES (@Username, @Email, @PasswordHash, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@PasswordHash", account.PasswordHash);
                command.Parameters.AddWithValue("@CreatedAt", account.CreatedAt);

                await connection.OpenAsync();
                var newId = await command.ExecuteScalarAsync();

                account.Id = Convert.ToInt32(newId);
            }

            return account;
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            string sql = @"
                UPDATE accounts
                SET Username = @Username,
                    Email = @Email,
                    PasswordHash = @PasswordHash
                WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", account.Id);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@PasswordHash", account.PasswordHash);

                await connection.OpenAsync();
                var rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE FROM accounts WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                var rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }

        // ==================== ХЕЛПЕР ====================

        private Account MapToAccount(SqlDataReader reader)
        {
            return new Account
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Username = reader.GetString(reader.GetOrdinal("Username")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }
    }
}
