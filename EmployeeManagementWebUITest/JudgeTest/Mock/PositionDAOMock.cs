using EmployeeManagement.LogicDTO;

namespace EmployeeManagementWebUITest.JudgeTest.Mock
{
    /// <summary>
    /// PositionDAOMockクラス
    /// </summary>
    /// <remarks>役職情報を必要とするテストに利用する</remarks>
    class PositionDAOMock
    {
        /// <summary>役職情報プロパティ</summary>
        /// <remarks>Mock用の役職情報</remarks>
        /// <value>役職情報プロパティ</value>
        public PositionDAO TestPositionDAOMock { get; set; }
    }
}
