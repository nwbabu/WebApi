using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public interface IClientKeys
    {
        bool IsUniqueKeyAlreadyGenerate(int UserID);
        void GenerateUniqueKey(out string ClientID, out string ClientSecert);
        int SaveClientIDandClientSecert(ClientKeys ClientKeys);
        int UpdateClientIDandClientSecert(ClientKeys ClientKeys);
        ClientKeys GetGenerateUniqueKeyByUserID(int UserID);
    }
}
