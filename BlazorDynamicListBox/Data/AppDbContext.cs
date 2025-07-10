using BlazorDynamicListBox.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorDynamicListBox.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ListBoxItem> ListBoxItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
