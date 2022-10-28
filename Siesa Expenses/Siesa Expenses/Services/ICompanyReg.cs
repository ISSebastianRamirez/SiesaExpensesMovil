using Siesa_Expenses.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siesa_Expenses.Services
{
    public interface ICompanyReg
    {
        Task<bool> AddCompanyAsync(CompanyModel companyModel);
        Task<bool> UpdateCompnyAsync(CompanyModel companyModel);
        Task<bool> DeleteCompanyAsync(int id);
        Task<CompanyModel> GetCompanyAsync(int id);
        Task<IEnumerable<CompanyModel>> GetCompanyAsync();

    }
}
