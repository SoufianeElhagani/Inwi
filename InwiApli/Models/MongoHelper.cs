using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InwiApli.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb+srv://soufiane:soufiane123@cluster0.tauku.mongodb.net/<dbname>?retryWrites=true&w=majority";
        public static string MongoDatabse = "BD_INWI";

        public static IMongoCollection<Models.Recharge> clients_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabse);

            }
            catch (Exception)
            {

            }
        }
    }
}