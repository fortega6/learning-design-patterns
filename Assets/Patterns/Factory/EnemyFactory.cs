using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Patterns.Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemyPrefabs;
        private Dictionary<string, Enemy> _idToEnemyPrefab;

        private void Awake()
        {
            _idToEnemyPrefab = new Dictionary<string, Enemy>();
            foreach (var enemyPrefab in _enemyPrefabs)
            {
                _idToEnemyPrefab.Add(enemyPrefab.Id, enemyPrefab);
            }
        }

        public void Create(string enemyId)
        {
            //var enemyPrefab = _enemyPrefabs.First(enemy => enemy.Id.Equals(enemyId));

            var enemyPrefab = _idToEnemyPrefab[enemyId];
            Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}
