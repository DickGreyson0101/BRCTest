namespace SeleniumUITest.Pages
{
    public static class PageFactory
    {

        public static T CreatePage<T>() where T : new()
        {
            return new T();
        }
    }
}
