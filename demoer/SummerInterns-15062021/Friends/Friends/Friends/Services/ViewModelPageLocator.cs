using System;
using System.Collections.Generic;
using LightInject;
using Xamarin.Forms;

namespace Friends.Services
{
    public class ViewModelPageLocator
    {
        public ViewModelPageLocator(IServiceRegistry serviceRegistry)
        {
            m_serviceRegistry = serviceRegistry;
        }
        
        private readonly IDictionary<Type, Func<Page>> m_pageMap = new Dictionary<Type, Func<Page>>();
        private readonly IServiceRegistry m_serviceRegistry;

        public void Register<TViewModel, TPage>()
            where TViewModel : class where TPage : Page, new()
        {
            m_serviceRegistry.Register<TViewModel>();
            m_serviceRegistry.Register(fac => new TPage());
            m_pageMap.Add(typeof(TViewModel), () => App.Container.GetInstance<TPage>());
        }
        
        public Tuple<TViewModel,Page> Lookup<TViewModel>() where TViewModel : class
        {
            if (!m_pageMap.TryGetValue(typeof(TViewModel), out var factory))
            {
                return null;
            }

            var viewmodel = App.Container.GetInstance<TViewModel>();
            var page = factory();
            
            return new Tuple<TViewModel, Page>(viewmodel, page);
        }
    }
}