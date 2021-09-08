using EmployeeManagement.Judge;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using System.Collections.Generic;

namespace EmployeeManagement.Session
{
    /// <summary>
    /// SLQから部署情報を取得するクラス
    /// </summary>
    /// <remarks>
    /// 部署情報を取得する
    /// </remarks>
    public class EV8002Logic : IEV8002Logic
    {
        /// <summary>
        /// SQL接続と社員情報取得を行う
        /// </summary>
        /// <remarks>SQL接続と社員情報取得を行う</remarks>
        public List<AffiliationDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();
            ValueJudge valueJudge = new ValueJudge();
            // DB接続の開始
            repository.Open();

            // SQLの生成
            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectquery); 
            var AffiliationList = new List<AffiliationDAO>();
           
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
