using System;

namespace Safety_app.Models
{
    public class Token
    {
        public int id;
        public string access_token;
        public string error_description;
        public DateTime expire_date;
        public Token()
        {

        }
    }
}
