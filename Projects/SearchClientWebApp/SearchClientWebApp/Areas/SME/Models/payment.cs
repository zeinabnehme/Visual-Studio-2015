using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Areas.SME.Models
{
    public class payment
    {
        public int PaymentID { get; set; }
        //[Remote("ValidateUserName", "Account", ErrorMessage = "Username is not available.")]
        public int AccountID { get; set; }



        public decimal amount  {  get { return  Amount2pay(AccountID); } }
       public decimal totalpaid { get { return GetTotalPaid(AccountID); } }

        public decimal PaymentAmount { get; set; }





        public Decimal GetTotalPaid(int accountid)
        {
            //    List<account> AAccounts = new List<account>();

            using (mifosEntitiesConnection db = new mifosEntitiesConnection())
            {

                var totalPaid = Convert.ToDecimal(db.rec_payment.Where(p => p.AccountID == accountid).Select(p => p.PaymentAmount).DefaultIfEmpty(0).Sum());
               
                    return totalPaid;
                  
            }
        }

        public Decimal Amount2pay(int accountid)
        {
            //    List<account> AAccounts = new List<account>();

            using (mifosEntitiesConnection db = new mifosEntitiesConnection())
            {
                var amountopay = db.rec_collection.Where(p => p.Account_id == accountid).Select(p => p.amount).Single();
                return amountopay;
            }
        }


        public rec_payment ConvertToUser(payment model)
        {
            rec_payment user = new rec_payment();
            user.PaymentID = model.PaymentID;
            user.AccountID = model.AccountID;
            user.PaymentAmount = model.PaymentAmount;
            
            return user;
        }

        public payment ConvertToUserModel(rec_payment item)
        {
            payment model = new payment();
            model.PaymentID = item.PaymentID;
            model.AccountID = item.AccountID;
            model.PaymentAmount = item.PaymentAmount;
            return model;
        }


    }
}

