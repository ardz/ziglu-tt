using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xbehave;
using Xunit;
using Xunit.Abstractions;
using ZigluService.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                .x(async () => { exchanges = (await ZigluService.TopThreeExchanges()).ToList(); });

            $"Then the user can see each of the exchanges names and their trust ranking"
                .x(() =>
                {
                    _output.WriteLine(JsonSerializer.Serialize(exchanges, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                    Assert.Equal(3, exchanges.Count);
                });
        }
    }
}