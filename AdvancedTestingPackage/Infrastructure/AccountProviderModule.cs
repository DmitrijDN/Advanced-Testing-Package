
using AdvancedTestingPackage.Services;
using Ninject.Modules;

namespace AdvancedTestingPackage.Infrastructure
{
    public class AccountProviderModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountService>().To<AccountService>();
        }
    }
}