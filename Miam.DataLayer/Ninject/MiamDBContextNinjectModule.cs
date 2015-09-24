using Miam.DataLayer;
using Ninject.Modules;

public class MiamDBContextNinjectModule : NinjectModule
{
    public override void Load()
    {
        Bind<MiamDbContext>().ToSelf().InScope(x => x.Kernel);
    }
}