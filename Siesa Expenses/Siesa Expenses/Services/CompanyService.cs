using Siesa_Expenses.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siesa_Expenses.Services
{
    public class CompanyService : ICompanyReg
    {
        public SQLiteAsyncConnection _database;
        public CompanyService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CompanyModel>().Wait();
        }
        public async Task<bool> AddCompanyAsync(CompanyModel companyModel)
        {
            if (companyModel.CompanyId>0)
            {
                await _database.UpdateAsync(companyModel);
            }
            else
            {
                await _database.InsertAsync(companyModel);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            await _database.DeleteAsync<CompanyModel>(id);
            return await Task.FromResult(true);
        }

        public async Task<CompanyModel> GetCompanyAsync(int id)
        {
            return await _database.Table<CompanyModel>().Where(p => p.CompanyId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompanyModel>> GetCompanyAsync()
        {
            return await Task.FromResult(await _database.Table<CompanyModel>().ToListAsync());
        }

        public Task<bool> UpdateCompnyAsync(CompanyModel companyModel)
        {
            throw new NotImplementedException();
        }
    }
}
