using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class RatingCreator : I_ModelCreator<Rating>
    {
        public Rating CreateModel(IDataReader dataReader)
        {
            Rating rating = new Rating();
            {
                rating.RatingID = Convert.ToInt32(dataReader["RatingID"]);
                rating.UserId = Convert.ToString(dataReader["UserID"]);
                rating.RecipeId = Convert.ToInt16(dataReader["RecipeID"]);
                rating.Score = Convert.ToInt16(dataReader["Score"]);
                rating.Comment = Convert.ToString(dataReader["Comment"]);
            }
            return rating;
        }
    }
}
