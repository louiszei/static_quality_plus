using RimWorld;
using UnityEngine;
using Verse;
using static static_quality.MapComponent_SQ;

namespace static_quality
{
    public static class _QualityUtility
    {

        public static QualityCategory _RandomCreationQuality(int relevantSkillLevel)
        {
            if (settings.quality_switch > 1)
            {
                System.Random rng = new System.Random();
                int mod = 0;

                if (settings.quality_switch == 3)
                {
                    mod = rng.Next(0, 5) - 2;
                } else
                {
                    mod = rng.Next(0, 3) - 1;
                }

                int rv = 3;

                switch (relevantSkillLevel)
                {
                    case 0:
                        rv = 0 + mod;
                        break;
                    case 1:
                        rv = 0 + mod;
                        break;
                    case 2:
                        rv = 0 + mod;
                        break;
                    case 3:
                        rv = 1 + mod;
                        break;
                    case 4:
                        rv = 1 + mod;
                        break;
                    case 5:
                        rv = 1 + mod;
                        break;
                    case 6:
                        rv = 2 + mod;
                        break;
                    case 7:
                        rv = 2 + mod;
                        break;
                    case 8:
                        rv = 2 + mod;
                        break;
                    case 9:
                        rv = 3 + mod;
                        break;
                    case 10:
                        rv = 3 + mod;
                        break;
                    case 11:
                        rv = 4 + mod;
                        break;
                    case 12:
                        rv = 4 + mod;
                        break;
                    case 13:
                        rv = 5 + mod;
                        break;
                    case 14:
                        rv = 5 + mod;
                        break;
                    case 15:
                        rv = 6 + mod;
                        break;
                    case 16:
                        rv = 6 + mod;
                        break;
                    case 17:
                        rv = 7 + mod;
                        break;
                    case 18:
                        rv = 7 + mod;
                        break;
                    case 19:
                        rv = 7 + mod;
                        break;
                    case 20:
                        rv = 8 + mod;
                        break;
                }
                if (rv < 0)
                {
                    rv = 0;
                }
                else if (rv > 8)
                {
                    rv = 8;
                }
                return (QualityCategory)rv;

            } else if (settings.quality_switch == 1)
            {
                switch (relevantSkillLevel)
                {
                    case 0:
                        return (QualityCategory)0;
                    case 1:
                        return (QualityCategory)0;
                    case 2:
                        return (QualityCategory)0;
                    case 3:
                        return (QualityCategory)1;
                    case 4:
                        return (QualityCategory)1;
                    case 5:
                        return (QualityCategory)1;
                    case 6:
                        return (QualityCategory)2;
                    case 7:
                        return (QualityCategory)2;
                    case 8:
                        return (QualityCategory)2;
                    case 9:
                        return (QualityCategory)3;
                    case 10:
                        return (QualityCategory)3;
                    case 11:
                        return (QualityCategory)4;
                    case 12:
                        return (QualityCategory)4;
                    case 13:
                        return (QualityCategory)5;
                    case 14:
                        return (QualityCategory)5;
                    case 15:
                        return (QualityCategory)6;
                    case 16:
                        return (QualityCategory)6;
                    case 17:
                        return (QualityCategory)7;
                    case 18:
                        return (QualityCategory)7;
                    case 19:
                        return (QualityCategory)7;
                    case 20:
                        return (QualityCategory)8;
                }
                return (QualityCategory)3;
            } else
            {
                float centerX = -1f;
                switch (relevantSkillLevel)
                {
                    case 0:
                        centerX = 0.167f;
                        break;
                    case 1:
                        centerX = 0.5f;
                        break;
                    case 2:
                        centerX = 0.833f;
                        break;
                    case 3:
                        centerX = 1.166f;
                        break;
                    case 4:
                        centerX = 1.5f;
                        break;
                    case 5:
                        centerX = 1.833f;
                        break;
                    case 6:
                        centerX = 2.166f;
                        break;
                    case 7:
                        centerX = 2.5f;
                        break;
                    case 8:
                        centerX = 2.833f;
                        break;
                    case 9:
                        centerX = 3.166f;
                        break;
                    case 10:
                        centerX = 3.5f;
                        break;
                    case 11:
                        centerX = 3.75f;
                        break;
                    case 12:
                        centerX = 4f;
                        break;
                    case 13:
                        centerX = 4.25f;
                        break;
                    case 14:
                        centerX = 4.5f;
                        break;
                    case 15:
                        centerX = 4.7f;
                        break;
                    case 16:
                        centerX = 4.9f;
                        break;
                    case 17:
                        centerX = 5.1f;
                        break;
                    case 18:
                        centerX = 5.3f;
                        break;
                    case 19:
                        centerX = 5.5f;
                        break;
                    case 20:
                        centerX = 5.7f;
                        break;
                }
                float num = Rand.Gaussian(centerX, 1.25f);
                num = Mathf.Clamp(num, 0f, (float)QualityUtility.AllQualityCategories.Count - 0.5f);
                return (QualityCategory)((int)num);
            }
        }
    }
}
