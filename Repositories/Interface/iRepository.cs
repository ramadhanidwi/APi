namespace APi.Repositories.Interface;

public interface iRepository<Key, Entity> where Entity : class 
{
    //Get All
    Task<IEnumerable<Entity>> GetAll(); //Method Asynchronus dengan tipe non void, IEnumerable biar datanya hanya readonly 

    //Get By Id 
    Task<Entity?> GetById(Key? key);

    //Insert 
    Task<int> Insert(Entity entity);

    //Update 
    Task<int> Update(Entity entity);

    //Delete 
    Task<int> Delete(Key key);
}
