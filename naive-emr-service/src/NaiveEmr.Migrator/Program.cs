using NaiveEmr.Migrator;

AppDbContextFactory _factory = new AppDbContextFactory();
var dbContext = _factory.CreateDbContext(args);