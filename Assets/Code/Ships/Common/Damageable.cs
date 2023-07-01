using System.Collections;
using UnityEngine;

namespace Ships.Common
{
    public interface Damageable
    {
        Teams Team { get; }

        void AddDamage(int amount);
    }
}