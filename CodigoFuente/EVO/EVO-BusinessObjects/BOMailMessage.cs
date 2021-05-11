using System.Collections.Generic;

namespace EVO_BusinessObjects
{
   public class BOMailMessage
    {
        public string CorreoEnvia { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public List<string> CorreosDestinatarios { get; set; }
        public List<string> RutasArchivos { get; set; }        

    }
}
