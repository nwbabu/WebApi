using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public interface IRegisterCompany
    {
      
            IEnumerable<RegisterCompany> ListofCompanies(int UserID);
            void Add(RegisterCompany entity);
            void Delete(RegisterCompany entity);
           // void Update(RegisterCompany entity);
            RegisterCompany FindCompanyByUserId(int UserID);
            bool ValidateCompanyName(RegisterCompany registercompany);
            bool CheckIsCompanyRegistered(int UserID);
        
    }
}
