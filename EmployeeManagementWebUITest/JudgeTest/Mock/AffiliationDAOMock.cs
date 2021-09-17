using EmployeeManagement.LogicDTO;

namespace EmployeeManagementWebUITest.ControllerTest.Mock
{
    /// <summary>
    /// AffiliationDAOのモッククラス
    /// </summary>
    /// <remarks>部門情報を必要とするテストに利用する</remarks>
    class AffiliationDAOMock
    {
        /// <summary>部門情報プロパティ</summary>
        /// <remarks>Mock用の部門情報</remarks>
        /// <value>部門情報プロパティ</value>
        public AffiliationDAO TestAffiliationDAO { get; set; }
    }
}
