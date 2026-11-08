using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class IngredientRepository : Repository, I_Repository<Ingredient>
    {
        public IngredientRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }

        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Ingredients WHERE IngredientId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }

        public bool Insert(Ingredient obj)
        {
            string sql = $@"INSERT INTO Ingredients (IngredientId, IngredientName)" +
                         $@" VALUES (@IngredientId, @IngredientName)";
            this.dBContext.AddParameter("@IngredientId", obj.IngredientID);
            this.dBContext.AddParameter("@IngredientName", obj.IngredientName);
            return this.dBContext.ChangeData(sql) > 0;
        }

        public Ingredient Select(string id)
        {
            string sql = $"SELECT * FROM Ingredients WHERE IngredientId = @IngredientId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.IngredientCreator.CreateModel(reader);
            }
            return null;
        }

        public List<Ingredient> SelectAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string sql = $"SELECT * FROM Ingredients";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    ingredients.Add(this.modelCreator.IngredientCreator.CreateModel(reader));
                }
            }
            return ingredients;
        }

        public bool Update(Ingredient item)
        {
            string sql = $"UPDATE Ingredients SET IngredientName = @IngredientName WHERE IngredientId = @IngredientId";
            this.dBContext.AddParameter("@IngredientId", item.IngredientID);
            this.dBContext.AddParameter("@IngredientName", item.IngredientName);
            return this.dBContext.ChangeData(sql) > 0;
        }
    }
}
