using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Models
{
    public class CustomerDetail
    {

        public class SummaryModel
        {
            [DisplayName("CustomerId")]
            public int CUSTOMER_ID { get; set; }
            [DisplayName("GLobal Account Num")]

            public string OldMIS { get; set; }

            public string GLOBAL_CUST_NUM { get; set; }
            [DisplayName("Name")]

            public string DISPLAY_NAME { get; set; }

            public String MotherName { get { return GetMotherName(CUSTOMER_ID); } }
            //[DisplayName("Address")]
            //public string DISPLAY_ADDRESS { get; set; }
            [DisplayName("GovId")]
            public string GOVERNMENT_ID { get; set; }
            public string Address { get; set; }
            //public virtual ICollection<customer_address_detail> customer_address_detail { get; set; }
            public customer_address_detail customerDetail { get { return GetAddressDetail(CUSTOMER_ID); }}
            public string DISCRIMINATOR { get; set; }

            public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }

          

            public virtual IList<account> accounts
            {
                get { return Getaccount(CUSTOMER_ID); }


            }

            public virtual IList<account> ClosedAccounts
            {
                get { return GetClosedaccount(CUSTOMER_ID); }


            }

            public virtual personnel personnel { get; set; }
            public virtual customer_detail customer_detail { get; set; }
            public virtual office office { get; set; }
            public virtual customer_state customer_state { get; set; }

            public List<account> Getaccount(int Cust)
            {
                List<account> AAccounts = new List<account>();

                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    //AAccounts = db.customers.Find(Cust).accounts.Where(p => p.ACCOUNT_STATE_ID == 5 || p.ACCOUNT_STATE_ID == 9).ToList();
                    AAccounts = db.accounts.Include(l => l.account_state.lookup_value).Include(l=> l.personnel).Include(l=>l.office).Where(p => p.CUSTOMER_ID == Cust && (p.ACCOUNT_STATE_ID == 5 || p.ACCOUNT_STATE_ID == 9)).ToList();
                }

                return AAccounts;
            }


            public List<account> GetClosedaccount(int Cust)
            {
                List<account> CAccounts = new List<account>();

                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    //CAccounts = db.customers.Find(Cust).accounts.Where(p =>  p.ACCOUNT_STATE_ID == 6 || p.ACCOUNT_STATE_ID == 7 ).ToList();
                    CAccounts = db.accounts.Include(l => l.account_state.lookup_value).Include(l => l.personnel).Include(l => l.office).Where(p => p.CUSTOMER_ID == Cust && (p.ACCOUNT_STATE_ID == 6 || p.ACCOUNT_STATE_ID == 7)).ToList();

                }

                return CAccounts;
            }

            public String GetMotherName(int Cust)
            {
                //    List<account> AAccounts = new List<account>();
                String motherName;
                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    motherName = db.customer_address_detail.Find(Cust).LINE_3;

                }

                return motherName;
            }

            public customer_address_detail GetAddressDetail(int Cust)
            {
                    //List<account> AAccounts = new List<account>();
                customer_address_detail CustomerDetail;
                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    CustomerDetail = db.customer_address_detail.Find(Cust);

                }

                return CustomerDetail;
            }

        }
    }
}