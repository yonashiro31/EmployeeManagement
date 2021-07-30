using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.EmployeeManagement.Model
{
    /// <summary>
    /// エラーメッセージとidの取得と設定を行う
    /// </summary>
    /// <remarks>
    /// Viewmodelに渡す
    /// </remarks>    
    public class ErrorMessageModel
    ///<summary>メッセージidの取得と設定</summary>    
    ///<remarks>メッセージidの取得と設定</remarks>
    ///<value>メッセージid</value>
    {
        public string MessageID { get; set; }
        ///<summary>メッセージの取得と設定</summary>    
        ///<remarks>メッセージの取得と設定</remarks>
        ///<value>表示メッセージ</value>
        public string DisplayForMessage { get; set; }
    }
}
