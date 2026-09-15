//dotnet test SuperChocolateMilk.UnitTests/SuperChocolateMilk.UnitTests.csproj    

namespace SuperChocolateMilk.UnitTests;

using Xunit;
using SuperChocolateMilk.core;

public class RecipeHelpersTests
{
    // 1. CombineVolumes
    [Fact]
    public void CombineVolumes_TwoPositiveVolumes_ReturnsSum()
    {
        int volumeA = 250;
        int volumeB = 750;
        int expected = 1000;

        int result = RecipeHelpers.CombineVolumes(volumeA, volumeB);

        Assert.Equal(expected, result);
    }

    // 2. LitersToMilliliters
    [Theory]
    [InlineData(1, 1000)]
    [InlineData(2, 2000)]
    [InlineData(0, 0)]
    [InlineData(10, 10000)]
    public void LitersToMilliliters_VariousLiters_ReturnsMilliliters(int liters, int expected)
    {
        int result = RecipeHelpers.LitersToMilliliters(liters);

        Assert.Equal(expected, result);
    }

    // 3. CalculateMilkWeightGrams
    [Fact]
    public void CalculateMilkWeightGrams_OneLiter_ReturnsWeightWithDensityApplied()
    {
        int volumeMl = 1000;
        double expected = 1030.0;

        double result = RecipeHelpers.CalculateMilkWeightGrams(volumeMl);

        Assert.Equal(expected, result, precision: 4);
    }

    // 4. IsValidBatchSize
    [Theory]
    [InlineData(1, true)]
    [InlineData(500, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void IsValidBatchSize_VariousSizes_ReturnsExpected(int totalMl, bool expected)
    {
        bool result = RecipeHelpers.IsValidBatchSize(totalMl);

        Assert.Equal(expected, result);
    }

    // 5. FormatTankLabel
    [Fact]
    public void FormatTankLabel_ValidInput_ReturnsFormattedLabel()
    {
        int tankId = 3;
        string contents = "Chocolate Syrup";
        string expected = "Tank-3: Chocolate Syrup";

        string result = RecipeHelpers.FormatTankLabel(tankId, contents);

        Assert.Equal(expected, result);
    }

    // 6. FormatTankLabel — edge cases
    [Theory]
    [InlineData(1, "Milk", "Tank-1: Milk")]
    [InlineData(0, "", "Tank-0: ")]
    [InlineData(42, "Ultra Choco", "Tank-42: Ultra Choco")]
    public void FormatTankLabel_VariousInputs_ReturnsFormattedLabel(
        int tankId, string contents, string expected)
    {
        string result = RecipeHelpers.FormatTankLabel(tankId, contents);

        Assert.Equal(expected, result);
    }

    // 7. CalculateRequiredBottles
    [Theory]
    [InlineData(250, 1)]
    [InlineData(251, 2)]
    [InlineData(500, 2)]
    [InlineData(999, 4)]
    [InlineData(0, 0)]
    public void CalculateRequiredBottles_VariousVolumes_RoundsUpToWholeBottles(
        int totalVolumeMl, int expected)
    {
        int result = RecipeHelpers.CalculateRequiredBottles(totalVolumeMl);

        Assert.Equal(expected, result);
    }

    // 8. ApplyBulkDiscount
    [Theory]
    [InlineData(100, 0, 100)]
    [InlineData(100, 49, 100)]
    [InlineData(100, 50, 90)]
    [InlineData(100, 99, 90)]
    [InlineData(100, 100, 85)]
    [InlineData(100, 250, 85)]
    public void ApplyBulkDiscount_VariousBottleCounts_ReturnsCorrectTier(
        decimal basePrice, int bottleCount, decimal expected)
    {
        decimal result = RecipeHelpers.ApplyBulkDiscount(basePrice, bottleCount);

        Assert.Equal(expected, result);
    }

    // 9. CalculateSugarGrams
    [Theory]
    [InlineData(240, 24.0)]
    [InlineData(480, 48.0)]
    [InlineData(0, 0.0)]
    [InlineData(3, 0.3)]
    public void CalculateSugarGrams_VariousVolumes_ReturnsScaledSugar(
        int volumeMl, double expected)
    {
        double result = RecipeHelpers.CalculateSugarGrams(volumeMl);

        Assert.Equal(expected, result, precision: 4);
    }

    // 10. NeedsMaintenance
    [Theory]
    [InlineData(500, true)]
    [InlineData(1000, true)]
    [InlineData(2500, true)]
    [InlineData(499, false)]
    [InlineData(501, false)]
    [InlineData(0, false)]
    [InlineData(-500, false)]
    public void NeedsMaintenance_VariousBatchCounts_ReturnsExpected(
        int totalBatchesRun, bool expected)
    {
        bool result = RecipeHelpers.NeedsMaintenance(totalBatchesRun);

        Assert.Equal(expected, result);
    }
}               