using System;
using Patterns.Structural.Adapter;
using UnityEngine;

namespace Patterns.Behaviour.Strategy
{
    public class Consumer
    {
        private readonly DataStore _dataStore;

        public Consumer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("Hola", 4545);
            _dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            var data = _dataStore.GetData<Data>("data2");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}
