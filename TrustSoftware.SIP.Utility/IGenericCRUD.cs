using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Utility
{
    public interface IGenericCRUD<O>
    {
        string strErro { get; }
        bool Save(O obj);

        bool Update(O obj);

        bool Delete(int id);

        O getById(int id);

        List<O> ListAll();

        List<O> listByFilter(List<Parametro> parametros);
        List<O> listByFilter();

        O ByFilter(List<Parametro> parametros);
        O ByFilter();


        void AddCriteria(Criteria type, Parametro parametro);
        void AddAlias(Parametro parametro);

    }
}
