﻿using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Logic
{
    /// <summary>
    /// SLQから部署情報を取得するクラス
    /// </summary>
    /// <remarks>
    /// SQL接続し、IDに該当する社員情報を取得する
    /// </remarks>
    public class EV8001Logic : IEV8001Logic
    {
        /// <summary>
        /// 社員情報取得メソッド
        /// </summary>
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredId)
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

            var selectquery = "SELECT * FROM employee_db.employee Where employee_id = @enteredId";

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                // { SQLに指定した変数名, 変数に入れたい値 }
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
        /// SQL登録クラス
        /// </summary>
        /// <remarks>入力値をSQLに登録する</remarks>
        /// <param name="entryValues">登録用入力値</param>
        public void Register(EmployeeInfoDAO entryValues)
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

            if (entryValues.Memo == null)
            {
                entryValues.Memo = "";
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
                { "@insertUser", entryValues.insertUser },
                { "@insertTime", entryValues.insertTime },
                { "@updateUser", entryValues.updateUser },
                { "@updateTime", entryValues.updateTime }
            };

            repository.ExcuteNonQuery(insertQuery, parametorNameAndValueDic);
            repository.Clone();
        }
    }
}
