using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public  class BaseRepository<T>:IBaseRepository<T>
    where T: class 
    {
        public BaseRepository(FileSharingContext fileSharingContxt)
        {
             if (fileSharingContxt == null)
            {
                throw new System.ArgumentException("An instance of DbContext is " +
                    "required to use this repository.", "context");
            }
            this.Context = fileSharingContxt;
            this.DbSet = this.Context.Set<T>();
        }
        protected FileSharingContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
            // var entry = this.Context.Entry(entity);
            // if (entry.State != EntityState.Detached)
            // {
            //     entry.State = EntityState.Added;
            // }
            // else
            // {
            //     this.DbSet.Add(entity);
            // }
        }

        public async Task AddAsync(T entity)
        {
             await this.DbSet.AddAsync(entity);
            
            // var entry = this.Context.Entry(entity);
            // if (entry.State != EntityState.Detached)
            // {
            //     entry.State = EntityState.Added;
            // }
            // else
            // {
            //     await this.DbSet.AddAsync(entity);
            // }
        }

        public void Delete(T entity)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);
            this.DbSet.Remove(entity);
        }

       

        public async Task DeleteAsync(int id)
        {
            var entity = await this.GetAsync(id);
            this.DbSet.Remove(entity);
        }

        public void Detach(T entity)
        {
            var  entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            //if (this.Context != null)
            //{
            //   this.Context.Dispose();
            //}
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet.AsNoTracking();
        }

        public async Task<T> GetAsync(int id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            Update(entity, o =>
            {
                var r = (IKey)o;
                return r.Id;


            });
        }

        public void Update(T entity, Func<T, int> getKey)
        {
            if (entity == null)
            {
                throw new System.ArgumentException("Cannot add a null entity.");
            }

            var entry = Context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = Context.Set<T>();
                T attachedEntity = set.Find(getKey(entity));

                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        public async  Task UpdateAsync(T entity)
        {
            await UpdateAsync(entity, o =>
            {
                var r = (IKey)o;
                return r.Id;


            });
        }

        public async Task UpdateAsync(T entity, Func<T, int> getKey)
        {
            if (entity == null)
            {
                throw new System.ArgumentException("Cannot add a null entity.");
            }

            var entry = Context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = Context.Set<T>();
                T attachedEntity = await set.FindAsync(getKey(entity));

                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }
    }
}