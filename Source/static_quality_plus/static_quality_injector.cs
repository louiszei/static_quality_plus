using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;
using Verse.AI;
using Object = System.Object;

namespace static_quality
{
    public class DetourInjector : SpecialInjector
    {
        private bool success = true;
        public override bool Inject()
        {
            

            MethodInfo m1a = typeof(QualityUtility).GetMethod("RandomCreationQuality", BindingFlags.Static | BindingFlags.Public);
            MethodInfo m1b = typeof(_QualityUtility).GetMethod("_RandomCreationQuality", BindingFlags.Static | BindingFlags.Public);

            MethodInfo m2a = typeof(SkillRecord).GetMethod("Interval", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo m2b = typeof(_SkillRecord_derived).GetMethod("_Interval", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo m3a = typeof(SkillRecord).GetMethod("get_LearningSaturatedToday", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo m3b = typeof(_SkillRecord_derived).GetMethod("get__LearningSaturatedToday", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo m4a = typeof(SkillRecord).GetMethod("Learn", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo m4b = typeof(_SkillRecord).GetMethod("_Learn", BindingFlags.Static | BindingFlags.Public);

            MethodInfo m5a = typeof(SkillUI).GetMethod("GetSkillDescription", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo m5b = typeof(_SkillUI).GetMethod("_GetSkillDescription", BindingFlags.Static | BindingFlags.NonPublic);

            MethodInfo m6a = typeof(Plant).GetMethod("get_Resting", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo m6b = typeof(_Plant).GetMethod("get__Resting", BindingFlags.Instance | BindingFlags.NonPublic);
            
/*
            Log.Message(typeof(SkillRecord).GetField("pawn", BindingFlags.Instance | BindingFlags.NonPublic).ToString());
            foreach (MethodInfo mx in typeof(static_quality_no_skill_degrading).GetMethods()) {
                Log.Message(mx.ToString());
            }
*/

            if (Detours.TryDetourFromTo(m1a, m1b))
            {
                Log.Message("static_quality_Injector: _QualityUtility _RandomCreationQuality injected successfully!");
            } else {
                success = false;
            }
            if (Detours.TryDetourFromTo(m2a, m2b))
            {
                Log.Message("static_quality_Injector: _SkillRecord_derived _Interval injected successfully!");
            } else {
                success = false;
            }
            if (Detours.TryDetourFromTo(m3a, m3b))
            {
                Log.Message("static_quality_Injector: _SkillRecord_derived _LearningSaturatedToday injected successfully!");
            } else {
                success = false;
            }
            if (Detours.TryDetourFromTo(m4a, m4b))
            {
                Log.Message("static_quality_Injector: _SkillRecord _Learn injected successfully!");
            } else {
                success = false;
            }
            if (Detours.TryDetourFromTo(m5a, m5b))
            {
                Log.Message("static_quality_Injector: _SkillUI _GetSkillDescription injected successfully!");
            } else {
                success = false;
            }
            if (Detours.TryDetourFromTo(m6a, m6b))
            {
                Log.Message("static_quality_Injector: _Plant _Resting injected successfully!");
            } else {
                success = false;
            }

            if (success == false)
            {
                return false;
            }
            else
            {
                GameObject initializer = new GameObject("MapComponentInjectorSQ");
                initializer.AddComponent<MapComponentInjectorSQ>();
                UnityEngine.Object.DontDestroyOnLoad(initializer);
                return true;
            }
        }
    }
}