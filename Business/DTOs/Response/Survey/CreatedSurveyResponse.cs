﻿namespace Business.DTOs.Response.Survey
{

    // CreatedSurveyResponse
    public class CreatedSurveyResponse
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserID { get; set; }
    }



}
