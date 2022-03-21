using dont_break_your_chain.Controllers;
using dont_break_your_chain.Models;
using Microsoft.AspNetCore.Mvc;

namespace dont_break_your_chain;

public class ChainController : AppController
{
    static List<Chain> Chains;
    static List<Ring> Rings;

    public IActionResult GetChain(int chainId)
    {
        var chain = Chains.FirstOrDefault(x => x.Id == chainId);
        // var range = chain.EndDate.Subtract(chain.StartDate);

        var res = new List<Tuple<DateTime, bool>> { };
        for (DateTime d = chain.StartDate.Date; d <= chain.EndDate.Date; d.AddDays(1))
        {
            var done = Rings.Any(x => x.DateTime.Date == d && x.ChainId == chainId);
            res.Add(new Tuple<DateTime, bool>(d, done));
        }

        return Ok(res);
    }

    public IActionResult DoneToday(int chainId)
    {
        var ring = new Ring
        {
            ChainId = chainId,
            DateTime = DateTime.Now,
        };

        Rings.Add(ring);

        return Ok();
    }

    public IActionResult DoneWithDate(int chainId, DateTime date)
    {
        var ring = new Ring
        {
            ChainId = chainId,
            DateTime = date,
        };

        Rings.Add(ring);

        return Ok();
    }

    public IActionResult CancelToday(int chainId)
    {
        var ring = Rings.FirstOrDefault(x => x.ChainId == chainId && x.DateTime == DateTime.Now);
        Rings.Remove(ring);

        return Ok();
    }

    public IActionResult CancelWithDate(int chainId, DateTime date)
    {
        var ring = Rings.FirstOrDefault(x => x.ChainId == chainId && x.DateTime == date);
        Rings.Remove(ring);

        return Ok();
    }

}