using System.Data;
using DTO_Library.Models;
using WSCookBook.ORM;
using WSCookBook.ORM.DBContext;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestDbContext();
            TestCatagoriesCreator();

            Console.ReadLine();
        }
        static void TestDbContext()
        {
            DBContext dbContext = new DBContext();
            dbContext.OpenConnection();
            dbContext.ChangeData("Delete from RecipeCatagories where CatId = 11");
            dbContext.CloseConnection();
        }

        static void TestCatagoriesCreator()
        {
            DBContext dbContext = new DBContext();
            dbContext.OpenConnection();
            string sql = "Select * from Catagories";
            IDataReader reader = dbContext.Select(sql);
            List<Catagories> catagoriesList = new List<Catagories>();
            UOWModelCreator uOWModelCreator = new UOWModelCreator();
            while (reader.Read() == true)
            {
                Catagories catagories = uOWModelCreator.CatagoriesCreator.CreateModel(reader);
                catagoriesList.Add(catagories);
            }
            dbContext.CloseConnection();
            foreach (Catagories cat in catagoriesList)
            {
                Console.WriteLine($"CatId: {cat.CatId}, CatagoryName: {cat.CatagoryName}");
            }
        }
    }
}
