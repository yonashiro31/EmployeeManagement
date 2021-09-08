
namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 未入力単項目チェック時に使用するリスト
    /// </summary>
    /// <remarks>
    /// 未入力単項目チェック時に使用するリスト
    /// </remarks>
    public class NullJudgeListModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>コンストラクタ</remarks>
        /// <param name="employeeDate">社員情報</param>
        public NullJudgeListModel(string employeeDate)
        {
            EmployeeDate = employeeDate;
        }
        public string EmployeeDate { get; set; }
    }
}




