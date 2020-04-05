using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QcsWeb.Configuration;
using QcsWeb.Data;
using QcsWeb.Models;
using QcsWeb.Services;
using QcsWeb.ViewModels;
using System;
using System.Collections.Generic;

namespace QcsWebTest
{
    [TestClass]
    public class LightFeedbackServiceTest
    {
        private FeedbackConfiguration _mockFeedbackConfig;
        private Mock<IGenericRepository<Customer>> _mockCustomerRepository;



        [TestInitialize]
        public void Initialize()
        {
            _mockFeedbackConfig = PopulateFeedbackConfig();
            _mockCustomerRepository = new Mock<IGenericRepository<Customer>>();
        }

        [TestMethod]
        public void Ctor_CalledWithNullConfig_ShouldThrowArgumentNullException()
        {
            Func<LightFeedbackService> func = () => new LightFeedbackService(_mockCustomerRepository.Object, null);
            func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("feedbackSteps");
        }

        [TestMethod]
        public void Ctor_CalledWithNullGenericRepository_ShouldThrowArgumentNullException()
        {
            Func<LightFeedbackService> func = () => new LightFeedbackService(null, _mockFeedbackConfig);
            func.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("customerRepo");
        }

        [TestMethod]
        public void GetFeedbackQuestionByIntIdOne_ReturnsNameOfViewToDisplayFromConfigValuesIsFullName()
        {
            var target = new LightFeedbackService(_mockCustomerRepository.Object, PopulateFeedbackConfig());
            var result = target.GetFeedbackQuestion(1);
            result.Should().Be("FullName");
        }

        [TestMethod]
        public void GetFeedbackQuestionByIntIdTwo_ReturnsNameOfViewToDisplayFromConfigValuesIsEmail()
        {
            var target = new LightFeedbackService(_mockCustomerRepository.Object, PopulateFeedbackConfig());
            var result = target.GetFeedbackQuestion(2);
            result.Should().Be("Email");
        }

        [TestMethod]
        public void SaveFeedback_CallsCustomerRepositoryToInsertFeedback()
        {
            var target = new LightFeedbackService(_mockCustomerRepository.Object, PopulateFeedbackConfig());

            _mockCustomerRepository.Setup(x => x.Insert(It.IsAny<Customer>()));
            target.SaveFeedBack(InitialiseViewModel());

            _mockCustomerRepository.Verify(mock => mock.Insert(It.IsAny<Customer>()), Times.Once());
        }

        [TestMethod]
        public void SaveFeedback_CallsCustomerRepositoryToSaveFeedback()
        {
            var target = new LightFeedbackService(_mockCustomerRepository.Object, PopulateFeedbackConfig());

            _mockCustomerRepository.Setup(x => x.Insert(It.IsAny<Customer>()));
            _mockCustomerRepository.Setup(x => x.Save());
            target.SaveFeedBack(InitialiseViewModel());

            _mockCustomerRepository.Verify(mock => mock.Save(), Times.Once());
        }


        private FeedbackConfiguration PopulateFeedbackConfig()
        {
            return new FeedbackConfiguration()
            {
                listOfSteps = new Dictionary<string, string>
                {
                    { "1", "FullName" },
                    { "2", "Email" },
                    { "3", "Address" },
                    { "4", "Satisfy" },
                    { "5", "Brightness" },
                    { "6", "Summary"}
                 }
            };
        }

        private LightFeedbackVm InitialiseViewModel()
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
    }
}
