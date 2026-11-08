using System.Data;

namespace WSCookBook.ORM
{
    public interface I_ModelCreator<T>
    {
        T CreateModel(IDataReader dataReader);

    }
}
