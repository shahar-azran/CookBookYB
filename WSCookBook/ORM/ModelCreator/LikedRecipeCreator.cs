using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class LikedRecipeCreator : I_ModelCreator<LikedRecipe>
    {
        public LikedRecipe CreateModel(IDataReader dataReader)
        {
            LikedRecipe likedRecipe = new LikedRecipe();
            {
                likedRecipe.LikeId = Convert.ToInt32(dataReader["LikedRecipeID"]);
                likedRecipe.UserId = Convert.ToString(dataReader["UserID"]);
                likedRecipe.RecipeId = Convert.ToInt16(dataReader["RecipeID"]);
            }
            return likedRecipe;
        }
    }
}
