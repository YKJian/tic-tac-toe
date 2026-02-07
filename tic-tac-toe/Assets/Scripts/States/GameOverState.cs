using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class GameOverState : StateBase
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private RawImage m_winner;
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
            m_retry.onClick.AddListener(OnClicked);
        }

        public override void Exit()
        {
            m_gameOverPanel.SetActive(false);
            m_retry.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
