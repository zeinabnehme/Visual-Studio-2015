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
        public payment pay { get; set; }
        //public int State { get; set; }

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
   }

    public class customCustomer
        {
        public int? customerID;
        public string displayName;

            }


}