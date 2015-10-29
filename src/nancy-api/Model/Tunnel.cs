namespace NancyApi.Model
{
    public class Tunnel : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
    }
}