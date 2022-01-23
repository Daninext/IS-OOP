using System;

namespace Transformer.JsonTemplate
{
    public class UserTemplate
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
        public string name { get; set; }
        public string password { get; set; }
        public string securitylevel { get; set; }
        public int intSecuritylevel
        {
            get => Convert.ToInt32(securitylevel);
            set
            {
                securitylevel = value.ToString();
            }
        }
        public string bossid { get; set; }
        public int intBossid
        {
            get => Convert.ToInt32(bossid);
            set
            {
                bossid = value.ToString();
            }
        }

    }
}
