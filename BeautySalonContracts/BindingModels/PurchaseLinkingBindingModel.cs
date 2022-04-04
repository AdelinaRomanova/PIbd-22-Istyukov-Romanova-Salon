using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonContracts.BindingModels
{
    public class PurchaseLinkingBindingModel
    {
        public int PurchaseId { get; set; }

        public int ReceiptId { get; set; }
    }
}
