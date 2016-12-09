using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using static static_quality.MapComponent_SQ;


namespace static_quality
{
    class _SkillUI
    {
        private static string _GetSkillDescription(SkillRecord sk)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (sk.TotallyDisabled)
            {
                stringBuilder.Append("DisabledLower".Translate().CapitalizeFirst());
            }
            else
            {
                stringBuilder.AppendLine(string.Concat(new object[]
                {
                    "Level".Translate(),
                    " ",
                    sk.level,
                    ": ",
                    sk.LevelDescriptor
                }));
                if (Current.ProgramState == ProgramState.MapPlaying)
                {
                    string text = (sk.level != 20) ? "ProgressToNextLevel".Translate() : "Experience".Translate();
                    stringBuilder.AppendLine(string.Concat(new object[]
                    {
                        text,
                        ": ",
                        sk.xpSinceLastLevel.ToString("F0"),
                        " / ",
                        sk.XpRequiredForLevelUp
                    }));
                }
                stringBuilder.Append("Passion".Translate() + ": ");

                float val1, val2, val3;
                if (settings.passion_tweak == true)
                {
                    val1 = 1f;
                    val2 = 1.25f;
                    val3 = 1.5f;
                }
                else
                {
                    val1 = 0.333f;
                    val2 = 1f;
                    val3 = 1.5f;
                }

                switch (sk.passion)
                {
                    case Passion.None:
                        stringBuilder.Append("PassionNone".Translate(new object[]
                        {
                        val1.ToStringPercent("F0")
                        }));
                        break;
                    case Passion.Minor:
                        stringBuilder.Append("PassionMinor".Translate(new object[]
                        {
                        val2.ToStringPercent("F0")
                        }));
                        break;
                    case Passion.Major:
                        stringBuilder.Append("PassionMajor".Translate(new object[]
                        {
                        val3.ToStringPercent("F0")
                        }));
                        break;
                }
                if (sk.LearningSaturatedToday)
                {
                    int val;
                    if (settings.learning_saturation_tweak == true)
                    {
                        val = sk.level * 500 + 1000;
                    } else
                    {
                        val = 4000;
                    }

                    stringBuilder.AppendLine();
                    stringBuilder.Append("LearnedMaxToday".Translate(new object[]
                    {
                        sk.xpSinceMidnight,
                        val,
                        0.2f.ToStringPercent("F0")
                    }));
                }
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.Append(sk.def.description);
            return stringBuilder.ToString();
        }
    }
}
