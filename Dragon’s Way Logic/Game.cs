using System.Security.AccessControl;

namespace Dragon_s_Way_Logic
{
    public class Game    
    {
 
        private char[,] _dragonsGame;

        public Game(int n, String route)
        {
            N = n;
            Route = route;
            _dragonsGame = new char[N, N * 2];
            SolutionGame();
        }

 
        public int N { get; }

        public String Route { get; }
        public bool Win;
        public override string ToString()
        {
            var output = string.Empty;
            output += ' ';
            for (int i = 0; i < N * 2; i++)
            {
                if (i > 9)
                {                    
                    output += i - 10;
                }
                else output += i;
            }
            output += "\n";
            for (int i = 0; i < N; i++)
            {
                output += i;
                for (int j = 0; j < N * 2; j++)                {
                   
                    output += $"{_dragonsGame[i, j]}";
                }
                output += "\n";
               
            }
            return output;
        }
        private void SolutionGame()
        {
            FillBorders();
            DragonsWay();
            
        }

        private void DragonsWay()
        {
            int row = 1;
            int column = 0;
            do
            {
                int i = 0;
                for (; i < Route.Length; i++)
                {
                    if (!(column < N * 2))
                    {
                        if (row == N -2)
                        {
                            Win = true;
                            return;
                        }
                        else
                        {
                            Win = false;
                            return;
                        } 
                    }
                    else
                    {
                        if (Route[i] == '→' && column < N * 2)
                        {
                            _dragonsGame[row, column] = '→';
                            column++;
                        }
                        if (Route[i] == '↓')
                        {
                            _dragonsGame[row, column] = '↓';
                            row++;
                        }
                    }


                }
            } while (column < N * 2);
            if (Win == false)
            {

            }
            Win = false;

        }

        private void FillBorders()
        {
            for (int i = 0; i < N * 2 - 1; i++)
            {
                _dragonsGame[0, i] = '▀';
            }
            _dragonsGame[0, N * 2-1] = '█';
            for (int i = 0; i < N * 2 - 1; i++)
            {
                _dragonsGame[1, i] = ' ';
            }

            _dragonsGame[1, N * 2 - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                _dragonsGame[i, 0] = '█';
                for (int j = 1; j < N * 2 - 1; j++)
                {
                    _dragonsGame[i, j] = ' ';
                }
                _dragonsGame[i, N * 2 - 1] = '█';
            }
            _dragonsGame[N - 2, 0] = '█';
            for (int i = 1; i < N * 2; i++)
            {
                _dragonsGame[N - 2, i] = ' ';
            }
            _dragonsGame[N - 1, 0] = '█';
            for (int i = 1; i < N * 2 - 1; i++)
            {
                _dragonsGame[N - 1, i] = '▄';
            }
            _dragonsGame[N - 1, N * 2 - 1] = '█';
        }
    }
    
}