using System;
using System.Collections.Generic;
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

        #region === DBの開閉とリソースの開放 ===

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

        #endregion

        #region === DB実行(取得結果返却あり) ===

        /// <summary>
        /// SQL実行
        /// </summary>
        /// <remarks>
        /// SQL実行後に実行結果を返却あり
        /// </remarks>
        /// <param name="selectQuery">SelectQuery</param>
        /// <param name="parametarKeyAndValue">SQLのパラメータ名と値</param>
        /// <returns>実行結果</returns>
        public SqlDataReader ExcuteQuery(string selectQuery, Dictionary<string, object> parametarKeyAndValue = null)
        {
            SqlCommand selectCommand = new SqlCommand(selectQuery, _connection);
            if (parametarKeyAndValue != null)
            {
                foreach (var info in parametarKeyAndValue)
                {
                    selectCommand.Parameters.AddWithValue(info.Key, info.Value);
                }
            }

            return selectCommand.ExecuteReader();
        }

        #endregion

        #region === DB実行(取得結果返却なし) ===

        /// <summary>
        /// SQL実行
        /// </summary>
        /// <remarks>
        /// SQL実行後に実行結果を返却なし
        /// </remarks>
        /// <param name="query"></param>
        /// <param name="parametarKeyAndValue"></param>
        public void ExcuteNonQuery(string query, Dictionary<string, object> parametarKeyAndValue = null)
        {
            SqlCommand selectCommand = new SqlCommand(query, _connection);
            if (parametarKeyAndValue != null)
            {
                foreach (var info in parametarKeyAndValue)
                {
                    selectCommand.Parameters.AddWithValue(info.Key, info.Value);
                }
            }

            selectCommand.ExecuteNonQuery();
        }

        #endregion
    }
}
