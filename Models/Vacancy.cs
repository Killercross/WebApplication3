using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Vacancy
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Отдел")]
        public string staffing_item_parrent_full_ext_id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Должность")]
        public string staffing_item_full_ext_id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "ФИО владельца")]
        public string Fio_vlad { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Телефон владельца")]
        public string Telefon_vlad { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "ФИО рекрутера")]
        public string Fio_rec { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Телефон рекрутера")]
        public string Telefon_rec { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "E-mail рекрутера")]
        public string Email_rec { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int id_candidate { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя")]
        public string first_name { get; set; }

        [Display(Name = "Отчество")]
        public string middle_name { get; set; }

        [Display(Name = "Отчество отсутствует")]
        public bool no_middle_name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Date)]
        [Display(Name = "День рождения")]
        public DateTime dt_birthday { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Пол")]
        public bool gender { get; set; }

        public int Rec_Active { get; set; }
    }
}
