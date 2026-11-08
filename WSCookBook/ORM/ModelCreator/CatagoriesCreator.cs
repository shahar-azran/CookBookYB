using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class CatagoriesCreator : I_ModelCreator<Catagories>
    {
        public Catagories CreateModel(IDataReader dataReader)
        {
            Catagories recipeCatagories = new Catagories();
            {
                recipeCatagories.CatId = Convert.ToInt32(dataReader["CatId"]);
                recipeCatagories.CatagoryName = Convert.ToString(dataReader["CatagoryName"]);
            }
            return recipeCatagories;
        }
    }
}
