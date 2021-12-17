using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class VacancyContext : DbContext
    {
        public VacancyContext(DbContextOptions<VacancyContext> options)
            : base(options)
        {

        }

        public DbSet<Vacancy> Vacancy { get; set; }

        public IQueryable<Vacancy> SearchVacancies(string fio_vlad)
        {
            var sql = "";
            SqlParameter parameter = new SqlParameter();
            if (!string.IsNullOrEmpty(fio_vlad))
            {
                if (DateTime.TryParse(fio_vlad, out var dateTime))
                {
                    sql = "EXEC Search_by_date @p0";
                    parameter = new SqlParameter("@p0", dateTime);
                }
                else if (Convert.ToInt32(fio_vlad) == 1 || Convert.ToInt32(fio_vlad) == 0)
                {
                    sql = "EXEC Search_by_int @p0";
                    parameter = new SqlParameter("@p0", Convert.ToInt32(fio_vlad));
                }
                else
                {
                    sql = "EXEC Select_data @p0";
                    parameter = new SqlParameter("@p0", fio_vlad);
                }
            }
             
            return Vacancy.FromSqlRaw(sql, parameter);
        }
    }
}
