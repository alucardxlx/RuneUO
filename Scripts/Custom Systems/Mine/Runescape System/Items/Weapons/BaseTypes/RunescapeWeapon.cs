﻿
using Server.Items;

namespace Server.Runescape
{
    public abstract class RunescapeWeapon : BaseWeapon
    {
        private RuneWeaponType mWeaponType;

        public RuneWeaponType WeaponType { get { return mWeaponType; } }

        public RunescapeWeapon(RuneWeaponType weaponType, int itemID)
            : base(itemID)
        {
            mWeaponType = weaponType;
        }

        public RunescapeWeapon(Serial serial)
            : base(serial)
        {
        }

        public override int Hue
        {
            get { return Utilities.Hue(WeaponType); }
            set { base.Hue = value; }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((int)mWeaponType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            switch (version)
            {
                case 0:
                    mWeaponType = (RuneWeaponType)reader.ReadInt();
                    break;
            }
        }
    }
}
