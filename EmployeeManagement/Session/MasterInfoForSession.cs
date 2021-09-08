using EmployeeManagement.Session;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmployeeManagementWebUI.Common.Session
{
    /// <summary>
    /// セッション用マスタ情報
    /// </summary>
    /// <remarks>
    /// セッション用マスタ情報
    /// </remarks>
    [DataContract]
    public class MasterInfoForSession
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// コンストラクタ
        /// </remarks>
        public MasterInfoForSession()
        {
            AffiliationInfoList = new List<AffiliationInfo>();
            PositionInfoList = new List<PositionInfo>();
        }

        /// <summary>部署情報リスト</summary>
        /// <remarks>部署情報リスト</remarks>
        /// <value>部署情報リスト</value>
        [DataMember]
        public IEnumerable<AffiliationInfo> AffiliationInfoList { get; set; }

        /// <summary>役職情報リスト</summary>
        /// <remarks>役職情報リスト</remarks>
        /// <value>役職情報リスト</value>
        [DataMember]
        public IEnumerable<PositionInfo> PositionInfoList { get; set; }
    }
}
