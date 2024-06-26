namespace Api{
    public class PjApi{
        
        public string className { get; set; }
        public string name { get; set; }
        public string story {get; set;} // VER EN PROCESOOOOOOOOOOOOOOOOOOO  
        public string noblePhantasms {get; set;} //tesoro sagrado 
        public string luck{get; set;} //suerte
        public string endurance {get; set;} 
        public string magic {get; set;} 
        public string agility {get; set;}
    }
    public class Respuesta{
        public List<PjApi> Items { get; set; }
    }

    public class InfoApi{
        public static async Task<List<PjApi>> traerInformacionApi(List<PjApi> listaPersonajes){
            try{
                HttpClient client = new HttpClient();
                var url = "https://api.atlasacademy.io/export/NA/nice_servant.json";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var Respuesta = JsonSerializer.Deserialize<Respuesta>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (Respuesta != null && Respuesta.Items != null)
                {
                    foreach (var personaje in Respuesta.Items)
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