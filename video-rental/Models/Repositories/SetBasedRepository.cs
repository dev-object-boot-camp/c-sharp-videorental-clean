using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using video_rental.Repositories;

namespace video_rental.Models.Repositories
{
    public class SetBasedRepository<T> where T : class
    {
        private readonly HashSet<T> objectSet;

        public SetBasedRepository()
        {
            objectSet = new HashSet<T>();
        }

        public SetBasedRepository(IEnumerable<T> entities)
        {
            objectSet = new HashSet<T>(entities);
        }

        public void Add(T entity)
        {
            if (entity == null) throw new NullObjectAddedException();
            objectSet.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentException();
            var listOfEntities = entities as IList<T> ?? entities.ToList();
            if (listOfEntities.Any(x=>x == null))
            {
                throw new NullObjectAddedException();
            }
            listOfEntities.ForEach(x=>objectSet.Add(x));
        }

        public HashSet<T> SelectAll()
        {
            return new HashSet<T>(objectSet);
        }

        public HashSet<T> SelectAll(IComparer<T> comparator)
        {
            var result = new List<T>(objectSet);
            result.Sort(comparator);
            return new HashSet<T>(result);
        }

        public HashSet<T> SelectSatisfying(Func<T, bool> specification)
        {
            return new HashSet<T>(objectSet.Where(specification).ToList());
        }

        public HashSet<T> SelectSatisfying(Func<T, bool> specification, IComparer<T> comparator)
        {
            var result = (IEnumerable<T>) objectSet.Where(specification).ToList();
            result.ToList().Sort(comparator);
            return new HashSet<T>(result);
        }

        public T SelectUnique(Func<T, bool> specification)
        {
            return objectSet.FirstOrDefault(specification);
        }
    }
}