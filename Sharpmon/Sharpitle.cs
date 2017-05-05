﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    class Sharpitle : Sharpmon
    {
        public Sharpitle()
        {
            InitializeProperties("Sharpitle", 11, 1, 2, 2, 1, 2);
            Attacks.Add(new Attack("Pound", 2, Effect.PropertieIsActivated.YES,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));
            
            Attacks.Add(new Attack("Shell", 0, Effect.PropertieIsActivated.NO,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                1, Effect.PropertieIsActivated.YES, Effect.PropertieEvolution.UP, Effect.Target.SELF,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL,
                0, Effect.PropertieIsActivated.NO, Effect.PropertieEvolution.NULL, Effect.Target.NULL));
        }
    }
}
