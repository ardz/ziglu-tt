using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
    /// So that {?what's the use case/business benefit being derived from this feature?}
    /// </summary>
    public class ExchangeTradingVolumes : FeatureFixture
    {
        private readonly ITestOutputHelper _output;

        public ExchangeTradingVolumes(ITestOutputHelper output)
        {
            _output = output;
        }

        [Scenario]
        [InlineData(10)]
        [InlineData(5)] // test works for however many exchanges you want to see
        public void UserCanView24HourBitcoinTradingVolumes(int numberOfExchanges)
        {
            var tradingVolumesExchanges = new List<Exchange>();

            // What's the given here? there isn't really one?
            // Givens are meant to describe initial system context
            // https://cucumber.io/docs/gherkin/reference/#given

            "When the user queries trading volumes"
                .x(async () =>
                {
                    tradingVolumesExchanges = (await ZigluService
                        .TopBitcoinTradingVolumesByExchange(numberOfExchanges)).ToList();
                });

            $"Then the user sees the top {numberOfExchanges} exchanges with the highest 24 hour trading bitcoin volumes"
                .x(() =>
                {
                    Assert.Equal(numberOfExchanges, tradingVolumesExchanges.Count);

                    _output
                        .WriteLine(
                            $"Top {numberOfExchanges} Exchanges with Highest 24 Hour Normalised BTC Trade Volumes:");

                    foreach (var output in tradingVolumesExchanges
                        .Select(exchange => $"{exchange.Name}/{exchange.TradeVolume24HoursNormalized}"))
                    {
                        _output.WriteLine(output);
                    }
                });

            // we're effectively testing the service has ordered the results desc here
            // OK I guess as we're actually testing something in ziglus domain here
            $"And the results are in descending order"
                .x(() =>
                {
                    tradingVolumesExchanges.Should()
                        .BeInDescendingOrder(x => x.TradeVolume24HoursNormalized);
                });
        }
    }
}