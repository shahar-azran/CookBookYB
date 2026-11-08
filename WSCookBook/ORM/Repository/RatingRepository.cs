using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class RatingRepository : Repository, I_Repository<Rating>
    {
        public RatingRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }

        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Ratings WHERE RatingId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(Rating obj)
        {
            string sql = $@"INSERT INTO Ratings (RatingId, UserId, RecipeId, RatingValue)" +
                         $@" VALUES (@RatingId, @UserId, @RecipeId, @RatingValue)";
            this.dBContext.AddParameter("@RatingId", obj.RatingID);
            this.dBContext.AddParameter("@UserId", obj.UserId);
            this.dBContext.AddParameter("@RecipeId", obj.RecipeId);
            this.dBContext.AddParameter("@RatingValue", obj.Score);
            return this.dBContext.ChangeData(sql) > 0;
        }

        public Rating Select(string id)
        {
            string sql = $"SELECT * FROM Ratings WHERE RatingId = @RatingId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.RatingCreator.CreateModel(reader);
            }
            return null;
        }

        public List<Rating> SelectAll()
        {
            List<Rating> ratings = new List<Rating>();
            string sql = $"SELECT * FROM Ratings";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    ratings.Add(this.modelCreator.RatingCreator.CreateModel(reader));
                }
            }
            return ratings;
        }

        public bool Update(Rating item)
        {
            string sql = $"UPDATE Ratings SET UserId = @UserId, RecipeId = @RecipeId, RatingValue = @RatingValue WHERE RatingId = @RatingId";
            this.dBContext.AddParameter("@RatingId", item.RatingID);
            this.dBContext.AddParameter("@UserId", item.UserId);
            this.dBContext.AddParameter("@RecipeId", item.RecipeId);
            this.dBContext.AddParameter("@RatingValue", item.Score);
            return this.dBContext.ChangeData(sql) > 0;
        }
    }
}
