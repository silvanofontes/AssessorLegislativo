using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility;

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
            base.AddCriteria(x => x.UserName, Utility.Criteria.Eq, login);
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

        /// <summary>
        /// 1 - Verifica se existe
        /// 2 - Se não existir, ele salva
        /// 3 - Se existir, não salva no banco
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario VerificaSalva(Usuario usuario)
        {
            if (base.getById(usuario.Id) == null)
                base.Save(usuario);

            return usuario;
        }

        /// <summary>
        /// Retorna o histórico de acessos do usuário.
        /// </summary>
        /// <param name="idUsuario">Id do Usuário</param>
        /// <returns>Lista de acessos do usuário</returns>
        public List<UsuarioAcesso> listAcessos(int idUsuario)
        {
            return new UsuarioAcessoNeg().listAcessosByUsuario(idUsuario);
        }
    }
}
