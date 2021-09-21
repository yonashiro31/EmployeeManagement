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
    public class EV8001LogicTest
    {
        /// <summary>
        /// DB情報取得メソッドテスト
        /// </summary>
        /// <remarks>社員情報を登録後取得し、比較する</remarks>
        [Test]
        public void FindByPrimaryKeyTest()
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

            var entryValues = new EmployeeInfoDAO
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
            };

            if (string.IsNullOrEmpty(entryValues.Memo))
            {
                entryValues.Memo = string.Empty;
            }

            var insertQuery = @"Insert Into employee_db.employee
                               Values (@employeeId,@affiliationCd,@positionCd,@employeeNm,@gender,@birthday,@foreignNationality,"
                               + "@baseSalary,@memo,@insertUser,@insertTime,@updateUser,@updateTime)";

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                // { SQLに指定した変数名, 変数に入れたい値 }
                { "@employeeId", entryValues.EmployeeID  },
                { "@affiliationCd", entryValues.AffiliationCd  },
                { "@positionCd", entryValues.PositionCd  },
                { "@employeeNm", entryValues.EmployeeNm },
                { "@gender", entryValues.Gender },
                { "@birthday", entryValues.BirthDay  },
                { "@foreignNationality", entryValues.ForeignNationality  },
                { "@baseSalary", entryValues.BaseSalary },
                { "@memo", entryValues.Memo },
                { "@insertUser", entryValues.InsertUser },
                { "@insertTime", entryValues.InsertTime },
                { "@updateUser", entryValues.UpdateUser },
                { "@updateTime", entryValues.UpdateTime }
            };

            repository.ExcuteNonQuery(insertQuery, parametorNameAndValueDic);
            repository.Clone();

            var eV8001Logic = new EV8001Logic();
            var getValues = eV8001Logic.FindByPrimaryKey(entryValues.EmployeeID);

            var result = getValues.Any(item => item.EmployeeID == entryValues.EmployeeID);
            Assert.AreEqual(true, result);

            Assert.AreEqual("10000000", entryValues.EmployeeID);
            Assert.AreEqual("1", entryValues.AffiliationCd);
            Assert.AreEqual("1", entryValues.PositionCd);
            Assert.AreEqual("テスト氏名", entryValues.EmployeeNm);
            Assert.AreEqual(1, entryValues.Gender);
            Assert.AreEqual(new DateTime(2017, 7, 20), entryValues.BirthDay);
            Assert.AreEqual(100.00m, entryValues.BaseSalary);
            Assert.AreEqual(true, entryValues.ForeignNationality);
            Assert.AreEqual("テストメモ", entryValues.Memo);
            Assert.AreEqual(CommonConstants.MOD_USER_ID, entryValues.InsertUser);
            Assert.AreEqual(new DateTime(2017, 7, 20), entryValues.InsertTime);
            Assert.AreEqual(CommonConstants.MOD_USER_ID, entryValues.UpdateUser);
            Assert.AreEqual(new DateTime(2017, 7, 20), entryValues.UpdateTime);

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

        /// <summary>
        /// 登録メソッドテスト
        /// </summary>
        /// <remarks>備考入力時未入力時の2パターンテストする</remarks>
        /// <param name="memo">備考</param>
        [TestCase("")]
        [TestCase("テストメモ")]
        public void RegisterTrueTest(string memo)
        {
            using var repository = new EmployeeSystemRepository();
            var eV8001Logic = new EV8001Logic();

            // Arrange
            var inputList = new List<EmployeeInfoDAO>()
            {
                new EmployeeInfoDAO
                {
                    EmployeeID = "10000000",
                    AffiliationCd = "1",
                    PositionCd = "1",
                    EmployeeNm = memo,
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

            inputList.ForEach(item => eV8001Logic.Register(item));

            repository.Open();
            var selectQuery = "SELECT * FROM employee_db.employee Where employee_id = @enteredId";

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                { "@enteredId",  "10000000" }
            };

            var selectResult = repository.ExcuteQuery(selectQuery, parametorNameAndValueDic);
            var getList = new List<EmployeeInfoDAO>();

            while (selectResult.Read())
            {
                getList = new List<EmployeeInfoDAO>()
                {
                    new EmployeeInfoDAO
                    {
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

            selectResult.Close();

            Assert.AreEqual("10000000", getList[0].EmployeeID);
            Assert.AreEqual("1", getList[0].AffiliationCd);
            Assert.AreEqual("1", getList[0].PositionCd);
            Assert.AreEqual("テスト氏名", getList[0].EmployeeNm);
            Assert.AreEqual(1, getList[0].Gender);
            Assert.AreEqual(new DateTime(2017, 7, 20), getList[0].BirthDay);
            Assert.AreEqual(100.00m, getList[0].BaseSalary);
            Assert.AreEqual(true, getList[0].ForeignNationality);
            Assert.AreEqual(memo, getList[0].Memo);
            Assert.AreEqual(CommonConstants.MOD_USER_ID, getList[0].InsertUser);
            Assert.AreEqual(new DateTime(2017, 7, 20), getList[0].InsertTime);
            Assert.AreEqual(CommonConstants.MOD_USER_ID, getList[0].UpdateUser);
            Assert.AreEqual(new DateTime(2017, 7, 20), getList[0].UpdateTime);

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
