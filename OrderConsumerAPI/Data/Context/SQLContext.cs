using Microsoft.EntityFrameworkCore;
using OrderConsumerAPI.Messages;

namespace OrderConsumerAPI.Data.Context;

public class SQLContext : DbContext
{
    public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

    public SQLContext() { }

    public DbSet<Order> orders { get; set; }         
}
