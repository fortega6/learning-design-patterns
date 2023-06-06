using System.Linq;
using UnityEngine;

namespace Patterns.Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemyPrefabs;

        public void Create(string enemyId)
        {
            var enemyPrefab = _enemyPrefabs.First(enemy => enemy.Id.Equals(enemyId));

            Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}
