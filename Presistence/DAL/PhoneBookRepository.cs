using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Presistence.DAL
{
    public class PhoneBookRepository<T> : IPhoneBookRepository<T> where T: PhoneBook
    {
        internal DataBaseContext _context =  new DataBaseContext() ;
        internal   IList<T> _entities;

        public PhoneBookRepository()
        {
//            _context = context;
            _entities = _context.Set<T>();
        }

       public async Task DeleteAsync(Guid Id)
        {
            await Task.Run(() =>
            {

                T entity = _entities.Where(x=> x.Id == Id).First();
                _entities.Remove(entity);
                _context.SaveChanges(_entities);
            });
        }

    public async Task<T> InsertAsync(T item)
    {
        try
        {
             return await Task.Run(() =>
        {
            _entities.Add(item);
            _context.SaveChanges(_entities);
            
            return item;

            });
        }
        catch (System.Exception)
        {
            
            return null;
        }     
    }

    public async Task<T> UpdateAsync(T item)
    {
         return await Task.Run(() =>
        {
            T entity = _entities.Where(x=> x.Id == item.Id).First();
            entity = item;
            _context.SaveChanges((IList<T>)_entities);
            return entity;
        });
        
    }

    public async Task<List<T>> GetEntitiesAsync()
    {
        return await Task.Run(() =>
        {
          return _entities as List<T>;
        });
    }

        public async Task<T> FindAsync(Guid Id)
        {
            return await Task.Run(() =>
            {
                return _entities.First(x=> x.Id == Id);
            });
        }
      
    }
}
