using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using VContainer;

namespace Roguelike.Presentation.Routing
{
    public class Router
    {
        private Stack<Route> _routes = new Stack<Route>();

        [Inject]
        public Router()
        {
        }

        public async UniTask Switch(IPresenter presenter)
        {
            var destroyRoutes = _routes.ToArray();

            _routes.Clear();
            await Push(presenter);

            foreach (var route in destroyRoutes)
            {
                Destroy(route);
            }
        }

        public async UniTask Push(IPresenter presenter)
        {
            var type = presenter.GetType();
            var address = type.Name.Replace("Presenter", "View");
            var handle = Addressables.LoadAssetAsync<GameObject>(address);

            await handle.Task;

            var obj = GameObject.Instantiate(handle.Result);

            _routes.Push(new Route()
            {
                Presenter = presenter,
                Handle = handle,
                GameObject = obj,
            });

            presenter.StartRoute(obj);
        }

        public void Pop()
        {
            Destroy(_routes.Pop());
        }

        private void Destroy(Route route)
        {
            route.Presenter.OnDestroyRoute();
            GameObject.Destroy(route.GameObject);
            Addressables.Release(route.Handle);
        }
    }
}