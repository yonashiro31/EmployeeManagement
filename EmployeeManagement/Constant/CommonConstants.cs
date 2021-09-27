namespace EmployeeManagement.Constant
{
    /// <summary>
    /// 共通定数宣言クラス
    /// </summary>
    /// <remarks>定数の宣言を行う</remarks>
    public static class CommonConstants
    {
        /// <summary>更新ユーザーID</summary>
        /// <remarks>更新ユーザID</remarks>
        public const string MOD_USER_ID = "user1";
        /// <summary></summary>
        /// <remarks></remarks>
        public const string AFFILIATION_CHECK_VALUE = "00";
        /// <summary>桁数定数</summary>
        /// <remarks>氏名の最小許容桁数</remarks>
        public const int NAME_MIN_DIGITS = 1;
        /// <summary>桁数定数</summary>
        /// <remarks>氏名の最大許容桁数</remarks>
        public const int NAME_MAX_DIGITS = 32;
        /// <summary>桁数定数</summary>
        ///   /// <remarks>社員IDの最小許容桁数</remarks>
        public const int ID_MIN_DIGITS = 8;
        /// <summary>桁数定数</summary>  
        /// <remarks>社員IDの最大許容桁数</remarks>
        public const int ID_MAX_DIGITS = 8;
        /// <summary>桁数定数</summary>
        ///   /// <remarks>部署の最小許容桁数</remarks>
        public const int AF_MIN_DIGITS = 1;
        /// <summary>桁数定数</summary>  
        /// <remarks>部署の最大許容桁数</remarks>
        public const int AF_MAX_DIGITS = 6;
        /// <remarks>役職の最小許容桁数</remarks>
        public const int POSI_MIN_DIGITS = 1;
        /// <summary>桁数定数</summary>  
        /// <remarks>役職の最大許容桁数</remarks>
        public const int POSI_MAX_DIGITS = 4;
        /// <summary>桁数定数</summary>  
        /// <remarks>社員IDの最大許容桁数</remarks>
        public const int GENDER_MIN_DIGITS = 1;
        /// <summary>桁数定数</summary>
        /// <remarks>部署役職の最小許容桁数</remarks>
        public const int GENDER_MAX_DIGITS = 1;
        /// <summary>桁数定数</summary>  
        /// <summary>桁数定数</summary>
        /// <remarks>生年月日の最小許容桁数</remarks>
        public const int BIRTH_DAY_MIN_DIGITS = 10;
        /// <summary>桁数定数</summary>
        /// <remarks>生年月日の最大許容桁数</remarks>
        public const int BIRTH_DAY_MAX_DIGITS = 9;
        /// <summary>桁数定数</summary>
        /// <remarks>基本給料の最小許容桁数</remarks>
        public const int SALARY_MIN_DIGITS = 1;
        /// <summary>桁数定数</summary>
        /// <remarks>基本給料の最大許容桁数</remarks>
        public const int SALARY_MAX_DIGITS = 8;
        /// <summary>性別定数</summary>
        /// <remarks>性別の初期値（男）</remarks>
        public const int GENDER_MEN = 1;
    }
}
