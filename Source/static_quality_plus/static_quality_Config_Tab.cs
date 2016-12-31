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
            listing_Standard.Label("SQP_Item_quality_options".Translate());
            listing_Standard.Gap(12f);
            bool[] qs = new bool[4];
            qs[0] = listing_Standard.RadioButton("SQP_Vanilla_quality".Translate(), (settings.quality_switch == 0), 0f);
            qs[1] = listing_Standard.RadioButton("SQP_Static_quality".Translate(), (settings.quality_switch == 1), 0f);
            qs[2] = listing_Standard.RadioButton("SQP_Static_quality_variability_1".Translate(), (settings.quality_switch == 2), 0f);
            qs[3] = listing_Standard.RadioButton("SQP_Static_quality_variability_2".Translate(), (settings.quality_switch == 3), 0f);
            listing_Standard.Gap(24f);
            bool[] ss = new bool[4];
            listing_Standard.Label("SQP_Skill_options".Translate());
            listing_Standard.Gap(12f);
            ss[0] = listing_Standard.RadioButton("SQP_Vanilla_degrading".Translate(), (settings.skill_switch == 0), 0f);
            ss[1] = listing_Standard.RadioButton("SQP_Halved_degrading".Translate(), (settings.skill_switch == 1), 0f);
            ss[2] = listing_Standard.RadioButton("SQP_Mild_degrading".Translate(), (settings.skill_switch == 2), 0f);
            ss[3] = listing_Standard.RadioButton("SQP_No_degrading".Translate(), (settings.skill_switch == 3), 0f);
            listing_Standard.Gap(12f);
            string text_nd = "SQP_No_skill_de_levelling".Translate();
            listing_Standard.CheckboxLabeled(text_nd, ref settings.no_delevel, "SQP_No_skill_de_levelling_Description".Translate());
            listing_Standard.Gap(12f);
            string text_ls = "SQP_Daily_xp_cap_level_based".Translate();
            listing_Standard.CheckboxLabeled(text_ls, ref settings.learning_saturation_tweak, "SQP_Daily_xp_cap_level_based_Description".Translate());
            listing_Standard.Gap(24f);
            listing_Standard.Label("SQP_Passion_options".Translate());
            listing_Standard.Gap(12f);
            string text_pt = "SQP_Passion_tweak_enabled".Translate();
            listing_Standard.CheckboxLabeled(text_pt, ref settings.passion_tweak, "SQP_Passion_tweak_enabled_Description".Translate());
            //listing_Standard.Gap(12f);
            string text_pg = "SQP_Passion_gain_enabled".Translate();
            listing_Standard.CheckboxLabeled(text_pg, ref settings.passion_gain, "SQP_Passion_gain_enabled_Description".Translate());
            //listing_Standard.Gap(12f);
            string text_pc = "SQP_Passion_cap_enabled".Translate();
            listing_Standard.CheckboxLabeled(text_pc, ref settings.passion_cap, "SQP_Passion_cap_enabled_Description".Translate());
            listing_Standard.Gap(12f);
            listing_Standard.Label("SQP_Miscellanenous_options".Translate());
            listing_Standard.Gap(12f);
            string text_pr = "SQP_Plant_resting_enabled".Translate();
            listing_Standard.CheckboxLabeled(text_pr, ref settings.plant_rest, "SQP_Plant_resting_enabled_Description".Translate());
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