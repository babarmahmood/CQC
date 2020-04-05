using QcsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Services
{
    public interface ITempDataService
    {
        LightFeedbackVm InitialiseViewModel();
        LightFeedbackVm UpdateTempData(LightFeedbackVm tempData, LightFeedbackVm lightFeedBackVm,  bool displaySameView);
    }
}
