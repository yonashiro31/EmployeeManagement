using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using EmployeeManagementWebUI.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Logic
{
    /// <summary>
    /// SLQから部署情報を取得するクラス
    /// </summary>
    /// <remarks>
    /// SQL接続し、
    /// </remarks>
    public class EV8001Logic : IEV8001Logic
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredId)
        {
            using var repository = new EmployeeSystemRepository();
            // ①DB接続の開始
            repository.Open();

            var selectquery = "SELECT * FROM employee_db.employee Where employee_id = @enteredId";

            // ③SQLのパラメータ設定

            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                // { SQLに指定した変数名, 変数に入れたい値 }
                { "@enteredId",  enteredId }
            };

            
            var selectResult = repository.ExcuteQuery(selectquery, parametorNameAndValueDic);
            var EmpList = new List<EmployeeInfoDAO>();
            // ToDo　修正箇所 
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
                }) ;
            }

            selectResult.Close();

            repository.Clone();
            return EmpList;
        }
        public void Register(List<EmployeeInfoDAO> entryValues)
        {

            using var repository = new EmployeeSystemRepository();
            // ①DB接続の開始
            repository.Open();

            var selectquery = @"Insert Into employee_db.employee
                               Values ('employeeId','affiliationCd','positionCd','employeeNm','gender','birthday','foreignNationality',
                              'baseSalary','memo','insertUser','insertTime','updateUser','updateTime')";
            
            var parametorNameAndValueDic = new Dictionary<string, object>()
            {
                // { SQLに指定した変数名, 変数に入れたい値 }
                { "@employeeId", entryValues[0].EmployeeID  },
                { "@affiliationCd", entryValues[0].AffiliationCd  },
                { "@positionCd", entryValues[0].PositionCd  },
                { "@employeeNm", entryValues[0].EmployeeNm },
                { "@gender", entryValues[0].Gender },
                { "@birthday", entryValues[0].BirthDay  },
                { "@foreignNationality", entryValues[0].ForeignNationality  },
                { "@baseSalary", entryValues[0].BaseSalary },
                { "@memo", entryValues[0].Memo },
                { "@insertUser", entryValues[0].insertUser },
                { "@insertTime", entryValues[0].insertTime },
                { "@updateUser", entryValues[0].updateUser },
                { "@updateTime", entryValues[0].updateTime }
            };

            SqlCommand selectcommand = new SqlCommand(selectquery);
        }
    }
}
