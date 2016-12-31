using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using System.Reflection;
using Verse;
using UnityEngine;
using static static_quality.MapComponent_SQ;


namespace static_quality
{
    public static class _SkillRecord
    {
        public static FieldInfo _pawn;

        public static Pawn GetPawn(this SkillRecord _this)
        {
            if (_pawn == null)
            {
                _pawn = typeof(SkillRecord).GetField("pawn", BindingFlags.Instance | BindingFlags.NonPublic);
            }
            if (_pawn == null)
            {
                Log.ErrorOnce("Unable to reflect SkillRecord.pawn!", 305432421);
            }
            return (Pawn)_pawn.GetValue(_this);
        }

        public static void _Learn(this SkillRecord _this, float xp)
        {
            Pawn pawn = _this.GetPawn();

            if (xp < 0f && _this.Level == 0)
            {
                return;
            }
            if (xp > 0f)
            {
                if (pawn.needs.joy != null)
                {
                    float amount = 0f;
                    switch (_this.passion)
                    {
                        case Passion.None:
                            amount = 0f * xp;
                            break;
                        case Passion.Minor:
                            amount = 1.5E-05f * xp;
                            break;
                        case Passion.Major:
                            amount = 3E-05f * xp;
                            break;
                    }
                    pawn.needs.joy.GainJoy(amount, JoyKindDefOf.Work);
                }
                xp *= _LearningFactor(pawn.GetStatValue(StatDefOf.GlobalLearningFactor, true), _this.passion, _this.LearningSaturatedToday);
            }
            _this.xpSinceLastLevel += xp;
            _this.xpSinceMidnight += xp;

            if (_this.xpSinceLastLevel >= _this.XpRequiredForLevelUp)
            {
                if (_this.Level != 20)
                {
                    _this.xpSinceLastLevel -= _this.XpRequiredForLevelUp;
                    _this.Level++;
                    if (settings.passion_gain && (_this.passion != Passion.Major))
                    {
                        _CheckPassionIncrease(pawn, _this.def);
                    }
                }
                else
                {
                    _this.xpSinceLastLevel = _this.XpRequiredForLevelUp - 1f;
                }
            }
            if (_this.xpSinceLastLevel < 0f)
            {
                if (settings.no_delevel == false)
                {
                    _this.Level--;
                    _this.xpSinceLastLevel += _this.XpRequiredForLevelUp;
                    if (_this.Level <= 0)
                    {
                        _this.Level = 0;
                        _this.xpSinceLastLevel = 0f;
                    }
                } else
                {
                    _this.xpSinceLastLevel = 1f;
                }
            }
        }

        public static void _CheckPassionIncrease (Pawn pawn, SkillDef skilldef)
        {
            System.Random rng = new System.Random();
            int mod;
            mod = rng.Next(1, 11);
            //Log.Message("prereq met " + mod.ToString() + " " + (pawn.skills.GetSkill(skilldef).level).ToString());
            if (pawn.skills.GetSkill(skilldef).Level > mod)
            {
                if (pawn.skills.GetSkill(skilldef).passion == Passion.None)
                {
                    pawn.skills.GetSkill(skilldef).passion = Passion.Minor;
                } else if (pawn.skills.GetSkill(skilldef).passion == Passion.Minor)
                {
                    pawn.skills.GetSkill(skilldef).passion = Passion.Major;
                }

                int passion_total = 0;
                System.Collections.Generic.List<SkillRecord> li = new List<SkillRecord>();

                foreach (SkillRecord sr in pawn.skills.skills)
                {
                    if ((sr.passion > Passion.None) && (sr.def != skilldef))
                    {
                        ++passion_total;
                        li.Add(sr);
                    }
                }
                if (settings.passion_cap && (passion_total > 4))
                {
                    mod = rng.Next(0, passion_total);
                    --li[mod].passion;
                    //Log.Message("Passion decreased on" + li[mod].def.ToString());
                }
            }
        }

        public static float _LearningFactor(float global_lf, Passion passion, bool learning_saturated)
        {
            {
                if (DebugSettings.fastLearning)
                {
                    return 200f;
                }

                float num = global_lf - 1f;
                if (settings.passion_tweak == false)
                {
                    switch (passion)
                    {
                        case Passion.None:
                            num += 0.333f;
                            break;
                        case Passion.Minor:
                            num += 1f;
                            break;
                        case Passion.Major:
                            num += 1.5f;
                            break;
                    }
                    if (learning_saturated)
                    {
                        num *= 0.2f;
                    }
                    return num;
                }
                else
                {
                    switch (passion)
                    {
                        case Passion.None:
                            num += 1f;
                            break;
                        case Passion.Minor:
                            num += 1.25f;
                            break;
                        case Passion.Major:
                            num += 1.5f;
                            break;
                    }
                    if (learning_saturated)
                    {
                        num *= 0.2f;
                    }
                    return num;
                }
            }
        }
    }
}
