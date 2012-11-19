using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace APIWebAPI
{
    //[RequireHttpsAttribute]
    public class GetDataController : ApiController
    {
        public Person Get()
        {
            return new Person { Name = "John", LastName = "Smith" };
        }
    }
}
