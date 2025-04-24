using Apps.BWX.Connections;
using Blackbird.Applications.Sdk.Common.Authentication;
using Tests.BWX.Base;

namespace Tests.BWX;

[TestClass]
public class ConnectionPingCheckerTests : TestBase
{
    [TestMethod]
    public async Task ValidateConnection_ValidData_ShouldBeSuccessful()
    {
        var validator = new ConnectionPingChecker();

        var result = await validator.ValidateConnection(Creds, CancellationToken.None);

        Assert.IsTrue(result.IsValid);
        Console.WriteLine(result.Message);
    }

    [TestMethod]
    public async Task ValidateConnection_InvalidData_ShouldFail()
    {
        var validator = new ConnectionPingChecker();
        var newCredentials = Creds
            .Select(x => new AuthenticationCredentialsProvider(x.KeyName, Guid.NewGuid().ToString()))
            .ToList(); 

        var result = await validator.ValidateConnection(newCredentials, CancellationToken.None);
        Console.WriteLine(result.Message);
        Assert.IsFalse(result.IsValid);
    }
}