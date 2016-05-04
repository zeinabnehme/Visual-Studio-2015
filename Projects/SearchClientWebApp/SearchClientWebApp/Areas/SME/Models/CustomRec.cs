using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Areas.SME.Models
{
    public class CustomRec
    {

       
        public int Account_id { get; set; }
        public int CollOrLegal { get; set; }
        public int Type { get; set; }
        public System.DateTime DateOfTransfer { get; set; }
        public decimal amount { get; set; }
        public int TypeFollowup { get; set; }
        public virtual account account { get; set; }
        public virtual rec_lookupvalue rec_lookupvalue { get; set; }
        public virtual rec_lookupvalue rec_lookupvalue1 { get; set; }
        public virtual rec_lookupvalue rec_lookupvalue2 { get; set; }
        public customCustomer detail { get { return GetCust(Account_id); } }
        public decimal totalpaid { get { return GetTotalPaid(Account_id); } }

       public decimal Due { get { return GetDue(amount,totalpaid); } }

        public customCustomer GetCust(int acc)
    {
        customCustomer detail = new customCustomer();

        using (mifosEntitiesConnection db = new mifosEntitiesConnection())
        {
            int? cus = db.accounts.Where(p => p.ACCOUNT_ID == acc).Select(p => p.CUSTOMER_ID).FirstOrDefault(); ;
            string dis = db.customers.Where(p => p.CUSTOMER_ID == cus).Select(p => p.DISPLAY_NAME).FirstOrDefault();
            detail.customerID = cus;
            detail.displayName = dis;
        }

        return detail;
    }


        public Decimal GetTotalPaid(int accountid)
        {
            //    List<account> AAccounts = new List<account>();

            using (mifosEntitiesConnection db = new mifosEntitiesConnection())
            {

                var totalPaid = Convert.ToDecimal(db.rec_payment.Where(p => p.AccountID == accountid).Select(p => p.PaymentAmount).DefaultIfEmpty(0).Sum());

                return totalPaid;

            }
        }

   

    public Decimal GetDue(decimal amount, decimal Paid)
    {
        //    List<account> AAccounts = new List<account>();



        var x = amount - Paid;

            return x;

        
    }
 }


public class customCustomer
        {
        public int? customerID;
        public string displayName;

            }


}
