using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xbehave;
using Xunit;
using Xunit.Abstractions;
using ZigluService.Models;

namespace ZigluFeatures.Features
{
    /// <summary>
    /// Feature 2
    ///
    /// As a user, I wish to see trade volumes for top exchanges
    /// So that ???
    /// </summary>
    public class ExchangeTradingVolumes : FeatureFixture
    {
        private readonly ITestOutputHelper _output;

        public ExchangeTradingVolumes(ITestOutputHelper output)
        {
            _output = output;
        }

        [Scenario]
        [InlineData(5)]
        public void UserCanView24HourBitcoinTradingVolumes(int limit)
        {
            var tradingVolumesExchanges = new List<Exchange>();
            
            "When the user queries trading volumes"
                .x(async () =>
                {
                    tradingVolumesExchanges = (await ZigluService
                        .TopExchangesBitCoinTradingVolume(limit)).ToList();

                });

            $"Then the user sees the top {limit} exchanges with the highest 24 hour trading bitcoin volumes"
                .x(() =>
                {
                    _output.WriteLine(JsonSerializer.Serialize(tradingVolumesExchanges, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                    Assert.Equal(limit, tradingVolumesExchanges.Count);
                });

            // I don't really know a good way of checking it's ordered
            // correctly, it's odd because you're effectively testing their
            // API at this point ?
            $"And the results are in descending order"
                .x(async () =>
                {
                    // tradingVolumesExchanges
                });
        }
    }
}