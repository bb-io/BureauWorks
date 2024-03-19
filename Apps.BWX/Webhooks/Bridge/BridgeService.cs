using Apps.BWX.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.BWX.Webhooks.Bridge;

public class BridgeService
{
    //private string TeamId { get; set; }

    //public BridgeService(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    //{
    //    var client = new BWXClient();

    //    var request = new BWXRequest("/team.info", Method.Get, authenticationCredentialsProviders);
    //    var team = client.Get<TeamInfoResponse>(request);

    //    if (team == null) throw new Exception("Could not fetch team details");

    //    TeamId = team.Team.Id;
    //}

    //public void Subscribe(string @event, string url, string bridgeServiceUrl)
    //{
    //    var client = new RestClient($"{bridgeServiceUrl}/webhooks/slack");

    //    var request = new RestRequest($"/{TeamId}/{@event}", Method.Post)
    //        .AddHeader("Blackbird-Token", ""/*ApplicationConstants.BlackbirdToken*/)
    //        .AddBody(url);

    //    client.Execute(request);
    //}

    //public void Unsubscribe(string @event, string url, string bridgeServiceUrl)
    //{
    //    var client = new RestClient($"{bridgeServiceUrl}/webhooks/slack");

    //    var requestGet = new RestRequest($"/{TeamId}/{@event}")
    //        .AddHeader("Blackbird-Token", ""/*ApplicationConstants.BlackbirdToken*/);

    //    var webhooks = client.Get<List<BridgeGetResponse>>(requestGet);
    //    var webhook = webhooks.FirstOrDefault(w => w.Value == url);

    //    if (webhook is null) return;

    //    var requestDelete = new RestRequest($"/{TeamId}/{@event}/{webhook.Id}", Method.Delete)
    //        .AddHeader("Blackbird-Token", ""/*ApplicationConstants.BlackbirdToken*/);

    //    client.Delete(requestDelete);
    //}
}