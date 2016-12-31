using System;
using System.Collections.Generic;
using System.IO;
using Verse;

namespace static_quality
{
    public class MapComponent_SQ : MapComponent
    {
        public static Settings settings = new Settings();
        public static bool init = false;

        public MapComponent_SQ(Map map) : base(map)
        {
            this.map = map;
            if (init == false) {
                if (File.Exists(settings.config_file))
                {
                    //Settings settings = new Settings();
                    settings = XmlLoader.ItemFromXmlFile<Settings>(settings.config_file, true);
                    Log.Message("Static Quality : config file " + settings.config_file + " loaded");
                }
                else
                {
                    Log.Message("Static Quality : config file " + settings.config_file + " not found, using defaults");
                }
                init = true;
            }
        }


    public override void ExposeData()
        {

            if (settings == null)
            {
                settings = new Settings();
            }

            //Scribe_Values.LookValue<bool>(ref _SkillRecord_derived.skill_degrading, "skill_degrading", false, true);
            Scribe_Values.LookValue<int>(ref settings.skill_switch, "skill_switch", 3, true);
            Scribe_Values.LookValue<bool>(ref settings.no_delevel, "no_skill_delevel", false, true);
            Scribe_Values.LookValue<bool>(ref settings.passion_tweak, "passion_tweak", false, true);
            Scribe_Values.LookValue<bool>(ref settings.learning_saturation_tweak, "learning_saturation", false, true);
            Scribe_Values.LookValue<bool>(ref settings.passion_gain, "passion_gain", false, true);
            Scribe_Values.LookValue<bool>(ref settings.passion_cap, "passion_cap", true, true);
            Scribe_Values.LookValue<int>(ref settings.quality_switch, "quality_switch", 1, true);
            Scribe_Values.LookValue<bool>(ref settings.plant_rest, "plant_rest", true, true);

        }
    }
}