using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class GameplayState: StateBase
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private GameObject m_gameplayPanel;
        [SerializeField] private RawImage[] m_currentPlayer;
        [SerializeField] private Button[] m_buttons;

        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameplayPanel.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_gameplayPanel.SetActive(true);

            foreach (var button in m_buttons)
            {
                button.onClick.AddListener(OnClicked);
            }

            m_playerController.enabled = true;
        }

        public override void Exit()
        {
            m_gameplayPanel.SetActive(false);

            m_playerController.enabled = false;
        }

        private void OnFinished(int score)
        {
            m_gameStateMachine.Enter<GameOverState>();
        }

        private void OnClicked()
        {
            
        }
    }
}