using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Framework.Core.Enum
{
    public enum PaymentTypesEnum
    {
        [Display(Name = "پرداخت از طریق کارت به کارت")]
        BankTransfer = 1,

        [Display(Name = "پرداخت با کارت بانکی")]
        CreditCard
    }
}
