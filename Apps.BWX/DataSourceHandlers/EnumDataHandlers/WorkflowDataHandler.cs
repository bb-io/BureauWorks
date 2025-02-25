using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class WorkflowDataHandler : IStaticDataSourceItemHandler
{
    IEnumerable<DataSourceItem> IStaticDataSourceItemHandler.GetData() => new List<DataSourceItem>()
    {
        new DataSourceItem("TRANSCRIPTION", "TRANSCRIPTION" ),
        new DataSourceItem("TRANSLATION", "TRANSLATION" ),
        new DataSourceItem("PROOFREADING", "PROOFREADING" ),
        new DataSourceItem("REVIEW", "REVIEW" ),
        new DataSourceItem("REVIEW_2", "REVIEW_2" ),
        new DataSourceItem("REVIEW_3", "REVIEW_3" ),
        new DataSourceItem("ICR", "ICR" ),
        new DataSourceItem("REGIONAL_APPROVAL", "REGIONAL_APPROVAL" ),
        new DataSourceItem("ICR_2", "ICR_2" ),
        new DataSourceItem("WEB_QA", "WEB_QA" ),
        new DataSourceItem("FEEDBACK_IMPLEMENTATION", "FEEDBACK_IMPLEMENTATION" ),
        new DataSourceItem("DTP", "DTP" ),
        new DataSourceItem("QA", "QA" ),
        new DataSourceItem("SUBTITLING", "SUBTITLING" ),
        new DataSourceItem("VIDEO_EDITING", "VIDEO_EDITING" ),
        new DataSourceItem("VOICEOVER", "VOICEOVER" ),
        new DataSourceItem("SWORN", "SWORN" ),
        new DataSourceItem("INTERPRETATION", "INTERPRETATION" ),
        new DataSourceItem("DEVELOPMENT", "DEVELOPMENT" )
    };
}