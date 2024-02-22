namespace GeographieQuizAPI.Models
{
    public class Frage
    {
        public int FrageID { get; set; }
        public string FrageInhalt { get; set; }
        public List<Antwort> Antworten { get; set; }
        public List<FrageKategorieZuordnung> FrageKategorien { get; set; }
    }
}
