using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dataBase
{
    class Program
    {

        public class Ventas
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; }
            [BsonElement("item")]
            public string? Item
            {
                get; set;
            }
            [BsonElement("price")]
            public double Price
            {
                get; set;   
            }
            [BsonElement("quantity")]
            public int Quantity 
            {
                get; set;
            }
            [BsonElement("date")]
            public DateTime Date 
            {
                get; set;
            }
                
        }

        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var ventasDB = client.GetDatabase("ventas");
            var salesCollection = ventasDB.GetCollection<Ventas>("sales");

            //Lista de los objetos encontrados en el find 
            List<Ventas> salesList = salesCollection.Find(d =>true).ToList(); 
            //Imprimir Lista
            salesList.ForEach(elemento => Console.WriteLine(elemento.Item));
        }
    }
}
