using FluentAssertions;
using Xbehave;
using Xunit;
using Xunit.Abstractions;
using ZigluService;
using ZigluService.Models;

namespace ZigluFeatures.Features
{
    /// <summary>
    /// Feature 3
    ///
    /// As a user, I want to be able to see coin data
    /// So that ???
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
        /// <param name="coinId"></param>
        [Scenario]
        [InlineData("telcoin")]
        //[InlineData("xtz")] I can't see a coin with this id
        [InlineData("nano")]
        public void UserCanQueryCoinValueInGbp(string coinId)
        {
            Coin coin = null;

            $"When the user queries coin data for {coinId}"
                .x(async () =>
                {
                    coin = await ZigluService.CoinInfo(coinId);
                });

            $"Then the user sees data for {coinId}"
                .x(() =>
                {
                    _output.WriteLine(Service.ModelToTextOutput(coin));
                    
                    Assert.Equal(coinId, coin.Name, true);
                });

            $"And the user sees the value of {coinId} in GBP"
                .x(() => { coin.MarketValue.Should().NotBe(default); });

            $"And the market cap for {coinId}"
                .x(() => { coin.MarketCap.Should().NotBe(default); });

            $"And the 24 hour GBP price change for {coinId}"
                .x(() => { coin.PriceChange.Should().NotBe(default); });

            $"And the time the coin data was last updated {coinId}"
                .x(() => { coin.LastUpdated.Should().NotBe(default); });
        }
    }
}