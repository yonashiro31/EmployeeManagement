using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUITest.ControllerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementWebUITest.JudgeTest
{
    [TestFixture]
    class CorrelationJudgeTest
    {
        [Test]
        public void IdCorrelationIdJudgeTest()
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock()
            {
                EmployeeInfoMock = new EmployeeInfoDAO()
                {

                }
            };

            var testTarget = new CorrelationJudgeTest();
        }

    }
}
