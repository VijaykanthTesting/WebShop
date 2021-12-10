using Microsoft.VisualStudio.TestTools.UnitTesting;
using Base;

namespace WebShop
{
    [TestClass]
    class AssemblyStartUp
    {

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            AssemblyHelper.WrapExtendReports(context);
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            AssemblyHelper.ClearExtendReport();
        }


    }
}
