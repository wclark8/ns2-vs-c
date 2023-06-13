
using NS2_VS.Services;
using System.Net.Http.Headers;

namespace NS2_VS
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<ICrawlerService, CrawlerService>( client =>
            {
                // add build time config
                client.BaseAddress = new Uri("http://localhost:3000");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
               app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            app.Run();

            //ComparePlayers("53147432", "854961158").GetAwaiter().GetResult();
        }
        /*
        static async Task ComparePlayers(string playerOneId, string playerTwoId)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {

                string[] playerIds = new string[2] { playerOneId, playerTwoId };
                HttpResponseMessage response = await client.PostAsJsonAsync("/players", playerIds);
                if(response.IsSuccessStatusCode)
                {
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }*/
    }
}