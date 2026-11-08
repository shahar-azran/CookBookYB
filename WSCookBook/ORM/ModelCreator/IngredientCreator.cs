using System.Data;
using DTO_Library.Models;

namespace WSCookBook.ORM.ModelCreator
{
    public class IngredientCreator : I_ModelCreator<Ingredient>
    {
        public Ingredient CreateModel(IDataReader dataReader)
        {
            Ingredient ingredient = new Ingredient();
            {
                ingredient.IngredientID = Convert.ToInt16(dataReader["IngredientID"]);
                ingredient.IngredientName = Convert.ToString(dataReader["IngredientName"]);
                ingredient.UnitId = Convert.ToInt16(dataReader["UnitId"]);
            }
            return ingredient;
        }
    }
}
