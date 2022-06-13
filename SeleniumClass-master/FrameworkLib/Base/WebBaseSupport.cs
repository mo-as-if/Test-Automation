using FrameworkLib.Base;

namespace FrameworkLib
{
    public abstract class WebBaseSupport : BasePage
    {
        private (object Driver, WebBaseSupport) ActiveDriver;

        public WebBaseSupport()
        {
            ActiveDriver = (DriverContext.Driver, this);
        }
    }
}