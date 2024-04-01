using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ACE.Common;
using ACE.Database.Models.Shard;
using ACE.Entity;
using ACE.Server.Entity;
using ACE.Server.WorldObjects;
using Serilog;
using static ACE.Common.DerethDateTime;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace ACE.Server.Managers
{
    public class CorpseManager
    {
        private readonly ILogger _log = Log.ForContext<CorpseManager>();

        public Player Player { get; }

        /// <summary>
        /// Constructs a new CorpseManager for a Player / Creature
        /// </summary>
        public CorpseManager(Player player)
        {
            Player = player;
        }

        public CharacterPropertiesCorpseRegistry GetCorpse(ObjectGuid corpse)
        {
            return Player.Character.GetCorpse(corpse.Full, Player.CharacterDatabaseLock);
        }

        public List<CharacterPropertiesCorpseRegistry> GetCorpses()
        {
            return Player.Character.GetCorpses(Player.CharacterDatabaseLock);
        }

            public void AddCorpse(Player player, ObjectGuid corpse, string killer, Position position, DateTime time)
        {

            // if (DungeonLandblocks.TryGetValue(position.Landblock.LandblockId))

            // else
            // {
            var coordsNS = (position.LandblockY * 192 + position.CellY + position.PositionY) / 240 - 101.95f;
            var coordsEW = (position.LandblockX * 192 + position.CellX + position.PositionX) / 240 - 101.95f;

            var nS = coordsNS > 0 ? "N" : "S";
            var eW = coordsEW > 0 ? "E" : "W";

            coordsNS = Math.Abs(coordsNS);
            coordsEW = Math.Abs(coordsEW);

            var location = $"{Math.Round(coordsNS, 2)} {nS}, {Math.Round(coordsEW, 2)} {eW}.";
            //  }

            var minutesToDecay = (int)player.Level * 60;
            var decayTime = DateTime.UtcNow.AddMinutes(minutesToDecay);

            player.Character.AddCorpse(corpse, killer, location, DateTime.UtcNow, decayTime, player.CharacterDatabaseLock, out bool added);

             if (added)
                player.CharacterChangesDetected = true;
        }

          public void RemoveCorpse(CharacterPropertiesCorpseRegistry corpse)
        {
           var removed = Player.Character.TryRemoveCorpse(corpse.Corpse, Player.CharacterDatabaseLock);

           if (removed)
                Player.CharacterChangesDetected = true;
        }
    }
}



