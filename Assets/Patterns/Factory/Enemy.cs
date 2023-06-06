using UnityEngine;

namespace Patterns.Factory
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}
