using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiDemo.Models
{
    public class ClientKeysConcrete:IClientKeys
    {
        DatabaseContext _context;
        public ClientKeysConcrete()
        {
            _context = new DatabaseContext();
        }

        public void GenerateUniqueKey(out string ClientID, out string ClientSecert)
        {
            ClientID = KeyGenerator.GetUniqueKey();
            ClientSecert =KeyGenerator.GetUniqueKey();
        }

        public bool IsUniqueKeyAlreadyGenerate(int UserID)
        {
            bool keyExists = _context.ClientKeys.Any(clientkeys => clientkeys.UserID.Equals(UserID));

            if (keyExists)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int SaveClientIDandClientSecert(ClientKeys ClientKeys)
        {
            _context.ClientKeys.Add(ClientKeys);
            return _context.SaveChanges();
        }

        public ClientKeys GetGenerateUniqueKeyByUserID(int UserID)
        {
            var clientkey = (from ckey in _context.ClientKeys
                             where ckey.UserID == UserID
                             select ckey).FirstOrDefault();
            return clientkey;
        }


        public int UpdateClientIDandClientSecert(ClientKeys ClientKeys)
        {
            _context.Entry(ClientKeys).State = EntityState.Modified;
            _context.SaveChanges();
            return _context.SaveChanges();
        }
    }
}