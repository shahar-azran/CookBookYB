using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class UnitCreator : I_ModelCreator<Unit>
    {
        public Unit CreateModel(IDataReader dataReader)
        {
            Unit unit = new Unit();
            {
                unit.UnitId = Convert.ToInt32(dataReader["UnitID"]);
                unit.UnitName = Convert.ToString(dataReader["UnitName"]);
                unit.UnitSymbol = Convert.ToString(dataReader["UnitSymbol"]);
            }
            return unit;
        }
    }
}
