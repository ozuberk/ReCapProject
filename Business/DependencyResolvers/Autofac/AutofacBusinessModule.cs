﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EFBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EFColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EFRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EFCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EFRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
