namespace SuperChocolateMilk.core;

public class RecipeHelpers
{
    public static int CombineVolumes(int volumeA, int volumeB)
    {
        return volumeA + volumeB;
    }

    public static int LitersToMilliliters(int liters)
    {
        return liters * 1000;
    }

    public static double CalculateMilkWeightGrams(int volumeMl)
    {
        return volumeMl * 1.03;
    }

    public static bool IsValidBatchSize(int totalMl)
    {
        return totalMl > 0;
    }

    public static string FormatTankLabel(int tankId, string contents)
    {
        return $"Tank-{tankId}: {contents}";
    }

    public static int CalculateRequiredBottles(int totalVolumeMl)
    {
        return (int)Math.Ceiling(totalVolumeMl / 250.0);
    }

    public static decimal ApplyBulkDiscount(decimal basePrice, int bottleCount)
    {
        if (bottleCount >= 100)
        {
            return basePrice * 0.85m; // 15% off
        }

        if (bottleCount >= 50)
        {
            return basePrice * 0.90m; // 10% off
        }

        return basePrice;
    }

    public static double CalculateSugarGrams(int volumeMl)
    {
        return volumeMl / 240.0 * 24.0;
    }

    public static bool NeedsMaintenance(int totalBatchesRun)
    {
        if (totalBatchesRun <= 0)
        {
            return false;
        }

        return totalBatchesRun % 500 == 0;
    }
}