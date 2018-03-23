using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDemo.Models
{
    public class RegisterCompanyConcrete :IRegisterCompany
    {
        DatabaseContext _context;
        public RegisterCompanyConcrete()
        {
            _context = new DatabaseContext();
        }

        public IEnumerable<RegisterCompany> ListofCompanies(int UserID)
        {
            try
            {
                var CompanyList = (from companies in _context.RegisterCompany
                                   where companies.UserID == UserID
                                   select companies).ToList();
                return CompanyList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(RegisterCompany entity)
        {
            try
            {
                _context.RegisterCompany.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(RegisterCompany entity)
        {
            try
            {
                var itemToRemove = _context.RegisterCompany.SingleOrDefault(x => x.CompanyID == entity.CompanyID);
                _context.RegisterCompany.Remove(itemToRemove);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RegisterCompany FindCompanyByUserId(int UserID)
        {
            try
            {
                var Company = _context.RegisterCompany.ToList().SingleOrDefault(x => x.UserID == UserID);
                return Company;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool ValidateCompanyName(RegisterCompany registercompany)
        {
            try
            {
                var result = (from company in _context.RegisterCompany
                              where company.Name == registercompany.Name &&
                                    company.EmailID == registercompany.EmailID
                              select company).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool CheckIsCompanyRegistered(int UserID)
        {
            try
            {
                var companyExists = _context.RegisterCompany.Any(x => x.UserID == UserID);

                if (companyExists)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}