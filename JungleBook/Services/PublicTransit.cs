using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace JungleBook.Services
{
	public class PublicTransit
	{
		public async Task<JObject> RetrieveAgencyList()
		{
			string url = $"http://webservices.nextbus.com/service/publicXMLFeed?command=agencyList";
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				string xml = await response.Content.ReadAsStringAsync();
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xml);
				string jsonConversionResult = JsonConvert.SerializeXmlNode(doc);
				JObject agencyList = JsonConvert.DeserializeObject<JObject>(jsonConversionResult);
				return agencyList;
			}
			return null;
		}
	}
}
