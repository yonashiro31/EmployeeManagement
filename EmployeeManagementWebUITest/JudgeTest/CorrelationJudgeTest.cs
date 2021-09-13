using EmployeeManagement.Judge;
using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using EmployeeManagementWebUITest.ControllerTest.Mock;
using EmployeeManagementWebUITest.JudgeTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementWebUITest.JudgeTest
{
    [TestFixture]
    class CorrelationJudgeTest
    {
        /// <summary>
        /// 社員ID相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果True時</remarks>
        /// <param name="value">社員ID</param>
        [TestCase(null)]
        public void IdCorrelationIdJudgeTrueTest(string value)
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock();
            var testTarget = new CorrelationJudge();
            employeeInfoDAOMock.EmployeeInfoListMock = new List<EmployeeInfoDAO>();

            employeeInfoDAOMock.EmployeeInfoListMock.ForEach(item => item.EmployeeID = value);

　          var testResult = testTarget.IdCorrelationIdJudge(employeeInfoDAOMock.EmployeeInfoListMock);

            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 社員ID相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果False時</remarks>
        /// <param name="value">社員ID</param>
        [TestCase("1")]
        public void IdCorrelationIdJudgeFalseTest(string value)
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock();
            var testTarget = new CorrelationJudge();
            employeeInfoDAOMock.EmployeeInfoListMock = new List<EmployeeInfoDAO>();

            employeeInfoDAOMock.EmployeeInfoListMock.ForEach(item => item.EmployeeID = value);

            var testResult = testTarget.IdCorrelationIdJudge(employeeInfoDAOMock.EmployeeInfoListMock);

            Assert.AreEqual(false, testResult);
        }

        /// <summary>
        /// 部署相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がTrue時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01","01")]
        public void AfCorrelationJudgeTrueTest(string inputValue,string sqlValue)
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock();
            var testTarget = new CorrelationJudge();
            employeeInfoDAOMock.EmployeeInfoListMock = new List<EmployeeInfoDAO>();

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    AffiliationCd = inputValue
                }
            };

            employeeInfoDAOMock.EmployeeInfoListMock.ForEach(item => item.AffiliationCd = sqlValue);
            var testResult = testTarget.AfCorrelationJudge(List,sCRN0002ViewModelMock.SCRN2ViewModelMock);
           
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 部署相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がfalse時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "00")]
        public void AfCorrelationJudgeFalseTest(string inputValue, string sqlValue)
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock();
            var testTarget = new CorrelationJudge();
            var List = new List<EmployeeInfoDAO>
            {
                new EmployeeInfoDAO() {AffiliationCd =sqlValue }
            };

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    AffiliationCd = inputValue
                }
            };

            var testResult = testTarget.AfCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock);
           
            Assert.AreEqual(false, testResult);
        }


        /// <summary>
        /// 役職相関チェックメソッドテスト
        /// </summary>
        /// <remarks>入力値がマスタに格納されている場合</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "01")]
        public void PosiCorrelationJudgeTrueTest(string inputValue, string sqlValue)
        {
           
            var testTarget = new CorrelationJudge();

            var List = new List<EmployeeInfoDAO>
            {
                new EmployeeInfoDAO() {PositionCd =sqlValue }
            };

            // 引数からSCRN002のインスタンスのPositionCdに値を渡す
            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    PositionCd = inputValue
                }
            };
            // それぞれの値をテスト対象メソッドに渡す
            var testResult = testTarget.PosiCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock);
           
            Assert.AreEqual(true, testResult);
        }

        /// <summary>
        /// 役職相関チェックメソッドテスト
        /// </summary>
        /// <remarks>結果がfalse時</remarks>
        /// <param name="inputValue">入力値</param>
        /// <param name="sqlValue">SQL値</param>
        [TestCase("01", "00")]
        public void PosiCorrelationJudgeFalseTest(string inputValue, string sqlValue)
        {
            var employeeInfoDAOMock = new EmployeeInfoDAOMock();
            var testTarget = new CorrelationJudge();
            var List = new List<EmployeeInfoDAO>
            {
                new EmployeeInfoDAO() {PositionCd =sqlValue }
            };

            var sCRN0002ViewModelMock = new SCRN0002ViewModelMock()
            {
                SCRN2ViewModelMock = new SCRN0002ViewModel()
                {
                    PositionCd = inputValue
                }
            };
           
            var testResult = testTarget.PosiCorrelationJudge(List, sCRN0002ViewModelMock.SCRN2ViewModelMock);
            
            Assert.AreEqual(false, testResult);
        }
    }
}
