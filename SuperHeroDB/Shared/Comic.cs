namespace SuperHeroDB.Shared
{
    public class Comic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "{Id = "+Id.ToString()+","+Name+"}";
        }
    }
}