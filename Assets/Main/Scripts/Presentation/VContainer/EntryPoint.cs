using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.Routing;

namespace Roguelike.Presentation.Injection
{
    public class EntryPoint : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private TitlePresenter _titlePresenter;

        [Inject]
        public EntryPoint()
        {
        }

        public async void Start()
        {
            await _router.Switch(_titlePresenter);
        }
    }
}