using Microsoft.EntityFrameworkCore;
using TestLinkBackend.Models;

namespace TestLinkBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NodeHierarchy> NodeHierarchies { get; set; }
        public DbSet<Testproject> Testprojects { get; set; }
        public DbSet<Testcase> Testcases { get; set; }
        public DbSet<TestcaseVersion> TestcaseVersions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<RequirementVersion> RequirementVersions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Testplan> Testplans { get; set; }
        public DbSet<TestplanRole> TestplanRoles { get; set; }
        public DbSet<Execution> Executions { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<TestCasePlatform> TestCasePlatforms { get; set; }
        public DbSet<TestCaseRelation> TestCaseRelations { get; set; }
        public DbSet<RequirementRelation> RequirementRelations { get; set; }
        public DbSet<RequirementMonitor> RequirementMonitors { get; set; }
        public DbSet<TextTemplate> TextTemplates { get; set; }
        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<PluginConfiguration> PluginConfigurations { get; set; }
        public DbSet<IssueTracker> IssueTrackers { get; set; }
        public DbSet<TestprojectIssueTracker> TestprojectIssueTrackers { get; set; }
        public DbSet<CodeTracker> CodeTrackers { get; set; }
        public DbSet<TestprojectCodeTracker> TestprojectCodeTrackers { get; set; }
        public DbSet<RequirementManagerSystem> RequirementManagerSystems { get; set; }
        public DbSet<TestprojectRequirementManagerSystem> TestprojectRequirementManagerSystems { get; set; }
        public DbSet<RequirementSpec> RequirementSpecs { get; set; }
        public DbSet<RequirementSpecRevision> RequirementSpecRevisions { get; set; }
        public DbSet<RequirementRevision> RequirementRevisions { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupAssign> UserGroupAssigns { get; set; }
        public DbSet<ObjectKeyword> ObjectKeywords { get; set; }
        public DbSet<TestCaseKeyword> TestCaseKeywords { get; set; }
        public DbSet<RequirementKeyword> RequirementKeywords { get; set; }
        public DbSet<TestSuite> TestSuites { get; set; }
        public DbSet<BaselineContext> BaselineContexts { get; set; }
        public DbSet<BaselineDetail> BaselineDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed some mock data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "admin", Password = "password", RoleId = 1, Email = "admin@testlink.com", First = "Admin", Last = "User", Active = true },
                new User { Id = 2, Login = "testuser", Password = "password", RoleId = 2, Email = "user@testlink.com", First = "Test", Last = "User", Active = true }
            );

            modelBuilder.Entity<Testproject>().HasData(
                new Testproject { Id = 1, Prefix = "TP", ApiKey = "api-key-123", Name = "Sample Project", Description = "A sample test project", Active = true }
            );

            modelBuilder.Entity<Testplan>().HasData(
                new Testplan { Id = 1, Name = "Sample Test Plan", TestprojectId = 1 }
            );

            modelBuilder.Entity<Build>().HasData(
                new Build { Id = 1, Name = "Build 1.0", TestprojectId = 1 }
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "Windows", TestprojectId = 1 }
            );

            modelBuilder.Entity<Testcase>().HasData(
                new Testcase { Id = 1, Name = "Login Test", Description = "Test login functionality", TestprojectId = 1 }
            );

            modelBuilder.Entity<TestcaseVersion>().HasData(
                new TestcaseVersion { Id = 1, TestcaseId = 1, Version = 1, Name = "Login Test v1", Description = "Test login functionality", Active = true }
            );

            // Configure composite keys
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.TestprojectId });
            modelBuilder.Entity<TestplanRole>().HasKey(tpr => new { tpr.UserId, tpr.TestplanId });
            modelBuilder.Entity<TestCasePlatform>().HasKey(tcp => new { tcp.TestcaseId, tcp.TestcaseVersionId, tcp.PlatformId });
            modelBuilder.Entity<RequirementMonitor>().HasKey(rm => new { rm.RequirementId, rm.UserId, rm.TestprojectId });
            modelBuilder.Entity<TestprojectIssueTracker>().HasKey(tpit => new { tpit.TestprojectId, tpit.IssueTrackerId });
            modelBuilder.Entity<TestprojectCodeTracker>().HasKey(tpct => new { tpct.TestprojectId, tpct.CodeTrackerId });
            modelBuilder.Entity<TestprojectRequirementManagerSystem>().HasKey(tprms => new { tprms.TestprojectId, tprms.RequirementManagerSystemId });
            modelBuilder.Entity<UserGroupAssign>().HasKey(uga => new { uga.UsergroupId, uga.UserId });
        }
    }
}
