namespace dont_break_your_chain.Models;

public class Ring : IEntity
{
    public int Id { get; set; }
    public int ChainId { get; set; }
    public Chain Chain { get; set; }
    public DateTime DateTime { get; set; }
}