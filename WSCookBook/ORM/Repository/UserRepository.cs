using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class UserRepository : Repository, I_Repository<User>
    {
        public UserRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }

        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Users WHERE UserId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(User user)
        {
            string sql = $@"INSERT INTO Users (UserId, UserName, UserEmail, UserPassword)" +
                         $@" VALUES (@UserId, @UserName, @UserEmail, @UserPassword)";
            
            this.dBContext.AddParameter("@UserId", user.UserId);
            this.dBContext.AddParameter("@UserName", user.UserName);
            this.dBContext.AddParameter("@UserEmail", user.UserEmail);
            this.dBContext.AddParameter("@UserPassword", user.UserPassword);

            return this.dBContext.ChangeData(sql) > 0;
        }

        public User Select(string id)
        {
            string sql = $"SELECT * FROM Users WHERE UserId = @UserId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.UserCreator.CreateModel(reader);
            }
            return null;
        }

        public List<User> SelectAll()
        {
            List<User> users = new List<User>();
            string sql = $"SELECT * FROM Users";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    users.Add(this.modelCreator.UserCreator.CreateModel(reader));
                }
            }
            return users;
        }

        public bool Update(User item)
        {
            string sql = $"UPDATE set Users UserName = @UserName, UserEmail = @UserEmail, UserPassword = @UserPassword WHERE UserId = @UserId";
            this.dBContext.AddParameter("@UserId", item.UserId);
            this.dBContext.AddParameter("@UserName", item.UserName);
            this.dBContext.AddParameter("@UserEmail", item.UserEmail);
            this.dBContext.AddParameter("@UserPassword", item.UserPassword);
            return this.dBContext.ChangeData(sql) > 0;
        }
    }
}
