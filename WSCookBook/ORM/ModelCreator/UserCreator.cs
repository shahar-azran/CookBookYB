using System.Data;
using DTO_Library.Models;
namespace WSCookBook.ORM.ModelCreator
{
    public class UserCreator : I_ModelCreator<User>
    {
        public User CreateModel(IDataReader dataReader)
        {
            User user = new User();
            {
                user.UserId = Convert.ToString(dataReader["UserID"]);
                user.UserName = Convert.ToString(dataReader["UserName"]);
                user.UserEmail = Convert.ToString(dataReader["UserEmail"]);
                user.UserPassword = Convert.ToString(dataReader["UserPassword"]);
            }
            return user;
        }
    }
}
