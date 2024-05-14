using Blackbird.Applications.Sdk.Common.Webhooks;
using System.Net;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common.Invocation;
using Apps.BWX.Invocables;
using Apps.BWX.Webhooks.Payload;
namespace Apps.BWX.Webhooks;

[WebhookList]
public class WebhookList : BWXInvocable
{

    public WebhookList(InvocationContext invocationContext) : base(invocationContext)
    {

    }

    [Webhook("On empty project created", Description = "On empty project created")]
    public async Task<WebhookResponse<NewProjectEvent>> EmptyProjectCreated(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<NewProjectEvent>();
        var payload = JsonConvert.DeserializeObject<NewProjectEvent>(rawPayload);
        return new WebhookResponse<NewProjectEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On new project created", Description = "On new project created")]
    public async Task<WebhookResponse<NewProjectEvent>> NewProjectCreated(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<NewProjectEvent>();
        var payload = JsonConvert.DeserializeObject<NewProjectEvent>(rawPayload);
        return new WebhookResponse<NewProjectEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On project status changed", Description = "On project status changed")]
    public async Task<WebhookResponse<ProjectStatusChangedPayload>> ProjectStatusChanged(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<ProjectStatusChangedPayload>();
        var payload = JsonConvert.DeserializeObject<ProjectStatusChangedPayload>(rawPayload);
        return new WebhookResponse<ProjectStatusChangedPayload>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On project translation finished", Description = "On project translation finished")]
    public async Task<WebhookResponse<ProjectTranslationFinishedEvent>> ProjectTranslationFinished(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<ProjectTranslationFinishedEvent>();
        var payload = JsonConvert.DeserializeObject<ProjectTranslationFinishedEvent>(rawPayload);
        return new WebhookResponse<ProjectTranslationFinishedEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On task assigned", Description = "On task assigned")]
    public async Task<WebhookResponse<TaskAssignedEvent>> TaskAssigned(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<TaskAssignedEvent>();
        var payload = JsonConvert.DeserializeObject<TaskAssignedEvent>(rawPayload);
        return new WebhookResponse<TaskAssignedEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On task status changed", Description = "On task status changed")]
    public async Task<WebhookResponse<TaskStatusChangedPayload>> TaskStatusChanged(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<TaskStatusChangedPayload>();
        var payload = JsonConvert.DeserializeObject<TaskStatusChangedPayload>(rawPayload);
        return new WebhookResponse<TaskStatusChangedPayload>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On work unit status changed", Description = "On work unit status changed")]
    public async Task<WebhookResponse<WorkUnitStatusChangedEvent>> WorkUnitStatusChanged(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<WorkUnitStatusChangedEvent>();
        var payload = JsonConvert.DeserializeObject<WorkUnitStatusChangedEvent>(rawPayload);
        return new WebhookResponse<WorkUnitStatusChangedEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On new organization created", Description = "On new organization created")]
    public async Task<WebhookResponse<NewOrgEvent>> NewOrgCreated(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<NewOrgEvent>();
        var payload = JsonConvert.DeserializeObject<NewOrgEvent>(rawPayload);
        return new WebhookResponse<NewOrgEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On new organization unit created", Description = "On new organization unit created")]
    public async Task<WebhookResponse<NewOrgEvent>> NewOrgUnitCreated(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<NewOrgEvent>();
        var payload = JsonConvert.DeserializeObject<NewOrgEvent>(rawPayload);
        return new WebhookResponse<NewOrgEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    [Webhook("On new user created", Description = "On new user created")]
    public async Task<WebhookResponse<NewUserEvent>> NewUserCreated(WebhookRequest webhookRequest)
    {
        var rawPayload = webhookRequest.Body.ToString();
        if (rawPayload == "{}")
            return GeneratePreflight<NewUserEvent>();
        var payload = JsonConvert.DeserializeObject<NewUserEvent>(rawPayload);
        return new WebhookResponse<NewUserEvent>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload,
            ReceivedWebhookRequestType = WebhookRequestType.Default,
        };
    }

    private WebhookResponse<T> GeneratePreflight<T>() where T : class
    {
        return new WebhookResponse<T>
        {
            ReceivedWebhookRequestType = WebhookRequestType.Preflight,
            HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK)
        };
    }
}