using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    /// <summary>
    /// Effect class handle Attack properties.
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// Allow to choose the target which will see her propertie modified.
        /// </summary>
        public enum Target
        {
            NULL,
            ENEMY,
            SELF
        };

        /// <summary>
        /// Allow to choose the way the propertie will be modified.
        /// </summary>
        public enum PropertieEvolution
        {
            NULL,
            UP,
            DOWN
        };

        /// <summary>
        /// Allow to activate the modification of a propertie.
        /// </summary>
        public enum PropertieIsActivated
        {
            YES,
            NO
        };

        protected string Name;
        protected int Damage;
        protected int Power;
        protected int Defense;
        protected int Dodge;
        protected int Accuracy;
        protected int Speed;

        protected Target PowerTarget;
        protected Target DefenseTarget;
        protected Target DodgeTarget;
        protected Target AccuracyTarget;
        protected Target SpeedTarget;

        protected PropertieEvolution PowerEvolution;
        protected PropertieEvolution DefenseEvolution;
        protected PropertieEvolution DodgeEvolution;
        protected PropertieEvolution AccuracyEvolution;
        protected PropertieEvolution SpeedEvolution;

        protected PropertieIsActivated DamageIsActivated;
        protected PropertieIsActivated PowerIsActivated;
        protected PropertieIsActivated DefenseIsActivated;
        protected PropertieIsActivated DodgeIsActivated;
        protected PropertieIsActivated AccuracyIsActivated;
        protected PropertieIsActivated SpeedIsActivated;

        public Effect()
        {
            
        }

        public int getDamage()
        {
            return Damage;
        }
    }
}
