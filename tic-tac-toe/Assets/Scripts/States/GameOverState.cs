using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class GameOverState : StateBase
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private Image m_winner;
        [SerializeField] private Button m_backToMenu;
        [SerializeField] private Button m_retry;

        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameOverPanel.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_gameOverPanel.SetActive(true);
            m_backToMenu.onClick.AddListener(OnBackToMenu);
            m_retry.onClick.AddListener(OnRetry);
        }

        public override void Exit()
        {
            m_gameOverPanel.SetActive(false);
            m_backToMenu.onClick.RemoveListener(OnBackToMenu);
            m_retry.onClick.RemoveListener(OnRetry);
        }

        private void OnBackToMenu()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }

        private void OnRetry()
        {
            m_gameStateMachine.Enter<GameplayState>();
        }
    }
}
