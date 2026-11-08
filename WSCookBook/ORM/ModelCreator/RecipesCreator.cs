using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class RecipesCreator : I_ModelCreator<Recipes>
    {
        public Recipes CreateModel(IDataReader dataReader)
        {
            Recipes recipes = new Recipes();
            {
                recipes.RecipeId = Convert.ToInt32(dataReader["RecipeID"]);
                recipes.RecipesName = Convert.ToString(dataReader["RecipeName"]);
                recipes.UserId = Convert.ToString(dataReader["UserID"]);
                recipes.CatId = Convert.ToInt16(dataReader["CatID"]);
                recipes.PreperationMethod = Convert.ToString(dataReader["RecipeInstructions"]);
                recipes.DishPhoto = Convert.ToString(dataReader["RecipeImage"]);
            }
            return recipes;
        }
    }
}
