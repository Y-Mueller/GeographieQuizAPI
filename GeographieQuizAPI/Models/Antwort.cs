namespace GeographieQuizAPI.Models
{
    public class Antwort
    {
        public int AntwortID { get; set; }
        public string AntwortInhalt { get; set; }
        public bool IstRichtigeAntwort { get; set; }
        public int FrageID { get; set; }
        public Frage Frage { get; set; }
    }
}
