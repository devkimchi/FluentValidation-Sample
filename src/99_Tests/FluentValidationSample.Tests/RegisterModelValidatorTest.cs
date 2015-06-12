using System;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using FluentValidationSample.WebApp.Models;
using FluentValidationSample.WebApp.Validators;
using NUnit.Framework;

namespace FluentValidationSample.Tests
{
    [TestFixture]
    public class RegisterModelValidatorTest
    {
        private IValidator _validator;

        [SetUp]
        public void Init()
        {
            this._validator = new RegisterViewModelValidator();
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        [TestCase("email", "password", "password", false)]
        [TestCase(null, "password", "password", false)]
        [TestCase("e@mail.com", "password", "password", true)]
        public void RegisterViewModel_Should_Be_Validated(string email, string password, string confirmPassword, bool expected)
        {
            var result = this._validator.Validate(new RegisterViewModel()
                                                      {
                                                          Email = email,
                                                          Password = password,
                                                          ConfirmPassword = confirmPassword,
                                                      });
            result.IsValid.Should().Be(expected);
        }

        [Test]
        [TestCase("password", false)]
        [TestCase(null, true)]
        public void Password_Should_Be_Validated(string password, bool exceptionExpected)
        {
            var validator = this._validator as RegisterViewModelValidator;
            try
            {
                validator.ShouldNotHaveValidationErrorFor(p => p.Password, password);
            }
            catch (ValidationTestException ex)
            {
                if (exceptionExpected)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        [TestCase("password", "password", false)]
        [TestCase("password", "different", true)]
        public void ConfirmPassword_Should_Be_Validated(string password, string confirmPassword, bool exceptionExpected)
        {
            var validator = this._validator as RegisterViewModelValidator;
            try
            {
                validator.ShouldNotHaveValidationErrorFor(
                    p => p.ConfirmPassword,
                    new RegisterViewModel() { Password = password, ConfirmPassword = confirmPassword });
            }
            catch (ValidationTestException ex)
            {
                if (exceptionExpected)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}