using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    class Sharpidgey : Sharpmon
    {
        public Sharpidgey()
        {
            InitializeProperties("Sharpidgey", 11, 2, 2, 2, 1, 2);
            Attacks.Add(new Attack("Peeck", 1, Effect.PropertieIsActivated.YES,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));

            Attacks.Add(new Attack("Gust", 2, Effect.PropertieIsActivated.YES,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));

            Attacks.Add(new Attack("Sand-Attack", 3, Effect.PropertieIsActivated.NO,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                1, Effect.PropertieIsActivated.YES, Effect.PropertieEvolution.UP, Effect.Target.SELF,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));
        }
    }
}
