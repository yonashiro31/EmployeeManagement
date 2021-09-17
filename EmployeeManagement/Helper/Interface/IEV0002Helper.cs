using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// EV0002Helperインターフェース
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
        /// <returns>
        /// 初期表示用ViewModelを返却する
        /// </returns>
        public SCRN0002ViewModel Init();

        /// <summary>
        /// 新規登録メソッド
        /// </summary>       
        /// <remarks>
        /// 新規登録に必要な処理を行う
        /// </remarks>
        /// <param name="inputEntryValues">新規登録用入力情報</param>
        /// <returns>DB登録する値を返却する</returns>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel inputEntryValues);
    }
}