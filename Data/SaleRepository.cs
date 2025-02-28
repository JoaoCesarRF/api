using Domain.Entities;
using Domain.Interfaces.Data;

namespace Data
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
