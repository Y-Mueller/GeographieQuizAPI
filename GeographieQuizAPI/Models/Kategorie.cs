using System.ComponentModel.DataAnnotations;

namespace GeographieQuizAPI.Models
{
    public class Kategorie
    {
        public int KategorieID { get; set; }
        public string KategorieName { get; set; }
        public List<FrageKategorieZuordnung> FrageKategorieZuordnung { get; set; }
    }
}
