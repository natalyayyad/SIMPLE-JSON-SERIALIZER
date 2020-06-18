using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Main
    {
        public static void main(string[] args)
        {
            Console.WriteLine("This is a Json Serializer!");
            SimpleSerializer();
        }

        public static void SimpleSerializer()
        {
            Configuration configuration = new Configuration(
                version: 2,
                domainName: "www.trianing.com",
                ipAddresses: new string[] { "192.168.1.8", "192.168.1.2" }
                );

            JSONSerializer json = new JSONSerializer();
            string output = json.Serializer(configuration);
            Console.WriteLine(output);

        }
    }
}
