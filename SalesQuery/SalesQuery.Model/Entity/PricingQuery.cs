using SalesQuery.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Model.Entity
{
    public class PricingQuery: IEntityBase
    {
        public Guid Id { get; set; }

        //reference to the User
        [ForeignKey("Users")]
        public Guid? UserId { get; set; }
        public virtual User Users { get; set; }

        //reference to the Product
        [ForeignKey("Products")]
        public Guid? ProductId { get; set; }
        public virtual Product Products { get; set; }

        ///-------Additional Infomartion -------------//

        public DateTime EnquiryDate { get; set; }
        public DateTime? RespondedDate { get; set; }

        public bool IsReplied { get; set; }
    }
}
