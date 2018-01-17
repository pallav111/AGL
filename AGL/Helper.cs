using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace AGL
{
    public static class Helper
    {
        public partial class Owner
        {
            [J("name")]
            public string Name { get; set; }
            [J("gender")]
            public string Gender { get; set; }
            [J("age")]
            public long Age { get; set; }
            [J("pets")]
            public List<Pet> Pets { get; set; }
        }

        public partial class Pet
        {
            [J("name")]
            public string Name { get; set; }
            [J("type")]
            public string Type { get; set; }
        }

        public static class Deserialize
        {
            public static List<Owner> FromJson(string json)
            {
                return JsonConvert.DeserializeObject<List<Owner>>(json, Converter.Settings);
            }
        }

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }

        public static class JsonQuery
        {
            public static List<string> GetAnimalNamesByGender(List<Owner> owner, string gender, string animal)
            {
                List<string> result = new List<string>();
                List<List<Pet>> query = (from own in owner
                                         where own.Gender == gender
                                         & own.Pets != null
                                         select own.Pets.FindAll(p => p.Type == animal)).ToList<List<Pet>>();

                foreach (List<Pet> lstPets in query)
                    foreach (Pet p in lstPets)
                        result.Add(p.Name);

                result.Sort();
                return result;
            }
        }
    }
}