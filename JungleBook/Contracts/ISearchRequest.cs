using JungleBook.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface ISearchRequest
	{
		Task<EventSearchResult> Search(string location, string keyword);
	}
}
