using EmployeeManagement.ViewModel;
using System;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 入力値の判定を行う
    /// </summary>
    /// <remarks>
    /// 入力値の判定を行う
    /// </remarks>
    public class ValueJudge
    {
        /// <summary>
        /// 入力値の判定を行う
        /// </summary>
        /// <remarks>
        /// 入力値の判定を行う
        /// </remarks>

        public SCRN0002ViewModel Judge(SCRN0002ViewModel sCRN0002ViewModel)
        {
            if (sCRN0002ViewModel.EmployeeID == string.Empty){
                ErrorMessageModel errorMessageModel = new ErrorMessageModel();

                // 受け渡しはよそでHelperとか
                errorMessageModel.DisplayForMessage = ErrorMessages.Message1;

            }
                return null;




           
                
            
        }


    }


}