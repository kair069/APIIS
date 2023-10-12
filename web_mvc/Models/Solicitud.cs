using System.ComponentModel.DataAnnotations;
namespace web_mvc.Models
{
    public class Solicitud
    {
        [Display(Name = "nsolicitud")] public int nsolicitud { get; set; }
        [Display(Name = "fsolicitud")] public DateTime fsolicitud { get; set; }
        [Display(Name = "idact")] public int idact { get; set; }
        [Display(Name = "dni")] public string dni { get; set; }
        [Display(Name = "nombre")] public string nombre { get; set; }
        [Display(Name = "email")] public string email { get; set; }
        [Display(Name = "desact")] public string desact { get; set; }


    }
}
