using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Tİtle { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
