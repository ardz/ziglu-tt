using System.Text.Json;
using Xbehave;
using Xunit;
using Xunit.Abstractions;
using ZigluService.Models;

namespace ZigluFeatures.Features
{
    /// <summary>
    /// Feature 3
    ///
    ///
    /// </summary>
    public class CoinComparisons : FeatureFixture
    {
        private readonly ITestOutputHelper _output;

        public CoinComparisons(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>
        /// BDD wouldn't be at this level in the real world :S
        /// </summary>
        /// <param name="coinName"></param>
        [Scenario]
        [InlineData("telcoin")]
        //[InlineData("xtz")] I can't see a coin with this id
        [InlineData("nano")]
        public void UserCanQueryCoinValueInGbp(string coinName)
        {
            var coin = new Coin();
            
            $"When the user queries coin data for {coinName}"
                .x(async () =>
                {
                    coin = await ZigluService.CoinInfo(coinName);
                    
                    _output.WriteLine(JsonSerializer.Serialize(coin, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                });

            $"Then the user sees the value of {coinName} in GBP"
                .x(() =>
                {
                    // Assert ??
                });

            $"And the market cap for {coinName}"
                .x(() =>
                {
                    // Assert ??
                });
            
            $"And the 24 hour GBP price change for {coinName}"
                .x(() =>
                {
                    // Assert ??
                });
            
            $"And the time the coin data was last updated {coinName}"
                .x(() => { });
        }
    }
}