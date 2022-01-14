using System;

namespace XDSDataSource
{
    class Program
    {
        static void Main(string[] args)
        {
           
            String body = ADLGenerator.GetITI41Request();
            String result = RestSender.SendRest(body);
            Console.WriteLine(result);
           
        }
    }
}
