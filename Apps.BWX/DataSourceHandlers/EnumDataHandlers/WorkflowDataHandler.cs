using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class WorkflowDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "TRANSCRIPTION", "TRANSCRIPTION" },
        { "TRANSLATION", "TRANSLATION" },
        { "PROOFREADING", "PROOFREADING" },
        { "REVIEW", "REVIEW" },
        { "REVIEW_2", "REVIEW_2" },
        { "REVIEW_3", "REVIEW_3" },
        { "ICR", "ICR" },
        { "REGIONAL_APPROVAL", "REGIONAL_APPROVAL" },
        { "ICR_2", "ICR_2" },
        { "WEB_QA", "WEB_QA" },
        { "FEEDBACK_IMPLEMENTATION", "FEEDBACK_IMPLEMENTATION" },
        { "DTP", "DTP" },
        { "QA", "QA" },
        { "SUBTITLING", "SUBTITLING" },
        { "VIDEO_EDITING", "VIDEO_EDITING" },
        { "VOICEOVER", "VOICEOVER" },
        { "SWORN", "SWORN" },
        { "INTERPRETATION", "INTERPRETATION" },
        { "DEVELOPMENT", "DEVELOPMENT" }
    };
}