using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISaleService
    {
        Task<Sale> UpdateSaleAsync(Sale sale);
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task DeleteSaleAsync(Guid id);
    }
}
