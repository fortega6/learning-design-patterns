using UnityEngine;

namespace Ships.CheckDestroyLimits
{
    public class DoNotCheckDestroyLimitsStrategy : CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            return true;
        }
    }
}