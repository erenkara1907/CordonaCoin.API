using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<DashboardManager>().As<IDashboardService>();
            builder.RegisterType<EfDashboardDal>().As<IDashboardDal>();

            builder.RegisterType<DepositManager>().As<IDepositService>();
            builder.RegisterType<EfDepositDal>().As<IDepositDal>();

            builder.RegisterType<ProfileManager>().As<IProfileService>();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>();

            builder.RegisterType<ReferenceManager>().As<IReferenceService>();
            builder.RegisterType<EfReferenceDal>().As<IReferenceDal>();

            builder.RegisterType<TransactionManager>().As<ITransactionService>();
            builder.RegisterType<EfTransactionDal>().As<ITransactionDal>();

            builder.RegisterType<WalletManager>().As<IWalletService>();
            builder.RegisterType<EfWalletDal>().As<IWalletDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
