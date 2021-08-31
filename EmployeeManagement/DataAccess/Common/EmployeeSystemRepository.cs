using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementWebUI.DataAccess
{
    /// <summary>
    /// 社員管理システム用Repositoryクラス
    /// </summary>
    /// <remarks>
    /// 社員管理システム用Repositoryクラス
    /// </remarks>
    public class EmployeeSystemRepository : IDisposable
    {
        #region === フィールド ===

        /// <summary>SQLコネクションオブジェクト</summary>
        /// <remarks>SQLコネクションオブジェクト</remarks>
        private readonly SqlConnection _connection = null;

        #endregion

        #region === コンストラクタ ===

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// Repositoryに接続文字列の設定を行う。
        /// </remarks>
        public EmployeeSystemRepository()
        {
            var connectionStrings = "Persist Security Info=False;Trusted_Connection=True;Initial Catalog=EMP_MNG_SYS;Server=(local);";
            _connection = new SqlConnection(connectionStrings);
        }

        #endregion

        /// <summary>
        /// DBの接続を開く
        /// </summary>
        /// <remarks>
        /// DBの接続を開く
        /// </remarks>
        public void Open()
        {
            _connection.Open();
        }

        /// <summary>
        /// DBの接続を閉じる
        /// </summary>
        /// <remarks>
        /// DBの接続を閉じる
        /// </remarks>
        public void Clone()
        {
            _connection.Close();
        }

        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <remarks>
        /// リソースの解放
        /// </remarks>
        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }

            _connection.Dispose();
        }
    }
}
