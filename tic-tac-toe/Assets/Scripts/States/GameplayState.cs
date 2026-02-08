using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class GameplayState: StateBase
    {
        [SerializeField] private GameObject m_gameplayPanel;
        [SerializeField] private Image[] m_playerImages;
        [SerializeField] private Button[] m_buttons;

        private GameStateMachine m_gameStateMachine;
        private Color m_transparentColor = Color.clear;
        private Color m_opaqueColor = Color.black;
        private int m_currentPlayer = 0;
        private int m_maxStep = 9;
        private int m_step = 0;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameplayPanel.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_step = 0;
            m_gameplayPanel.SetActive(true);
            m_playerImages[m_currentPlayer].enabled = true;

            foreach (var button in m_buttons)
            {
                button.onClick.AddListener(() => OnClicked(button));

                SetButton(button, m_transparentColor, true);
            }
        }

        public override void Exit()
        {
            m_gameplayPanel.SetActive(false);
            m_playerImages[m_currentPlayer].enabled = false;

            foreach (var button in m_buttons)
            {
                button.onClick.RemoveAllListeners();
            }
        }

        private void OnFinished()
        {
            m_gameStateMachine.Enter<GameOverState>();
        }

        private void OnClicked(Button button)
        {
            m_step++;

            SetButton(button, m_opaqueColor, false);
            ChangeCurrentPlayer();

            if (m_step == m_maxStep)
            {
                OnFinished();
            }
        }

        private void SetButton(Button button, Color color, bool needReset)
        {
            button.interactable = !button.interactable;

            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = color;

            if (needReset)
            {
                buttonImage.sprite = null;
            }
            else
            {
                buttonImage.sprite = m_playerImages[m_currentPlayer].sprite;
            }
        }

        private void ChangeCurrentPlayer()
        {
            m_playerImages[m_currentPlayer].enabled = false;

            if (m_currentPlayer == 0)
            {
                m_currentPlayer = 1;
            }
            else
            {
                m_currentPlayer = 0;
            }

            m_playerImages[m_currentPlayer].enabled = true;
        }
    }
}