using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class GameplayState: StateBase
    {
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameObject m_gameplayPanel;
        [SerializeField] private Image[] m_playerImages;
        [SerializeField] private Button[] m_buttons;

        private GameStateMachine m_gameStateMachine;
        private Color m_transparentColor = Color.clear;
        private Color m_opaqueColor = Color.black;
        private int[] m_occupiedCells; // 1 or 2
        private int m_currentPlayer = 0;
        private int m_minWinStep = 5;
        private int m_maxStep = 9;
        private int m_step = 0;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameplayPanel.SetActive(false);
            m_gameStateMachine = gameStateMachine;

            m_occupiedCells = new int[m_buttons.Length];
        }

        public override void Enter()
        {
            m_step = 0; 
            m_levelController.isDraw = false;

            m_gameplayPanel.SetActive(true);
            m_playerImages[m_currentPlayer].enabled = true;

            for (int i = 0; i < m_buttons.Length; i++)
            {
                m_occupiedCells[i] = 0;
                int index = i;
                m_buttons[i].onClick.AddListener(() => OnClicked(m_buttons[index], index));

                SetButton(m_buttons[i], m_transparentColor, true);
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

        private void OnClicked(Button button, int index)
        {
            m_step++;
            m_occupiedCells[index] = m_currentPlayer + 1;

            if (m_step == m_maxStep && !m_levelController.CheckWin(m_occupiedCells))
            {
                m_levelController.isDraw = true;
                OnFinished();
            }
            else if (m_step >= m_minWinStep && m_levelController.CheckWin(m_occupiedCells))
            {
                m_levelController.winner = m_playerImages[m_currentPlayer];
                OnFinished();
            }

            SetButton(button, m_opaqueColor, false);
            ChangeCurrentPlayer();
        }

        private void SetButton(Button button, Color color, bool needReset)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = color;

            if (needReset)
            {
                buttonImage.sprite = null;
                button.interactable = true;
            }
            else
            {
                buttonImage.sprite = m_playerImages[m_currentPlayer].sprite;
                button.interactable = false;
            }
        }

        private void ChangeCurrentPlayer()
        {
            m_playerImages[m_currentPlayer].enabled = false;

            m_currentPlayer = m_currentPlayer == 0 ? 1 : 0;

            m_playerImages[m_currentPlayer].enabled = true;
        }
    }
}