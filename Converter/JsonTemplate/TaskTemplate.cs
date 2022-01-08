using System;

namespace Converter.JsonTemplate
{
    public class TaskTemplate
    {
        public string id { get; set; }
        public int intId
        {
            get => Convert.ToInt32(id);

            set
            {
                id = value.ToString();
            }
        }
        public string target { get; set; }
        public string needsecuritylevel { get; set; }
        public int intNeedsecuritylevel
        {
            get => Convert.ToInt32(needsecuritylevel);

            set
            {
                needsecuritylevel = value.ToString();
            }
        }
        public string createdtime { get; set; }
        public string lastchangetime { get; set; }
        public string staffid { get; set; }
        public int intStaffid
        {
            get => Convert.ToInt32(staffid);
            set
            {
                staffid = value.ToString();
            }

        }
        public string laststaffid { get; set; }
        public int intLaststaffid
        {
            get => Convert.ToInt32(laststaffid);
            set
            {
                laststaffid = value.ToString();
            }
        }
        public string bybossid { get; set; }
        public int intBybossid
        {
            get => Convert.ToInt32(bybossid);
            set
            {
                bybossid = value.ToString();
            }
        }
        public string comment { get; set; }
    }
}
