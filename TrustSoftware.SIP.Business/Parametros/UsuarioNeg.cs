using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Business.Parametros
{
    public class UsuarioNeg : GenericBusiness<Usuario>
    {
        public UsuarioNeg() { }

        public Usuario getById(int id)
        {
            return base.getById(id);
        }

        public Usuario getByLogin(string login)
        {
            base.AddCriteria(x => x.Login, Utility.Criteria.Eq, login);

            return base.ByFilter();

        }

        public List<Usuario> listAll()
        {
            return base.ListAll();
        }

        public Usuario Update(Usuario usuario)
        {
            if (base.getById(usuario.Id) == null)
                base.Save(usuario);
            else
                base.Update(usuario);

            return usuario;
        }

        public Usuario VerificaSalva(Usuario usuario)
        {
            if (base.getById(usuario.Id) == null)
                base.Save(usuario);

            return usuario;
        }
    }
}
