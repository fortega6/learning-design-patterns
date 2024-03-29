using UnityEngine;

namespace Patterns.Structural.Adapter
{
    public class PlayerPrefsDataStoreAdapter : DataStore
    {
        public void SetData<T>(T data, string name)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(name, json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string name)
        {
            var json = PlayerPrefs.GetString(name);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
