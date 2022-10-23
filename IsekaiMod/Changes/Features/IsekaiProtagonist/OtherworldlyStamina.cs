﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class OtherworldlyStamina
    {
        public static void Add()
        {
            var Icon_Bravery = Resources.GetBlueprint<BlueprintFeature>("f6388946f9f472f4585591b80e9f2452").m_Icon;
            var OtherworldlyStamina = Helpers.CreateBlueprint<BlueprintFeature>("OtherworldlyStamina", bp => {
                bp.SetName("Otherworldly Stamina");
                bp.SetDescription("At 15th Level, the Isekai Protagonist becomes immune to fatigue and exhaustion.");
                bp.m_Icon = Icon_Bravery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
            });
        }
    }
}
