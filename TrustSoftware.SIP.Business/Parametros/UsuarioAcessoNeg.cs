using System.Collections.Generic;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business.Parametros
{
    public class UsuarioAcessoNeg : GenericBusiness<UsuarioAcesso>
    {
        public UsuarioAcessoNeg() { }

        public bool Save(UsuarioAcesso acesso)
        {
            return base.Save(acesso);
        }

        public List<UsuarioAcesso> listAcessosByUsuario(int idUsuario)
        {
            base.AddCriteria(x => x.Usuario, Criteria.Eq, idUsuario);
            return base.listByFilter();
        }


    }
}
