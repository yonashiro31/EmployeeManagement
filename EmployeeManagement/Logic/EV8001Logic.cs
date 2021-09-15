using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Logic
{
    /// <summary>
    /// SLQ接続クラス
    /// </summary>
    /// <remarks>
    /// 社員情報を取得と登録を行うメソッドを宣言する
    /// </remarks>
    public class EV8001Logic : IEV8001Logic
    {
        /// <summary>
        /// 社員情報取得メソッド
        /// </summary>
        /// <remarks>入力IDに対応した社員情報を取得する</remarks>
        /// <param name="enteredId">入力した社員ID</param>
        /// <returns>IDに紐づいた社員情報を返却する</returns>
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredId)
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

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
                });
            }

            selectResult.Close();
            repository.Clone();

            return EmpList;
        }
        /// <summary>
        /// 新規登録メソッド
        /// </summary>
        /// <remarks>登録用の値をSQLに登録する</remarks>
        /// <param name="entryValues">登録用入力値</param>
        public void Register(EmployeeInfoDAO entryValues)
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

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
        }
    }
}
