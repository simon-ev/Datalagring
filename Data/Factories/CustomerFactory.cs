using Data.Entities;
using Data.Models;

namespace Data.Factories;

public static class CustomerFactory
{
    public static CustomerEntity? CreateCustomerEntity(CustomerRegistrationForm form) => form == null ? null : new()
    {
        CustomerName = form.CustomerName,
    };

    public static Customer? Create(CustomerEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,
    };

    public static CustomerEntity? CreateCustomerEntity(Customer customer) => customer == null ? null : new()
    {
        Id = customer.Id,
        CustomerName = customer.CustomerName,
    };
}
