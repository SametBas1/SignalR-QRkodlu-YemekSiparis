using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.SocialMediaDtos
{
    public class GetSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Tİtle { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
