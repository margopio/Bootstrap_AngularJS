using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfterWorkTambayan.Web.Utilities
{
    public class Currencies
    {
        public static readonly IDictionary<string, string> StateDictionary = new Dictionary<string, string> {            
            {"Australian Dollar", "AUD"},            
            {"British Pound", "GBP"},
            {"Canadian Dollar", "CAD"},            
            {"Chinese Yuan", "CNY"},          
            {"Euro", "EUR"}, 
            {"Hong Kong Dollar", "HKD"}, 
            {"Japanese Yen", "JPY"}, 
            {"Philippine Peso", "PHP"},            
            {"Singapore Dollar", "SGD"}, 
            {"South Korean Won", "KRW"}, 
            {"Swiss Franc", "CHF"}, 
            {"US Dollar", "USD"}                      
        };

        public static SelectList StateSelectList
        {
            get { return new SelectList(StateDictionary, "Value", "Key"); }
        }
    }
}