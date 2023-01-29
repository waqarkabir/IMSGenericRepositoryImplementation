using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class CategoryRepository<T> where T : IBaseEntity
    {
        private readonly List<T> collection;

        public CategoryRepository()
        {
            collection = new List<T>();
        }

        public void Create(T item)
        {
            collection.Add(item);
        }
        //Through Reflections
        //public T GetCategoryById(int Id)
        //{

        //    var nameProp = typeof(T).GetProperty("Id");
        //    var result = collection.Where(x => nameProp.GetValue(x).Equals(Id));
        //    return result.FirstOrDefault();
        //}
        public T GetCategoryById(int Id)
        {
            
            return collection.Find(p=>p.Id == Id);
        }

        public IEnumerable<T> List()
        {
            return collection;
        }
        public void Delete(T item)
        {
            collection.Remove(item);
        }
        public void Update(int id, T item)
        {
            T entity = collection.FirstOrDefault(e=>e.Id == id);
            if (entity != null)
            {
                int index = collection.IndexOf(entity);
                collection[index] = item;
            }
        }

    }
}
