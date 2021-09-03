using EmployeeManagement.Session.Interface;
using EmployeeManagement.SessionModel;
using EmployeeManagement.ViewModel;
using EmployeeManagementWebUI.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeManagement.Session
{
    /// <summary>
    /// SLQから部署情報を取得するクラス
    /// </summary>
    /// <remarks>
    /// SQL接続し、
    /// </remarks>
    public class EV8003Logic : IEV8003Logic
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PositionDO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();

            // ①DB接続の開始
            repository.Open();

            // ②SQLの生成

            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            // ③SQLのパラメータ設定
            SqlCommand selectcommand = new SqlCommand(selectquery);

            var selectResult = repository.ExcuteQuery(selectquery);
            var cdList = new List<PositionDO>();
            // ToDo　修正箇所 
            while (selectResult.Read())
            {
                cdList.Add(new PositionDO()
                {
                    PositionCd = selectResult[0].ToString(),
                    ManagementCd = selectResult[1].ToString(),
                    BrunchCd = selectResult[2].ToString(),
                    GroupCd = selectResult[3].ToString(),
                    ManagementNm = selectResult[4].ToString(),
                    BrunchNm = selectResult[5].ToString(),
                    GroupNm = selectResult[6].ToString(),
                    ManagementEmployeeId = selectResult[7].ToString(),
                });
            }

            selectResult.Close();

            repository.Clone();
            return cdList;
        }
    }
}