using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private string _enemyId1;
        [SerializeField] private string _enemyId2;

        [SerializeField] private Enemy[] _enemyPrefabs;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                CreateEnemy(_enemyId1);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                CreateEnemy(_enemyId2);
            }
        }

        private void CreateEnemy(string enemyId)
        {
            var enemyPrefab = _enemyPrefabs.First(enemy => enemy.Id.Equals(enemyId));

            Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}
