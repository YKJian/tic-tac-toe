using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class MainMenuState : StateBase
    {
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_startButton;
        [SerializeField] private Button m_exitButton;

        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_mainMenuRoot.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_mainMenuRoot.SetActive(true);

            m_startButton.onClick.AddListener(OnStart);
            m_exitButton.onClick.AddListener(OnExit);
        }

        public override void Exit()
        {
            m_mainMenuRoot.SetActive(false);

            m_startButton.onClick.RemoveListener(OnStart);
            m_exitButton.onClick.RemoveListener(OnExit);
        }

        private void OnStart()
        {
            m_gameStateMachine.Enter<GameplayState>();
        }

        private void OnExit()
        {
            Application.Quit();
        }
    }
}
