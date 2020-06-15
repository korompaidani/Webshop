using CommonServices.Authentication;
using System;
using System.Collections.Generic;
using Xunit;

namespace CommonServices.Test
{
    public class SimulatedAuthenticationServiceUnitTest
    {
        private const string validEmail = "sd123@gmail.com";
        private SimulatedAuthenticationService _service;

        // XUnit doesn't have attribute to Setup than e.g. NUnit Framework
        // so it's a constructor's responsibility
        public SimulatedAuthenticationServiceUnitTest()
        {
            _service = new SimulatedAuthenticationService();
        }

        [Fact]
        public void EmailValidationTest()
        {
            bool result = _service.IsEmailValid("");
            Assert.False(result);

            result = _service.IsEmailValid("korompaidani@gmail.com");
            Assert.False(result);

            result = _service.IsEmailValid(validEmail);
            Assert.True(result);
        }

        [Fact]
        public void GetTheSettedEmail()
        {
            var parameterPair = new KeyValuePair<string, string>("email", "name");          
            _service.SetLoggedUser(parameterPair);

            var resultPair = _service.GetLoggedUser();
            Assert.Equal(parameterPair, resultPair);
        }
    }
}
