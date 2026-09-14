namespace SuperChocolateMilk.UnitTests;

using Xunit;
using SuperChocolateMilk.core;

public class MilkRecipeCalculatorTests
{
    [Fact]
    public void CalculateChocolateSyruprequired_RegularRichness_ReturnsTenPercentRatio()
    {
        int milkVolume = 1000;
        String richness = "REGULAR";

        decimal result = MilkRecipeCalculator.CalculateChocolateSyrupRequired(milkVolume, richness);
        
        Assert.Equal(100m, result);
    }
}