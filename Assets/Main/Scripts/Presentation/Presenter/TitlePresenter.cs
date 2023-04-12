using UnityEngine;
using UniRx;
using VContainer;
using Roguelike.Presentation.Routing;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class TitlePresenter : IPresenter
    {
        [Inject]
        private Router _router;
        [Inject]
        private DungeonPresenter _dungeonPresenter;

        [Inject]
        public TitlePresenter()
        {
        }

        public void StartRoute(GameObject obj)
        {
            var view = obj.GetComponent<TitleView>();
            view.OnClickStartButton.Subscribe(async _ =>
            {
                await _router.Switch(_dungeonPresenter);
            }).AddTo(view);
        }

        public void OnDestroyRoute()
        {
        }
    }
}