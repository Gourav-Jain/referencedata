using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReferenceData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatasetController : ControllerBase
    {
        public enum QueryParam {
            title,
            sortofincome,
            useofaccount,
            country
        }
        private static readonly string[] Title = new[]
        {
            "Mr", "Mrs", "Dr", "Miss", "Prof."
        };
        private static readonly string[] SortOfIncome = new[]
        {
            "Salary", "Rent", "Other Source Income", "Business"
        };
        private static readonly string[] UseOfAccount = new[]
        {
            "Everything", "Just Paying bills", "Other", "Savings",
        };
        private static readonly string[] Country = new[]
        {
            "UK", "India", "Sweden", "Norway", "USA"
        };

        private readonly ILogger<DatasetController> _logger;

        public DatasetController(ILogger<DatasetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Dataset> Get([FromQuery]string [] t)
        {
            QueryParam objQueryParam =  (QueryParam)Enum.Parse(typeof(QueryParam), t[0]);
            IEnumerable<Dataset> dataset = null;
            switch(objQueryParam){
                case QueryParam.title:
                dataset = Enumerable.Range(0, Title.Length).Select(idx => new Dataset { id = idx,  value = Title[idx] }).ToArray();
                break;
                case QueryParam.useofaccount:
                dataset = Enumerable.Range(0, UseOfAccount.Length).Select(idx => new Dataset { id = idx,  value = UseOfAccount[idx] }).ToArray();
                break;
                case QueryParam.sortofincome:
                dataset = Enumerable.Range(0, SortOfIncome.Length).Select(idx => new Dataset { id = idx,  value = SortOfIncome[idx] }).ToArray();
                break;
                case QueryParam.country:
                dataset = Enumerable.Range(0, Country.Length).Select(idx => new Dataset { id = idx,  value = Country[idx] }).ToArray();
                break;
                default:
                break;
            }
            return dataset;
        }
    }
}
