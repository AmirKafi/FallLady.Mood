using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Framework.Core.Enum
{
    public enum PaymentStatesEnum
    {
        [Display(Name = "در انتظار پرداخت")]
        WaitingForPayment = 1,

        [Display(Name = "خطا در پرداخت")]
        PaymentFailed,

        [Display(Name = "پرداخت موفق")]
        PaymentSucceeded,

        [Display(Name = "لغو پرداخت")]
        PaymentCanceled,

        [Display(Name = "عدم تایید پرداخت")]
        PaymentnotConfirmed,

        [Display(Name = "در انتظار تایید پرداخت")]
        WaitingForConfirmation

    }
}
