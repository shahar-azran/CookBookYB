using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM.Repositories
{
    public class RecipeRepository : Repository, I_Repository<Recipes>
    {
        int allRecipes;

        public int AllRecipes
        {
            get { return allRecipes; }
        }
        public RecipeRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }
        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Recipes WHERE RecipeId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(Recipes recipe)
        {
            string sql = $@"INSERT INTO Recipes (RecipeId, UserId, CatId, RecipesName, PreperationMethod, DishPhoto)" +
                         $@" VALUES (@RecipeId, @UserId, @CatId, @RecipeName, @PreperationMethod, @DishPhoto)";
            this.dBContext.AddParameter("@RecipeId", recipe.RecipeId);
            this.dBContext.AddParameter("@UserId", recipe.UserId);
            this.dBContext.AddParameter("@CatId", recipe.CatId);
            this.dBContext.AddParameter("@RecipeName", recipe.RecipesName);
            this.dBContext.AddParameter("@PreperationMethod", recipe.PreperationMethod);
            this.dBContext.AddParameter("@DishPhoto", recipe.DishPhoto);

            return this.dBContext.ChangeData(sql) > 0;
        }

        public Recipes Select(string id)
        {
            string sql = $"SELECT * FROM Recipes WHERE RecipeId = @RecipeId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.RecipesCreator.CreateModel(reader);
            }
            return null;
        }

        public List<Recipes> SelectAll()
        {
            List<Recipes> recipes = new List<Recipes>();
            string sql = $"SELECT * FROM Recipes";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    recipes.Add(this.modelCreator.RecipesCreator.CreateModel(reader));
                }
            }
            return recipes;
        }

        public bool Update(Recipes item)
        {
            string sql = $"UPDATE Recipes SET UserId = @UserId, CatId = @CatId, RecipesName = @RecipesName, PreperationMethod = @PreperationMethod, DishPhoto = @DishPhoto WHERE RecipeId = @RecipeId";
            this.dBContext.AddParameter("@RecipeId", item.RecipeId);
            this.dBContext.AddParameter("@UserId", item.UserId);
            this.dBContext.AddParameter("@CatId", item.CatId);
            this.dBContext.AddParameter("@RecipesName", item.RecipesName);
            this.dBContext.AddParameter("@PreperationMethod", item.PreperationMethod);
            this.dBContext.AddParameter("@DishPhoto", item.DishPhoto);
            return this.dBContext.ChangeData(sql) > 0;
        }

        internal List<Recipes> GetRecipeByPage(int page, int recipesPerPage)
        {
            List<Recipes> recipes = this.SelectAll();
            this.allRecipes = recipes.Count;
            return recipes.Skip<Recipes>((page - 1) * recipesPerPage).Take(recipesPerPage).ToList<Recipes>();
        }
    }
}
