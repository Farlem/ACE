using System;

using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Server.Network.GameMessages.Messages;
using ACE.Server.WorldObjects;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ACE.Server.Entity
{
    public class CorpseLog
    {
        public ObjectGuid Corpse;

        public string Killer;

        public DateTime Time;

        public string Location;

        public DateTime DecayTime;

        public CorpseLog(ObjectGuid corpse, string killer, Position position, int playerLevel)
        {
            Corpse = corpse;

            Killer = killer;

            Time = DateTime.UtcNow;

           // if (DungeonLandblocks.TryGetValue(position.Landblock.LandblockId))

           // else
           // {
                var coordsNS = (position.LandblockY * 192 + position.CellY + position.PositionY) / 240 - 101.95f;
                var coordsEW = (position.LandblockX * 192 + position.CellX + position.PositionX) / 240 - 101.95f;

                var nS = coordsNS > 0 ? "N" : "S";
                var eW = coordsEW > 0 ? "E" : "W";

                coordsNS = Math.Abs(coordsNS);
                coordsEW = Math.Abs(coordsEW);

                Location = $"{Math.Round(coordsNS, 2)} {nS}, {Math.Round(coordsEW, 2)} {eW}.";
          //  }

            var minutesToDecay = playerLevel * 60;
            DecayTime = DateTime.UtcNow.AddMinutes(minutesToDecay);

        }
    }
}
