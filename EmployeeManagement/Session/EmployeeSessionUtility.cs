using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EmployeeManagementWebUI.Common.Session
{
    /// <summary>
    /// 社員管理用セッションUtility
    /// </summary>
    /// <remarks>
    /// 社員管理用セッションUtility
    /// </remarks>
    public static class EmployeeSessionUtility
    {
        /// <summary>
        /// 新規セッションオブジェクト生成
        /// </summary>
        /// <remarks>
        /// 新規セッションオブジェクト生成
        /// </remarks>
        /// <returns>新規セッションオブジェクト</returns>
        public static Session CreateNewSessionObj() => new Session();

        /// <summary>
        /// セッション書き込み処理
        /// </summary>
        /// <remarks>
        /// オブジェクトをセッションに書き込む処理
        /// </remarks>
        /// <typeparam name="T">TObject</typeparam>
        /// <param name="session">セッション</param>
        /// <param name="key">セッションキー</param>
        /// <param name="obj">セッション値</param>
        public static void SetSessionObject<T>(this ISession session, string key, T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            session.SetString(key, json);
        }

        /// <summary>
        /// セッション読み込み処理
        /// </summary>
        /// <remarks>
        /// セッションからキーに紐づく値を読み込む処理
        /// </remarks>
        /// <typeparam name="T">TObject</typeparam>
        /// <param name="session">セッション</param>
        /// <param name="key">セッションキー</param>
        /// <returns>取得したセッション値</returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return string.IsNullOrEmpty(json)
                ? default : JsonConvert.DeserializeObject<T>(json);
        }
    }
}
