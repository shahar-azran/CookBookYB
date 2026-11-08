using System.Data;
using System.Data.OleDb;

namespace WSCookBook
{
    public class DBContext : I_DB_Context
    {
        OleDbConnection connection;
        //מטרתו ליצור קשר עם מסד נתונים
        //צריך לדעת את סוג המסד נתונים
        //צריך לדעת איפה ממוקם המסד נתונים במחשב
        OleDbCommand command;
        //תפקידו לשלוח פקודות למסד נתונים (update,insert...)
        OleDbDataReader reader;
        //תפקידו לשמור טבלאות ממסד נתונים
        OleDbTransaction transaction;
        //תפקידו לפקח על הטרנצקציה

        public DBContext()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\computer\yud bet\CookBookYB\WSCookBook\AppData\CookBook.accdb""";
            command = new OleDbCommand();
            command.Connection = connection;

        }
        public void CloseConnection()
        {
            connection.Close();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public int ChangeData(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void OpenTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IDataReader Select(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteReader();
        }

        public void AddParameter(string parameterName, object value)
        {
            this.command.Parameters.Add(new OleDbParameter(parameterName, value));
        }
    }
}
