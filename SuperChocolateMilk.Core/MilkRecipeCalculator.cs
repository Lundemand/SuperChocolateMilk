namespace SuperChocolateMilk.core;

public class MilkRecipeCalculator
{
    public static decimal CalculateChocolateSyrupRequired(decimal milkVolumeM1, string richnessLevel)
    {
        if (milkVolumeM1 <= 0) return 0m;

        decimal baseSyrupM1 = milkVolumeM1 * 0.1m; //Base Syrup is 10% of milk volume

        return richnessLevel.ToUpper() switch
        {
            "LIGHT" => baseSyrupM1 * 0.75m,
            "MEDIUM" => baseSyrupM1,
            "EXTRA" => baseSyrupM1 * 1.5m,
            "ULTRA_COCO" => baseSyrupM1 * 2m,
            _ => baseSyrupM1 // Default to medium if unknown richness level
        };
    }
}