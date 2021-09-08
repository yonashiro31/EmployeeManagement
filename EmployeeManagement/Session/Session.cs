using System.Runtime.Serialization;

namespace EmployeeManagementWebUI.Common.Session
{
    /// <summary>
    /// 各セッション情報の格納
    /// </summary>
    /// <remarks>
    /// 各セッション情報の格納
    /// </remarks>
    [DataContract]
    public class Session
    {
        /// <summary>
        /// セッションクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// コンストラクタ
        /// </remarks>
        public Session()
        {
            MasterInfo = new MasterInfoForSession();
        }

        /// <summary>マスタ情報</summary>
        /// <remarks>マスタ情報</remarks>
        /// <value>マスタ情報</value>
        [DataMember]
        public MasterInfoForSession MasterInfo { get; set; }

        /// <summary>更新社員ID</summary>
        /// <remarks>更新社員ID</remarks>
        /// <value>更新社員ID</value>
        [DataMember]
        public string UpdateEmployeeID { get; set; }
    }
}
