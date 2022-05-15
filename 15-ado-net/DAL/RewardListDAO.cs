using System.Collections.Generic;
using Entities;
using Interfaces;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RewardListDAO : IRewardDAO
    {
        private readonly string connectionString;
        public RewardListDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Reward reward)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC AddReward @title, @description", connection))
            {
                connection.Open();
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = reward.Title;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = reward.Description;
                command.ExecuteNonQuery();
            }
        }
        public void Remove(Reward reward)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC DeleteReward @id", connection))
            {
                connection.Open();
                command.Parameters.Add("id", SqlDbType.Int).Value = reward.Id;
                command.ExecuteNonQuery();
            }
        }
        public void Update(Reward reward, string title, string description)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("EXEC UpdateReward @id, @title, @description", connection))
            {
                connection.Open();
                command.Parameters.Add("id", SqlDbType.Int).Value = reward.Id;
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = description;
                command.ExecuteNonQuery();
            }
        }
        public List<Reward> GetAll()
        {
            var listReward = new List<Reward>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT Id, [Title], [Description] from dbo.Rewards", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var reward = new Reward(reader.GetInt32(0), reader.GetString(1), reader.IsDBNull(2) ? null : reader.GetString(2));
                    listReward.Add(reward);
                }
            }
            return listReward;
        }
    }
}
