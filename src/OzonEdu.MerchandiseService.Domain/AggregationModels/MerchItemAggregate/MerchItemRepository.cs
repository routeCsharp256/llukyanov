using System;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItemRepository : IMerchItemRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        public Task<MerchItem> CreateAsync(MerchItem itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MerchItem> UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MerchItem> AskMerchItemAsync(int employeeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default)
        {
            // 1. Выясняем, есть ли мерч в нужном кол-ве с помощью команды CheckMerchItemAsync из этого репозитория
            // 2. Если мерча нет на складе в нужном кол-ве, вызываем метод ReserveMerchItemAsync из этого репозитория
            //////// на вход то кол-во мерча, которого не хватает для выполнения заявки 
            // 3. Возвращаем тот мерч, который можно выдать уже сейчас
            throw new NotImplementedException();
        }

        public Task<MerchItem> AskMerchItemAsync(int employeeId, EmployeeEventType employeeEventType, Sku sku,
            Quantity quantity,
            CancellationToken cancellationToken = default)
        {
            // 1. Проверяем, получил ли сотрудник данный мерч, всвязи с событием
            // 2. Выясняем, есть ли мерч в нужном кол-ве с помощью команды CheckMerchItemAsync из этого репозитория
            // 3. Если мерча нет на складе в нужном кол-ве, вызываем метод ReserveMerchItemAsync из этого репозитория
            //////// на вход то кол-во мерча, которого не хватает для выполнения заявки 
            // 4. Возвращаем тот мерч, который можно выдать уже сейчас
            throw new NotImplementedException();
        }

        public Task<MerchItem> CheckMerchItemAsync(Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default)
        {
            // 1. Отправляем запрос FindBySkuAsync() в StockAPI
            // 2. Возвращаем то, что есть в том кол-ве, которое есть (quantity = 0, если нет таких)
            throw new NotImplementedException();
        }

        public Task ReserveMerchItemAsync(int employeeId, Sku sku, Quantity quantity,
            CancellationToken cancellationToken = default)
        {
            // 1. Отправить команду StockAPI на то, что нужно поставить товар с SKU = sku в кол-ве = quantity
            throw new NotImplementedException();
        }
    }
}