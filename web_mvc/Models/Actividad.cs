using System.ComponentModel.DataAnnotations;
namespace web_mvc.Models
{
    public class Actividad
    {

        [Display(Name = "idact")] public int idact { get; set; }
        [Display(Name = "fecha")] public DateTime fecha { get; set; }
        [Display(Name = "idcateg")] public int idcateg { get; set; }
        [Display(Name = "desact")] public string desact { get; set; }
        [Display(Name = "vacantes")] public int vacantes { get; set; }
        [Display(Name = "descateg")] public string descateg { get; set; }

    }
}
