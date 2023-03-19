﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats {

    internal class ExceptionalFeatSelection {
        private static readonly BlueprintFeatureSelection MythicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9ee0f6745f555484299b0a1563b99d81");
        private static readonly BlueprintFeatureSelection ExtraFeatMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e10c4f18a6c8b4342afe6954bde0587b");
        private static readonly BlueprintFeatureSelection ExtraMythicAbilityMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a6a511c55e67d04db328cc49aaad2b8");

        public static void Add() {
            // Add more Exceptional feats later
            var ExceptionalFeatures = MythicFeatSelection.m_AllFeatures
                    .RemoveFromArray(ExtraFeatMythicFeat.ToReference<BlueprintFeatureReference>())
                    .RemoveFromArray(ExtraMythicAbilityMythicFeat.ToReference<BlueprintFeatureReference>());

            // The reason for two copies is to avoid a UI bug when exceptional feats are selected both in feat and bonus feat.
            var ExceptionalFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Feats");
                bp.SetDescription(IsekaiContext, "Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<PureRecommendation>(c => {
                    c.Priority = RecommendationPriority.Good;
                });
                bp.m_AllFeatures = ExceptionalFeatures;
            });
            var ExceptionalFeatBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Feats");
                bp.SetDescription(IsekaiContext, "Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<PureRecommendation>(c => {
                    c.Priority = RecommendationPriority.Good;
                });
                bp.m_AllFeatures = ExceptionalFeatures;
            });

            StaticReferences.Selections.BasicFeatSelection.AddToFirst(ExceptionalFeatSelection);
        }

        public static void AddToSelection(BlueprintFeatureSelection selection, BlueprintFeatureSelection bonusSelection) {
            var ExceptionalFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection");
            ExceptionalFeatSelection.AddToSelection(selection);
            ExceptionalFeatBonusSelection.AddToSelection(bonusSelection);
        }
    }
}