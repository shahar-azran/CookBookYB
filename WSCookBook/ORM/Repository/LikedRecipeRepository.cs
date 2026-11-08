using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class LikedRecipeRepository : Repository, I_Repository<LikedRecipe>
    {
        public LikedRecipeRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }

        public bool Delete(string id)
        {
            string sql = $"DELETE FROM LikedRecipes WHERE LikedRecipeId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(LikedRecipe obj)
        {
            string sql = $@"INSERT INTO LikedRecipes (LikedRecipeId, UserId, RecipeId)" +
                         $@" VALUES (@LikedRecipeId, @UserId, @RecipeId)";
            this.dBContext.AddParameter("@LikedRecipeId", obj.LikeId);
            this.dBContext.AddParameter("@UserId", obj.UserId);
            this.dBContext.AddParameter("@RecipeId", obj.RecipeId);
            return this.dBContext.ChangeData(sql) > 0;
        }

        public LikedRecipe Select(string id)
        {
            string sql = $"SELECT * FROM LikedRecipes WHERE LikedRecipeId = @LikedRecipeId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.LikedRecipeCreator.CreateModel(reader);
            }
            return null;
        }

        public List<LikedRecipe> SelectAll()
        {
            List<LikedRecipe> likedRecipes = new List<LikedRecipe>();
            string sql = $"SELECT * FROM LikedRecipes";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    likedRecipes.Add(this.modelCreator.LikedRecipeCreator.CreateModel(reader));
                }
            }
            return likedRecipes;
        }

        public bool Update(LikedRecipe item)
        {
            string sql = $"UPDATE LikedRecipes SET UserId = @UserId, RecipeId = @RecipeId WHERE LikedRecipeId = @LikedRecipeId";
            this.dBContext.AddParameter("@LikedRecipeId", item.LikeId);
            this.dBContext.AddParameter("@UserId", item.UserId);
            this.dBContext.AddParameter("@RecipeId", item.RecipeId);
            return this.dBContext.ChangeData(sql) > 0;
        }
    }
}
