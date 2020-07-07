using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MortgageRateCalculator.Models;

namespace MortgageRateCalculator.Controllers
{
    public class CalcController : ApiController
    {

       [HttpGet]
        public IHttpActionResult calculateRate (int? creditScore, int? term)
        {
            string err = "";
            double? rate;
            double? baseRate = 2.5;

            if (creditScore == null || creditScore < 300 || creditScore > 850)
            {
                err += "Please enter a valid credit score between 300 and 850";
            }
            
            if (term == null || term < 8 || term > 30)
            {
                if (err != "")
                {
                    err += "\n";
                }
                err += "Please enter a valid term between 8 and 30";
            }

            if (err != "")
            {
                return Content(HttpStatusCode.BadRequest, err);
            }

            if (creditScore > 760)
            {
                creditScore = 760;
            }

            if (creditScore < 680)
            {
                rate = -1;
            }
            else
            {
                //This is obviously a place holder equation, we'd normally hit the DB here to pull what we needed in order to calculate the rate
                //rate = a base 2.5% + (0% - 2% depending on credit score) + (0% - 1% depending on term)
                //rate = baseRate + (2.0 * (1.0 - ((creditScore - 300.0) / 550.0))) + ((term - 8.0) / 22.0);

                rate = baseRate + (2.0 * (1.0 - ((creditScore - 300.0) / 460.0))) + ((term - 8.0) / 22.0);
            }

            return Content(HttpStatusCode.OK, rate);

        }
    }

}
