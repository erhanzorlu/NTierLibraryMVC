using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DataStatus Status { get; set; }

        public BaseEntity()
        {
            CreatedTime = DateTime.Now;
            Status = DataStatus.Insterted;
        }
    }
}
