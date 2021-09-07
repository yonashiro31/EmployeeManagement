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
    public class EV8003Logic : IEV8003Logic
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PositionDAO> FindAll()
        {
            using var repository = new EmployeeSystemRepository();

            // DB接続の開始
            repository.Open();

            var selectquery = "SELECT * FROM employee_db.m_affiliation";

            var selectResult = repository.ExcuteQuery(selectquery);
            var PositionList = new List<PositionDAO>();
            // ToDo　修正箇所 
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