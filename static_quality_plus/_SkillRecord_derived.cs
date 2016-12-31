using RimWorld;
using System.Reflection;
using Verse;
using static static_quality.MapComponent_SQ;


namespace static_quality
{
    public class _SkillRecord_derived : SkillRecord
    {



        public bool _LearningSaturatedToday
        {
            get
            {
                if (settings.learning_saturation_tweak == true)
                {
                    float val = this.Level * 500 + 1000;
                    return (this.xpSinceMidnight > val);
                }
                else
                {
                    return (this.xpSinceMidnight > 4000);
                }
            }
        }


        public void _Interval()
        {
            if (Find.TickManager.TicksAbs % 60000 <= 200)
            {
                this.xpSinceMidnight = 0f;
            }

//            if (skill_degrading == false)
            if (settings.skill_switch == 0)  // vanilla
            {
                switch (this.Level)
                {
                    case 10:
                        this.Learn(-0.1f);
                        break;
                    case 11:
                        this.Learn(-0.2f);
                        break;
                    case 12:
                        this.Learn(-0.4f);
                        break;
                    case 13:
                        this.Learn(-0.65f);
                        break;
                    case 14:
                        this.Learn(-1f);
                        break;
                    case 15:
                        this.Learn(-1.5f);
                        break;
                    case 16:
                        this.Learn(-2f);
                        break;
                    case 17:
                        this.Learn(-3f);
                        break;
                    case 18:
                        this.Learn(-4f);
                        break;
                    case 19:
                        this.Learn(-6f);
                        break;
                    case 20:
                        this.Learn(-8f);
                        break;
                }
            }
            else if (settings.skill_switch == 1)  // halved
            {
                switch (this.Level)
                {
                    case 10:
                        this.Learn(-0.1f*0.5f);
                        break;
                    case 11:
                        this.Learn(-0.2f * 0.5f);
                        break;
                    case 12:
                        this.Learn(-0.4f * 0.5f);
                        break;
                    case 13:
                        this.Learn(-0.65f * 0.5f);
                        break;
                    case 14:
                        this.Learn(-1f * 0.5f);
                        break;
                    case 15:
                        this.Learn(-1.5f * 0.5f);
                        break;
                    case 16:
                        this.Learn(-2f * 0.5f);
                        break;
                    case 17:
                        this.Learn(-3f * 0.5f);
                        break;
                    case 18:
                        this.Learn(-4f * 0.5f);
                        break;
                    case 19:
                        this.Learn(-6f * 0.5f);
                        break;
                    case 20:
                        this.Learn(-8f * 0.5f);
                        break;
                }
            }
            else if (settings.skill_switch == 2)  // mild
            {
                this.Learn(-0.1f);
            }
        }
    }
}
