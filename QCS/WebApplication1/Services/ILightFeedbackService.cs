using QcsWeb.Models;
using QcsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Services
{
   public interface ILightFeedbackService
    {
        string GetFeedbackQuestion(int currentStep);
        string SaveFeedBack(LightFeedbackVm lightFeedBackVm);
    }
}
