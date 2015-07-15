namespace Q08DistanceInLabyrinth
{
    class Cell
    {
        public int RowCoord { get; set; }
        public int ColCoord { get; set; }
        public int Step { get; set; }
        public Cell(int rowCoord, int colCoord, int step = 0)
        {
            this.RowCoord = rowCoord;
            this.ColCoord = colCoord;
            this.Step = step;
        }
    }
}
