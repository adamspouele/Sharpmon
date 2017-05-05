using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    public class Sharpmender : Sharpmon
    {
        public Sharpmender()
        {
            InitializeProperties("Sharpmender", 10, 1, 1, 1, 2, 1);
            Attacks.Add(new Attack("Scratch", 3, Effect.PropertieIsActivated.YES, 
                0,Effect.PropertieIsActivated.NO,Effect.PropertieEvolution.NULL,Effect.Target.NULL,
                0,Effect.PropertieIsActivated.NO,Effect.PropertieEvolution.NULL, Effect.Target.NULL, 
                0,Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL, 
                0,Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL, 
                0,Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));

            Attacks.Add(new Attack("Grawl", 0, Effect.PropertieIsActivated.NO,
                1, Effect.PropertieIsActivated.YES, Effect.PropertieEvolution.UP, Effect.Target.SELF,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));
        }


    }
}
