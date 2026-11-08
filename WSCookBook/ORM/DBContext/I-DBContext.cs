using System.Data;

namespace WSCookBook
{
    public interface I_DB_Context
    {
        void OpenConnection();
        void CloseConnection();

        IDataReader Select(string sql);
        int ChangeData(string sql);
        void OpenTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
    }
}
