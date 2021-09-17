using EmployeeManagement.Judge;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using System.Collections.Generic;

namespace EmployeeManagement.Session
{
    /// <summary>
    /// 部署情報取得クラス
    /// </summary>
    /// <remarks>
    /// SLQから部署情報を取得するクラス
    /// </remarks>
    public class EV8002Logic : IEV8002Logic
    {
        /// <summary>
        /// 部署情報取得を行うメソッド
        /// </summary>
        /// <remarks>SQL接続し、部署情報の取得を行う</remarks>
        /// <returns>部署情報をリストに格納し返す</returns>
        public List<AffiliationDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();
            // DB接続の開始
            repository.Open();

            // SQLの生成
            var selectQuery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectQuery);
            var affiliationList = new List<AffiliationDAO>();

            while (selectResult.Read())
            {
                affiliationList.Add(new AffiliationDAO()
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

            affiliationList.ForEach(item => item.AffiliationNm = ValueJudge.AffiliationNmCheck(item));

            return affiliationList;
        }
    }
}
