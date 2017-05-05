using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    /// <summary>
    /// Attack class
    /// --> setTheSelfSharpmon() and setTheEnemy() methods must be initialized before to attack another sharpmon.
    /// </summary>
    public class Attack : Effect
    {
        public Sharpmon TheEnemy { get; set; }
        public Sharpmon SelfSharpmon { get; set; }

        public Attack(string name, int damage, PropertieIsActivated damageIsActivated, 
                    int power, PropertieIsActivated powerIsActivated, PropertieEvolution powerEvolution, Target powerTarget, 
                    int defense, PropertieIsActivated defenseIsActivated, PropertieEvolution defenseEvolution, Target defenseTarget, 
                    int dodge, PropertieIsActivated dodgeActivated, PropertieEvolution dodgeEvolution, Target dodgeTarget, 
                    int accuracy, PropertieIsActivated accuracyIsActivated, PropertieEvolution accuracyEvolution, Target accuracyTarget, 
                    int speed, PropertieIsActivated speedIsActivated, PropertieEvolution speedEvolution, Target speedTarget)
        {
            Name = name;
            Damage = damage;
            DamageIsActivated = damageIsActivated;

            Power = power;
            PowerIsActivated = powerIsActivated;
            PowerTarget = powerTarget;
            PowerEvolution = powerEvolution;

            Defense = defense;
            DefenseIsActivated = defenseIsActivated;
            DefenseTarget = defenseTarget;
            DefenseEvolution = defenseEvolution;

            Dodge = dodge;
            DodgeIsActivated = dodgeActivated;
            DodgeTarget = dodgeTarget;
            DodgeEvolution = dodgeEvolution;

            Accuracy = accuracy;
            AccuracyIsActivated = accuracyIsActivated;
            AccuracyTarget = accuracyTarget;
            AccuracyEvolution = accuracyEvolution;

            Speed = speed;
            SpeedIsActivated = speedIsActivated;
            SpeedTarget = speedTarget;
            SpeedEvolution = speedEvolution;

        }

        public void setTheEnemy(Sharpmon targetSharpmon)
        {
            TheEnemy = targetSharpmon;
        }

        public void setTheSelfSharpmon(Sharpmon selfSharpmon)
        {
            SelfSharpmon = selfSharpmon;
        }

        /// <summary>
        /// Check if float value get numbers under comma.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ValueIsPure(float value)
        {
            var intConv = (int)value; // = XX
            var floatConv = (float) intConv; // XX.0

            var final = (value - floatConv);

            if (final == 0.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetAttackName()
        {
            return Name;
        }

        /// <summary>
        /// Attack method, 
        /// Attack Formula: LauncherPower * Damage / TargetDefense
        /// Dodge Formula: (PlayerSharpmon Acc / (PlayerSharpmon Acc + EnemySharpmon Dodge)) + 0.1% chance
        /// </summary>
        public void LaunchAttack()
        {
            if (DamageIsActivated == PropertieIsActivated.YES)
            {
                int result; //final result

                var probaDodge = (float) ((SelfSharpmon.GetAccuracy()/(SelfSharpmon.GetAccuracy() + TheEnemy.GetDodge())) + 0.1);
                var tmpResult = (Power*Damage)/TheEnemy.GetDefense() + 1;

                result = tmpResult;
                Console.Beep(); //Beep sound
                TheEnemy.ReduceHp(result);
                

                if (SelfSharpmon.GetExperience() == 10)
                {
                    Console.WriteLine("This sharpmon Level Up !");
                    SelfSharpmon.IncrementLevel();
                    SelfSharpmon.ClearExperience();
                }
                    
            }

            if (PowerIsActivated == PropertieIsActivated.YES)
            {
                if (PowerEvolution == PropertieEvolution.DOWN)
                {
                    if (PowerTarget == Target.ENEMY)
                    {
                        TheEnemy.ReducePower(1);
                        Console.WriteLine("This sharpmon reduced -1 Power to her enemy.");
                    }
                    else if (PowerTarget == Target.SELF)
                    {
                        SelfSharpmon.ReducePower(1);
                        Console.WriteLine("This sharpmon lost -1 Power.");
                    }
                }
                else if (PowerEvolution == PropertieEvolution.UP)
                {
                    if (PowerTarget == Target.ENEMY)
                    {
                        TheEnemy.AddPower(1);
                        Console.WriteLine("This sharpmon win +1 Power to her enemy.");
                    }
                    else if (PowerTarget == Target.SELF)
                    {
                        SelfSharpmon.AddPower(1);
                        Console.WriteLine("This sharpmon win +1 Power.");
                    }
                }
            }

            if (DefenseIsActivated == PropertieIsActivated.YES)
            {
                if (DefenseEvolution == PropertieEvolution.DOWN)
                {
                    if (DefenseTarget == Target.ENEMY)
                    {
                        TheEnemy.ReduceDefense(1);
                        Console.WriteLine("This sharpmon reduced -1 Defense to her enemy.");
                    }
                    else if (DefenseTarget == Target.SELF)
                    {
                        SelfSharpmon.ReduceDefense(1);
                        Console.WriteLine("This sharpmon lost -1 Defense.");
                    }
                }
                else if (DefenseEvolution == PropertieEvolution.UP)
                {
                    if (DefenseTarget == Target.ENEMY)
                    {
                        TheEnemy.AddDefense(1);
                        Console.WriteLine("This sharpmon win +1 Defense to her enemy.");
                    }
                    else if (DefenseTarget == Target.SELF)
                    {
                        SelfSharpmon.AddDefense(1);
                        Console.WriteLine("This sharpmon win +1 Defense.");
                    }
                }
            }

            if (DodgeIsActivated == PropertieIsActivated.YES)
            {
                if (DodgeEvolution == PropertieEvolution.DOWN)
                {
                    if (DodgeTarget == Target.ENEMY)
                    {
                        TheEnemy.ReduceDodge(1);
                        Console.WriteLine("This sharpmon reduced -1 Dodge to her enemy.");
                    }
                    else if (DodgeTarget == Target.SELF)
                    {
                        SelfSharpmon.ReduceDodge(1);
                        Console.WriteLine("This sharpmon lost -1 Dodge.");
                    }
                }
                else if (DodgeEvolution == PropertieEvolution.UP)
                {
                    if (DodgeTarget == Target.ENEMY)
                    {
                        TheEnemy.AddDodge(1);
                        Console.WriteLine("This sharpmon win +1 Dodge to her enemy.");
                    }
                    else if (DodgeTarget == Target.SELF)
                    {
                        SelfSharpmon.AddDodge(1);
                        Console.WriteLine("This sharpmon win +1 Dodge.");
                    }
                }
            }

            if (AccuracyIsActivated == PropertieIsActivated.YES)
            {
                if (AccuracyEvolution == PropertieEvolution.DOWN)
                {
                    if (AccuracyTarget == Target.ENEMY)
                    {
                        TheEnemy.ReduceAccuracy(1);
                        Console.WriteLine("This sharpmon reduced -1 Accuracy to her enemy.");
                    }
                    else if (AccuracyTarget == Target.SELF)
                    {
                        SelfSharpmon.ReduceAccuracy(1);
                        Console.WriteLine("This sharpmon lost -1 Accuracy.");
                    }
                }
                else if (AccuracyEvolution == PropertieEvolution.UP)
                {
                    if (AccuracyTarget == Target.ENEMY)
                    {
                        TheEnemy.AddAccuracy(1);
                        Console.WriteLine("This sharpmon win +1 Accuracy to her enemy.");
                    }
                    else if (AccuracyTarget == Target.SELF)
                    {
                        SelfSharpmon.AddAccuracy(1);
                        Console.WriteLine("This sharpmon win +1 Accuracy.");
                    }
                }
            }

            if (SpeedIsActivated == PropertieIsActivated.YES)
            {
                if (SpeedEvolution == PropertieEvolution.DOWN)
                {
                    if (SpeedTarget == Target.ENEMY)
                    {
                        TheEnemy.ReduceSpeed(1);
                        Console.WriteLine("This sharpmon reduced -1 Speed to her enemy.");
                    }
                    else if (SpeedTarget == Target.SELF)
                    {
                        SelfSharpmon.ReduceSpeed(1);
                        Console.WriteLine("This sharpmon lost -1 Speed.");
                    }
                }
                else if (SpeedEvolution == PropertieEvolution.UP)
                {
                    if (SpeedTarget == Target.ENEMY)
                    {
                        TheEnemy.AddSpeed(1);
                        Console.WriteLine("This sharpmon win +1 Speed to her enemy.");
                    }
                    else if (SpeedTarget == Target.SELF)
                    {
                        SelfSharpmon.AddSpeed(1);
                        Console.WriteLine("This sharpmon win +1 Speed.");
                    }
                }
            }


        }


    }
}
