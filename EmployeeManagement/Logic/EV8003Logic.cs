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
    /// SQL接続し、
    /// </remarks>
    public class EV8003Logic : IEV8003Logic
    {
        /// <summary>
        /// 部署情報の取得を行うクラス
        /// </summary>
        /// <remarks>SQL接続を行う</remarks>
        public List<PositionDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();

            // DB接続の開始
            repository.Open();

            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectquery);
            var PositionList = new List<PositionDAO>();
            
            while (selectResult.Read())
            {
                PositionList.Add(new PositionDAO()
                {
                    PositionCd = selectResult[0].ToString(),
                    GradeCd = selectResult[1].ToString(),
                    RankCd = selectResult[2].ToString(),
                    PositionNm = selectResult[3].ToString(),
                });
            }

            selectResult.Close();
            repository.Clone();

            return PositionList;
        }
    }
}