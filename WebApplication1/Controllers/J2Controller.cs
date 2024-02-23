using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class J2Controller : ApiController
    {
        /**
         * <Summary>
         * Determines the number of ways to roll the value of 10 with two dice.
         * </Summary>
         * <param name="m">The number of sides on the first die</param>
         * <param name="n">The number of sides on the second die</param>
         * <returns>The number of ways to roll the value of 10</returns>
         * GET api/J2/DiceGame/6/6 -> "There are 5 total ways to get the sum 10"
         */
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public IHttpActionResult CountWaysToRollTen(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                return BadRequest("Number of sides for each die must be positive integers.");
            }

            int count = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i + j == 10)
                    {
                        count++;
                    }
                }
            }

            return Ok($"There are {count} total ways to get the sum 10");
        }
    }
}
