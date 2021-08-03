using EmployeeManagement.Helper;
using EmployeeManagement.ViewModel;

namespace EmployeeManagementWebUITest.ControllerTest.Mock
{
    /// <summary>
    /// 初期表示時テスト用Mock
    /// </summary>
    /// <remarks>
    /// IE0001VHelperの代替クラス
    /// </remarks>
    class SCRN0001Mock : IEV0001Helper
    {
        /// <summary>初期表示画面テスト用プロパティ</summary>
        /// <remarks>SCRN001ViewModelを格納する</remarks>
        public SCRN0001ViewModel SCRN0001ViewModelMock { get; set; }

        /// <summary>
        /// テストメソッド
        /// </summary>
        /// <remarks>
        /// SCRN001ViewModelを返す
        /// </remarks>
        /// <returns>SCRN0001ViewModelから値を与えるプロパティ</returns>
        public SCRN0001ViewModel Init()
        {
            return SCRN0001ViewModelMock;
        }
    }
}
