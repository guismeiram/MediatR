using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        private DateTime? _createdAt;

        public DateTime? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value ?? DateTime.UtcNow;
        }

        public DateTime? UpdatedAt { get; set; }
    }
}
