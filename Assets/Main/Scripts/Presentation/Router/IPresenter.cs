using UnityEngine;

namespace Roguelike.Presentation.Routing
{
    public interface IPresenter
    {
        void StartRoute(GameObject obj);
        void OnDestroyRoute();
    }
}