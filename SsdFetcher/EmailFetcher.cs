using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using S22.Imap;

namespace SsdFetcher
{
    public class EmailFetcher
    {
        public static List<Earthquake> Fetch(string hostname, int port, string username, string password, string fromEmail)
        {
            var quakes = new List<Earthquake>();
            using (ImapClient client = new ImapClient(hostname, port, username, password, AuthMethod.Login, true))
            {
                var ids = client.Search(SearchCondition.Unseen().And(SearchCondition.From(fromEmail)));
                //Console.WriteLine(client.Supports("IDLE"));
                foreach (var id in ids)
                {
                    var message = client.GetMessage(id, true);
                    //Console.WriteLine(message.Subject + " - " + message.Date());
                    foreach (var attachment in message.Attachments)
                    {
                        try
                        {
                            using (var reader = new StreamReader(attachment.ContentStream))
                            {
                                quakes.Add(Parse(reader.ReadToEnd()));
                            }
                        }
                        catch (Exception)
                        {
                            throw new ParsingException("", id, message, attachment.Name);
                        }
                    }
                }
            }
            return quakes;
        }

        public static Earthquake Parse(string content)
        {
            var quake = new Earthquake();
            var lines = content.Split('\n');
            var chunks = lines[3].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            quake.Date = DateTime.ParseExact(chunks[0] + ' ' + chunks[1], "yyyy/MM/dd HH:mm:ss.ff", CultureInfo.InvariantCulture);
            quake.Latitude = double.Parse(chunks[3], CultureInfo.InvariantCulture);
            quake.Longitude = double.Parse(chunks[4], CultureInfo.InvariantCulture);
            quake.Depth = double.Parse(chunks[8], CultureInfo.InvariantCulture);
            quake.OrigID = int.Parse(chunks[16], CultureInfo.InvariantCulture);

            chunks = lines[6].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            quake.Magnitude = double.Parse(chunks[1], CultureInfo.InvariantCulture);
            chunks = lines[7].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            quake.Class = double.Parse(chunks[1], CultureInfo.InvariantCulture);

            //Console.WriteLine(quake);
            return quake;
        }
    }
}