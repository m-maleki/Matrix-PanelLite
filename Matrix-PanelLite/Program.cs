using System.Net;
using System.Net.Cache;

const string urlParamForUnLockDoor = "V01R53Monitor?action=set\u0001doorId=5\u0001unLockDoor";

const string urlParamForLockDoor = "V01R53Monitor?action=set\u0001doorId=5\u0001LockDoor";

const string urlParamForGetEvents = "V01R53EventLogs?action=get\u0001pageNo=1\u0001eventPerPage=50" +
                                   "\u0001totalevent\u0001fromtime=0000\u0001totime=2359\u0001fromdate=01012020" +
                                   "\u0001todate=29012024\u0001userAllowed=1\u0001userDenied=1\u0001door=1" +
                                   "\u0001alarm=1\u0001system=1\u0001saveOnPC=0";

const string urlParamForGetUsers = "get\u0001searchType=1\u0001searchStr=\u0001pageNo=1\u0001userPerPage=13\u0001alphaNumId" +
                                  "\u0001name\u0001acessGroup\u0001acessSchedule\u0001status" +
                                  "\u0001card\u0001finger\u0001palm\u0001getOnlyActiveUsers=0";


var url = "http://x.x.x.x/cgi-bin/submit";

string response;

WebClient client = new();

client.CachePolicy = new HttpRequestCachePolicy();

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------");
    Console.WriteLine("1.Lock Door");
    Console.WriteLine("2.UnLock Door");
    Console.WriteLine("3.Get Events");
    Console.WriteLine("4.Get Users");
    Console.WriteLine("5.Exit");
    Console.WriteLine("---------------------");
    Console.Write("please select item : ");

    var choseItem = Console.ReadLine();

    switch (choseItem)
    {
        case "1":
            Console.Clear();
            response = client.UploadString(url, urlParamForLockDoor);
            Console.WriteLine("Door status locked");
            Console.ReadKey();

            break;

        case "2":
            Console.Clear();
            response = client.UploadString(url, urlParamForUnLockDoor);
            Console.WriteLine("Door status unlocked");
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            response = client.UploadString(url, urlParamForGetEvents);
            Console.WriteLine(response);
            Console.ReadKey();
            break;

        case "4":
            Console.Clear();
            response = client.UploadString(url, urlParamForGetUsers);
            Console.WriteLine(response);
            Console.ReadKey();
            break;
    }

}