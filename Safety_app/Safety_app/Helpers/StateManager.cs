using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Safety_app.Helpers
{
    public static class StateManager
    {

        
    
          
      
        public static void StoreProperties<T>(String key,object obj)
        {
            key = key.ToUpper();
            if (Application.Current.Properties.Where(p => p.Key == key.ToUpper()).Any())
            {
                Application.Current.Properties.Remove(key);
            }
            Application.Current.Properties[key] = obj;
        }

        public static T GetProperties<T>(String key)
        {
            key = key.ToUpper();
         var  Property= Application.Current.Properties.Where(p => p.Key == key.ToUpper()).FirstOrDefault ();
            if (Property.Value != null)
            {
                return (T)Property.Value;
            }
            else
            {
                return (T)new object();
            }
        }
    }
}
