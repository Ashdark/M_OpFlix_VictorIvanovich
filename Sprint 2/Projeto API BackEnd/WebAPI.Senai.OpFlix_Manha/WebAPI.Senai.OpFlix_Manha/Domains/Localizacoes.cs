using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public class Localizacoes
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        //[BsonRequired]
        [Required]
        public string Latitude { get; set; }
        //[BsonRequired]
        [Required]
        public string Longitude { get; set; }

    }
}
