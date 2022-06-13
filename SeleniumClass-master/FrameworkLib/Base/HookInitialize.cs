using FrameworkLib.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static FrameworkLib.Base.Browsers;

namespace FrameworkLib
{
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize(): base(BrowserType.Chrome)
        {
            InitizalizeSettings();
        }

    }
}
