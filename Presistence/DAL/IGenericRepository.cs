using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace  Presistence.DAL
{
    public interface IGenericRepository<TEntity>  where TEntity : class
    {
        Task DeleteAsync(Guid item);
        Task<TEntity> InsertAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task<List<TEntity>> GetEntitiesAsync();
        //Task<List<TEntity>> GetOrderdListBy(string byProperty);

    }
    
}