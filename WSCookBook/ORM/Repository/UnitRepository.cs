using DTO_Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class UnitRepository : Repository, I_Repository<Unit>
    {
        public UnitRepository(DBContext dBContext, UOWModelCreator modelCreator) : base(dBContext, modelCreator)
        {
        }
        public bool Delete(string id)
        {
            string sql = $"DELETE FROM Units where UnitId = '{id}'";
            return this.dBContext.ChangeData(sql) > 0;
        }
        public bool Insert(Unit unit)
        {
            string sql = $@"INSERT INTO Units (UnitId, UnitName, UnitSymbol)" +
                         $@" VALUES (@UnitId, @UnitName, @UnitSymbol)";
            
            this.dBContext.AddParameter("@UnitId", unit.UnitId);
            this.dBContext.AddParameter("@UnitName", unit.UnitName);
            this.dBContext.AddParameter("@UnitSymbol", unit.UnitSymbol);

            return this.dBContext.ChangeData(sql) > 0;
        }
        public Unit Select(string id)
        {
            string sql = $"SELECT * FROM Units WHERE UnitId = @UnitId";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                reader.Read();
                return this.modelCreator.UnitCreator.CreateModel(reader);
            }
        }
        public List<Unit> SelectAll()
        {
            List<Unit> units = new List<Unit>();
            string sql = $"SELECT * FROM Units";
            using (IDataReader reader = this.dBContext.Select(sql))
            {
                while (reader.Read())
                {
                    units.Add(this.modelCreator.UnitCreator.CreateModel(reader));
                }
            } return units;
        }
        public bool Update(Unit item)
        {
            string sql = $"UPDATE Units SET UnitName = @UnitName, UnitSymbol = @UnitSymbol WHERE UnitId = @UnitId";
            this.dBContext.AddParameter("@UnitId", item.UnitId);
            this.dBContext.AddParameter("@UnitName", item.UnitName);
            this.dBContext.AddParameter("@UnitSymbol", item.UnitSymbol);
            return this.dBContext.ChangeData(sql) > 0;
        }

    }
}
