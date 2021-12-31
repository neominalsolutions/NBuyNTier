using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyCore.Models
{
    public interface IEntity
    {
         List<IDomainEvent> DomainEvents { get; set; }

         void AddEvent(IDomainEvent @event);
    }
}
