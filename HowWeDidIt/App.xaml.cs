using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HowWeDidIt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IKitchenService, KitchenService>();

            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
        
    }
}
