﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.BeachEpisode
{
    class Unstoppable
    {
        public static void Add()
        {
            var Icon_DextrousDuelist = Resources.GetBlueprint<BlueprintFeature>("b701196306bb4674bb902c9f1160180f").m_Icon;
            var Unstoppable = Helpers.CreateBlueprint<BlueprintFeature>("Unstoppable", bp => {
                bp.SetName("Unstoppable");
                bp.SetDescription("You gain immunity to dazed, dazzled, stunned, staggered, slowed, entangled, and movement impairing effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Slowed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Staggered;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Stunned;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.CantMove;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing;
                });
                bp.m_Icon = Icon_DextrousDuelist;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
