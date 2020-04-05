using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QcsWeb.Data;
using QcsWeb.Helpers;
using QcsWeb.Models;
using QcsWeb.Services;
using QcsWeb.ViewModels;

namespace QcsWeb.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ILightFeedbackService _lightFeedbackService;
        private readonly ITempDataService _tempDataService;
        private const string _feedbackTempDataKey = "feedbackTempData";

        public SurveyController(ILightFeedbackService lightFeedbackService,
                               ITempDataService tempDataService)
        {
            _lightFeedbackService = lightFeedbackService;
            _tempDataService = tempDataService;
        }

        public IActionResult Index()
        {
            var currentView = new LightFeedbackVm()
            {
                FullNameVm = new FullNameVm(),
                EmailVm = new EmailVm(),
                HomeAddress = new AddressVm(),
                CurrentStep = 1
            };
            TempDataHelper.Put<LightFeedbackVm>(TempData, _feedbackTempDataKey, currentView);
            return View(currentView);
        }


        public IActionResult GetNextQuestion(LightFeedbackVm lightingSurveyVm)
        {
           
            if (!ModelState.IsValid)
            {
                var feedbackTempVm = UpdateTempData(lightingSurveyVm, true);
                var view = _lightFeedbackService.GetFeedbackQuestion(feedbackTempVm.CurrentStep);
                return  PartialView(view, feedbackTempVm);
            }
            var feedbackVm = UpdateTempData(lightingSurveyVm, false);
            var viewToDisplay = _lightFeedbackService.GetFeedbackQuestion(feedbackVm.CurrentStep);
            return PartialView(viewToDisplay, feedbackVm);
        }

        public IActionResult GetViewById(int viewId)
        {
            var feedbackTempData = TempDataHelper.Get<LightFeedbackVm>(TempData, _feedbackTempDataKey);
            var viewToDisplay = _lightFeedbackService.GetFeedbackQuestion(viewId);
            feedbackTempData.CurrentStep = viewId;
            TempDataHelper.Put<LightFeedbackVm>(TempData, _feedbackTempDataKey, feedbackTempData);
            return PartialView(viewToDisplay, feedbackTempData);
        }

        public IActionResult SaveData()
        {
            var currentVm = TempDataHelper.Get<LightFeedbackVm>(TempData, _feedbackTempDataKey);
            _lightFeedbackService.SaveFeedBack(currentVm);
            return PartialView("Complete");
        }

        private LightFeedbackVm UpdateTempData(LightFeedbackVm lightingSurveyVm, bool displaySameView)
        {
            var currentVm = TempDataHelper.Get<LightFeedbackVm>(TempData, _feedbackTempDataKey);
            var updatedTempData = _tempDataService.UpdateTempData(currentVm, lightingSurveyVm, displaySameView);
            TempDataHelper.Put<LightFeedbackVm>(TempData, _feedbackTempDataKey, updatedTempData);
            return updatedTempData;
        }
    }
}