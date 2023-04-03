using System;

namespace cpModel.Dtos.Template
{
    public class IncidentTemplateDto: IncidentDto
    {
        public string IncidentDateAsString => IncidentDate?.ToShortDateString() ?? "";

    }
}
