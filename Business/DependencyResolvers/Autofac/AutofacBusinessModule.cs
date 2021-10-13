using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Jwt.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Managers
            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();

            builder.RegisterType<RestourantManager>().As<IRestourantService>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //Data Access Layers
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<EfFoodDal>().As<IFoodDal>().SingleInstance();

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCartDal>().As<ICartDal>().SingleInstance();

            builder.RegisterType<EfRestourantDal>().As<IRestourantDal>().SingleInstance();

            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<EfFoodImageDal>().As<IFoodImageDal>().SingleInstance(); 
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
