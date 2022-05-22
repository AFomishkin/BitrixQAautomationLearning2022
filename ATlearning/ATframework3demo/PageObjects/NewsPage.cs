using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        internal NewsPostForm AddPost()
        {
            //Клик в Написать сообщение
            var btnPostCreate = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click();
            return new NewsPostForm();
        }
        internal bool IsFilePublished(string FileName)
        {
            //проверить, что был создан пост с прикрепленным файлом
            var NewPostFileArea = new atFrameWork2.SeleniumFramework.WebItem($"//span[@class='feed-com-file-name-wrap']//a[contains(@title,{FileName})]",
                "Имя прикрепленного файла в новом посте");
            if (!NewPostFileArea.WaitElementDisplayed())
                Log.Error("Пост с прикрепленным файлом отсутствует в ленте");
            return NewPostFileArea.AssertTextContains(FileName, default);
        }
    }
}
