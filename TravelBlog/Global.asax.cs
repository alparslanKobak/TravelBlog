using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TravelBlog.Entity;
using TravelBlog.Entity.Abstract;
using TravelBlog.Entity.Concrete;
using TravelBlog.Entity.DbSeeder;

namespace TravelBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register your DbContext.
            builder.RegisterType<DataContext>().AsSelf().InstancePerRequest();

            // Register your services and repositories with appropriate interfaces.
            builder.RegisterType<RegionCrud>().As<IRegionCrud>().InstancePerRequest();
            builder.RegisterType<BlogPostCrud>().As<IBlogPostCrud>().InstancePerRequest();
            builder.RegisterType<AppUserCrud>().As<IAppUserCrud>().InstancePerRequest();
            builder.RegisterType<CityCrud>().As<ICityCrud>().InstancePerRequest();
            builder.RegisterType<CommentCrud>().As<ICommentCrud>().InstancePerRequest();
            builder.RegisterType<LikeCrud>().As<ILikeCrud>().InstancePerRequest();

            // Register any other dependencies...

            // Build the container.
            var container = builder.Build();

            // Set the dependency resolver for MVC to use Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Other MVC application setup...

           DbSeeder.DbSeed();

        }
    }
}
