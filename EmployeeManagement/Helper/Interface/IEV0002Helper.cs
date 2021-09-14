using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// EV0001Helperインターフェース
    /// </summary>
    /// <remarks>
    /// Controllerの補助を行う
    /// </remarks>
    public interface IEV0002Helper
    {
        /// <summary>
        /// 初期表示メソッド
        /// </summary>
        /// <remarks>
        /// 初期表示に必要な処理を行う
        /// </remarks>
        public SCRN0002ViewModel Init();

        /// <summary>
        /// 新規登録メソッド
        /// </summary>       
        /// <returns>
        /// 新規登録に必要な処理を行う
        /// </returns>
        /// <param name="entry">新規登録用入力情報</param>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel entry);
    }
}