using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyCore.Models
{
    public abstract class BaseEntity: IEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } // true ise nesne silinfi olarak işratlenmiştir.
        public List<IDomainEvent> DomainEvents { get; set; } = new List<IDomainEvent>();

        public void AddEvent(IDomainEvent @event)
        {
            DomainEvents.Add(@event);
        }
    }
}
