using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    public class Item
    {
        protected Sharpmon Target;

        public string Name { get; }
        public int Price { get; }
        public int SellPrice { get; }
        public String Description { get; }
        protected int Hp = 0;
        protected int Power = 0;
        protected int Defense = 0;
        protected int Dodge = 0;
        protected int Accuracy = 0;
        protected int Speed = 0;
        protected int Experience = 0;

        public Item(string _name, int _price, string _description, int _hp, int _power, int _defense, int _dodge, int _accuracy, int _speed, int _experience, Sharpmon _target)
        {
            Name = _name;
            Price = _price;
            SellPrice = Price/2;
            Description = _description;
            Hp = _hp;
            Power = _power;
            Defense = _defense;
            Dodge = _dodge;
            Accuracy = _accuracy;
            Speed = _speed;
            Experience = _experience;
            Target = _target;
        }

        public void setTarget(Sharpmon target)
        {
            Target = target;
        }


        public void Use()
        {

            if (Hp > 0)
            {
                if (Target.GetHp() + Hp > Target.GetBaseHp())
                {
                    int val = Target.GetBaseHp() - Target.GetHp();
                    Target.AddHp(val);
                }
                
            }

            if (Power > 0)
            {
                Target.AddPower(Power);
            }

            if (Defense > 0)
            {
                Target.AddDefense(Defense);
            }

            if (Dodge > 0)
            {
                Target.AddDodge(Dodge);
            }

            if (Accuracy > 0)
            {
                Target.AddAccuracy(Accuracy);
            }

            if (Speed > 0)
            {
                Target.AddSpeed(Speed);
            }

            if (Experience > 0)
            {
                Target.AddExperience(Experience);
            }

        }
    }
}
