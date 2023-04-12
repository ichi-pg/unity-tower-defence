using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Roguelike.Presentation.Routing
{
    public class Route
    {
        public IPresenter Presenter;
        public AsyncOperationHandle<GameObject> Handle;
        public GameObject GameObject;
    }
}