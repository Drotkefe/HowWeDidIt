using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace HowWeDidIt.Infrastructure
{
    public class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
