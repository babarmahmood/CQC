using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.ViewModels
{
    public class LightFeedbackVm
    {
        public FullNameVm FullNameVm { get; set; }
        public EmailVm EmailVm { get; set; }
        public AddressVm HomeAddress { get; set; }
        public bool IsHappy { get; set; }
        public int LevelOfBrightness { get; set; }
        public int CurrentStep { get; set; }
        public bool IsNextButtonClicked { get; set; }
    }
}
