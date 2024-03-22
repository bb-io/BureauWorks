using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers
{
    public class WorkflowDataHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
            {
                {"TRANSCRIPTION","TRANSCRIPTION"},
                {"TRANSLATION","TRANSLATION"},
                {"PROOFREADING","PROOFREADING"},
                {"REVIEW","REVIEW"},
                {"REVIEW_2","REVIEW_2"},
                {"REVIEW_3","REVIEW_3"},
                {"ICR","ICR"},
                {"REGIONAL_APPROVAL","REGIONAL_APPROVAL"},
                {"ICR_2","ICR_2"},
                {"WEB_QA","WEB_QA"},
                {"FEEDBACK_IMPLEMENTATION","FEEDBACK_IMPLEMENTATION"},
                {"DTP","DTP"},
                {"QA","QA"},
                {"SUBTITLING","SUBTITLING"},
                {"VIDEO_EDITING","VIDEO_EDITING"},
                {"VOICEOVER","VOICEOVER"},
                {"SWORN","SWORN"},
                {"INTERPRETATION","INTERPRETATION"},
                {"DEVELOPMENT","DEVELOPMENT"}
            };
    }
}
