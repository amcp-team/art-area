namespace ArtArea.Models
{
    public class Tag
    {
        public string Name { get; set; }
        
        // stores HEX representation of the color as string (ex: #EDEAB7)
        public string ColorHex { get; set; }
        public string Description { get; set; }
    }
}