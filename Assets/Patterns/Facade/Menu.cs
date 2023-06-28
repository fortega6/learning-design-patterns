using System.Collections.Generic;
using Patterns.Adapter;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Facade
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;
        
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PlayerSpawner _playerSpawner;
        private DataStore _dataStore;

        private void Awake()
        {
            _saveButton.onClick.AddListener(SaveGame);
            _loadButton.onClick.AddListener(LoadGame);
            _dataStore = new PlayerPrefsDataStoreAdapter();
        }

        private void SaveGame()
        {
            var saveData = new SaveData(_enemySpawner.Enemies,_playerSpawner.Player);
            _dataStore.SetData(saveData, "SaveData");
        }
        
        private void LoadGame()
        {
            var saveData = _dataStore.GetData<SaveData>("SaveData");
            _enemySpawner.Enemies = saveData.Enemies;
            _playerSpawner.Player = saveData.Player;
        }
    }
}
