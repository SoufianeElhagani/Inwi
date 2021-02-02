using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InwiApli.Controllers
{
    public class RechargeController : ApiController
    {

        public RechargeController()
        {
             Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.clients_collection =
                Models.MongoHelper.database.GetCollection<Models.Recharge>("Recharges");
        }
        // GET: api/Recharge
        public List<Models.Recharge> Get()
        {
            var filter = Builders<Models.Recharge>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.clients_collection.Find(filter).ToList();
            return result;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Recharge/5
        public Models.Recharge Get(string id)
        {
            var filter = Builders<Models.Recharge>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.clients_collection.Find(filter).FirstOrDefault();
            return result;
            //return "value";
        }

        private static Random random = new Random();

        private object GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // POST: api/Recharge
        public string Post(Models.NumeroMontant NumMon)
        {
            try
            {
                Object id = GenerateRandomID(24);

                Models.MongoHelper.clients_collection.InsertOneAsync(new Models.Recharge
                {

                    _id = id,
                    tel = NumMon.tel,
                    montant = NumMon.montant,
                    date = DateTime.UtcNow

                });

                return "Recharge created succesfully";
            }
            catch
            {
                return "Recharge not created";
            }
        }


        // DELETE: api/Recharge/5
        public string Delete(string id)
        {
            try
            {

                var filter = Builders<Models.Recharge>.Filter.Eq("_id", id);
                var result = Models.MongoHelper.clients_collection.DeleteOneAsync(filter);


                return "Recharge deleted succesfully";
            }
            catch
            {
                return "Problem occured";
            }
        }

        public string GetMessage()
        {
            return "Welcome to Inwi! In this page you can buy data for your line";
        }
    }
}
