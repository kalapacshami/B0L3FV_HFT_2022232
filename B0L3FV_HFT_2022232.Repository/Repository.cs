using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace B0L3FV_HFT_2022232.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected GoblinDbContext ctx;

        public Repository(GoblinDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
        }

        public T Read(int id)
        {
            
        }

        public IQueryable<T> ReadAll()
        {
            
        }

        public void Update(T item)
        {
            
        }
    }
}
