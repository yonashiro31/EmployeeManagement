using EmployeeManagement.EmployeeManagement.Model;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// Viewに表示するデータを設定するクラス
    /// </summary>
    /// <remarks>
    /// Viewに表示するデータを設定する
    /// </remarks>
    public class SCRN0001ViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 各プロパティの初期値を設定する。
        /// </remarks>
        public SCRN0001ViewModel()
        {
            ErrorMessageList = new List<ErrorMessageModel>();
            EmployeeID = string.Empty;
        }

        /// <summary>エラーメッセージリストの取得と設定</summary>
        /// <remarks>エラーメッセージリストの取得と設定</remarks>
        /// <value>エラーメッセージリスト</value>
        public IList<ErrorMessageModel> ErrorMessageList { get; set; }

        /// <summary>社員IDの取得と設定</summary>
        /// <remarks>社員IDの取得と設定</remarks>
        /// <value>社員ID</value>
        public string EmployeeID { get; set; }
    }
}




