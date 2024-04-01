using System;

using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    public class CorpseLog
    {
        public ObjectGuid Corpse;

        public string Killer;

        public DateTime Time;

        public Position Location;

        public double DecayTime;

        public CorpseLog(ObjectGuid corpse, string killer, Position position, double decayTime)
        {
            Corpse = corpse;

            Killer = killer;

            Time = DateTime.UtcNow;

            Location = position;

            DecayTime = decayTime;

        }
    }
}
