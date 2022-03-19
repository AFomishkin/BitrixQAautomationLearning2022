using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class bitrix24_settings : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var CaseCollection = new List<TestCase>();
            CaseCollection.Add(new TestCase("Настройка адресации всем по умолчанию", homePage => SendToAllByDefault(homePage)));
                
                return CaseCollection;
        }
        void SendToAllByDefault(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            // перейти в настройки
            // снять галочку адресовать всем по умолчанию
            // сохранить настройки
            // пойти в ленту
            // начать создавать пост и проверить, что шильдик пропал
        }
    }
}
