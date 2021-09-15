using EmployeeManagement.Constant;
using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementWebUITest.JudgeTest
{
    class EV8001LogicTest
    {
        private readonly IEV8001Logic _ev8001Logic = null;
        public EV8001LogicTest(IEV8001Logic ev8001Logic)
        {
            _ev8001Logic = ev8001Logic;
        }
        public void RegisterTest(EmployeeInfoDAO testEntryValues)
        {
            // テスト用登録値格納
            decimal num = 10.00;
            testEntryValues = new EmployeeInfoDAO
            {
                EmployeeID = "",
                AffiliationCd = "",
                PositionCd = "",
                EmployeeNm = "",
                Gender = 1,
                BirthDay = DateTime.Now,
                BaseSalary = ,
                ForeignNationality = ,
                Memo = ,
                InsertUser = CommonConstants.MOD_USER_ID,
                InsertTime = DateTime.Now,
                UpdateUser = CommonConstants.MOD_USER_ID,
                UpdateTime = DateTime.Now,
            };

            _ev8001Logic.Register(testEntryValues);



            // 取得
            var selectquery = "SELECT * FROM employee_db.employee Where employee_id = @enteredId";

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                { "@enteredId",  enteredId }
            };

            var selectResult = repository.ExcuteQuery(selectquery, parametorNameAndValueDic);
            var EmpList = new List<EmployeeInfoDAO>();

            while (selectResult.Read())
            {
                EmpList.Add(new EmployeeInfoDAO()
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
                });
            }



        }
}
}
