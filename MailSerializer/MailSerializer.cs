using MimeKit;

namespace Dewrox.MailSerializer
{
    public class MailSerializer
    {
        public MailSerializer()
        {
            
        }
        
        public byte[] Serialize(System.Net.Mail.MailMessage message)
        {
            MimeMessage msg = (MimeMessage)message;
            using MemoryStream ms = new();
            msg.WriteTo(ms);
            return ms.ToArray();
        }
        
        public byte[] Serialize(MimeMessage message)
        {
            using MemoryStream ms = new();
            message.WriteTo(ms);
            return ms.ToArray();
        }
        
        public MimeMessage Deserialize(byte[] msg)
        {
            using MemoryStream ms = new(msg);
            return MimeMessage.Load(ms);
        }
    }
}