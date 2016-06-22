# ssdfetcher
# Usage:
var quakes = EmailFetcher.Fetch(hostname, 993, username, password, from);
foreach (var quake in quakes)
{
Console.WriteLine(quake);
}