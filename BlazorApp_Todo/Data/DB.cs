using BlazorApp_Todo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_Todo.Data
{
    public class DB : DbContext

    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
