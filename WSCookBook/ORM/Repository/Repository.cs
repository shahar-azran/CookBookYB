using System;
using WSCookBook;
using DTO_Library.Models;
using WSCookBook.ORM.ModelCreator;
namespace WSCookBook.ORM
{
    public class Repository
    {
        protected DBContext dBContext;
        protected UOWModelCreator modelCreator;

        public Repository(DBContext dBContext, UOWModelCreator modelCreator)
        {
            this.dBContext = dBContext;
            this.modelCreator = modelCreator;
        }
    }
}
