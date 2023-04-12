using VContainer;
using Roguelike.Domain.Data;
using Roguelike.Domain.Model;

namespace Roguelike.Application.UseCase
{
    public class BattleUseCase
    {
        private Battle _battle;
        public Battle Battle => _battle;

        [Inject]
        public BattleUseCase()
        {
        }

        public void Start()
        {
            _battle = new Battle();
            //TODO ステージと手持ちに合わせて構築
        }

        public void Update()
        {
            BattleModel.Update(_battle);
        }

        public void Finish()
        {
            _battle = null;
        }
    }
}