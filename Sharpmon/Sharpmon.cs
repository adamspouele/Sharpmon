using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    /*
    - Name
    - Level (start at 1)
    - Experience (start at 0)
    - HP & MaxHP : Current and maximum Health Points
    - Power & BasePower: Current and base (beginning of the fight) power.
    o The more power the sharpmon has, the more damage it does per attack.
    - Defense & BaseDefense: Same as power, but for defense
    o The more defense the sharpmon has, the less damage it takes per attack.
    - Dodge & BaseDodge: Same as power, but for dodge
    o The more dodge the sharpmon has, the more it can dodge attacks.
    - Accuracy & BaseAccuracy: Same as power, but for accuracy
    o The more accuracy the sharpmon has, the less it can miss attacks.
    - speed: Determines the playing order in fight
    - A List of Attacks (described below)
    */
    public class Sharpmon
    {
        protected String Name = "";
        protected int Level = 1;
        protected int Experience = 1;

        //HP & MaxHP
        protected int HP = 0;
        protected int BaseHP = 0;

        //Power & BasePower
        protected int Power = 0;
        protected int BasePower = 0;

        //Defense & BaseDefense
        protected int Defense = 0;
        protected int BaseDefense = 0;

        //Dodge & BaseDodge
        protected int Dodge = 0;
        protected int BaseDodge = 0;

        //Accuracy & BaseAccuracy
        protected int Accuracy = 0;
        protected int BaseAccuracy = 0;

        //speed
        protected int Speed = 0;

        //Sharpmon Attacks list
        public List<Attack> Attacks = new List<Attack>(); 


        public Sharpmon()
        {

        }

        public virtual Sharpmon Clone()
        {
            var copy = (Sharpmon)MemberwiseClone();
            
            return copy;
        }

        public void InitializeProperties(string sharpmonName, int maximumHp, int initialPower, int initialDefense,
                                        int initialDodge, int initialAccuracy, int speed)
        {
            Name = sharpmonName;

            if (maximumHp <= 0)
            {
                HP = 5;
            }
            else
            {
                BaseHP = maximumHp;
                HP = maximumHp;
            }

            if (initialPower <= 0)
            {
                Power = 1;
            }
            else
            {
                BasePower = initialPower;
                Power = initialPower;
            }

            if (initialDefense <= 0)
            {
                Defense = 1;
            }
            else
            {
                BaseDefense = initialDefense;
                Defense = initialDefense;
            }

            if (initialDodge <= 0)
            {
                Dodge = 1;
            }
            else
            {
                BaseDodge = initialDodge;
                Dodge = initialDodge;
            }

            if (initialAccuracy <= 0)
            {
                Accuracy = 1;
            }
            else
            {
                BaseAccuracy = initialAccuracy;
                Accuracy = initialAccuracy;
            }

            this.Speed = speed;
        }

        public void RestoreProperties()
        {
            this.HP = this.BaseHP;
            this.Power = this.BasePower;
            this.Defense = this.BaseDefense;
            this.Dodge = this.BaseDodge;
            this.Accuracy = this.BaseAccuracy;
    }

        public String GetName()
        {
            return Name;
        }

        public void SetName(string newName)
        {
            Name = newName;
        }

        public int GetExperience()
        {
            return Experience;
        }

        public void AddExperience(int value)
        {
            Experience += value;
        }

        public void ClearExperience()
        {
            Experience = 1;
        }

        public void setExperience(int exp)
        {
            Experience = exp;
        }

        public int GetBaseHp()
        {
            return BaseHP;
        }

        public void AddMaxHp(int value)
        {
            BaseHP += value;
        }

        public int GetHp()
        {
            return HP;
        }

        public void AddHp(int value)
        {
            HP += value;
        }

        public void ReduceHp(int value)
        {
            HP -= value;
        }

        public void RestoreHp()
        {
            HP = BaseHP;
        }

        public int GetBasePower()
        {
            return BasePower;
        }

        public void AddBasePower(int value)
        {
             BasePower += value;
        }

        public int GetPower()
        {
            return Power;
        }

        public void ReducePower(int value)
        {
            Power -= value;
        }

        public void AddPower(int value)
        {
            Power += value;
        }

        public void RestorePower()
        {
            Power = BasePower;
        }

        public int GetBaseDefense()
        {
            return BaseDefense;
        }

        public void AddBaseDefense(int value)
        {
            BaseDefense += value;
        }

        public int GetDefense()
        {
            return Defense;
        }

        public void ReduceDefense(int value)
        {
            Defense -= value;
        }

        public void AddDefense(int value)
        {
            Defense += value;
        }

        public void RestoreDefense()
        {
            Power = BasePower;
        }

        public int GetBaseDodge()
        {
            return BaseDodge;
        }

        public void AddBaseDodge(int value)
        {
            BaseDodge += value;
        }

        public int GetDodge()
        {
            return Dodge;
        }

        public void ReduceDodge(int value)
        {
            Dodge -= value;
        }

        public void AddDodge(int value)
        {
            Dodge += value;
        }

        public void RestoreDodge()
        {
            Dodge = BaseDodge;
        }

        public int GetBaseAccuracy()
        {
            return BaseAccuracy;
        }

        public void AddBaseAccuracy(int value)
        {
            BaseAccuracy += value;
        }

        public int GetAccuracy()
        {
            return Accuracy;
        }

        public void ReduceAccuracy(int value)
        {
            Accuracy -= value;
        }

        public void AddAccuracy(int value)
        {
            Accuracy += value;
        }

        public void RestoreAccuracy()
        {
            Accuracy = BaseAccuracy;
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public void ReduceSpeed(int value)
        {
            Speed -= value;
        }

        public void AddSpeed(int value)
        {
            Speed += value;
        }

        public int getLevel()
        {
            return Level;
        }

        public void IncrementLevel()
        {
            Level += 1;
        }
    }
}
