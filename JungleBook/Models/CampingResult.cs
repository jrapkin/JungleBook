
namespace JungleBook.Models
{

	public class CampingResult
	{
		public Campground[] campgrounds { get; set; }
		public int success { get; set; }
	}

	public class Campground
	{
		public int id { get; set; }
		public string name { get; set; }
		public bool isBookable { get; set; }
		public bool isCampground { get; set; }
		public string location { get; set; }
		public float latitude { get; set; }
		public float longitude { get; set; }
		public string url { get; set; }
		public string imgUrl { get; set; }
		public int numCampsites { get; set; }
	}

}
