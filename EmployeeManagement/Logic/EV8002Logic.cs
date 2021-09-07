using EmployeeManagement.Judge;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.LogicDTO;
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
    public class EV8002Logic : IEV8002Logic
    {
        /// <summary>
        /// 
        /// </summary>
        public List<AffiliationDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();
            ValueJudge valueJudge = new ValueJudge();
            // ①DB接続の開始
            repository.Open();

            // ②SQLの生成
            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectquery); 
            var AffiliationList = new List<AffiliationDAO>();
            // ToDo　修正箇所 
            while (selectResult.Read())
            {
                AffiliationList.Add(new AffiliationDAO()
                {
                    AffiliationCd = selectResult[0].ToString(),
                    ManagementCd = selectResult[1].ToString(),
                    BrunchCd = selectResult[2].ToString(),
                    GroupCd = selectResult[3].ToString(),
                    ManagementNm = selectResult[4].ToString(),
                    BrunchNm = selectResult[5].ToString(),
                    GroupNm = selectResult[6].ToString(),
                    ManagementEmployeeId = selectResult[7].ToString(),
                    AffiliationNm = selectResult[8].ToString(),
                });
            }
            selectResult.Close();
            repository.Clone();

            AffiliationList.ForEach(item => item.AffiliationNm = valueJudge.AffiliationNmCheck(item));
                    
            return AffiliationList;
        }
    }
}
