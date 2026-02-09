using System;
using UnityEngine;
using UnityEngine.UI;

namespace tictactoe
{
    public class LevelController : MonoBehaviour
    {
        private int[][] m_solutions;
        private Image m_winner;
        private bool m_isDraw;

        public Image winner { get { return m_winner; } set { m_winner = value; } }
        public bool isDraw { get { return m_isDraw; } set { m_isDraw = value; } }

        private void Awake()
        {
            m_solutions = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 }, 
                new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, 
                new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }
            };
        }

        public bool CheckWin(int[] cells)
        {
            int firstCell = 0; 
            bool win = true;

            foreach (int[] solution in m_solutions)
            {
                firstCell = cells[solution[0]]; 
                if (firstCell == 0)
                {
                    continue;
                }

                foreach (int index in solution)
                {
                    win = firstCell == cells[index] ? true : false; 
                    if (!win)
                    {
                        break;
                    }
                }
                if (win)
                {
                    return win;
                }
            }

            return false;
        }
    }
}
