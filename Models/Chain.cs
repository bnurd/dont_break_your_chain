namespace dont_break_your_chain.Models;

public class Chain : IEntity{

    public int Id { get; set; }
    public string Content { get; set; }
    
    public List<Ring> Rings { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}