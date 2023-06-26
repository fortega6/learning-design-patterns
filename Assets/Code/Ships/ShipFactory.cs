using UnityEngine;

namespace Ships
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ShipBuilder Create(string id)
        {
            var prefab = _configuration.GetShipById(id);

            return new ShipBuilder()
                .FromPrebab(prefab);
        }
    }
}
