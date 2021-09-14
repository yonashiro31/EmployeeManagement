using EmployeeManagement.Session.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagementWebUI.DataAccess;
using System.Collections.Generic;

namespace EmployeeManagement.Session
{
    /// <summary>
    /// SLQから役職情報を取得するクラス
    /// </summary>
    /// <remarks>
    /// ドロップダウンリスト用の役職情報の取得を行う
    /// </remarks>
    public class EV8003Logic : IEV8003Logic
    {
        /// <summary>
        /// 役職情報の取得を行うメソッド
        /// </summary>
        /// <remarks>役職情報をリストに格納し返却する</remarks>
        public List<PositionDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();

            // DB接続の開始
            repository.Open();

            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectquery);
            var positionList = new List<PositionDAO>();
            
            while (selectResult.Read())
            {
                positionList.Add(new PositionDAO()
                {
                    PositionCd = selectResult[0].ToString(),
                    GradeCd = selectResult[1].ToString(),
                    RankCd = selectResult[2].ToString(),
                    PositionNm = selectResult[3].ToString(),
                });
            }

            selectResult.Close();
            repository.Clone();

            return positionList;
        }
    }
}