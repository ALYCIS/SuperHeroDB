using System.ComponentModel.DataAnnotations;

namespace SuperHeroDB.Shared
{
    public class Comic
    {
        public int Id { get; set; } = 1001;
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return "{Id = "+Id.ToString()+","+Name+"}";
        }
    }
}