using System;
using Transformer.SystemTempate;

namespace Transformer.JsonTemplate
{
    public class ReportTemplate
    {
        public ReportTemplate() { }

        public ReportTemplate(Report report)
        {
            name = report.Name;
            comment = report.Comment;
            intStaffid = report.Staff.Id;
            type = report.Type;
            boolResolve = false;
        }

        public string id { get; set; }
        public int intId
        {
            get => Convert.ToInt32(id);

            set
            {
                id = value.ToString();
            }
        }
        public string name { get; set; }
        public string staffid { get; set; }
        public int intStaffid
        {
            get => Convert.ToInt32(staffid);
            set
            {
                staffid = value.ToString();
            }

        }
        public string type { get; set; }
        public string comment { get; set; }
        public string resolve { get; set; }
        public bool boolResolve
        {
            get => Convert.ToBoolean(resolve);
            set
            {
                resolve = Convert.ToString(value);
            }
        }
    }
}
