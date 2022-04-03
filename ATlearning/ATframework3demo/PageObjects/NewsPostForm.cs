using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
        internal bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            return recipientsArea.AssertTextContains(recipientName, default);
        }
        internal NewsPostForm OpenAttachForm()
        {
            //Клик в Прикрепить файл
            var btnOpenAttachForm = new atFrameWork2.SeleniumFramework.WebItem("//i[@id='bx-b-uploadfile-blogPostForm']", "Кнопка открытия формы прикрепления файла'");
            btnOpenAttachForm.WaitElementDisplayed();
            btnOpenAttachForm.Click();
            return new NewsPostForm();
        }
        
        internal NewsPostForm AttachFile(string FileName)
        {
            //Прикрепление файла со своего ПК
            var btnAttachFile = new atFrameWork2.SeleniumFramework.WebItem("//div[@class='disk-file-control'][not(contains(@style,'display: none'))]//input[(contains(@id,'diskuf-input'))]", "Кнопка прикрепления файла'");
            btnAttachFile.SendKeys($"E:/Work/Github_Repo/ATlearning/ATframework3demo/TestFiles/{FileName}.txt");
            if (!IsFileAttached(FileName))
                Log.Error("Файл не прикрепился");            
            return new NewsPostForm();
        }
        internal NewsPage Send()
        {
            //Клик в Отправить
            var btnSend = new atFrameWork2.SeleniumFramework.WebItem("//button[@id='blog-submit-button-save']", "Кнопка отправки поста");
            btnSend.Click();         
            return new NewsPage();
        }
        internal bool IsFileAttached(string FileName)
        {
            //проверить наличие файла
            var FileArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@class='disk-file-thumb-text']",
                "Имя прикрепленного файла");
            var Counter = new atFrameWork2.SeleniumFramework.WebItem("//span[@class='main-post-form-toolbar-button-file']//div[@class='ui-counter-inner' and text()='1']",
               "Проверка статуса загрузки файла");
            Counter.WaitElementDisplayed();//ожидание загрузки файла
            return FileArea.AssertTextContains(FileName, default);
        }        
    }
}
