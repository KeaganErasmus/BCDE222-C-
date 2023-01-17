namespace ChessMaze
{
    public interface IGame
    {
        int[,] Move(int nextRow, int nextCol);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Start();
        void Load();
        void SelectMove();
        void SetMove();
        int[,] GetPlayerCell();
        int[,] GetFinalCell();
        int[,] GetPrevCell();
    }
}
