using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class CatagoriesRepository : Repository, I_Repository<Catagories>
    {
        public CatagoriesRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }

        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Catagories WHERE CatagoryId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(Catagories obj)
        {
            string sql = $@"INSERT INTO Catagories (CatagoryId, CatagoryName)" +
                         $@" VALUES (@CatagoryId, @CatagoryName)";
            this.dBContext.AddParameter("@CatagoryId", obj.CatId);
            this.dBContext.AddParameter("@CatagoryName", obj.CatagoryName);
            return this.dBContext.ChangeData(sql) > 0;
        }

        public Catagories Select(string id)
        {
            string sql = $"SELECT * FROM Catagories WHERE CatagoryId = @CatagoryId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.CatagoriesCreator.CreateModel(reader);
            }
            return null;
        }

        public List<Catagories> SelectAll()
        {
            List<Catagories> catagoriesList = new List<Catagories>();
            string sql = $"SELECT * FROM Catagories";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    catagoriesList.Add(this.modelCreator.CatagoriesCreator.CreateModel(reader));
                }
            }
            return catagoriesList;
        }

        public bool Update(Catagories item)
        {
            string sql = $"UPDATE Catagories SET CatagoryName = @CatagoryName WHERE CatagoryId = @CatagoryId";
            this.dBContext.AddParameter("@CatagoryId", item.CatId);
            this.dBContext.AddParameter("@CatagoryName", item.CatagoryName);
            return this.dBContext.ChangeData(sql) > 0;
        }
    }
}
