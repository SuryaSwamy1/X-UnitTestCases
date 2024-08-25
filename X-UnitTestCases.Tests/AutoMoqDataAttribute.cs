using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_UnitTestCases.Interfaces;
using X_UnitTestCases.Logic;
using X_UnitTestCases.Models;

namespace X_UnitTestCases.Tests
{
    [ExcludeFromCodeCoverage]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(Extensions.CreateFixture) { }
    }

    [ExcludeFromCodeCoverage]
    public class InLineAutoMoqDataAttribute : InlineAutoDataAttribute 
    {
        public InLineAutoMoqDataAttribute(params object[] objects) : base(new AutoMoqDataAttribute(), objects)
        {

        }
    }

    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(x => fixture.Behaviors.Remove(x));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());   
            fixture.Register(() =>
            {
                var model = fixture.Build<User>()
                .With(x => x.AccountNumber, fixture.Create<string>)
                .With(x => x.AccountHolder, fixture.Create<string>)
                .With(x => x.Balance, fixture.Create<decimal>)
                .Create();
                return model;
            });
            fixture.Register(() => fixture.Freeze<Interfaces.IVerifyTransactions>());
            fixture.Register(() => fixture.Freeze<Mock<Interfaces.IVerifyTransactions>>().Object);
            return fixture;
        }
    }
}
