using EmployeeManagement.Constant;
using EmployeeManagement.Logic;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementWebUITest.JudgeTest
{
    /// <summary>
    /// EV8001Logicテストクラス
    /// </summary>
    /// <remarks>登録した社員情報と、登録後取得した値を比較する</remarks>
    [TestFixture]
    class EV8001LogicTest
    {
        /// <summary>
        /// 登録メソッドテスト
        /// </summary>
        /// <remarks>社員情報を登録後、同じプライマリーキーで取得した値と比較する</remarks>
        [Test]
        public void RegisterTrueTest()
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();
            var test = new EV8001Logic();

            // Arrange
            var list = new List<EmployeeInfoDAO>()
            {
                new EmployeeInfoDAO
                {
                    EmployeeID = "10000000",
                    AffiliationCd = "1",
                    PositionCd = "1",
                    EmployeeNm = "テスト氏名",
                    Gender = 1,
                    BirthDay = new DateTime(2017, 7, 20),
                    BaseSalary = 100.00m,
                    ForeignNationality = true,
                    Memo = "テストメモ",
                    InsertUser = CommonConstants.MOD_USER_ID,
                    InsertTime = new DateTime(2017, 7, 20),
                    UpdateUser = CommonConstants.MOD_USER_ID,
                    UpdateTime = new DateTime(2017, 7, 20),
                }
            };

            // テスト用登録値格納
            list.ForEach(item => test.Register(item));
            // 取得
            var selectQuery = "SELECT * FROM employee_db.employee Where employee_id = @enteredId";

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                { "@enteredId",  "10000000" }
            };

            var selectResult = repository.ExcuteQuery(selectQuery, parametorNameAndValueDic);
            var empList = new List<EmployeeInfoDAO>();

            while (selectResult.Read())
            {
                empList = new List<EmployeeInfoDAO>()
                {
                    new EmployeeInfoDAO{
                    EmployeeID = selectResult[0].ToString(),
                    AffiliationCd = selectResult[1].ToString(),
                    PositionCd = selectResult[2].ToString(),
                    EmployeeNm = selectResult[3].ToString(),
                    Gender = Convert.ToInt32(selectResult[4]),
                    BirthDay = Convert.ToDateTime(selectResult[5]),
                    ForeignNationality = Convert.ToBoolean(selectResult[6]),
                    BaseSalary = Convert.ToDecimal(selectResult[7]),
                    Memo = selectResult[8].ToString(),
                    InsertUser = selectResult[9].ToString(),
                    InsertTime = Convert.ToDateTime(selectResult[10]),
                    UpdateUser = selectResult[11].ToString(),
                    UpdateTime = Convert.ToDateTime(selectResult[12]),
                    }
                };
            }

            var result = list.Any(item => empList.Any(item2 => item2.EmployeeID == item.EmployeeID));
            Assert.AreEqual(true, result);
            repository.Clone();
            // 登録情報削除
            repository.Open();
            var deleteQuery = "DELETE FROM employee_db.employee Where employee_id = @enteredId";

            var deleteParametorNameAndValueDic = new Dictionary<string, object>()
            {
                { "@enteredId",  "10000000" }
            };

            repository.ExcuteQuery(deleteQuery, deleteParametorNameAndValueDic);
            repository.Clone();
        }      
    }
}
