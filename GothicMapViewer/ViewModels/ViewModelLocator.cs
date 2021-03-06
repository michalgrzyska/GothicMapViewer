﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GothicMapViewer.Interfaces;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map;

namespace GothicMapViewer.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ITranslationService, TranslationService>();

            SimpleIoc.Default.Register<IMapRepository, MapRepository>();
            SimpleIoc.Default.Register<IMainRepository, MainRepository>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MapViewModel>();
        }

        public MapViewModel MapViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MapViewModel>();
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}
