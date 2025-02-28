using Domain.Entities;
using Domain.Interfaces.Data;
using Domain.Interfaces.Services;

namespace Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            ApplyDiscounts(sale);
            await _saleRepository.Create(sale);
            LogEvent($"SaleCreated: {sale.Id}");
            return sale;
        }

        public async Task<Sale> UpdateSaleAsync(Sale sale)
        {
            ApplyDiscounts(sale);
            await _saleRepository.Update(sale);
            LogEvent($"SaleModified: {sale.Id}");
            return sale;
        }

        public async Task DeleteSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetById(id);
            if (sale == null) throw new Exception("Sale not Found");
            await _saleRepository.Delete(sale);
            LogEvent($"SaleCancelled: {id}");
        }

        public async Task<Sale> GetSaleByIdAsync(Guid id)
        {
            return await _saleRepository.GetById(id);
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.ListAll();
        }

        private void ApplyDiscounts(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20)
                    throw new InvalidOperationException("Cannot sell more than 20 items of the same product.");

                if (item.Quantity >= 10)
                    item.Discount = 0.20m;
                else if (item.Quantity >= 4)
                    item.Discount = 0.10m;
                else
                    item.Discount = 0m;
            }

            sale.TotalAmount = sale.Items.Sum(i => i.TotalAmount);
        }

        private void LogEvent(string message)
        {
            Console.WriteLine($"Event: {message}");
        }
    }
}
