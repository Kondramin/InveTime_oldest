using InveTime.Interfaces.Base.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InveTime.Interfaces.Base.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// This property using to safe data in database. When you need add/update/remove many entities at a time, 
        /// you need set this value to false. But don't forget to save data manually.
        /// </summary>
        bool AutoSaveChanges { get; set; }


        /// <summary>Add entity in database async</summary>
        /// <param name="item">New entity</param>
        /// <param name="Cancel"></param>
        /// <returns>Added(new) entity</returns>
        Task<T> AddAsync(T item, CancellationToken Cancel = default);


        /// <summary>Check existing entity by Id in database</summary>
        /// <param name="id">Id of entity</param>
        /// <param name="Cancel"></param>
        /// <returns>true/false</returns>
        Task<bool> ExistIdAsync(int id, CancellationToken Cancel = default);


        /// <summary>Check existing entity in database</summary>
        /// <param name="item">entity</param>
        /// <param name="Cancel"></param>
        /// <returns>true/false</returns>
        Task<bool> ExistAsync(T item, CancellationToken Cancel = default);


        /// <summary>Returning some count elements after skip</summary>
        /// <param name="Skip">Count skipping elements</param>
        /// <param name="Count">Count returning elements after skip</param>
        /// <param name="Cancel"></param>
        /// <returns>IEnumerable<Entity></returns>
        Task<IEnumerable<T>> GetAfterSkipAsync(int Skip, int Count, CancellationToken Cancel = default);


        /// <summary>Return all entities from database</summary>
        /// <param name="Cancel"></param>
        /// <returns>IEnumerable<entity></returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default);


        /// <summary>Return current entity async</summary>
        /// <param name="id">Id of entity</param>
        /// <returns>Current entity</returns>
        Task<T> GetByIdAsync(int id, CancellationToken Cancel = default);


        /// <summary>Return count of entities in database</summary>
        /// <param name="Cancel"></param>
        /// <returns>Count of entities</returns>
        Task<int> GetCountAsync(CancellationToken Cancel = default);


        /// <summary>Return page of entities from database</summary>
        /// <param name="PageIndex">Number of page</param>
        /// <param name="PageSize">Count of elements</param>
        /// <param name="Cancel"></param>
        /// <returns>Page of elements</returns>
        Task<IPage<T>> GetPageAsync(int PageIndex, int PageSize, CancellationToken Cancel = default);

        
        /// <summary>Update entity in database async</summary>
        /// <param name="item">Updating entity</param>
        /// <param name="Cancel"></param>
        /// <returns>Updated entity</returns>
        Task<T> UpdateAsync(T item, CancellationToken Cancel = default);


        /// <summary>Delete entity by id from database async</summary>
        /// <param name="id">entity id</param>
        /// <param name="Cancel"></param>
        /// <returns>Deleted entity</returns>
        Task<T> RemoveByIdAsync(int id, CancellationToken Cancel = default);

      
        /// <summary>Delete entity from database async</summary>
        /// <param name="item">entity</param>
        /// <param name="Cancel"></param>
        /// <returns>Deleted entity<returns>
        Task<T> RemoveAsync(T item, CancellationToken Cancel = default);

       
        /// <summary>Save database updates</summary>
        /// <param name="Cancel"></param>
        /// <returns>Count of saved entities</returns>
        Task<int> SaveChangesAsync(CancellationToken Cancel = default);

    }

    public interface IPage<out T>
    {
        /// <summary>Items on page</summary>
        IEnumerable<T> Items { get; }

        /// <summary>Count elements in database</summary>
        int TotalCount { get; }

        /// <summary>Index of page</summary>
        int PageIndex { get; }

        /// <summary>Size of page</summary>
        int PageSize { get; }

        /// <summary>Count of pages</summary>
        int TotalPagesCount { get; }
    }
}

