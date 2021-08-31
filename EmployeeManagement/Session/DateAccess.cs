using EmployeeManagement.Session.Interface;
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
    public class DateAccess : IDateAccess
    {
        public List<string> DateSelect()
        {
            using var repository = new EmployeeSystemRepository();

            // ①DB接続の開始
            repository.Open();

            // ②SQLの生成
            string selectquery = "SELECT management_cd, management_nm FROM employee_db.m_affiliation ";
            SqlCommand selectcommand = new SqlCommand(selectquery);
            // ③SQLのパラメータ設定
            SqlDataReader reader = selectcommand.ExecuteReader();
            List<string> cdList = new List<string>();
            
            // ToDo　修正箇所 
            var resultcdList = cdList.Select(item => item = reader.GetString(0)).ToList(); ;
            
            reader.Close();
            // ④SQLの実行

            // ⑤SQL結果の取得

            // ⑥DB接続の終了
            repository.Clone();
            return resultcdList;
        }
    }
}
