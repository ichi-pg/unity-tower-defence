using UnityEngine;
using VContainer;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Routing;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class BattlePresenter : IPresenter
    {
        [Inject]
        private BattleUseCase _battleUseCase;

        [Inject]
        public BattlePresenter()
        {
        }

        public void StartRoute(GameObject obj)
        {
        }

        public void OnDestroyRoute()
        {
        }
    }
}