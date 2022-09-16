namespace ChessMaze
{
    public interface IGame
    {
        void Move(int nextRow, int nextCol);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Start();
        void Load();
        void SelectMove();
        void SetMove();
        Cell GetPlayerCell();
        Cell GetFinalCell();
    }
}
