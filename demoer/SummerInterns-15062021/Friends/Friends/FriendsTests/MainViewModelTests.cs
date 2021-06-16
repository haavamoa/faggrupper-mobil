using System;
using FluentAssertions;
using Friends.Services;
using Friends.ViewModels;
using Moq;
using Xunit;

namespace FriendsTests
{
    public class MainViewModelTests
    {
        private readonly MainViewModel m_mainViewModel;

        public MainViewModelTests()
        {
            m_mainViewModel = new MainViewModel(new Mock<IFriendsService>().Object, new Mock<IPlatformService>().Object);
        }

        [Fact]
        public async void Method_Scenario_Expectation()
        {
            await m_mainViewModel.Initialize();
            m_mainViewModel.Friends.Should().NotBeEmpty();
        }  
    }
}