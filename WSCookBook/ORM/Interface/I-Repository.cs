namespace WSCookBook.ORM
{
    public interface I_Repository<T>
    {
        //אלו פעולות CRUD
        bool Insert(T obj); //Create
        T Select(string id); //Read
        bool Update(T item); //Update
        bool Delete(string id); //Delete

        List<T> SelectAll(); //Read All
    }
}
