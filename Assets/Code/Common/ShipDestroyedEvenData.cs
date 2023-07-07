using Ships.Common;

namespace Common
{
    public class ShipDestroyedEvenData : EventData
    {
        public readonly int ScoreToAdd;
        public readonly Teams Team;
        public readonly int InstanceId;
        public ShipDestroyedEvenData(int scoreToAdd, Teams team, int instanceId) : base(EventIds.ShipDestroyed)
        {
            ScoreToAdd = scoreToAdd;
            Team = team;
            InstanceId = instanceId;
        }
    }
}
