using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class CandidaturaNeg : GenericBusiness<Candidatura>
    {
        public CandidaturaNeg(Usuario usuario)
        {
            if (usuario != null)
            {
                switch (usuario.Perfil)
                {
                    case PerfilUsuario.Administrador:
                        break;

                    case PerfilUsuario.Parlamentar:
                    case PerfilUsuario.Usuario:
                    case PerfilUsuario.Eleitor:

                        if (usuario.Empresa != null)
                        {
                            for (int i = 0; i < usuario.Empresa.Candidaturas.Count; i++)
                            {
                                base.AddCriteria(x => x.Id, Criteria.Eq, usuario.Empresa.Candidaturas[i].Id);
                            }
                        }
                        else
                        {
                            ///throw new Exception("Usuário não possui empresa associada");
                        }
                        break;

                }
            }

        }
    }
}
