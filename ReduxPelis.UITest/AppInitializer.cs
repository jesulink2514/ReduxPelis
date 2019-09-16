using System;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace ReduxPelis.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            const string apkPath = "D:/Projects/ReduxPelis/com.companyname.reduxpelis.apk";
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .ApkFile(apkPath)
                    .EnableLocalScreenshots()
                    .StartApp(AppDataMode.Clear);
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}