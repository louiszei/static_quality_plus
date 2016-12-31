using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using static static_quality.MapComponent_SQ;

namespace static_quality
{
    class _Plant : Plant
    {
        private bool _Resting

//        protected virtual bool Resting
        {
            get
            {
                if (settings.plant_rest == true)
                {
                    return GenLocalDate.DayPercent(this) < 0.25f || GenLocalDate.DayPercent(this) > 0.8f;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
