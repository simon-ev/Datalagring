using Data.Factories;
using Data.Helpers;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class CustomerService(CustomerRepository customerRepository)
{
    private readonly CustomerRepository _customerRepository = customerRepository;

    public async Task CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var customerEntity = CustomerFactory.CreateCustomerEntity(form);
        await _customerRepository.AddAsync(customerEntity!);

        //return true;
    }
    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var customerEntities = await _customerRepository.GetAsync();

        return customerEntities.Select(CustomerFactory.Create)!;

    }

    public async Task<Customer> GetCustomerByNameAsync(string customerName)
    {
        var customerEntity = await _customerRepository.GetAsync(c => EF.Functions.Like(c.CustomerName, customerName));
        if (customerEntity == null)
        {
            return null!;
        }
        return CustomerMapper.MapToModel(customerEntity);
    }
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);

        return CustomerFactory.Create(customerEntity!);
    }
    public async Task<Customer?> GetCustomerByCustomerNameAsync(string customerName)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
        return CustomerFactory.Create(customerEntity!);
    }
    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        var customerEntity = CustomerFactory.CreateCustomerEntity(customer);
        if (customerEntity == null)
        {
            return false;
        }
        await _customerRepository.UpdateAsync(customerEntity);
        return true;
    }
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        if (customerEntity == null)
        {
            return false;
        }
        await _customerRepository.RemoveAsync(customerEntity);
        return true;
    }
}
