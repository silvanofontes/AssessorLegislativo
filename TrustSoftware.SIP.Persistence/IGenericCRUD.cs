using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Persistence
{
    public interface IGenericCRUD<O>
    {
        void Save(O obj);

        void Update(O obj);

        void Delete(int id);

        O getById(int id);

        List<O> ListAll();
    }
}
