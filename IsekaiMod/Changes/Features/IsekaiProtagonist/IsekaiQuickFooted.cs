﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class IsekaiQuickFooted
    {
        public static void Add()
        {
            var Icon_ExpeditiousRetreat = Resources.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379").m_Icon;
            var IsekaiQuickFooted = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiQuickFooted", bp => {
                bp.SetName("Quick-Footed");
                bp.SetDescription("At 15th level, the Isekai Protagonist gains a competence {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}checks{/g} equal to their {g|Encyclopedia:Charisma}Charisma{/g} modifier (minimum 1).");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "The Isekai Protagonist gains a competence {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}checks{/g} equal to their {g|Encyclopedia:Charisma}Charisma{/g} modifier (minimum 1).");
                bp.m_Icon = Icon_ExpeditiousRetreat;
                bp.AddComponent<DerivativeStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.BaseStat = StatType.Charisma;
                    c.DerivativeStat = StatType.Initiative;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Charisma;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
