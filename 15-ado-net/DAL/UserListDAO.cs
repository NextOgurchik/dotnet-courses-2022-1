﻿using System.Collections.Generic;
using Entities;
using Interfaces;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserListDAO : IUserDAO
    {
        private readonly string connectionString;
        public UserListDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC AddUser @FirstName, @LastName, @Birthdate", connection))
            {
                connection.Open();
                command.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                command.Parameters.Add("LastName", SqlDbType.NVarChar).Value = user.LastName;
                command.Parameters.Add("Birthdate", SqlDbType.Date).Value = user.Birthdate;
                command.ExecuteNonQuery();
            }
        }
        public void Remove(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC DeleteUser @id", connection))
            {
                connection.Open();
                command.Parameters.Add("id", SqlDbType.NVarChar).Value = user.Id;
                command.ExecuteNonQuery();
            }
        }
        public List<User> GetAll()
        {
            var listUser = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT Id, [FirstName], [LastName], [Birthdate] FROM dbo.Users", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                    listUser.Add(user);
                }
            }

            for (int i = 0; i < listUser.Count; i++)
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand("EXEC GetUserRewards @id", connection))
                {
                    connection.Open();
                    command.Parameters.Add("id", SqlDbType.Int).Value = listUser[i].Id;

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var reward = new Reward(reader.GetInt32(0), reader.GetString(1), reader.IsDBNull(2) ? null : reader.GetString(2));
                        listUser[i].ListReward.Add(reward);
                    }
                }
            }
            return listUser;
        }
        public void Update(User user, string firstName, string lastName, DateTime birthdate)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC UpdateUser @id, @FirstName, @LastName, @Birthdate", connection))
            {
                connection.Open();
                command.Parameters.Add("id", SqlDbType.Int).Value = user.Id;
                command.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                command.Parameters.Add("LastName", SqlDbType.NVarChar).Value = user.LastName;
                command.Parameters.Add("Birthdate", SqlDbType.Date).Value = user.Birthdate;
                command.ExecuteNonQuery();
            }
        }
        public void AddReward(User user, Reward reward)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("INSERT INTO UsersRewards(UserId, RewardId) VALUES(@userId, @rewardId)", connection))
            {
                connection.Open();
                command.Parameters.Add("userId", SqlDbType.Int).Value = user.Id;
                command.Parameters.Add("rewardId", SqlDbType.Int).Value = reward.Id;
                command.ExecuteNonQuery();
            }
        }
        public void RemoveReward(User user, Reward reward)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("DELETE FROM UsersRewards WHERE (UserId = @userId) AND (RewardId = @rewardId)", connection))
            {
                connection.Open();
                command.Parameters.Add("userId", SqlDbType.Int).Value = user.Id;
                command.Parameters.Add("rewardId", SqlDbType.Int).Value = reward.Id;
                command.ExecuteNonQuery();
            }
        }
    }
}
