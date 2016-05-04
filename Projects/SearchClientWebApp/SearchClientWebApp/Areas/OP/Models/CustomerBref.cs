using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Models
{
    public class CustomerBref
    {

        public class GroupSummaryModel
        {
            [DisplayName("CustomerId")]
            public int CUSTOMER_ID { get; set; }
            [DisplayName("GLobal Account Num")]
            public string GLOBAL_CUST_NUM { get; set; }
           
            [DisplayName("FullName")]
            public string DISPLAY_NAME { get; set; }
            public string name { get; set; }
            public string last { get; set; }

            public String MotherName { get { return GetMotherName(CUSTOMER_ID); } }
            //[DisplayName("Address")]
            //public string DISPLAY_ADDRESS { get; set; }
            [DisplayName("GovId")]
            public string GOVERNMENT_ID { get; set; }




            //public virtual ICollection<customer_address_detail> customer_address_detail { get; set; }

            public virtual office office { get; set; }
            public virtual IList<account> accounts
            {
                get { return Getaccount(CUSTOMER_ID); }

            }


            public virtual IList<account> ClosedAccounts
            {
                get { return GetClosedaccount(CUSTOMER_ID); }

            }



            public List<account> Getaccount(int Cust)
            {
                List<account> AAccounts = new List<account>();

                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    AAccounts = db.customers.Find(Cust).accounts.Where(p => p.ACCOUNT_STATE_ID == 5 || p.ACCOUNT_STATE_ID == 6 || p.ACCOUNT_STATE_ID == 7 || p.ACCOUNT_STATE_ID == 9).ToList();

                }

                return AAccounts;
            }


            public List<account> GetClosedaccount(int Cust)
            {
                List<account> CAccounts = new List<account>();

                using (mifosEntitiesConnection db = new mifosEntitiesConnection())
                {
                    customer c = new customer();
                    CAccounts = db.customers.Find(Cust).accounts.Where(p => p.ACCOUNT_STATE_ID != 5 || p.ACCOUNT_STATE_ID != 9).ToList();

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
              motherName      = db.customer_address_detail.Find(Cust).LINE_3;

              }

                return motherName;
            }

            
   

        }


       
    }
}