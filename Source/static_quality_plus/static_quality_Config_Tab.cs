using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;
using static static_quality.MapComponent_SQ;

namespace static_quality
{
    internal class static_quality_Config_Tab : MainTabWindow
    {

        public override Vector2 InitialSize
        {
            get
            {
                return new Vector2(380, 600);
            }
        }

        public override void DoWindowContents(Rect canvas)
        {
            Listing_Standard listing_Standard = new Listing_Standard(canvas);
            //            listing_Standard.
            //            listing_Standard.set_ColumnWidth(rect.get_width() - 4f);
            listing_Standard.Label("Item quality options:");
            listing_Standard.Gap(12f);
            bool[] qs = new bool[4];
            qs[0] = listing_Standard.RadioButton("Vanilla quality", (settings.quality_switch == 0), 0f);
            qs[1] = listing_Standard.RadioButton("Static quality", (settings.quality_switch == 1), 0f);
            qs[2] = listing_Standard.RadioButton("Static quality +/- 1", (settings.quality_switch == 2), 0f);
            qs[3] = listing_Standard.RadioButton("Static quality +/- 2", (settings.quality_switch == 3), 0f);
            listing_Standard.Gap(24f);
            bool[] ss = new bool[4];
            listing_Standard.Label("Skill options:");
            listing_Standard.Gap(12f);
            ss[0] = listing_Standard.RadioButton("Vanilla degrading", (settings.skill_switch == 0), 0f);
            ss[1] = listing_Standard.RadioButton("Halved degrading", (settings.skill_switch == 1), 0f);
            ss[2] = listing_Standard.RadioButton("Mild degrading", (settings.skill_switch == 2), 0f);
            ss[3] = listing_Standard.RadioButton("No degrading", (settings.skill_switch == 3), 0f);
            listing_Standard.Gap(12f);
            string text_nd = "No skill de-levelling";
            listing_Standard.CheckboxLabeled(text_nd, ref settings.no_delevel, "Skill levels can't decrease from skill degradation");
            listing_Standard.Gap(12f);
            string text_ls = "Daily xp cap level based";
            listing_Standard.CheckboxLabeled(text_ls, ref settings.learning_saturation_tweak, "Learning Saturation is no longer fixed at 4k per day and level*500 + 1000 instead");
            listing_Standard.Gap(24f);
            listing_Standard.Label("Passion options:");
            listing_Standard.Gap(12f);
            string text_pt = "Passion tweak enabled";
            listing_Standard.CheckboxLabeled(text_pt, ref settings.passion_tweak, "Passion now modifies xp gain by 1, 1.25 and 1.5, instead of 0.33, 1 and 1.5");
            //listing_Standard.Gap(12f);
            string text_pg = "Passion gain enabled";
            listing_Standard.CheckboxLabeled(text_pg, ref settings.passion_gain, "Levelling up gives a Pawn the chance to gain Passion for a skill");
            //listing_Standard.Gap(12f);
            string text_pc = "Passion cap enabled";
            listing_Standard.CheckboxLabeled(text_pc, ref settings.passion_cap, "A Pawn can have a maximum of 4 passionate skills, gaining passion in a skill will downgrade the passion on a random other skill");
            listing_Standard.Gap(12f);
            listing_Standard.Label("Miscellanenous options:");
            listing_Standard.Gap(12f);
            string text_pr = "Plant resting enabled";
            listing_Standard.CheckboxLabeled(text_pr, ref settings.plant_rest, "If disabled, plants can grow 24 hours a day");
            listing_Standard.Gap(12f);


            for (int i = 0; i < (qs.Length); ++i)
            {
                if (qs[i])
                {
                    settings.quality_switch = i;
                    break;
                }
            }
            for (int i = 0; i < (ss.Length); ++i)
            {
                if (ss[i])
                {
                    settings.skill_switch = i;
                    break;
                }
            }

            listing_Standard.End();
            //listing_Standard.RadioButton(string label, bool active, [float tabIn]);
            //            return listing_Standard.get_CurHeight();
        }

        public override void PostClose()
        {
            base.PostClose();
            this.forcePause = false;
        }

        public override void PostOpen()
        {
            base.PostOpen();
        }

        public override void PreClose()
        {
            base.PreClose();
        }

        public override void PreOpen()
        {
            base.PreOpen();
            this.forcePause = true;
        }

    }
}