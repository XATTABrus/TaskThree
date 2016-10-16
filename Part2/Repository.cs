using System;
using System.Collections;
using System.Collections.Generic;

namespace TaskThree.Part2
{
    static class Repository
    {
        private static Hashtable _repository;
        static Repository() { _repository = new Hashtable(); }

        public static T Create<T>() where T : class, new() // Ввел ограничение на наличие ссылочного типа, посколькоку в 3 методе должна быть возможность возвращать null. 
        {
            var type = new T();
            _repository.Add(Guid.NewGuid(), type);
            return type;
        }

        public static Dictionary<Guid, T> GetAllGuidAndObjectForType<T>() where T: class
        {
            var resultDictionary = new Dictionary<Guid, T>();
            foreach (var item in _repository.Keys)
            {
                var obj = _repository[item];
                if (obj is T)
                    resultDictionary.Add((Guid)item, (T)obj);
            }
            return resultDictionary;
        }

        public static T GetObjectByGuid<T> (Guid guid) where T : class
        {
            if (!_repository.Contains(guid))
                return null;
            return _repository[guid] as T;
        }
    }
}
