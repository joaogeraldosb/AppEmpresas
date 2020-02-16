using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Services.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenService
    {
        string Generate(int id);

        void Validate(string token, int id, bool authenticate);
    }
}
