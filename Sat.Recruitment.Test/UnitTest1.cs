using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    public abstract class UnitTest1
    {
        public UnitTest1()
        {
            SetupMockObjects();
        }

        internal abstract void SetupMockObjects();
    }
}
