using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siesa_Expenses.Models
{
    public class CompanyModel
    {
        [PrimaryKey,AutoIncrement]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
