using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public interface IAuthenticate
    {
        ClientKeys GetClientKeysDetailsbyCLientIDandClientSecert(string clientID, string clientSecert);
        bool ValidateKeys(ClientKeys ClientKeys);
        bool IsTokenAlreadyExists(int CompanyID);
        int DeleteGenerateToken(int CompanyID);
        int InsertToken(TokensManager token);
        string GenerateToken(ClientKeys ClientKeys, DateTime IssuedOn);
    }
}
