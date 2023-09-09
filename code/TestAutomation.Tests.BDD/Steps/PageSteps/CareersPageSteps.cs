using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.PageSteps
{
    public class CareersPageSteps : BaseStep
    {
        protected CareersPage CareersPage { get; set; }
        public CareersPageSteps()
        {
            CareersPage = new CareersPage(Driver);
        }

    }
}
