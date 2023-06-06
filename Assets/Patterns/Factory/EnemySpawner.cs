using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyId _enemyId1;
        [SerializeField] private EnemyId _enemyId2;

        [SerializeField] private EnemyFactory _enemyFactory;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                _enemyFactory.Create(_enemyId1.Value);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                _enemyFactory.Create(_enemyId2.Value);
            }
        }

        
    }
}
