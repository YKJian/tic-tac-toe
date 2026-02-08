using UnityEngine;

namespace tictactoe
{
    public class BootstrapState : StateBase
    {
        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }

        public override void Exit()
        {

        }
    }
}
