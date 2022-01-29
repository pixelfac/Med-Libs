namespace Models
{
    public class Word
    {
        public double confidence { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string text { get; set; }
    }
}