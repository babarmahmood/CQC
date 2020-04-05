using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QcsWeb.Configuration;
using QcsWeb.Data;
using QcsWeb.Helpers;
using QcsWeb.Models;
using QcsWeb.ViewModels;

namespace QcsWeb.Services
{
    public class LightFeedbackService : ILightFeedbackService
    {
        private readonly FeedbackConfiguration _feedbackSteps;
        private readonly IGenericRepository<Customer> _customerRepo;

        public LightFeedbackService(IGenericRepository<Customer> customerRepo,
                                    FeedbackConfiguration feedbackSteps)
        {
            _customerRepo = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo));
            _feedbackSteps = feedbackSteps ?? throw new ArgumentNullException(nameof(feedbackSteps));
        }

        public string GetFeedbackQuestion(int currentStep)
        {
            var viewToDisplay = _feedbackSteps.listOfSteps.Where(x => int.Parse(x.Key) == currentStep).FirstOrDefault().Value;
            return viewToDisplay;
        }

        public string SaveFeedBack(LightFeedbackVm lightFeedBackVm)
        {
            var dateCreated = DateTime.Now;
            var customer = new Customer()
            {
                FullName = lightFeedBackVm.FullNameVm.FullName,
                Email = lightFeedBackVm.EmailVm.EmailAddress,
                DateCreated = dateCreated,
                Address = new Address()
                {
                    BuildingAndStreet = lightFeedBackVm.HomeAddress.BuildindAndStreet,
                    TownOrCity = lightFeedBackVm.HomeAddress.TownOrCity,
                    County = lightFeedBackVm.HomeAddress.County,
                    PostCode = lightFeedBackVm.HomeAddress.PostCode,
                    DateCreated = dateCreated
                },
                LightSurvey = new LightFeedback
                {
                    IsHappy = lightFeedBackVm.IsHappy,
                    BrightnessLevel = lightFeedBackVm.LevelOfBrightness,
                    DateCreated = dateCreated
                }
            };
            _customerRepo.Insert(customer);
            _customerRepo.Save();

            return _feedbackSteps.listOfSteps.Last().Value;
        }

    }
}
