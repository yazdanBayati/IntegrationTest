using System.Threading.Tasks;
using Core;
using DataAccess;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

public class FileSharingContext : DbContext, IUintOfWork
{
    
    private DbConfig _config;
     public FileSharingContext()
    {
        
    }
    public FileSharingContext(DbConfig config)
    {
        this._config = config;
    }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("testDB");
        
        // optionsBuilder.UseNpgsql("Host=localhost; Database =FileSharingDB;Username=postgres;Password=123;"); we should use this section for migration
        
        if(_config.IsDevEnv)
        {
           //optionsBuilder.UseSqlServer(_config.ConnectionString);

           //optionsBuilder.UseNpgsql(_config.ConnectionString);   
        }
        else
        {
           //optionsBuilder.Sqllight(_config.ConnectionString);
        }
    }


    public override void Dispose()
    {
        //do the some action
    }

    public DbSet<File> Files {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<File>()
        .ToTable("File" , "FH")  
        .HasKey(x => x.Id);
    }
   
   

    public void Start()
    {
        throw new System.NotImplementedException();
    }

    public Task StartAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CommitAsync()
    {
       return await this.SaveChangesAsync();
    }

    public Task<int> CommitAsync(int userId)
    {
        throw new System.NotImplementedException();
    }

     public int Commit()
    {
        return this.SaveChanges();
    }

    public int Commit(int userId)
    {
        throw new System.NotImplementedException();
    }

   

   
}