using InveTime.Database.Context;
using InveTime.DataEntities.Entities.Base;
using InveTime.Interfaces.Base.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InveTime.Services.Services.DbRepositories.Base
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly InveTimeDB _db;

        protected DbSet<T> Set { get; }

        protected virtual IQueryable<T> Items => Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(InveTimeDB db)
        {
            _db = db;
            Set = _db.Set<T>();
        }


        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            //Варианты реализации
            //_db.Entry(item).State = EntityState.Added;
            //Set.Add(item);
           
            await _db.AddAsync(item, Cancel).ConfigureAwait(false);

            if (AutoSaveChanges)
                await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return item;
        }


        public async Task<bool> ExistIdAsync(int id, CancellationToken Cancel = default)
        {
            return await Items.AnyAsync(item => item.Id == id, Cancel).ConfigureAwait(false);
        }


        public async Task<bool> ExistAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            return await Items.AnyAsync(i => i.Id == item.Id, Cancel).ConfigureAwait(false);
        }


        public async Task<IEnumerable<T>> GetAfterSkipAsync(int Skip, int Count, CancellationToken Cancel = default)
        {
            //Вариант реализации
            //return await Items
            //   .Skip(Skip)
            //   .Take(Count)
            //   .ToArrayAsync(Cancel);

            if (Count <= 0)
                return Enumerable.Empty<T>();

            IQueryable<T> query = Items switch
            {
                IOrderedQueryable<T> ordered_query => ordered_query,
                { } q => q.OrderBy(i => i.Id)
            };

            if (Skip > 0)
                query = query.Skip(Skip);

            return await query.Take(Count).ToArrayAsync(Cancel).ConfigureAwait(false);
        }


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default)
        {
            return await Items.ToArrayAsync(Cancel).ConfigureAwait(false);
        }


        public async Task<T> GetByIdAsync(int id, CancellationToken Cancel = default)
        {
            switch (Items)
            {
                case DbSet<T> set:
                    return await set.FindAsync(new object[] { id }, Cancel).ConfigureAwait(false);
                case { } items:
                    return await items.FirstOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);
                default:
                    throw new InvalidOperationException("Ошибка в определении источника данных");
            }
        }


        public async Task<int> GetCountAsync(CancellationToken Cancel = default)
        {
            return await Items.CountAsync(Cancel).ConfigureAwait(false);
        }


        public async Task<IPage<T>> GetPageAsync(int PageIndex, int PageSize, CancellationToken Cancel = default)
        {
            if (PageSize <= 0) return new Page(Enumerable.Empty<T>(), PageSize, PageIndex, PageSize);

            var query = Items;
            var total_count = await query.CountAsync(Cancel).ConfigureAwait(false);
            if (total_count == 0)
                return new Page(Enumerable.Empty<T>(), 0, PageIndex, PageSize);

            if (query is not IOrderedQueryable<T>)
                query = query.OrderBy(item => item.Id);

            if (PageIndex > 0)
                query = query.Skip(PageIndex * PageSize);

            query = query.Take(PageSize);

            var items = await query.ToArrayAsync(Cancel).ConfigureAwait(false);

            return new Page(items, total_count, PageIndex, PageSize);
        }


        public async Task<T> UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            //Варианты реализации
            //_db.Entry(item).State = EntityState.Modified;
            //Set.Update(item);

            _db.Update(item);

            if (AutoSaveChanges)
                await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return item;
        }


        public async Task<T> RemoveByIdAsync(int id, CancellationToken Cancel = default)
        {
            var item = Set.Local.FirstOrDefault(i => i.Id == id);
            if (item is null)
                item = await Set
                   .Select(i => new T { Id = i.Id })
                   .FirstOrDefaultAsync(i => i.Id == id, Cancel)
                   .ConfigureAwait(false);
            if (item is null)
                return null;

            return await RemoveAsync(item, Cancel).ConfigureAwait(false);
        }


        public async Task<T> RemoveAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (!await ExistIdAsync(item.Id, Cancel))
                return null;

            //Варианты реализации
            //_db.Entry(item).State = EntityState.Deleted;
            //Set.Remove(item);

            _db.Remove(item);

            if (AutoSaveChanges)
                await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return item;
        }


        public async Task<int> SaveChangesAsync(CancellationToken Cancel = default)
        {
            return await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }





        protected record Page(IEnumerable<T> Items, int TotalCount, int PageIndex, int PageSize) : IPage<T>
        {
            public int TotalPagesCount => (int)Math.Ceiling((double)TotalCount / PageSize);
        }
    }
}
