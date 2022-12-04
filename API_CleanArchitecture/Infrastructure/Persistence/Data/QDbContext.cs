namespace Infrastructure.Data;

using Domain.Models.AccessLevelModels;
using Domain.Models;
using Domain.Models.CardFormatsModels;
using Domain.Models.CardModels;
using Domain.Models.ControllerModels;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ControllerModels.DoorModels.ReaderModeds;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;
using Domain.Models.ControllerModels.DoorModels.RexModels;
using Domain.Models.PrioritiesModels;
using Domain.Models.QUserModels;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore.Infrastructure;

using Serilog;
using Domain.Models.AccessConfigsModels;
using Domain.Models.OutputSensorModel;
using Domain.Models.DoorGroupModels;

public class QDbContext : DbContext
{
    public DbSet<Controller> Controllers => Set<Controller>();
    public DbSet<Door> Doors => Set<Door>();
    public DbSet<DoorAdvanceConfiguration> DoorAdvanceConfigurations => Set<DoorAdvanceConfiguration>();
    public DbSet<Reader> Readers => Set<Reader>();
    public DbSet<Rex> Rexes => Set<Rex>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<ScheduleItem> ScheduleItems => Set<ScheduleItem>();

    public DbSet<ReaderIdentificationType> ReaderIdentificationTypes => Set<ReaderIdentificationType>();
    public DbSet<Priority> Priorities => Set<Priority>();

    public DbSet<Card> Cards => Set<Card>();
    public DbSet<QUser> QUsers => Set<QUser>();

    //public DbSet<QUserAccessLevel> QUserAccessLevels => Set<QUserAccessLevel>();

    //public DbSet<AccessLevel> AccessLevels => Set<AccessLevel>();

    public DbSet<CardFormat> CardFormats => Set<CardFormat>();
    public DbSet<CardFormatItems> CardFormatsItems => Set<CardFormatItems>();
    public DbSet<Area> Areas => Set<Area>();

    //Access Levels
    public DbSet<AccessLevel> AccessLevels => Set<AccessLevel>();
    public DbSet<AccessLevelDoor> AccessLevelDoors => Set<AccessLevelDoor>();
    public DbSet<QUserAccessLevel> QUserAccessLevels => Set<QUserAccessLevel>();

    //QPerson
    public DbSet<QUser> QUser => Set<QUser>();
    public DbSet<QUserFile> QUserFiles => Set<QUserFile>();

    //AccessConfigs
    public DbSet<AccessConfig> AccessConfigs => Set<AccessConfig>();

    public DbSet<ControllerIOPorts> ControllerIOPorts => Set<ControllerIOPorts>();

    // DoorGroup
    public DbSet<DoorGroup> DoorGroups => Set<DoorGroup>();
    public DbSet<DoorGroupDoors> DoorGroupDoors => Set<DoorGroupDoors>();

    public QDbContext(DbContextOptions options)
        : base(options)
    {
        Database.SetCommandTimeout(TimeSpan.FromMinutes(1));

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this.GetService<IQClaims>());
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Schedule>().HasData(new Schedules { Id = 1, IsSubtraction = false, Name = "Abdul", Token = "Basit", OrganizationId = -1 });
    }



    ~QDbContext()
    {

        Log.Verbose("Disposing QDbContext");
        Dispose();
    }
    public override void Dispose()
    {
        base.Dispose();

        GC.SuppressFinalize(this);
    }
}
