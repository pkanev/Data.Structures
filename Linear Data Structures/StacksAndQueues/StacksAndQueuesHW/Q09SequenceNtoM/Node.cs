namespace Q09SequenceNtoM
{
    public class Node
    {
        public int Number { get; set; }
        public Node PrevNode { get; set; }

        public Node(int num, Node prevNode = null)
        {
            this.Number = num;
            this.PrevNode = prevNode;
        }
    }
}