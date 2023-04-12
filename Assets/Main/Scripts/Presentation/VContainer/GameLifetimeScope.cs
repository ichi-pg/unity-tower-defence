using UnityEngine;
using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Infrastructure.Repository;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.Routing;

namespace Roguelike.Presentation.Injection
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISaveDataRepository, SaveDataRepository>(Lifetime.Scoped);
            builder.Register<IMasterDataRepository, MasterDataRepository>(Lifetime.Scoped);

            builder.Register<DungeonUseCase>(Lifetime.Scoped);
            builder.Register<BattleUseCase>(Lifetime.Scoped);

            builder.Register<TitlePresenter>(Lifetime.Scoped);
            builder.Register<DungeonPresenter>(Lifetime.Scoped);
            builder.Register<BattlePresenter>(Lifetime.Scoped);

            builder.Register<Router>(Lifetime.Scoped);

            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Scoped);
        }
    }
}