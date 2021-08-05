using EmployeeManagement.Helper;
using NUnit.Framework;

namespace EmployeeManagementWebUITest.HelperTest
{
    /// <summary>
    /// EV0001Helperのテストクラス
    /// </summary>
    /// <remarks>
    /// IDの初期化と出力内容が正しいかテストを行う
    /// </remarks>
    [TestFixture]
    public class EV0001HelperTest
    {
        /// <summary>
        /// EV0001Helperのテストクラス
        /// </summary>
        /// <remarks>
        /// IDの初期化と出力内容が正しいかテストを行う
        /// </remarks>
        [Test]
        public void InitTest()
        {
            // テストクラス、メソッドの呼び出し
            EV0001Helper testTarget = new EV0001Helper();

            var actResult = testTarget.Init();
            
            // テストの実行
            Assert.AreEqual(string.Empty, actResult.EmployeeID);
            CollectionAssert.IsEmpty(actResult.ErrorMessageList);
        }
    }
}
