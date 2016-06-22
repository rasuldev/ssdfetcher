using System;
using System.Net.Mail;
using S22.Imap;

namespace SsdFetcher
{
    public class ParsingException: Exception
    {
        public string EmailTitle { get; set; }
        public DateTime? EmailDate { get; set; }
        public uint EmailUid { get; set; }        
        public MailMessage Email { get; set; }
        public string AttachmentName { get; set; }

        public ParsingException(string message, uint uid, MailMessage email, string attachmentName)
            :base(message)
        {
            EmailTitle = email.Subject;
            EmailDate = email.Date();
            EmailUid = uid;
            Email = email;
            AttachmentName = attachmentName;
        }
    }
}