using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xbehave;
using Xunit;
using Xunit.Abstractions;
using ZigluService;
using ZigluService.Models;

namespace ZigluFeatures.Features
{
    /// <summary>
    /// Feature 1
    /// 
    /// As a ?user? [I don't really know who the user is in this example?]
    /// I want to be able to find out which exchanges have the top trust rankings
    /// so I can make informed decisions about which exchanges I wish to engage with
    /// </summary>
    public class ExchangeTrustScores : FeatureFixture
    {
        private readonly ITestOutputHelper _output;

        public ExchangeTrustScores(ITestOutputHelper output)
        {
            _output = output;
        }

        [Scenario]
        public void UserCanViewTopThreeExchangesTrustScore(List<Exchange> exchanges)
        {
            $"When the user queries the top three exchanges"
                .x(async () => { exchanges = (await ZigluService.GetExchanges(3)).ToList(); });

            $"Then the user can see each of the exchanges names and their trust ranking"
                .x(() =>
                {
                    Assert.Equal(3, exchanges.Count);

                    foreach (var exchange in exchanges)
                    {
                        exchange.TrustScore.Should().NotBe(default);
                        exchange.TrustScoreRank.Should().NotBe(default);
                        _output.WriteLine(Service.ModelToTextOutput(exchange));
                    }
                });
        }
    }
}