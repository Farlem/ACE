using ACE.Entity;
using System;
using System.Collections.Generic;

#nullable disable

namespace ACE.Database.Models.Shard
{
    public partial class CharacterPropertiesCorpseRegistry
    {
        public uint CharacterId { get; set; }

        public uint Corpse { get; set; }

        public string Killer { get; set; }

        public DateTime Time { get; set; }

        public string Location { get; set; }

        public DateTime DecayTime { get; set; }

        public virtual Character Character { get; set; }
    }
}
