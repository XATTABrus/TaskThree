using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskThree.Part2
{
    public static class Repository
    {
        private static readonly Dictionary<Type, Dictionary<Guid, object>> _repository;
        static Repository() { _repository = new Dictionary<Type, Dictionary<Guid, object>>(); }

        public static T Create<T>() where T : class, new() // Ввел ограничение на наличие ссылочного типа, посколькоку в 3 методе должна быть возможность возвращать null. 
        {
            var obj = new T();
            var type = typeof (T);
            var guid = Guid.NewGuid();

            if (!_repository.ContainsKey(type))
                _repository[type] = new Dictionary<Guid, object>();

            _repository[type][guid] = obj;
            return obj;
        }

        public static Dictionary<Guid, T> GetAllGuidAndObjectForType<T>() where T: class
        {
            return _repository.ContainsKey(typeof(T)) ? _repository[typeof(T)].ToDictionary(x => x.Key, x => (T)x.Value) : new Dictionary<Guid, T>();
        }

        public static T GetObjectByGuid<T> (Guid guid) where T : class
        {
            var type = typeof (T);
            object result;

            _repository[type].TryGetValue(guid, out result);
            return result as T;
        }
    }
}
