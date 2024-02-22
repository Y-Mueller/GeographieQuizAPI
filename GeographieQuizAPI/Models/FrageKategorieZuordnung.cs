namespace GeographieQuizAPI.Models
{
    public class FrageKategorieZuordnung
    {
        public int FrageID { get; set; }
        public Frage Frage { get; set; }
        public int KategorieID { get; set; }
        public Kategorie Kategorie { get; set; }
    }
}
