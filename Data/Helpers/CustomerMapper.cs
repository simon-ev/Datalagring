

using Data.Entities;
using Data.Models;

namespace Data.Helpers;

public static class CustomerMapper
{

    public static Customer MapToModel(CustomerEntity entity)
    {
        return new Customer
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName
        };
    }


    public static CustomerEntity MapToEntity(Customer model)
    {
        return new CustomerEntity
        {
            Id = model.Id,
            CustomerName = model.CustomerName
        };
    }
}
