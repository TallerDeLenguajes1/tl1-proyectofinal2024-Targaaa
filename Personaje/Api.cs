using System.Text.Json;

namespace Api{
    // personajesApi myDeserializedClass = JsonConvert.DeserializeObject<List<personajesApi>>(myJsonResponse);

    public class personajeApi
    {
        public string name { get; set; }
        public string type { get; set; }
        public string className { get; set; }
        public string attribute { get; set; }
        public int rarity { get; set; }
        public int atkMax { get; set; }
        public int hpMax { get; set; }


    }


    public class Respuesta{
        public List<personajeApi> personajesApi { get; set; }
    }

    public class InfoApi
{
    public static async Task<List<personajeApi>> TraerInformacionApi(List<personajeApi> listaPersonajes)
    {
        try
        {
            HttpClient client = new HttpClient();
            var url = "https://api.atlasacademy.io/export/NA/basic_servant.json";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<List<personajeApi>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); // Cambiado aquí
            if (apiResponse != null )
            {
                foreach ( var personaje in apiResponse)
                {
                    listaPersonajes.Add(personaje);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
        return listaPersonajes;
    }
}
}