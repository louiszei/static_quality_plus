using System;
using UnityEngine;
using Verse;
using Object = UnityEngine.Object;

namespace static_quality       // Replace with yours.
{       // This code is mostly borrowed from Pawn State Icons mod by Dan Sadler, which has open source and no license I could find, so...
    [StaticConstructorOnStartup]
    public class MapComponentInjectorSQ : MonoBehaviour
    {
        private static Type static_quality = typeof(MapComponent_SQ);


        public void FixedUpdate()
        {
            if (Current.ProgramState != ProgramState.MapPlaying)
            {
                return;
            }


            if (Find.Map.components.FindAll(c => c.GetType() == static_quality).Count == 0)
            {
                Find.Map.components.Add((MapComponent)Activator.CreateInstance(static_quality));

                Log.Message("Static Quality :: Added to the map.");
            }
            Destroy(this);
        }

    }
}