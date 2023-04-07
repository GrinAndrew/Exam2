using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Model
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public Applications Application { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public string CommentText { get; set; }

        [NotMapped]
        public string UserName
        {
            get
            {
                return DBManager.GetUserByID(UserID).Name;
            }
        }
        [NotMapped]
        public string AppName
        {
            get
            {
                return DBManager.GetAppByID(ApplicationID).Name;
            }
        }
    }
}
