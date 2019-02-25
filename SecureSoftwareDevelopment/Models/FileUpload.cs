using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureSoftwareDevelopment.Models
{
    public class FileUpload
    {
        [ScaffoldColumn(false)]
        [Key]
        public int fileID { get; set; }

        [DisplayName("Set the file name")]
        [Required(ErrorMessage = "A file name is required")]
        [StringLength(15)]
        public string SetFileName { get; set; }

        [DisplayName("Set the file expected size in MB")]
        [Required(ErrorMessage = "Please ensure numbers only are used")]
        [Range(0.01, 600.00, ErrorMessage = "Price must be between 0.01 and 600.00")]
        public int expectedSizeofFile { get; set; }

        [DisplayName("Set the file type, e.g. Doc, Exl")]
        [Required(ErrorMessage = "A file type is required")]
        [StringLength(10)]
        public string documentType { get; set; }

        [DisplayName("Set location")]
        [Required(ErrorMessage = "A location is required")]
        [StringLength(15)]
        public string docLocation { get; set; }

    }
}