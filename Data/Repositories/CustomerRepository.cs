﻿
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;


public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
}

//public class CustomerRepository(DataContext context)
//{
//    private readonly DataContext _context = context;

//    // CREATE

//    // READ

//    // UPDATE

//    // DELETE
//    public async Task<bool> DeleteAsync(int id)
//    {
//        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
//        if (entity != null)
//        {
//            _context.Customers.Remove(entity);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        return false;
//    }
//}
