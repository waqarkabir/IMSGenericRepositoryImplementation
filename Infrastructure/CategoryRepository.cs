using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CategoryRepository<T> where T : class
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

        public T GetCategoryById(int Id)
        {
            T item = null;
            foreach (var collectionItem in collection)
            {
                item = collectionItem;
                break;
            }
            return item;
        }

        public IEnumerable<T> List()
        {
            return collection;
        }
        public void Delete(T item)
        {
            collection.Remove(item);
        }
        public void Update(T item, Predicate<T> predicate)
        {
            int index = collection.FindIndex(predicate);
            if (index >= 0)
            {
                collection[index] = item;
            }
        }

    }
}
