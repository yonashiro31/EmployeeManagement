using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// SCRN0001Controllerを補助するクラス
    /// </summary>
    /// <remarks>
    /// SCRN0001Controllerを補助するクラス
    /// </remarks>
    public class EV0001Helper : IEV0001Helper
    {
        /// <summary>
        /// SCRN0001ViewModelのデータを渡すメソッド
        /// </summary>
        /// <remarks>
        /// SCRN0001ViewModelのデータを渡すメソッド
        /// </remarks>
        public SCRN0001ViewModel Init()
        {
            SCRN0001ViewModel scrn0001ViewModelinstance = new SCRN0001ViewModel();
            return scrn0001ViewModelinstance;
        }
    }
}
