using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchClientWebApp.Areas.OP.Models
{
    public class Suggname
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        public List<string> search(string name)
        {
            return db.customers.Where(p => p.DISPLAY_NAME.StartsWith(name)).Select(p => p.DISPLAY_NAME).Take(5).ToList();
        }

        public List<string> Search2(string name)
        {
            return db.customer_name_detail.Where(d => d.NAME_TYPE == 3 && d.DISPLAY_NAME == name || (d.FIRST_NAME + " " + d.LAST_NAME) == name).Select(p=>p.DISPLAY_NAME).ToList();
        }

    }
}