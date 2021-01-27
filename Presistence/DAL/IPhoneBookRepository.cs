
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Presistence.DAL
{
    public  interface IPhoneBookRepository<T> : IGenericRepository<T> where T:class
    {
        Task<T> FindAsync(Guid Id);
    }
}