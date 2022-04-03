using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_File : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание поста с прикрепленным файлом в новостях", homePage => NewPostWithAttachedFile(homePage)));
            return caseCollection;
        }
        //Начать создавать новый пост
        //Открыть форму прикрепления файла
        //Прикрепить файл
        //Отправить
        //Проверить, появился ли пост с файлом в ленте
        void NewPostWithAttachedFile(PortalHomePage homePage)
        {
            string FileName = "AddFileTest";
            new NewsPage()
                .AddPost()
                .OpenAttachForm()
                .AttachFile(FileName)
                .Send()            
                .IsFilePublished(FileName)
            ;
        }
    }
}
