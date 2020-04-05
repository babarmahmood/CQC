using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QcsWeb.ViewModels;

namespace QcsWeb.Services
{
    public class TempDataService : ITempDataService
    {
        public LightFeedbackVm InitialiseViewModel()
        {
            var lightFeedbackVm = new LightFeedbackVm()
            {
                FullNameVm = new FullNameVm(),
                EmailVm = new EmailVm(),
                HomeAddress = new AddressVm(),
                CurrentStep = 1
            };
            return lightFeedbackVm;
        }

        public LightFeedbackVm UpdateTempData(LightFeedbackVm tempData, LightFeedbackVm lightFeedBackVm, bool displaySameView)
        {
            if (lightFeedBackVm.EmailVm != null)
            {
                tempData.EmailVm = lightFeedBackVm.EmailVm;
            }
            if (lightFeedBackVm.FullNameVm != null)
            {
                tempData.FullNameVm = lightFeedBackVm.FullNameVm;
            }
            if (lightFeedBackVm.HomeAddress != null)
            {
                tempData.HomeAddress.BuildindAndStreet = lightFeedBackVm.HomeAddress.BuildindAndStreet;
                tempData.HomeAddress.TownOrCity = lightFeedBackVm.HomeAddress.TownOrCity;
                tempData.HomeAddress.County = lightFeedBackVm.HomeAddress.County;
                tempData.HomeAddress.PostCode = lightFeedBackVm.HomeAddress.PostCode;
            }

            if (tempData.CurrentStep == 4)
                tempData.IsHappy = lightFeedBackVm.IsHappy;

            if (lightFeedBackVm.LevelOfBrightness > 0)
                tempData.LevelOfBrightness = lightFeedBackVm.LevelOfBrightness;

            if (!displaySameView)
                tempData.CurrentStep = lightFeedBackVm.IsNextButtonClicked ? tempData.CurrentStep + 1 : tempData.CurrentStep - 1;

            return tempData;
        }
    }
}
