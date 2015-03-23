using System.Collections.Generic;
using SilvanoFontes.AL.Persistence;

namespace SilvanoFontes.AL.Business
{
    public class GenericBusiness<T>
    {
        GenericCRUD<T> objCRUD;


        public GenericBusiness()
        {
            objCRUD = new GenericCRUD<T>();
        }

        public void Save(T obj)
        {
            objCRUD.Save(obj);
        }

        public void Update(T obj)
        {
            objCRUD.Update(obj);
        }

        public void Delete(int id)
        {
            objCRUD.Delete(id);
        }

        public T gerById(int id)
        {
            return objCRUD.getById(id);
        }

        public List<T> ListAll()
        {
            return objCRUD.ListAll();
        }
    }
}
