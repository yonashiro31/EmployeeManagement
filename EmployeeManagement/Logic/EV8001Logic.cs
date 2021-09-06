using EmployeeManagement.Logic.Interface;
using EmployeeManagement.SessionModel;
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

            // ②SQLの生成

            var selectquery = "SELECT employee_id FROM employee_db.employee Where employee_id = @enteredId";

            // ③SQLのパラメータ設定
            SqlCommand selectcommand = new SqlCommand(selectquery);

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
                    Gender = selectResult[4].ToString(),
                    BirthDay = selectResult[5].ToString(),
                    ForeignNationality = (bool)selectResult[6],
                    BaseSalary = selectResult[7].ToString(),
                    Memo = selectResult[8].ToString(),
                });
            }

            selectResult.Close();

            repository.Clone();
            return EmpList;
        }
        public void Register()
        {

            using var repository = new EmployeeSystemRepository();
            // ①DB接続の開始
            repository.Open();

            // ②SQLの生成

            var selectquery = @"Insert Into employee_db.m_affiliation
                              (affiliation_cd,management_cd,management_nm,insert_user,insert_time,update_user,update_time)
                               Values (1,1,'総務','teruki','2019-10-04 15:25:07','teruki','2019-10-04 15:25:07')";

            SqlCommand selectcommand = new SqlCommand(selectquery);
        }
    }
}
