using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Utility.Enums
{
    #region "Geral"
    public enum StatusLogin
    {
        Inativo = 0,
        Ativo = 1,
        Bloqueado = 3
    }

    public enum SimNao
    {
        Sim = 1,
        Não = 0
    }

    public enum Sexo
    {
        Masculino = 2,
        Feminino = 4
    }

    public enum PerfilUsuario
    {
        Administrador = 1,
        Usuario = 2,
        Eleitor = 3,
        Parceiro = 4
    }

    public enum AnoLayout
    {
        Ate2008 = 1,
        Apos2012 = 0,
        Apos2014 = 3
    }

    /// <summary>
    /// CODIGO_COR_RACA - Código da cor/raça do candidato (auto declaração)
    /// DESCRICAO_COR_RACA - Descrição da cor/raça do candidato (auto declaração)
    /// </summary>
    public enum CorRaca
    {
        BRANCA = 1,
        PRETA = 2,
        PARDA = 3,
        AMARELA = 4,
        INDIGINA = 5
    }


    #endregion

    #region "Eleições"

    public enum UnidadeEleitoral
    {
        BR = 1,
        ZZ = 2,
        VT = 3
    }

    #endregion

    public enum DBAction
    {
        Create = 1,
        Update = 2,
        Export = 3
    }
}
