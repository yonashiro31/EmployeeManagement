using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// インターフェース
    /// </summary>
    /// <remarks>
    /// EV0001Helperのインターフェース
    /// </remarks>
    public interface IEV0001Helper
    {

        /// <summary>
        /// 社員管理メニュー画面で利用するメソッド
        /// </summary>
        /// <remarks>
        /// SCRN0001ViewModelのデータを渡す
        /// </remarks>
        public SCRN0001ViewModel Init();
    }
}
